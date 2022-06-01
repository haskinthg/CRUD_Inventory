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
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
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
