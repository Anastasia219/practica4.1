using Microsoft.Win32;
using Practica4._1.DBases;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Practica4._1.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditEmployeePage.xaml
    /// </summary>
    public partial class AddEditEmployeePage : Page
    {
        User user;
        UserImage userImage;
        bool isNew;
        string oldLogin;
        List<Operation> operations;
        public AddEditEmployeePage(User user, bool isNew, string title = "Добавить сотрудника")
        {
            InitializeComponent();
            if (!App.mainWindow.MainFrame.CanGoBack)
                Back.Visibility = Visibility.Collapsed;

            if (App.currentUser.RoleId == 1 || App.currentUser.RoleId == 2 || App.currentUser.RoleId == 5)
            {
                MainPanel.IsEnabled = false;
                SaveBtn.Visibility = Visibility.Collapsed;
                AddBtn.Visibility = Visibility.Collapsed;
                RoleCb.ItemsSource = App.db.Role.Where(x => x.Id != 4).ToList();
            }
            else if (App.currentUser.RoleId == 4)
            {
                PhotoPanel.Visibility = Visibility.Visible;
                PostPanel.Visibility = Visibility.Collapsed;
                EducationPanel.Visibility = Visibility.Collapsed;
                OperationPanel.Visibility = Visibility.Collapsed;
                RoleCb.ItemsSource = App.db.Role.ToList();
                RoleCb.IsEnabled = false;
                if (user.IdUserImage != null)
                    MainImage.Source = Methods.GetBitmapImageFromBytes(user.UserImage.Photo);
            }
            else
                RoleCb.ItemsSource = App.db.Role.Where(x => x.Id != 4).ToList();

            TitleTb.Text = title;
            oldLogin = user.Login;
            RoleCb.SelectedItem = user.Role;
            this.user = user;
            this.isNew = isNew;
            DataContext = this.user;

            operations = user.Operation.ToList();
            Refresh();
        }
        private void Refresh()
        {
            IEnumerable<Operation> operations = this.operations;
            MyList.ItemsSource = operations.ToList();
        }

        private void AddBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            operations.Add(new Operation());
            Refresh();
        }

        private void Back_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
                App.listEmploye = null;
            }
        }

        private void OperationTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            (textBox.DataContext as Operation).Name = textBox.Text;
        }

        private void SaveBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string mistake = "";

            if (LoginTb.Text == "" && mistake == "")
                mistake = "Вы не заполнили логин!";
            if (PasswordTb.Text == "" && mistake == "")
                mistake = "Вы не заполнили пароль!";
            mistake = ValidatePassword(PasswordTb.Text);
            if (App.db.User.Any(x => x.Login == LoginTb.Text) && (oldLogin != LoginTb.Text || isNew) && mistake == "")
                mistake = "Такой логин уже есть!";
            if (RoleCb.SelectedIndex == -1 && mistake == "")
                mistake = "Вы не выбрали роль!";
            if (LastNameCb.Text == "" && mistake == "")
                mistake = "Вы не заполнили фамилию!";
            if (FirstNameCb.Text == "" && mistake == "")
                mistake = "Вы не заполнили имя!";
            if (PatronymicCb.Text == "" && mistake == "")
                mistake = "Вы не заполнили отчество!";

            if (mistake != "")
            {
                Methods.TakeWarning(mistake);
                return;
            }
            if (userImage != null && userImage.Id == 0)
            {
                userImage = App.db.UserImage.Add(userImage);
                user.IdUserImage = userImage.Id;
            }

            user.RoleId = (RoleCb.SelectedItem as Role).Id;
            if (isNew)
                user = App.db.User.Add(user);

            foreach (var operation in operations)
            {
                if (operation.Id == 0)
                {
                    operation.Login = user.Login;
                    App.db.Operation.Add(operation);
                }
            }

            App.db.SaveChanges();
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
                if (App.listEmploye != null)
                    App.listEmploye.Refresh();
                App.listEmploye = null;
            }
            Methods.TakeInformation("Изменения успешно сохранены!");
        }
        private string ValidatePassword(string password)
        {
            if (password.Length < 4 || password.Length > 16)
                return "Пароль должен содержать от 4 до 16 символов.";
            const string forbiddenChars = "*&{}|+";
            if (forbiddenChars.Any(x => password.Contains(x)))
                return "Пароль не должен содержать символы *, &, {, }, |, +.";
            if (!Regex.IsMatch(password, "[A-Z]"))
                return "Пароль должен содержать хотя бы одну заглавную букву.";
            if (!Regex.IsMatch(password, @"\d"))
                return "Пароль должен содержать хотя бы одну цифру.";

            return "";
        }

        private void Delete_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            Operation operation = image.DataContext as Operation;

            operations.Remove(operation);
            if (operation.Id != 0)
                App.db.Operation.Remove(operation);
            Refresh();
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            var opn = new OpenFileDialog();
            opn.Title = "Выберите изображение";
            opn.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tif;*.tiff|All Files|*.*";
            if (opn.ShowDialog() == true)
            {
                byte[] bytes = File.ReadAllBytes(opn.FileName);
                UserImage image = App.db.UserImage.FirstOrDefault(x => x.Photo == bytes);
                if (image != null)
                {
                    user.IdUserImage = image.Id;
                    userImage = image;
                }
                else
                    userImage = new UserImage() { Photo = bytes };

                MainImage.Source = Methods.GetBitmapImageFromBytes(bytes);
            }
        }

        private void DeleteImage_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainImage.Source = null;
            user.IdUserImage = null;

            if (userImage.Id == 0)
                userImage = null;
            else
            {
                if (isNew && userImage.User.Count() > 0)
                    user.IdUserImage = null;
                else if (!isNew && userImage.User.Count() > 1)
                    user.IdUserImage = null;
                else if (!isNew && userImage.User.Count() == 1)
                {
                    user.IdUserImage = null;
                    App.db.UserImage.Remove(userImage);
                }
            }
        }
    }
}
