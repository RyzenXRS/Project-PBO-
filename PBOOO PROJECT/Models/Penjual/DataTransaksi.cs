using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBOOO_PROJECT.Models.Penjual
{
    internal class DataTransaksi
    {
        public int id_transaksi_maggot { get; set; }
        public string nama_pembeli { get; set; }
        public string jenis_ewallet { get; set; }  // bisa null
        public string nomor_ewallet { get; set; }  // bisa null
        public DateTime tanggal { get; set; }
        public string status { get; set; }
        public decimal total_harga_keseluruhan { get; set; }
    }
}
