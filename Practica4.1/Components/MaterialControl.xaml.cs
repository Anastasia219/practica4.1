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
    /// Логика взаимодействия для MaterialControl.xaml
    /// </summary>
    public partial class MaterialControl : UserControl
    {
        public ProductMaterial material;

        ProductControl productControl;
        public MaterialControl(ProductMaterial material, ProductControl productControl)
        {
            InitializeComponent();
            this.material = material;
            this.productControl = productControl;
            MaterialCb.ItemsSource = App.db.Material.ToList();
            DataContext = material;
        }


        private void CountTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void MaterialCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            material.MaterialArticle = (MaterialCb.SelectedItem as Material).Article;
        }

        private void Trash_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Methods.TakeChoice("Вы точно хотите удалить материал?"))
            {
                productControl.materials.Remove(this);
                if (material.Id != 0)
                {
                    App.db.ProductMaterial.Remove(material);
                    App.db.SaveChanges();
                }
                productControl.RefreshMaterals();
                Methods.TakeInformation("Материал успешно удален!");
            }
        }

        private void CountTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            material.Count = Convert.ToInt32(CountTb.Text);
        }
    }
}
