using CRUD_Inventory.Model;
using System;
using System.Windows;
namespace CRUD_Inventory
{
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
        private void Change(object sender, RoutedEventArgs e)
        {
            Data.ProductId = (data.SelectedItem as Product).ProductId;
            var window = new ChangeProduct();
            window.Show();
            window.Closed += Window_Closed;
        }
        private void ShowResult(object sender, RoutedEventArgs e)
        {
            var window = new Results();
            window.Show();
            window.Closed += Window_Closed;
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            foreach (var entity in db.ChangeTracker.Entries())
            {
                entity.Reload();
            }
            Update();
        }
    }
}
