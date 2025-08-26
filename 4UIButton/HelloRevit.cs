using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloRevit
{
    [Transaction(TransactionMode.Manual)]
    class SayHellotorevit : IExternalCommand
    //自动获取框架
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            //获取当前文档
            TaskDialog.Show("Demo", "Hello, Revit Api !");
            return Result.Succeeded;
        }
    }
}