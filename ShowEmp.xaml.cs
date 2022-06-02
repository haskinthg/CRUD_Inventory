using System.Windows;
namespace CRUD_Inventory
{
    public partial class ShowEmp : Window
    {
        public ShowEmp()
        {
            InitializeComponent();
            Update();
        }
        Model.InventoryEntities db = new Model.InventoryEntities();
        private void Update()
        {
            data.Items.Clear();
            foreach (var i in Model.Data.GetEmployees(db))
                data.Items.Add(i);
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            Model.Data.RemoveEmployee(db, data.SelectedItem as Model.Employee);
            Update();
        }
    }
}
