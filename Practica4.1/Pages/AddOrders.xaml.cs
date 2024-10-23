using Practica4._1.DBases;
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

namespace Practica4._1.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddOrders.xaml
    /// </summary>
    public partial class AddOrders : Page
    {
        
        private int currentOrderCount = 0; // Счетчик заказов для формирования номера заказа

        public AddOrders()
        {
            InitializeComponent();
            OrderDateTextBox.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
       
        

        private void SaveOrderButton_Click(object sender, RoutedEventArgs e)
        {
            
           
        }

        private bool ValidateForm()
        {
            
            if (string.IsNullOrWhiteSpace(OrderNameTextBox.Text) || CustomerComboBox.SelectedItem == null)
            {
                MessageBox.Show("Заполните наименование заказа и выберите заказчика.");
                return false;
            }
            return true;
        }

        private string GenerateOrderNumber()
        {
            currentOrderCount++;
            string customerInfo = CustomerComboBox.SelectedItem.ToString();
            char firstLetter = customerInfo[0];
            char secondLetter = customerInfo.Contains(' ') ? customerInfo[customerInfo.IndexOf(' ') + 1] : '_';
            string dateInfo = DateTime.Now.ToString("yyMMdd");
            string orderNumber = $"{char.ToUpper(firstLetter)}{char.ToUpper(secondLetter)}{dateInfo}{currentOrderCount.ToString("D2")}";

            return orderNumber;
        }

       
    }
}
