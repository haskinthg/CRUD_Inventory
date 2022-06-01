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
    /// Логика взаимодействия для ShowProducers.xaml
    /// </summary>
    public partial class ShowProducers : Window
    {
        public ShowProducers()
        {
            InitializeComponent();
            Update();
        }
        Model.InventoryEntities db = new Model.InventoryEntities();
        private void Update()
        {
            data.Items.Clear();
            foreach(var i in Model.Data.GetProducers(db))
                data.Items.Add(i);
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            Model.Data.RemoveProducer(db, data.SelectedItem as Model.Producer);
        }
    }
}
