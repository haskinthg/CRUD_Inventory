using System.Windows;
namespace CRUD_Inventory
{
    public partial class AddProduct : Window
    {
        public AddProduct()
        {
            InitializeComponent();
            foreach(var i in Model.Data.GetProducers(db))
                prod.Items.Add(i);
        }
        Model.InventoryEntities db = new Model.InventoryEntities();
        private void AddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var s = new Model.Product
                {
                    PName = name.Text,
                    PCountry = country.Text,
                    PGroup = group.Text,
                    ProducerId = (prod.SelectedItem as Model.Producer).ProducerId,
                    PUnit = eden.Text
                };
                Model.Data.AddProduct(db, s);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка! Введите все данные!");
            }
        }
    }
}
