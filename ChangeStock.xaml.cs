using System.Windows;
using CRUD_Inventory.Model;
namespace CRUD_Inventory
{
    public partial class ChangeStock : Window
    {
        public ChangeStock()
        {
            InitializeComponent();
        }
        InventoryEntities db = new InventoryEntities();
        private void Click(object sender, RoutedEventArgs e)
        {
            var s = Data.FingStock(db, Data.StocksId);
            if (name.Text != "") s.SName = name.Text;
            if(city.Text !="") s.SCity = city.Text;
            if(adress.Text !="") s.Adress = adress.Text;
            db.SaveChanges();
            Close();
        }
    }
}
