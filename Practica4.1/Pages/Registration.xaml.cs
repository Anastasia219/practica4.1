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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        User user = new User();
        UserImage image = new UserImage();
        public Registration()
        {
            InitializeComponent();
        }
        private void LoadImageBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var opn = new OpenFileDialog();
            opn.Title = "Выберите изображение";
            opn.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tif;*.tiff|All Files|*.*";
            if (opn.ShowDialog() == true)
            {
                image.Photo = File.ReadAllBytes(opn.FileName);
                if (image.Id == 0)
                    App.db.UserImage.Add(image);
                user.IdUserImage = image.Id;
                MainImage.Source = Methods.GetBitmapImageFromBytes(image.Photo);
            }
        }
        private void DeleteImageBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (image.Id == 0)
                image.Photo = null;
            else
            {
                App.db.UserImage.Remove(image);
                image = new UserImage();
            }
            user.IdUserImage = null;
            MainImage.Source = null;
        }

        private void RegBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Regex FIO = new Regex(@"^[А-ЯA-Z][а-яa-z]*$");
            if (LastNameTb.Text == "" || !FIO.IsMatch(LastNameTb.Text))
            {
                MessageBox.Show("Вы неправильно ввели фаимлию!");
                return;
            }

            if (txtFirstName.Text == "" || !FIO.IsMatch(txtFirstName.Text))
            {
                MessageBox.Show("Вы неправильно ввели имя!");
                return;
            }
            if (txtMiddleName.Text == "" || !FIO.IsMatch(txtMiddleName.Text))
            {
                MessageBox.Show("Вы неправильно ввели отчество!");
                return;
            }

            if (App.db.User.Any(x => x.Login == txtLogin.Text))
            {
                MessageBox.Show("Этот логин уже используется!");
                return;
            }
            if (txtPassword.Password == "")
            {
                MessageBox.Show("Вы не ввели пароль!");
                return;
            }
           

            if (txtPassword.Password.Length < 4 || txtPassword.Password.Length > 16)
            {
                MessageBox.Show("Пароль должен содержать от 4 до 16 символов.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (!Regex.IsMatch(txtPassword.Password, "[A-Z]"))
            {
                MessageBox.Show("Пароль должен содержать хотя бы одну заглавную букву.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

    
            if (!Regex.IsMatch(txtPassword.Password, "[0-9]"))
            {
                MessageBox.Show("Пароль должен содержать хотя бы одну цифру.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Regex.IsMatch(txtPassword.Password, @"[*&{}|+]"))
            {
                MessageBox.Show("Пароль не должен содержать символы: * & { } | +.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            user.LastName = LastNameTb.Text;
            user.FirstName = txtFirstName.Text;
            user.Patronymic = txtMiddleName.Text;
            user.Login = txtLogin.Text;
            user.Password = txtPassword.Password;
            App.db.User.Add(user);

            App.db.SaveChanges();

            NavigationService.Navigate(new Autorization());
            Methods.TakeInformation("Вы зарегистрированны!");
        }

        private void Back_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }
    }
}
