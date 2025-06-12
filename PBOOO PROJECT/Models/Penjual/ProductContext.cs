using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBOOO_PROJECT.Models.Penjual
{
    internal class ProductContext
    {
        public int id_maggot { get; set; }
        public string jenis_maggot { get; set; }
        public decimal harga_per_kg { get; set; }
        public decimal stok { get; set; }
        public string status { get; set; }
        public int id_penjual { get; set; }
        public string nama_penjual { get; set; }


    }
}
