using Practica4._1.Pages;
using System.IO;
using System.Linq;
using System.Windows;

namespace Practica4._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            App.mainWindow = this;
            if (File.Exists(@"RememberMe.txt"))
            {
                string Login = File.ReadAllText(@"RememberMe.txt");
                App.currentUser = App.db.User.FirstOrDefault(x => x.Login == Login);
                if (App.currentUser == null)
                {
                    MainFrame.Navigate(new Autorization());
                    return;
                }
                if (App.currentUser.RoleId == 3)
                {
                    App.mainWindow.SetIcons(true, true, true, true, true, true, false, false);
                    MainFrame.Navigate(new ListEmploye());
                }
                else if (App.currentUser.RoleId == 4)
                {
                    App.mainWindow.SetIcons(false, false, true, true, false, true, false, false);
                    MainFrame.Navigate(new OrdersClient());
                }
                else if (App.currentUser.RoleId == 1)
                {
                    App.mainWindow.SetIcons(false, true, true, true, false, true, true, true);
                    MainFrame.Navigate(new ComponAndMater());
                }
                else
                {
                    App.mainWindow.SetIcons(false, true, true, true, false, true, false, false);
                    MainFrame.Navigate(new ComponAndMater());
                }
                Methods.TakeInformation("Вы успешно зашли в систему!");
            }
            else
                MainFrame.Navigate(new Autorization());
        }

        public void SetIcons(bool employee, bool materials, bool exit, bool account, bool plan, bool order, bool failure, bool test)
        {
            Employee.Visibility = employee ? Visibility.Visible : Visibility.Collapsed;
            Material.Visibility = materials ? Visibility.Visible : Visibility.Collapsed;
            Person.Visibility = account ? Visibility.Visible : Visibility.Collapsed;
            Exit.Visibility = exit ? Visibility.Visible : Visibility.Collapsed;
            Plan.Visibility = plan ? Visibility.Visible : Visibility.Collapsed;
            Order.Visibility = order ? Visibility.Visible : Visibility.Collapsed;
            Failure.Visibility = failure ? Visibility.Visible : Visibility.Collapsed;
            Test.Visibility = test ? Visibility.Visible : Visibility.Collapsed;
        }
        

        private void Exit_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (File.Exists(@"RememberMe.txt"))
                File.Delete(@"RememberMe.txt");

            MainFrame.Navigate(new Autorization());
            Exit.Visibility = Visibility.Collapsed;
            Person.Visibility = Visibility.Collapsed;
            SetIcons(false, false, false, false, false, false, false, false);
        }
        
        private void Material_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new ComponAndMater());
        }

        private void Employee_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new ListEmploye());
        }

        private void Person_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new AddEditEmployeePage(App.currentUser, false, "Ваш профиль"));
        }

        private void Plan_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new Sech());
        }

        private void Order_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new OrdersClient());
        }
        private void Failure_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new FailurePage());
        }

        private void Test_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new TestPage());
        }
    }
}
