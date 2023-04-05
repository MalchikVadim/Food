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
    /// Логика взаимодействия для DRClient.xaml
    /// </summary>
    public partial class DRClient : Page
    {
        private Clients _currentClients = new Clients();
        public DRClient(Clients selectedSale)
        {
            InitializeComponent();
            if (selectedSale != null)
            {
                _currentClients = selectedSale;
                TitletxtSales.Text = "Изменение клиента";
                BtnAddSale.Content = "Изменить";
            }
            // Создаём контекст
            DataContext = _currentClients;
        }
        private void BtnAddSale_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentClients.surname)) error.AppendLine("Укажите имя");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentClients.first_name))) error.AppendLine("Укажите фамилию");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentClients.patronymic))) error.AppendLine("Укажите отчество");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            if (_currentClients.id_Clients == 0)
            {
                FoodEntities.GetContext().Clients.Add(_currentClients);
                try
                {
                    FoodEntities.GetContext().SaveChanges();
                    Classes.ClassFrame.frmObj.Navigate(new PageClients());
                    MessageBox.Show("Новый клиент успешно добавлен!");
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
                    Classes.ClassFrame.frmObj.Navigate(new PageClients());
                    MessageBox.Show("Клиент успешно изменён!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnCancelSale_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PageClients());
        }
    }
}
