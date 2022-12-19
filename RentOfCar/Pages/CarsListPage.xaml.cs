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
using RentOfCar.Pages;

namespace RentOfCar.Pages
{
    /// <summary>
    /// Логика взаимодействия для CarsListPage.xaml
    /// </summary>
    public partial class CarsListPage : Page
    {
        public CarsListPage()
        {
            InitializeComponent();
            CarList.ItemsSource = DbConnect.db.Car.ToList();
        }
        private void Refresh()
        {

            IEnumerable<Car> filter = DbConnect.db.Car;
            if (Sort.SelectedIndex > 0)
            {
                if (Sort.SelectedIndex == 1)
                    filter = filter.OrderBy(x => x.Name);
                else if (Sort.SelectedIndex == 2)
                    filter = filter.OrderByDescending(x => x.Name);
            }
            ////
            if (SearchBox.Text.Length > 0)
            {
                filter = filter.Where(x => x.Name.ToLower().StartsWith(SearchBox.Text.ToLower()) || x.Model.ToLower().StartsWith(SearchBox.Text.ToLower()));
            }

            CarList.ItemsSource = filter.ToList();
        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
        private void SearchBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Navigatiom.role == 2)
            {
                MessageBox.Show("Отказано в доступе");
            }
            else
            Navigatiom.NextPage(new Nav(new CarEditAddPage(new Car())));
            
        }
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Navigatiom.role == 1)
            {
                var selProd = (sender as Button).DataContext as Car;
                Navigatiom.NextPage(new Nav(new CarEditAddPage(selProd)));
                
            }
            else
            {
                MessageBox.Show("Отказано в доступе");
            }
        }
    }
}
