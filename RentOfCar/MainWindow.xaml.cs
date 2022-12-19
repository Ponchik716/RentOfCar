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
using RentOfCar.Pages;
using RentOfCar.Components;

namespace RentOfCar
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigatiom.main = this;
            Navigatiom.NextPage(new Nav(new LogPage()));
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigatiom.isAuth = false;
            Navigatiom.navs.Clear();
            Navigatiom.NextPage(new Nav(new LogPage()));
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigatiom.BackPage();
        }
    }
}
