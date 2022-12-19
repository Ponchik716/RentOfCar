using RentOfCar.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
    /// Логика взаимодействия для ExecutionPage.xaml
    /// </summary>
    public partial class ExecutionPage : Page
    {
        public ObservableCollection<Car> Cars
        {
            get { return (ObservableCollection<Car>)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("Cars", typeof(ObservableCollection<Car>), typeof(ExecutionPage));


        public ObservableCollection<Car> CarsAddOrder
        {
            get { return (ObservableCollection<Car>)GetValue(ProductsAddOrderProperty); }
            set { SetValue(ProductsAddOrderProperty, value); }
        }

        

        public object CarsAddOrderProperty { get; private set; }
        public object СarsAddOrderProperty { get; private set; }

        

        public static readonly DependencyProperty ProductsAddOrderProperty =
            DependencyProperty.Register("ProductsAddOrder", typeof(ObservableCollection<Car>), typeof(ExecutionPage));



        public ExecutionPage()
        {
            DbConnect.db.Car.Load();
            Cars = new ObservableCollection<Car>(DbConnect.db.Car.Local);
            CarsAddOrder = new ObservableCollection<Car>();

            InitializeComponent();
        }

        private void ButtonAddProductOrderClick(object sender, RoutedEventArgs e)
        {
            if (ProductList.SelectedItem == null)
                return;

            Car car = ProductList.SelectedItem as Car;

            Cars.Remove(car);
            CarsAddOrder.Add(car);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            decimal totalCost = 0;

            foreach (var item in CarsAddOrder)
                totalCost += (decimal)item.Cost;

            Order order = new Order()
            {
                EmployeeId = 4,
                ClientId = Navigatiom.AuthUser.Id, //
                OrderDate = DateTime.Now,
                TotalCost = totalCost
            };

            DbConnect.db.Order.Add(order);

            foreach (var item in CarsAddOrder)
            {
                CarOrder car = new CarOrder()
                {
                    OrderId = order.Id,
                    Car = item,
                    
                };

                DbConnect.db.CarOrder.Add(car);
            }

            DbConnect.db.SaveChanges();
            Navigatiom.NextPage(new Nav(new OrderListPage()));
        }
    }
}
