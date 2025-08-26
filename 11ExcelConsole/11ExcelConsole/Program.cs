using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11ExcelConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FileInfo file = new FileInfo(@"F:\BaiduSyncdisk\Revit API\Projet_Junhui\11ExcelConsole\Test.xlsx");

            ExcelPackage.License.SetNonCommercialPersonal("Junhui"); //This will also set the Author property to the name provided in the argument.
            using (var package = new ExcelPackage(new FileInfo(@"F:\BaiduSyncdisk\Revit API\Projet_Junhui\11ExcelConsole\Test.xlsx")))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; //Get the first worksheet
                var a = worksheet.Cells[1,1]; //Get the cell(all infos)
                Console.WriteLine(a.Text); //Print the value of the cell

                var b = worksheet.Cells[6, 1];
                var mergeaddress = worksheet.MergedCells[b.Start.Row, b.Start.Column]; //Get the merged cell address
                if (!string.IsNullOrEmpty(mergeaddress)) //Check if the cell is merged, isNullOrEmpty for espace ou empty
                {

                    Console.WriteLine($"Merged Cell Address: {mergeaddress}"); //Print the merged cell address
                    var cells = new ExcelAddress(mergeaddress).Start; //Get the cells in the merged cell
                    var bvalue = worksheet.Cells[cells.Row, cells.Column]; //Return the first cell in the merged cell
                    Console.WriteLine($"Merged Cell Value: {bvalue.Text}"); //Print the value of the merged cell
                }
                else
                {
                    Console.WriteLine($"This cell is not merged, value : {b.Text}");
                    //for revit Taskdialog.Show("This cell is not merged, value : " + b.Text);

                }


                //var bValue = worksheet.MergedCells[b.Start.Row, b.Start.Column] is string mergeAddress 
                //    ? worksheet.Cells[new ExcelAddress(mergeAddress).Start.Row, new ExcelAddress(mergeAddress).Start.Column].Text
                //    : b.Text;

                //Console.WriteLine(bValue); //Print the value of the merged cell



                //var b = GetMergeValue(worksheet, 3, 1);
            }
        }
    }
}
