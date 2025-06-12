using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using PBOOO_PROJECT.Models.Admin;
//using PBOOO_PROJECT.Models.penjual;
using PBOOO_PROJECT.Tools;

namespace PBOOO_PROJECT.View.Admin
{
    internal class ReadListController
    {
        public List<ReadListContext> ListOwner = new List<ReadListContext>();
        public void Read()
        {
            // ... kode lama tetap ada di bawah
            string query = string.Format(@"SELECT pj.id_penjual, pj.nama_penjual, pj.no_telp, pj.alamat,SUM(tm.jumlah_kg * m.harga_per_kg) AS total_revenue
                                           FROM penjual pj
                                           JOIN maggot m ON pj.id_penjual = m.id_penjual
                                           JOIN detail_transaksi_maggot dt ON m.id_maggot = dt.id_maggot
                                           JOIN transaksi_maggot tm ON dt.id_transaksi_maggot = tm.id_transaksi_maggot
                                           WHERE tm.status = 'diterima'
                                           GROUP BY pj.id_penjual, pj.nama_penjual, pj.no_telp, pj.alamat;");

            using (var db = new DBConnection())
            {
                db.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, db.Connection))
                {
                    cmd.CommandText = query;
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    ListOwner.Clear();
                    while (reader.Read())
                    {
                        ReadListContext listRenters = new ReadListContext();
                        long pendapatanFormat = Convert.ToInt64(reader["total_revenue"]);
                        listRenters.ID = (int)reader["id_penjual"];
                        listRenters.Nama_Penjual = (string)reader["nama_penjual"];
                        listRenters.No_telp = (string)reader["no_telp"];
                        listRenters.Alamat = (string)reader["alamat"];
                        listRenters.Pendapatan = $"Rp.{pendapatanFormat}";
                        ListOwner.Add(listRenters);
                    }
                }
            }
        }
    }
}

//readListController.Read();
