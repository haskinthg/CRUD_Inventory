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
    /// Логика взаимодействия для Results.xaml
    /// </summary>
    public partial class Results : Window
    {
        public Results()
        {
            InitializeComponent();
            Update();
        }
        InventoryEntities db = new InventoryEntities();
        private void Update()
        {
            foreach (var entity in db.ChangeTracker.Entries())
            {
                entity.Reload();
            }
            data.Items.Clear();
            foreach (var i in Data.GetProducts(db))
            {
                i.nost = Data.GetNost(db, i.ProductId);
                i.dif = i.nost - i.rost;
                data.Items.Add(i);
            }
            db.SaveChanges();
        }

        private void addr(object sender, RoutedEventArgs e)
        {
            var window = new AddR();
            window.Show();
            window.Closed += Window_Closed;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Update();
        }
    }
}
