using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;

using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace UIButton
{
    [Transaction(TransactionMode.Manual)]
    class UIDemo : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            throw new NotImplementedException();
        }

        public Result OnStartup(UIControlledApplication application)
        {
            application.CreateRibbonTab("UITab");
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("UITab", "UIPanel");

           
            string assemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string classNameHelloRevit = "HelloRevit.SayHellotorevit";

              PushButtonData pbd = new PushButtonData("InnerNameRevit", "HelloRevit", assemblyPath, classNameHelloRevit);
            PushButton pushButton = ribbonPanel.AddItem(pbd) as PushButton;

            //（大图标一般是32px，小图标一般是16px，格式可以是ico,png,jpg）


            //string imgPath = @"F:\BaiduSyncdisk\Revit API\img2.png";
            pushButton.LargeImage = new BitmapImage(new Uri(@"pack://application:,,,/UIButton;component/pic/img2.png"));
            //pushButton.LargeImage = new BitmapImage(new Uri(imgPath));
            pushButton.ToolTip = "By Junhui";


            return Result.Succeeded;

        }
    }

}
