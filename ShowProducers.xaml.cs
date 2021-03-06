using System.Windows;
namespace CRUD_Inventory
{
    public partial class ShowProducers : Window
    {
        public ShowProducers()
        {
            InitializeComponent();
            Update();
        }
        Model.InventoryEntities db = new Model.InventoryEntities();
        private void Update()
        {
            data.Items.Clear();
            foreach (var i in Model.Data.GetProducers(db))
                data.Items.Add(i);
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            Model.Data.RemoveProducer(db, data.SelectedItem as Model.Producer);
            Update();
        }
    }
}
