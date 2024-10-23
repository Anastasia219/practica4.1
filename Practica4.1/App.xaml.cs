using Practica4._1.DBases;
using Practica4._1.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Practica4._1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static UchebkaEntities1 db = new UchebkaEntities1();
        public static MainWindow mainWindow;
        public static User currentUser;
        public static ListEmploye listEmploye;
    }
}
