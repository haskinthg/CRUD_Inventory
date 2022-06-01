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
    /// Логика взаимодействия для AddIn.xaml
    /// </summary>
    public partial class AddIn : Window
    {
        public AddIn()
        {
            InitializeComponent();
        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            var o = new Model.InProduct
            {
                InDate = date.SelectedDate.Value.Date,
                InCount = int.Parse(count.Text)
            };
            var db = new Model.InventoryEntities();
            Model.Data.AddIn(db, o);
            this.Close();
        }
    }
}
