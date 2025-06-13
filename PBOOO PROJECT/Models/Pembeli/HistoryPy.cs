using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBOOO_PROJECT.Models.Pembeli
{
    internal class HistoryPy
    {
        public int id_transaksi_maggot { get; set; }
        public string tanggal { get; set; }
        public string status_transaksi { get; set; }
        public string nomor_ewallet { get; set; }
        public string jenis_ewallet { get; set; }
        public decimal total_harga_keseluruhan { get; set; }
    }
}
