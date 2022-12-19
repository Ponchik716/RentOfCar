using RentOfCar.Components;
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
    /// Логика взаимодействия для OrderListPage.xaml
    /// </summary>
    public partial class OrderListPage : Page
    {
        public OrderListPage()
        {
            InitializeComponent();
            OrdersList.ItemsSource = DbConnect.db.Order.ToList();
        }

        private void ExecutionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Navigatiom.role == 3 || Navigatiom.role == 2)
            {
                Navigatiom.NextPage(new Nav(new ExecutionPage()));
            }
            else
                MessageBox.Show("Отказано в доступе");
        }
    }
}
