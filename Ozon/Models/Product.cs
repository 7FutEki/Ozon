using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Ozon.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Options { get; set; }
        [NotMapped] public BitmapImage QrCode { get; set; }

        public Product(Guid id, string name, double price, string options)
        {
            Id = id;
            Name = name;
            Price = price;
            Options = options;
            QrCode = QRCodeGenerator.GenerateQrCode(name, options, price);
        }


    }
}
