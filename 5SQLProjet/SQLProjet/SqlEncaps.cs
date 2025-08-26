using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace SQLProjet
{
    internal class SqlEncaps
    {
        // Encapsulate the SQL logic in a separate class or method to improve maintainability and readability.


        // Faire attention à static, car si on utilise plusieurs fois la méthode ExecuteQuery, on va écraser la connectionString
        public static string connectionString = @"Server=.;Database=Revit;Integrated Security=True;";
        public static SqlDataReader ExecuteQuery(string query)
        {


            // Replace with your actual SQL query

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                connection.Close();
                throw ex;
            }

        }
    }
}
