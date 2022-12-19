﻿using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RentOfCar.Components;

namespace RentOfCar.Pages
{
    /// <summary>
    /// Логика взаимодействия для LogPage.xaml
    /// </summary>
    public partial class LogPage : Page
    {
        public LogPage()
        {
            InitializeComponent();
            LoginTb.Text = Properties.Settings.Default.Login;
            PasswordTb.Password = Properties.Settings.Default.Password;
        }
        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            string password = PasswordTb.Password.Trim();

            if (login.Length == 0 || password.Length == 0)
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                Navigatiom.AuthUser = DbConnect.db.User.ToList().Find(x => x.Login == login && x.Password == password);
                if (Navigatiom.AuthUser == null)
                {
                    MessageBox.Show("Такого пользователя нет", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    if (SaveCb.IsChecked == true)
                    {
                        Properties.Settings.Default.Login = LoginTb.Text.Trim();
                        Properties.Settings.Default.Password = PasswordTb.Password.Trim();
                        Properties.Settings.Default.Save();
                    }
                    else if (SaveCb.IsChecked == false)
                    {
                        Properties.Settings.Default.Login = "";
                        Properties.Settings.Default.Password = "";
                        Properties.Settings.Default.Save();
                    }
                    Navigatiom.isAuth = true;
                    Navigatiom.role = (int)Navigatiom.AuthUser.RoleId;
                    Navigatiom.NextPage(new Nav(new Perehod()));
                }

            }

        }

        private void RegistrBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigatiom.isAuth = true;
            Navigatiom.NextPage(new Nav(new RegistrPage()));
        }
    }
}
