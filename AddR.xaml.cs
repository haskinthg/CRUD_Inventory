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
    /// Логика взаимодействия для AddR.xaml
    /// </summary>
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
    }
}
