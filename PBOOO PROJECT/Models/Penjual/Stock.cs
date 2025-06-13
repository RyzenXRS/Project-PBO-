using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBOOO_PROJECT.Models.Penjual
{
    public class Stock
    {
        public int id_stok_maggot { get; set; }
        public int id_maggot { get; set; }
        public string jenis_maggot { get; set; }
        public int harga_per_kg { get; set; }
        public int jumlah_kg { get; set; }
        public string status { get; set; }
        public string nama_penjual { get; set; }
        public int id_penjual { get; set; }
        public string deskripsi { get; set; }
    }

}
