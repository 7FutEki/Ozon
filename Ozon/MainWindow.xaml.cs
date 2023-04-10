using Microsoft.Data.Sqlite;
using Ozon.Forms;
using Ozon.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ozon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        ApplicationContext db;
        public ObservableCollection<Product> ListProduct { get; set; }
        public Product Product { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ListProduct = new();
            DataContext = this;
            db = new ApplicationContext();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            
            
            Forms.Window_Add add = new Forms.Window_Add();
            add.ShowDialog();
            ListProduct.Add(add.Product);
        }

        private void btn_dlt_Click(object sender, RoutedEventArgs e)
        {
            if (Product == null)
            {
                return;
            }
            Window_Add window = new Window_Add();
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы уверены?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                ListProduct.Remove(window.Product);
            }
        }

        private void btn_edt_Click(object sender, RoutedEventArgs e)
        {
            if (Product == null)
            {
                return;
            }
            Window_Add window = new Window_Add();
            window.ShowDialog();
        }
    }
}
