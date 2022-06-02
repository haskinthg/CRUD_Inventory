using CRUD_Inventory.Model;
using System.Windows;
namespace CRUD_Inventory
{
    public partial class ChangeProduct : Window
    {
        public ChangeProduct()
        {
            InitializeComponent();
            foreach (var i in Model.Data.GetProducers(db))
                prod.Items.Add(i);
        }
        InventoryEntities db = new InventoryEntities();
        private void ChangeClick(object sender, RoutedEventArgs e)
        {
            var p = Data.FingProduct(db, Data.ProductId);
            if(eden.Text!="") p.PUnit = eden.Text;
            if(name.Text!="") p.PName = name.Text;
            if(group.Text!="") p.PGroup = group.Text;
            if(country.Text!="") p.PCountry = country.Text;
            db.SaveChanges();
            Close();
        }
    }
}
