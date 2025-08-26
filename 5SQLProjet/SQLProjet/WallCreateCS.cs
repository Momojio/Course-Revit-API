using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Microsoft.VisualBasic;
using SQLProjet.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using Transaction = Autodesk.Revit.DB.Transaction;

namespace SQLProjet
{

    [Transaction(TransactionMode.Manual)]
    public class CreateWallCS : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {



            #region SQL

            // Prepare the environment

            //string connectionString = $"Server=.;Database=Revit;User Id=Junhui;Password=558300;"; // Replace with your actual connection string
            string connectionString = "Server=.;Database=Revit;Integrated Security=True;";
            string query = "SELECT * FROM WallCreate Where WallId = 1"; // Replace with your actual SQL query

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            // Execute the query and read the results
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader(); 
            WallCreate wallCreate = new WallCreate(); // Create an instance of WallCreate
            if (reader.Read()) {
                wallCreate.WallId = reader.GetInt32(0);
                wallCreate.WallHeight = reader.GetDouble(1);
                wallCreate.StartPointX = reader.GetDouble(2);
                wallCreate.StartPointY = reader.GetDouble(3);
                wallCreate.StartPointZ = reader.GetDouble(4);
                wallCreate.EndPointX = reader.GetDouble(5);     
                wallCreate.EndPointY = reader.GetDouble(6);
                wallCreate.EndPointZ = reader.GetDouble(7);
            }   
            reader.Close();
            connection.Close();

            #endregion



            Document Doc = commandData.Application.ActiveUIDocument.Document;
            FilteredElementCollector collector = new FilteredElementCollector(Doc);
            Element element = collector.OfCategory(BuiltInCategory.OST_Walls).OfClass(typeof(WallType)).FirstOrDefault(x => x.Name == "CW 102-50-100p") as WallType;

            //
            //The minimum usage
            Level level = new FilteredElementCollector(Doc)
                .OfClass(typeof(Level))
                .FirstOrDefault(x => x.Name == "Niveau 1") as Level;

            XYZ start = new XYZ(wallCreate.StartPointX, wallCreate.StartPointY, wallCreate.StartPointZ);
            XYZ end = new XYZ(wallCreate.EndPointX, wallCreate.EndPointY, wallCreate.EndPointZ);
            Line geomLine = Line.CreateBound(start, end);

            double height = wallCreate.WallHeight / 0.3048; // Wall height in feet
            double offset = 0.0; // Wall offset in feet



            //
            Transaction transaction = new Transaction(Doc, "Create Wall");
            transaction.Start();
            Wall wall = Wall.Create(Doc, geomLine, element.Id, level.Id, height, offset, true, true);
            transaction.Commit();



            //SQL Insert
            WallInformation wallInformation = new WallInformation
            {
                WallId = wallCreate.WallId,
                //Two ways to get the area and length of the wall
                Area = wall.get_Parameter(BuiltInParameter.HOST_AREA_COMPUTED).AsDouble() * 0.3048 * 0.3048, // Area in square meters 
                Length = wall.LookupParameter("Longueur").AsDouble() * 0.3048  // Length

            };


            SqlConnection insertConnection = new SqlConnection(connectionString);
            insertConnection.Open();


            // Insert by using parameters
            string insertQuery = @"INSERT INTO WallInformation (WallId, Area, Length) 
                       VALUES (@WallId, @Area, @Length)";

            using (SqlCommand cmd = new SqlCommand(insertQuery, insertConnection))
            {
                // 添加参数（自动处理类型和格式）
                cmd.Parameters.AddWithValue("@WallId", wallInformation.WallId);
                cmd.Parameters.AddWithValue("@Area", wallInformation.Area);
                cmd.Parameters.AddWithValue("@Length", wallInformation.Length);


                int insertResult = cmd.ExecuteNonQuery();
                TaskDialog.Show("SQL Insert", $"Executing result:{insertResult}");
            }

            ;//Execute the insert command
            
            insertConnection.Close();



            #region Old Insert Method


            //string insertQuery = $"Insert into WallInformation (WallId, Area, Length) values ({wallInformation.WallId}, {wallInformation.Area}, {wallInformation.Length})"; // Replace with your actual SQL insert query


            //TaskDialog.Show("SQL debug", $"Executing SQL:\n{insertQuery}");

            //SqlCommand insertCommand = new SqlCommand(insertQuery, insertConnection);
            //int insertResult = insertCommand.ExecuteNonQuery();



            //insertConnection.Close();

            #endregion




            return Result.Succeeded;
        }
    }
}