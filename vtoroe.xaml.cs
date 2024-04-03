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

namespace praktika4en2
{
    /// <summary>
    /// Логика взаимодействия для vtoroe.xaml
    /// </summary>
    public partial class vtoroe : Window
    {
        private praktikaEntities context = new praktikaEntities();
        public vtoroe()
        {
            InitializeComponent();
            vybor.ItemsSource = context.Mesto.ToList();
            vybor.DisplayMemberPath = "Sektor";
        }

        private void poiskk(object sender, RoutedEventArgs e)
        {
            dg1.ItemsSource = context.Mesto.ToList().Where(item => item.Mesto1.Contains(SearchTxt.Text));
        }

        private void pokaz(object sender, RoutedEventArgs e)
        {
            dg1.ItemsSource = context.Mesto.ToList();
        }

        private void vyhod(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void vybor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (vybor.SelectedItem is Mesto selectedMesto)
            {
                dg1.ItemsSource = context.Mesto.ToList().Where(item => item.Sektor == selectedMesto.Sektor).ToList();
            }
        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
