﻿using System;
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
    /// Логика взаимодействия для AddProducer.xaml
    /// </summary>
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
    }
}
