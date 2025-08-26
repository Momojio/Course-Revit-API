using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows;

namespace FamilyInstance
{

    [Transaction(TransactionMode.Manual)]
    public class CreateWall : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //[1]
            Document Doc = commandData.Application.ActiveUIDocument.Document;

            #region WPF
            MainWindow mainWindow = new MainWindow();


            //非模态
            //mainWindow.Show();

            mainWindow.ShowDialog();

            if (!mainWindow.IsClickClosed)
            {
                return Result.Cancelled;
            }

            double height = Convert.ToDouble(mainWindow.textBox.Text) / 0.3048;

            #endregion

            FilteredElementCollector collector = new FilteredElementCollector(Doc);

            // as WallType ==== Wall wall = (Wall)element;
            Element element = collector.OfCategory(BuiltInCategory.OST_Walls)
                .OfClass(typeof(WallType))
                .FirstOrDefault(x => x.Name == "CW 102-50-100p") as WallType;

            //[2]
            //The minimum usage
            Level level = new FilteredElementCollector(Doc)
                .OfClass(typeof(Level))
                .FirstOrDefault(x => x.Name == "Niveau 1") as Level;

            XYZ start = new XYZ(0, 0, 0);
            XYZ end = new XYZ(10, 0, 0);
            Line geomLine = Line.CreateBound(start, end);

            //double height = 15.0 / 0.3048; // Wall height in feet
            double offset = 0.0; // Wall offset in feet

            

            //[3]
            Transaction transaction = new Transaction(Doc, "Create Wall");  
            transaction.Start();
            Wall wall = Wall.Create(Doc, geomLine, element.Id, level.Id, height, offset, true, true);
            transaction.Commit();

            return Result.Succeeded;
        }
    }
}
