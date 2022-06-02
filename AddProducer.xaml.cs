using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
namespace CRUD_Inventory
{
    public partial class AddProducer : Window
    {
        public AddProducer()
        {
            InitializeComponent();
        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var s = new Model.Producer
                {
                    PName = name.Text,
                    PAdress = adress.Text,
                    PPhone = phone.Text,
                    StockId = Model.Data.StocksId
                };
                var db = new Model.InventoryEntities();
                Model.Data.AddProducer(db, s);
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
