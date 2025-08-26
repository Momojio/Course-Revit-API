using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

namespace WPFCombox
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Exemple de données pour le CBClass
            List<Person> persons = new List<Person>
            {
                new Person { Name = "Alice", Age = 30, Id = 1 },
                new Person { Name = "Bob", Age = 25, Id = 2 },
                new Person { Name = "Charlie", Age = 35, Id = 3, Ps = "Oversea" }
            };
            // Associer la liste de personnes à la ComboBox
            CBClass.ItemsSource = persons;

            // Définir le mode d'affichage de la ComboBox pour afficher le nom des personnes
            CBClass.DisplayMemberPath = "Name";
            CBClass.SelectedValuePath = "Ps";

            DGData.ItemsSource = persons; // Associer la même liste au DataGrid pour affichage
           
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
        }



        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //this.TBNormal.Text = CBNormal.SelectedItem?.ToString() ?? string.Empty;
            //Évite les crashes quand les données UI sont vides
            this.TBNormal.Text = CBNormal.SelectedItem is ComboBoxItem item ? item.Content.ToString() : string.Empty;
        }

        private void CBClass_SelectionChanged(object sender, EventArgs e)
        {
            //this.TBClass.Text = CBClass.SelectedItem is Person person ? person.Name : string.Empty;


        }


        private void CBClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBClass.SelectedValue == null)
            {
                this.TBClass.Text = $"No more infos.";

            }
            else
            {
                this.TBClass.Text = $"More information={CBClass.SelectedValue}";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DGData.SelectedItem== null)
            {
                MessageBox.Show("Veuillez sélectionner une personne dans le DataGrid.", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Person person = DGData.SelectedItem as Person;
            MessageBox.Show($"Vous avez sélectionné : P.S.: {person.Ps}", "More information", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (var item in DGData.Items)
            {
                if (item is Person person)
                {
                    MessageBox.Show($"Pour toutes les pesonnes : {person.Name}, {person.Age} ans, P.S.: {person.Ps}", "More information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
            }
        }


        //With Display in the class Person.cs. To change the Header of P.S. column in the DataGrid.
        private void DGData_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var displayAttr = (e.PropertyDescriptor as PropertyDescriptor)
                ?.Attributes.OfType<DisplayAttribute>()
                .FirstOrDefault();
            if (displayAttr != null)
            {
                e.Column.Header = displayAttr.GetName(); // 设置自定义列名
            }
        }


        private void TBClass_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TBNormal_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
