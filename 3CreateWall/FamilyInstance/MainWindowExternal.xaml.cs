using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using QiShiLog;
using QiShiLog.Log;

namespace FamilyInstance
{
    /// <summary>
    /// Logique d'interaction pour MainWindowExternal.xaml
    /// </summary>
    public partial class MainWindowExternal : Window
    {

        //External event
        CreateWallExternal createWallExternal = null;
        ExternalEvent createWallEvent = null;   

        public MainWindowExternal()
        {
            InitializeComponent();

            //initial
            createWallExternal = new CreateWallExternal();  
            createWallEvent = ExternalEvent.Create(createWallExternal);
            //this.UseLayoutRounding = true; // 消除模糊
            //this.SnapsToDevicePixels = true;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Main method


            #region error try
            try
            {
                if (!double.TryParse(this.textBox.Text, out double height))
                {
                    MessageBox.Show($"Incorrect：'{this.textBox.Text}'");
                    return;
                }

                //createWallExternal.WallHeight = Convert.ToDouble(this.textBox.Text);
                createWallExternal.WallHeight = height;
                createWallEvent.Raise();


            }
            catch (Exception ex)
            {


                TaskDialog.Show($"Error, {ex.Message}", ex.Message);    
                //Console.WriteLine(ex.Message);
            }


            

            #endregion

            //MainWindowExternal mainWindowExternal = new MainWindowExternal(); 
            //if (!double.TryParse(mainWindowExternal.textBox.Text, out double height))
            //{
            //    MessageBox.Show("请输入有效的数字！");
            //    return;
            //}

            ////createWallExternal.WallHeight = Convert.ToDouble(this.textBox.Text);
            //createWallEvent.Raise();


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
