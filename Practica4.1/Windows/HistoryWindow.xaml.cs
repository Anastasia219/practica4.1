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
using System.Windows.Shapes;

namespace Practica4._1.Windows
{
    /// <summary>
    /// Логика взаимодействия для HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        public HistoryWindow()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh()
        {
            IEnumerable<StatusOrder> statuses = App.db.StatusOrder;
            if (App.currentUser.RoleId == 5)
                statuses = statuses.Where(x => x.Order.LoginManager == null || x.Order.LoginManager == App.currentUser.Login);

            MyList.ItemsSource = statuses.ToList();
        }
    }
}
