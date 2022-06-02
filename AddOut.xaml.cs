using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
namespace CRUD_Inventory
{
    public partial class AddOut : Window
    {
        public AddOut()
        {
            InitializeComponent();
        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var i = new Model.OutProduct
                {
                    ProductId = Model.Data.ProductId,
                    OutDate = date.SelectedDate.Value.Date,
                    OutCount = int.Parse(count.Text)
                };
                var db = new Model.InventoryEntities();
                Model.Data.AddOut(db, i);
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
