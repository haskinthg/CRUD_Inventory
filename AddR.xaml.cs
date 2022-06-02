using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
namespace CRUD_Inventory
{
    public partial class AddR : Window
    {
        public AddR()
        {
            InitializeComponent();
        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var db = new Model.InventoryEntities();
                var p = Model.Data.FingProduct(db, Model.Data.ProductId);
                p.rost = int.Parse(count.Text);
                p.dif = p.nost - p.rost;
                db.SaveChanges();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка! Введите все данные!");
            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
