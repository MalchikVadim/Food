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
    /// Логика взаимодействия для DRDishe.xaml
    /// </summary>
    public partial class DRDishe : Page
    {
        private Dishes _currentClients = new Dishes();
        public DRDishe(Dishes selectedSale)
        {
            InitializeComponent();
            if (selectedSale != null)
            {
                _currentClients = selectedSale;
                TitletxtSales.Text = "Изменение блюдо";
                BtnAddSale.Content = "Изменить";
            }
            // Создаём контекст
            DataContext = _currentClients;
        }

        private void BtnAddSale_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentClients.title)) error.AppendLine("Укажите название");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentClients.view_dish))) error.AppendLine("Укажите вид");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentClients.price))) error.AppendLine("Укажите цену");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentClients.image))) error.AppendLine("Вставьте фото");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            if (_currentClients.id_Dishes == 0)
            {
                FoodEntities.GetContext().Dishes.Add(_currentClients);
                try
                {
                    FoodEntities.GetContext().SaveChanges();
                    Classes.ClassFrame.frmObj.Navigate(new PageDishes());
                    MessageBox.Show("Новое блюдо успешно добавлено!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                try
                {
                    FoodEntities.GetContext().SaveChanges();
                    Classes.ClassFrame.frmObj.Navigate(new PageDishes());
                    MessageBox.Show("Блюдо успешно изменено!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnCancelSale_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PageDishes());
        }
    }
}
