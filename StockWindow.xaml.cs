using System;
using System.Windows;
namespace CRUD_Inventory
{
    public partial class StockWindow : Window
    {
        public StockWindow()
        {
            InitializeComponent();
            db = new Model.InventoryEntities();
            Update();
        }
        Model.InventoryEntities db;
        private void OpenClick(object sender, RoutedEventArgs e)
        {
            if (data.SelectedItem != null)
            {
                var window = new MainWindow();
                Model.Data.StocksId = (data.SelectedItem as Model.Stock).StockId;
                window.Show();
                window.Owner = this;
            }
        }
        private void AddOpen(object sender, RoutedEventArgs e)
        {
            var window = new AddStock();
            window.Show();
            window.Closed += Window_Closed;
            window.Owner = this;
        }
        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            if(data.SelectedItem!=null)
                Model.Data.RemoveStock(db, data.SelectedItem as Model.Stock);
            Update();
        }
        private void ChangeClick(object sender, RoutedEventArgs e)
        {
            Model.Data.StocksId = (data.SelectedItem as Model.Stock).StockId;
            var window = new ChangeStock();
            window.Show();
            window.Closed += Window_Closed;
            window.Owner = this;
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            Update();
        }
        private void Update()
        {
            foreach (var entity in db.ChangeTracker.Entries())
            {
                entity.Reload();
            }
            data.Items.Clear();
            foreach(var i in Model.Data.GetStocks(db))
                data.Items.Add(i);
        }
        private void Show(object sender, RoutedEventArgs e)
        {
            Model.Data.StocksId = (data.SelectedItem as Model.Stock).StockId;
            var window = new ShowEmp();
            window.Show();
            window.Owner = this;
        }
    }
}
