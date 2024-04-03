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
    /// Логика взаимодействия для tri.xaml
    /// </summary>
    public partial class tri : Window
    {
        private praktikaEntities context = new praktikaEntities();
        public tri()
        {
            InitializeComponent();
            vybor.ItemsSource = context.Orders.ToList();
            vybor.DisplayMemberPath = "Price";
        }

        private void poiskk(object sender, RoutedEventArgs e)
        {
            dg1.ItemsSource = context.Orders.ToList().Where(item => item.DataPokupki.ToString().Contains(SearchTxt.Text));
        }

        private void pokaz(object sender, RoutedEventArgs e)
        {
            dg1.ItemsSource = context.Orders.ToList();
        }

        private void vyhod(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void vybor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (vybor.SelectedItem is Orders selectedPrice)
            {
                dg1.ItemsSource = context.Orders.ToList().Where(item => item.Price == selectedPrice.Price).ToList();
            }
        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
