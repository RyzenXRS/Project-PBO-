using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBOOO_PROJECT.Models.Admin
{
    internal class ListPembeliContext
    {
        public int ID { get; set; }
        public string Nama_Pembeli { get; set; }
        public string no_telp { get; set; }
        public string alamat_pembeli { get; set; }
        public long jumlah_pembeli { get; set; }
    }
}
