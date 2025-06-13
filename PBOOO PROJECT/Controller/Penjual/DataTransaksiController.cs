using Npgsql;
using PBOOO_PROJECT.Models.Penjual;
using PBOOO_PROJECT.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBOOO_PROJECT.Controller.Penjual
{
    internal class DataTransaksiContoller
    {
        private int _userId;
        public List<DataTransaksi> Listdatatransaksi = new List<DataTransaksi>();

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public void Read()
        {
            string query = @"SELECT  t.id_transaksi_maggot,pb.nama_pembeli,ew.jenis_ewallet,ew.nomor_ewallet,t.tanggal AS tanggal_transaksi,t.status,SUM(t.jumlah_kg * m.harga_per_kg) AS total_harga_keseluruhan
                            FROM penjual pj
                            JOIN maggot m ON m.id_penjual = pj.id_penjual
                            JOIN transaksi_maggot t ON t.id_maggot = m.id_maggot
                            LEFT JOIN detail_transaksi_maggot dt  ON dt.id_transaksi_maggot = t.id_transaksi_maggot AND dt.id_maggot   = m.id_maggot
                            JOIN pembeli pb ON pb.id_pembeli = t.id_pembeli_maggot
                            LEFT JOIN pembayaran_ewallet ew ON ew.id_ewallet = t.id_ewallet
                            WHERE pj.id_penjual = @userId
                            GROUP BY t.id_transaksi_maggot,pb.nama_pembeli,ew.jenis_ewallet,ew.nomor_ewallet,t.tanggal,t.status
                            ORDER BY t.tanggal DESC";

            using (var db = new DBConnection())
            {
                db.Open();
                using (NpgsqlCommand data = new NpgsqlCommand(query, db.Connection))
                {
                    data.Parameters.AddWithValue("@userId", _userId);
                    NpgsqlDataReader reader = data.ExecuteReader();
                    Listdatatransaksi.Clear();
                    while (reader.Read())
                    {
                        DataTransaksi dataTransakasi = new DataTransaksi();
                        dataTransakasi.id_transaksi_maggot = (int)reader["id_transaksi_maggot"];
                        dataTransakasi.nama_pembeli = (string)reader["nama_pembeli"];
                        dataTransakasi.jenis_ewallet = (string)reader["jenis_ewallet"];
                        dataTransakasi.nomor_ewallet = (string)reader["nomor_ewallet"];
                        dataTransakasi.tanggal = (DateTime)reader["tanggal_transaksi"];
                        dataTransakasi.status = (string)reader["status"];
                        dataTransakasi.total_harga_keseluruhan = (long)(decimal)reader["total_harga_keseluruhan"];
                        Listdatatransaksi.Add(dataTransakasi);
                    }
                }
            }
        }
        public List<DataTransaksiDT> GetDetailPeminjamanDT(int id_transaksi)
        {
            string query = @"SELECT m.jenis_maggot, t.jumlah_kg, m.harga_per_kg, t.jumlah_kg * m.harga_per_kg AS total_harga
                            FROM detail_transaksi_maggot dt
                            JOIN maggot m ON m.id_maggot = dt.id_maggot
                            JOIN transaksi_maggot t ON t.id_transaksi_maggot = dt.id_transaksi_maggot
                            WHERE dt.id_transaksi_maggot = @id_transaksi;";
            List<DataTransaksiDT> details = new List<DataTransaksiDT>();

            using (var db = new DBConnection())
            {
                db.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, db.Connection))
                {
                    cmd.Parameters.AddWithValue("@id_transaksi", id_transaksi);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DataTransaksiDT detail = new DataTransaksiDT
                        {
                            jenis_maggot = reader.GetString(reader.GetOrdinal("jenis_maggot")),
                            jumlah_kg = reader.GetInt32(reader.GetOrdinal("jumlah_kg")),
                            harga_per_kg = reader.GetDecimal(reader.GetOrdinal("harga_per_kg")),
                            total_harga = reader.GetDecimal(reader.GetOrdinal("total_harga"))
                        };
                        details.Add(detail);
                    }
                }
            }
            return details;
        }
    }
}
