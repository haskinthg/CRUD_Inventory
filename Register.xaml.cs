using System.Windows;
using CRUD_Inventory.Model;
namespace CRUD_Inventory
{
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var emp = new Employee
                {
                    StockId = Data.StocksId,
                    SFName = fname.Text,
                    SSName = sname.Text,
                    SLName = lname.Text,
                    Password = password.Text
                };
                InventoryEntities db = new InventoryEntities();
                Data.AddEmp(db, emp);
                MessageBox.Show($"Логин {emp.EmployeeId} \n Пароль - {emp.Password}");
            }
            catch
            {
                MessageBox.Show("Ошибка! Введите все данные!");
            }
        }
    }
}
