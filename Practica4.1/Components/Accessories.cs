﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Practica4._1.DBases
{
    public partial class Accessories
    {
        public Visibility canEdit
        {
            get
            {
                Visibility visib = Visibility.Collapsed;
                if (App.currentUser != null && (App.currentUser.RoleId == 3 || App.currentUser.RoleId == 5))
                    visib = Visibility.Visible;
                return visib;
            }
        }
    }
}
