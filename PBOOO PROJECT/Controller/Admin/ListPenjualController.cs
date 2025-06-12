using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBOOO_PROJECT.Tools;
using PBOOO_PROJECT.Models.Admin;

namespace PBOOO_PROJECT.Controller.Admin
{
    internal class ListPembeliController
    {
        public List<ListPembeliContext> ListPembeli = new List<ListPembeliContext>();


        public void Read()
        {
            string query = string.Format(@"select p.id_pembeli, p.nama_pembeli, p.alamat, p.no_telp, COUNT(tso.id_transaksi_sampah) AS jumlah_transaksi
                                           FROM pembeli p 
                                           JOIN transaksi_sampah_organik tso ON p.id_pembeli = tso.id_pembeli_sampah
                                           WHERE tso.status = 'diterima'
                                           GROUP BY p.id_pembeli, p.nama_pembeli, p.alamat, p.no_telp");
            using (var db = new DBConnection())
            {
                db.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, db.Connection))
                {
                    cmd.CommandText = query;
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    ListPembeli.Clear();
                    while (reader.Read())
                    {
                        ListPembeliContext listPembeli = new ListPembeliContext();
                        listPembeli.ID = (int)reader["id_pembeli"];
                        listPembeli.Nama_Pembeli = (string)reader["nama_pembeli"];
                        listPembeli.no_telp = (string)reader["no_telp"];
                        listPembeli.alamat_pembeli = (string)reader["alamat"]; ;
                        listPembeli.jumlah_pembeli = (long)reader["jumlah_transaksi"];
                        ListPembeli.Add(listPembeli);
                    }
                }
            }
        }
    }
}
