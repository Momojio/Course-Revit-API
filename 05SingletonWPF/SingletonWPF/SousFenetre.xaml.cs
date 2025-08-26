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
using System.Windows.Shapes;

namespace SingletonWPF
{
    /// <summary>
    /// Logique d'interaction pour SousFenetre.xaml
    /// </summary>
    public partial class SousFenetre : Window
    {
        private SousFenetre()
        {
            InitializeComponent();
        }

        private static SousFenetre _instance;

        //public static SousFenetre instance { get; }


        // Utilisation d'un singleton pour la fenêtre
        public static SousFenetre instance
        {


            get
            {
                if (ReferenceEquals(_instance, null))
                {
                    _instance = new SousFenetre();
                }

                return _instance;
            }

        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(SysCache.instance.TextValue, "Valeur du Cache", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true; // Empêche la fermeture de la fenêtre
            this.Hide(); // Masque la fenêtre au lieu de la fermer
        }
    }
}
