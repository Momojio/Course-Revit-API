using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyInstance
{
    [Transaction(TransactionMode.Manual)]
    public class Operatewall : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //[1]
            UIDocument uidoc = commandData.Application.ActiveUIDocument;    
            Document Doc = uidoc.Document;
            FilteredElementCollector collector = new FilteredElementCollector(Doc);

            // as WallType ==== Wall wall = (Wall)element;
            Element wall = collector.OfCategory(BuiltInCategory.OST_Walls)
                .OfClass(typeof(Wall))
                .FirstOrDefault(x => x.Name == "CW 102-50-100p") as Wall;


            double WallHeight = wall.LookupParameter("Hauteur non contrainte").AsDouble()*0.3048; // Get the height of the wall
            double WallHeightorignal = wall.LookupParameter("Hauteur non contrainte").AsDouble();

            int WallId = wall.Id.IntegerValue; // Get the ID of the wall    

            uidoc.Selection.SetElementIds(new List<ElementId> { wall.Id });
            TaskDialog.Show("Wall Height", $"The height of the wall is {WallHeight}m. The ID is {WallId}. ");

            //[2]
            Transaction transaction = new Transaction(Doc, "Change Wall Height");
            transaction.Start();
            wall.LookupParameter("Hauteur non contrainte").Set(WallHeightorignal * 3); // Set the height of the wall to 3 times the original height
            transaction.Commit();

            double WallHeightchanged = wall.LookupParameter("Hauteur non contrainte").AsDouble() * 0.3048; // Get the new height of the wall

            TaskDialog.Show("Wall Height Changed", $"The new height of the wall is {WallHeightchanged}m.");

            return Result.Succeeded;

        }
    }
}


