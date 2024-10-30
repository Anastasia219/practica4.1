using Practica4._1.DBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Practica4._1.Components
{
    /// <summary>
    /// Логика взаимодействия для AccessoriesControl.xaml
    /// </summary>
    public partial class AccessoriesControl : UserControl
    {
        public ProductAccessories accessories;


        ProductControl productControl;
        public AccessoriesControl(ProductAccessories accessories, ProductControl productControl)
        {
            InitializeComponent();
            this.accessories = accessories;
            this.productControl = productControl;
            MaterialCb.ItemsSource = App.db.Accessories.ToList();
            DataContext = accessories;
        }


        private void CountTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void MaterialCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            accessories.AccessoriesArticle = (MaterialCb.SelectedItem as Accessories).Article;
        }

        private void Trash_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Methods.TakeChoice("Вы точно хотите удалить комплектующее?"))
            {
                productControl.accessories.Remove(this);
                if (accessories.Id != 0)
                {
                    App.db.ProductAccessories.Remove(accessories);
                    App.db.SaveChanges();
                }
                productControl.RefreshAccessories();
                Methods.TakeInformation("Комплектующее успешно удалено!");
            }
        }

        private void CountTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            accessories.Count = Convert.ToInt32(CountTb.Text);
        }
    }
}
