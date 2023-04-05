using Food.Classes;
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

namespace Food.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageDishes.xaml
    /// </summary>
    public partial class PageDishes : Page
    {
        public PageDishes()
        {
            InitializeComponent();
            ListClients.ItemsSource = FoodEntities.GetContext().Dishes.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(null);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new DRDishe(null));
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new DRDishe((Dishes)ListClients.SelectedItem));
        }
    }
}
