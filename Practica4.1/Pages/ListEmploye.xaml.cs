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
    /// Логика взаимодействия для ListEmploye.xaml
    /// </summary>
    public partial class ListEmploye : Page
    {
        public ListEmploye()
        {
            InitializeComponent();
            SortCb.SelectedIndex = 0;
        }
        public void Refresh()
        {
            IEnumerable<User> employee = App.db.User.Where(x => x.RoleId != 4);

            if (SearchTb.Text != "")
                employee = employee.Where(x => x.FIO.Contains(SearchTb.Text));


            if (SortCb.SelectedIndex == 1)
                employee = employee.OrderBy(x => x.LastName);
            else if (SortCb.SelectedIndex == 2)
                employee = employee.OrderByDescending(x => x.LastName);
            else if (SortCb.SelectedIndex == 3)
                employee = employee.OrderBy(x => x.Age);
            else if (SortCb.SelectedIndex == 4)
                employee = employee.OrderByDescending(x => x.Age);
            else if (SortCb.SelectedIndex == 5)
                employee = employee.OrderBy(x => x.RoleId);


            MyList.ItemsSource = employee.ToList();
        }

        private void AddEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            App.listEmploye = this;
            NavigationService.Navigate(new AddEditEmployeePage(new User(), true));
        }

        private void Delete_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Methods.TakeChoice("Вы точно хотите удалить сотрудника?"))
            {
                App.db.User.Remove((sender as Image).DataContext as User);
                Methods.TakeInformation("Успешно удалено!");
            }
        }

        private void Edit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            App.listEmploye = this;
            NavigationService.Navigate(new AddEditEmployeePage((sender as Image).DataContext as User, false, "Редактировать сотрудника"));
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}

