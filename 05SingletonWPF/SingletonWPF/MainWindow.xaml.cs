using Cache;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace SingletonWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            //SousFenetre sousFenêtre = new SousFenetre();//For the mutiple window example
            SousFenetre sousFenêtre = SousFenetre.instance; // Utilisation du singleton
            sousFenêtre.Show();

        }

        private void txBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SysCache.instance.TextValue = txBox.Text.Trim(); // Mettre à jour la valeur du cache
        }
    }
}
