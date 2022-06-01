using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CRUD_Inventory
{
    /// <summary>
    /// Логика взаимодействия для AddOut.xaml
    /// </summary>
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
