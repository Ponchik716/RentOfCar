using RentOfCar.Components;
using RentOfCar.Pages;
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

namespace RentOfCar.Pages
{
    /// <summary>
    /// Логика взаимодействия для Perehod.xaml
    /// </summary>
    public partial class Perehod : Page
    {
        public Perehod()
        {
            InitializeComponent();
        }


        private void CarBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigatiom.NextPage(new Nav(new CarsListPage()));
        }
        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigatiom.NextPage(new Nav(new OrderListPage()));
        }
    }
}
