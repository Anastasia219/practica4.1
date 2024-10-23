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
                    App.mainWindow.SetIcons(true, true, true, true);
                    MainFrame.Navigate(new ListEmploye());
                }
                else if (App.currentUser.RoleId == 4)
                {
                    App.mainWindow.SetIcons(false, false, true, true);
                    MainFrame.Navigate(new Zaglu());
                }
                else
                {
                    App.mainWindow.SetIcons(false, true, true, true);
                    MainFrame.Navigate(new ComponAndMater());
                }
                Methods.TakeInformation("Вы успешно зашли в систему!");
            }
            else
                MainFrame.Navigate(new Autorization());
        }
        private void Image_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Exit_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (File.Exists(@"RememberMe.txt"))
                File.Delete(@"RememberMe.txt");

            MainFrame.Navigate(new Autorization());
            Exit.Visibility = Visibility.Collapsed;
            Person.Visibility = Visibility.Collapsed;
        }
        public void SetIcons(bool employee, bool materials, bool exit, bool account)
        {
            Employee.Visibility = employee ? Visibility.Visible : Visibility.Collapsed;
            Material.Visibility = materials ? Visibility.Visible : Visibility.Collapsed;
            Person.Visibility = account ? Visibility.Visible : Visibility.Collapsed;
            Exit.Visibility = exit ? Visibility.Visible : Visibility.Collapsed;
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
    }
}
