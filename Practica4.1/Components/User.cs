﻿using Practica4._1.DBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Practica4._1.DBases
{
    public partial class User
    {
        public int Age
        {
            get
            {
                if (DateBithday == null)
                    return 0;
                return DateTime.Now.Year - DateBithday.Value.Year;
            }
        }

        public string FIO
        {
            get { return LastName + " " + FirstName + " " + Patronymic; }
        }

        public string Operations
        {
            get
            {
                string operations = "";
                var list = Operation.ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == Operation.Count - 1)
                        operations += list[i].Name.ToString() + ".";
                    else
                        operations += list[i].Name.ToString() + ", ";
                }
                return operations;
            }
        }

        public Visibility canEdit
        {
            get { return RoleId != 3 ? Visibility.Collapsed : Visibility.Visible; }
        }
    }
}
