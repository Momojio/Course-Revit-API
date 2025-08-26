using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FamilyInstance
{
    [Transaction(TransactionMode.Manual)]
    public class CreateWallExternalProgram : IExternalCommand
    {

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var doc = commandData.Application.ActiveUIDocument.Document;

            MainWindowExternal mainWindowExternal = new MainWindowExternal();



            //PreviewControl pc = new PreviewControl(doc, commandData.Application.ActiveUIDocument.ActiveGraphicalView.Id);
            //mainWindowExternal.MainGrid.Children.Add(pc);


            mainWindowExternal.Show(); 
            return Result.Succeeded;
        }
    }
}
