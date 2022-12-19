using Microsoft.Win32;
using RentOfCar.Components;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для CarEditAddPage.xaml
    /// </summary>
    public partial class CarEditAddPage : Page
    {
        Car car;
        public CarEditAddPage(Car _car)
        {
            InitializeComponent();
            car = _car;
            DataContext = car;
            Category.ItemsSource = DbConnect.db.Category.ToList();
            
        }
        private void SeaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (car.Id == 0)
            {
                DbConnect.db.Car.Add(car);
            }
            DbConnect.db.SaveChanges();
            MessageBox.Show("Все успешно");
            Navigatiom.NextPage(new Nav(new CarsListPage()));
        }
        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|.jpeg|*.jpeg|*.jpg|*.jpg",

            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                car.Photo = File.ReadAllBytes(openFileDialog.FileName);
                S63AMG.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }

        }
    }
}
