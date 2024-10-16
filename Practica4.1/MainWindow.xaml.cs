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
                MainFrame.Navigate(new Zaglu());
                Exit.Visibility = Visibility.Visible;
                Person.Visibility = Visibility.Visible;
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
    }
}
