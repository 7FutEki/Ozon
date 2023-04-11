using Microsoft.EntityFrameworkCore;
using Ozon.Models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace Ozon.Forms
{
    /// <summary>
    /// Логика взаимодействия для Window_Add.xaml
    /// </summary>
    public partial class Window_Add : Window
    {
       
        public Product Product { get; set; }
        public Window_Add()
        {
            InitializeComponent();
            Product = new Product();
            DataContext = Product;
            Product.Id = Guid.NewGuid();
        }
        


        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            ApplicationContext db = new ApplicationContext();

            Product product = new Product
            {
                Name = Product.Name,
                Price = Product.Price,
                Options = Product.Options,
                Id = Guid.NewGuid(),

            };
            db.Database.Migrate();
            db.Products.Add(product);
            db.SaveChanges();
            this.Close();

        }

        private void btn_madeQr_Click(object sender, RoutedEventArgs e)
        {
            string str = "Уникальный идентификатор: " + tb_id.Text + "\n" + "Название товара: " + tb_name.Text + "\n" + "Цена товара: " + tb_price.Text + " рублей" + "\n" + "Описание товара: " + tb_opt.Text;
            QRCodeGenerator qrGenerator = new();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(str, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qr = qrCode.GetGraphic(150);
            qr_im.Source = Convert(qr);
            Product.QrCode = Convert(qr);

        }
        public BitmapImage Convert(Bitmap src)
        {
            MemoryStream ms = new MemoryStream();
            ((System.Drawing.Bitmap)src).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }
        
    }
}
