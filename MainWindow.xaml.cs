using CRUD_Inventory.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRUD_Inventory
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogInClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var db = new InventoryEntities();
                if (id.Text != "" && password.Password != "")
                {
                    if ((password.Password == Data.LogIn(db, int.Parse(id.Text))))
                    {
                        if (Data.FindEmployee(db, int.Parse(id.Text)) != null)
                        {
                            var window = new ProductsWindow();
                            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                            window.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неправильный логин или пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Введите логин или пароль");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
            password.Clear();
            id.Clear();
            this.Close();
        }
        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            var window = new Register();
            window.Show();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
