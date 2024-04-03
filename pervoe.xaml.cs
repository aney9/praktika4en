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
    /// Логика взаимодействия для pervoe.xaml
    /// </summary>
    public partial class pervoe : Window
    {
        private praktikaEntities context = new praktikaEntities();
        public pervoe()
        {
            InitializeComponent();
            vybor.ItemsSource = context.Clients.ToList();
            vybor.DisplayMemberPath = "FanId";
        }

        private void poiskk(object sender, RoutedEventArgs e)
        {
            dg1.ItemsSource = context.Clients.ToList().Where(item => item.Email.Contains(SearchTxt.Text));
        }

        private void vybor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (vybor.SelectedItem is Clients selectedFanId)
            {
                dg1.ItemsSource = context.Clients.ToList().Where(item => item.FanId == selectedFanId.FanId).ToList();
            }
        }

        private void pokaz(object sender, RoutedEventArgs e)
        {
            dg1.ItemsSource = context.Clients.ToList();
        }

        private void vyhod(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
