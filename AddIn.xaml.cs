using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
namespace CRUD_Inventory
{
    public partial class AddIn : Window
    {
        public AddIn()
        {
            InitializeComponent();
        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var o = new Model.InProduct
                {
                    ProductId = Model.Data.ProductId,
                    InDate = date.SelectedDate.Value.Date,
                    InCount = int.Parse(count.Text)
                };
                var db = new Model.InventoryEntities();
                Model.Data.AddIn(db, o);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка! Введите все данные!");
            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,.]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
