using CRUD_Inventory.Model;
using System;
using System.Windows;
namespace CRUD_Inventory
{
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
