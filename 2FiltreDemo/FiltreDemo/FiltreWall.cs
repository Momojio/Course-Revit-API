using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltreDemo
{
    [Transaction(TransactionMode.Manual)]
    class FiltreWall : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //UI interface
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            //for information
            Document doc = uiDoc.Document;
            //New filtre，collecteur get IEnumerable<ElementId>
            FilteredElementCollector collecteur = new FilteredElementCollector(doc);

            //【1】获取墙族实例   

            //分类获取，ofClass可以获取Family, f instance etc, ofCategory is for category.(Categoryid)
            //collect.OfCategory(BuiltInCategory.OST_Walls).OfClass(typeof(Wall));


            //builticategory for 墙类别, TypeofWall is Wall类型。After ofcategory, we can't get family, only instance.
            collecteur.OfCategory(BuiltInCategory.OST_Walls).OfClass(typeof(Wall));

            #region collector universal method
            //ElementCategoryFilter elementCategoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_Walls);
            //ElementClassFilter elementClassFilter = new ElementClassFilter(typeof(Wall));
            //collector.WherePasses(elementClassFilter).WherePasses(elementClassFilter);
            #endregion

            #region list的使用
            //List<Element> elementlist = new List<Element>();
            //foreach (var item in collecteur)
            //{
            //    if (item.Name == "CL_W1")//without, it will get all walls
            //    {

            //        elementlist.Add(item);
            //    }
            //}

            //var sel = uiDoc.Selection.GetElementIds();


            ////把elementlist的值赋给Wallinstance,只能获得list第一个值
            ////Element Wallinstance = elementlist[0];
            //Element Wallinstance = elementlist.FirstOrDefault<Element>();


            //TaskDialog.Show("查看结果", Wallinstance.Name);
            //sel.Add(Wallinstance.Id);

            #endregion

            //【2】输出族实例(可能多个)

            #region Basic usage 
            //var sel = uiDoc.Selection.GetElementIds();//Create a new selection set  
            //foreach (var item in collecteur)
            //{
            //    if (item.Name == "CL_W1")//without, it will get all walls
            //    {
            //        TaskDialog.Show("查看结果", item.Id.ToString());

            //        sel.Add(item.Id);//add to selection 

            //    }
            //}

            //uiDoc.Selection.SetElementIds(sel);//for highlight
            #endregion

            #region one by one, Version Améliorée


            //elementlist.Add(item); to get all of infos Element, not only ElementId id,！use+ List<Element>
            List<ElementId> elementlist = new List<ElementId>();
            foreach (var item in collecteur)
            {
                //如果墙的名字是CL_W1，则添加到elementlist
                if (item.Name == "CL_W1")//without, it will get all walls
                {
                    elementlist.Add(item.Id);
                }
            }
            
            foreach (ElementId id in elementlist)
            {
                uiDoc.Selection.SetElementIds(new List<ElementId> { id });//new List! no need Nom de variable, liste temporaire
                TaskDialog.Show("item ID", $"ID: {id}");  
            }
             
            uiDoc.Selection.SetElementIds(elementlist); //for all highlight 
            #endregion

            #region Linq usage

            //For more filtering, Where(item => item is Wall && item.Name == "CL_W1")
            //elementlist no need to be list<>.
            //var linq = collecteur.Where(x => x.Name == "CL_W1").Select(x => x.Id).ToList();
            //ElementId firstone = linq[0];//linq is a list! so we can get the first one


            #endregion

            #region Quick usage Lambda
            //Quick usage, get family
            //var fam = new FilteredElementCollector(doc).OfClass(typeof(Family)).FirstOrDefault(x => x?.Name == "FamilyName");
            #endregion


            return Result.Succeeded;

            #region Tips
            ////get e element by id, and use taskdialog to show the name of element
            ////Element ele = doc.GetElement(new ElementId(493697));


            //强制转换，()()这里是强制转换数字-2000011。类似于 Wall wall = element as Wall;  
            //collecteur.OfCategory((BuiltInCategory)(-2000011)).OfClass(typeof(Wall));



            #endregion

        }
    }
}