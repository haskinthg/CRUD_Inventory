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
    /// Логика взаимодействия для StockWindow.xaml
    /// </summary>
    public partial class StockWindow : Window
    {
        public StockWindow()
        {
            InitializeComponent();
            Update();
        }
        Model.InventoryEntities db = new Model.InventoryEntities();

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
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Update();
        }

        private void Update()
        {
            data.Items.Clear();
            foreach(var i in Model.Data.GetStocks(db))
                data.Items.Add(i);
        }

    }
}
