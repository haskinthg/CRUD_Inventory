using System.Windows;
namespace CRUD_Inventory
{
    public partial class AddStock : Window
    {
        public AddStock()
        {
            InitializeComponent();
        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var s = new Model.Stock
                {
                    Adress = adress.Text,
                    SCity = city.Text,
                    SName = name.Text
                };
                Model.InventoryEntities db = new Model.InventoryEntities();
                Model.Data.AddStocks(db, s);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка! Введите все данные!");
            }
        }
    }
}
