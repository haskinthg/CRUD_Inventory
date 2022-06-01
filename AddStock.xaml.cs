using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для AddStock.xaml
    /// </summary>
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
