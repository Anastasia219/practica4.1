﻿using Practica4._1.DBases;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        public Autorization()
        {
            InitializeComponent();
        }
        private void RegLink_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            User user = App.db.User.FirstOrDefault(x => x.Login == LoginTb.Text && x.Password == PasswordPb.Password);
            if (user != null)
            {
                if (RememberCb.IsChecked == true)
                    File.WriteAllText(@"RememberMe.txt", user.Login);
                App.currentUser = user;

                if (user.RoleId == 3)
                {
                    App.mainWindow.SetIcons(true, true, true, true, true, true, false, false);
                    NavigationService.Navigate(new ListEmploye());
                }
                else if (user.RoleId == 4)
                {
                    App.mainWindow.SetIcons(false, false, true, true, false, true, false, false);
                    NavigationService.Navigate(new Zaglu());
                }
                else if (user.RoleId == 1)
                {
                    App.mainWindow.SetIcons(false, true, true, true, false, true, true, true);
                    NavigationService.Navigate(new ComponAndMater());
                }
                else
                {
                    App.mainWindow.SetIcons(false, true, true, true, false, true, false, false);
                    NavigationService.Navigate(new ComponAndMater());
                }

                Methods.TakeInformation("Вы успешно зашли в систему!");
            }
            else
                Methods.TakeWarning("Неверный логин или пароль!");
        }
    }
}
