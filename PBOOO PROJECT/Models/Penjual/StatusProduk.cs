using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBOOO_PROJECT.Models.Penjual
{
    public enum TransaksiStatus
    {
        dikirim,
        diterima,
        dibatalkan
    }
    internal class StatusProduk
    {
        public int id_transaksi_maggot { get; set; }
        public string jenis_maggot { get; set; }
        public string tanggal { get; set; }
        public TransaksiStatus Status { get; set; }
        public int id_penjual { get; set; }
        public int id_maggot { get; set; }
        public int jumlah_kg { get; set; }
        public string nama_pembeli { get; set; }   
        public string nomor_ewallet { get; set; }
        public int total_harga { get; set; }
    }
}
