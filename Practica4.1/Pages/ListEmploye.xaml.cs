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
            App.listEmploye = this;
            refresh();
        }
        public void refresh()
        {
            IEnumerable<User> SortList = App.db.User.Where(x => x.RoleId == 1 || x.RoleId == 2 || x.RoleId == 5).ToList();
            var Item = SortCb.SelectedItem;
            if (Item != null)
            {
                if (SortCb.SelectedIndex == 0)
                {
                    SortList = SortList.OrderBy(x => x.LastName);
                }
                else
                {
                    SortList = SortList.OrderByDescending(x => x.LastName);
                }
            }
            if (SearchTb.Text != null) 
            {
                SortList = SortList.Where(x => x.LastName.ToLower().Contains(SearchTb.Text.ToLower()));
            }
            MyList.ItemsSource = SortList.ToList();

        }

        private void AddEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditEmployeePage( new User()));
        }


        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refresh();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            refresh();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            User emp = (sender as Button).DataContext as User;
            if (emp != null)
            {
                NavigationService.Navigate(new AddEditEmployeePage(emp));
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            User emp = (sender as Button).DataContext as User;
            if (emp != null)
            {
                if (emp.Login == App.currentUser.Login)
                {
                    MessageBox.Show("Вы не можете удалить себя из базы данных!");
                    return;
                }
                
                App.db.User.Remove(emp);
                App.db.SaveChanges();
                refresh();
                MessageBox.Show("✦  Сотрудник успешно удален!  ✦");
            }
            else
                MessageBox.Show("Вы не выбрали сотрудника из листа!!");
        }
    }
}

