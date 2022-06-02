using CRUD_Inventory.Model;
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

namespace CRUD_Inventory
{
    /// <summary>
    /// Логика взаимодействия для ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        public ProductsWindow()
        {
            InitializeComponent();
            Update();
        }
        InventoryEntities db = new InventoryEntities();

        private void AddProducer(object sender, RoutedEventArgs e)
        {
            var window = new AddProducer();
            window.Show();
        }

        private void ShowProd(object sender, RoutedEventArgs e)
        {
            var window = new ShowProducers();
            window.Show();
        }

        private void Update()
        {
            data.Items.Clear();
            foreach(var i in Data.GetProducts(db))
            {
                data.Items.Add(i);
            }
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            var window = new AddProduct();
            window.Show();
            window.Closed += Window_Closed;
        }
        private void inadd(object sender, RoutedEventArgs e)
        {
            Data.ProductId = (data.SelectedItem as Product).ProductId;
            var window = new AddIn();
            window.Show();
            window.Closed += Window_Closed;
        }
        private void outadd(object sender, RoutedEventArgs e)
        {
            Data.ProductId = (data.SelectedItem as Product).ProductId;
            var window = new AddOut();
            window.Show();
            window.Closed += Window_Closed;

        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            Data.RemoveProduct(db,data.SelectedItem as Product);
            Update();
        }
        private void ShowResult(object sender, RoutedEventArgs e)
        {
            var window = new Results();
            window.Show();
            window.Closed += Window_Closed;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Update();
        }
    }
}
