using Npgsql;
using PBOOO_PROJECT.Models.Pembeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBOOO_PROJECT.Tools;
using PBOOO_PROJECT.Models.Penjual;
using static PBOOO_PROJECT.Models.Pembeli.HistoryDetailPy;

namespace PBOOO_PROJECT.Controller.Pembeli
{
    internal class HistoryController
    {
        private int _userId;
        public List<HistoryPy> ListHistory = new List<HistoryPy>();
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        public void Read()
        {
            string query = string.Format(@"SELECT t.id_transaksi_maggot,t.tanggal,t.status,COALESCE(ew.nomor_ewallet, '-') AS nomor_ewallet,COALESCE(ew.jenis_ewallet, '-') AS jenis_ewallet,SUM(m.harga_per_kg * t.jumlah_kg) AS total_harga_keseluruhan
                                        FROM transaksi_maggot t
                                        JOIN maggot m ON m.id_maggot = t.id_maggot
                                        LEFT JOIN pembayaran_ewallet ew ON ew.id_ewallet = t.id_ewallet
                                        WHERE t.id_pembeli_maggot = @userId
                                        GROUP BY t.id_transaksi_maggot, t.tanggal, t.status, ew.nomor_ewallet, ew.jenis_ewallet
                                        ORDER BY t.tanggal DESC;");
            using (var db = new DBConnection())
            {
                db.Open();
                using (NpgsqlCommand data = new NpgsqlCommand(query, db.Connection))
                {
                    data.Parameters.AddWithValue("@userId", _userId);
                    NpgsqlDataReader reader = data.ExecuteReader();
                    ListHistory.Clear();
                    while (reader.Read())
                    {
                        HistoryPy historyPy = new HistoryPy();
                        historyPy.id_transaksi_maggot = (int)reader["id_transaksi_maggot"];
                        historyPy.tanggal = ((DateTime)reader["tanggal"]).ToString("yyyy-MM-dd");
                        historyPy.status_transaksi = (string)reader["status"];
                        historyPy.nomor_ewallet = (string)reader["nomor_ewallet"];
                        historyPy.jenis_ewallet = (string)reader["jenis_ewallet"];
                        historyPy.total_harga_keseluruhan = (decimal)reader["total_harga_keseluruhan"];
                        ListHistory.Add(historyPy);
                    }
                }
            }
        }
        public List<HistoryDetailPy> GetDetailPeminjaman(int idTransaksi)
        {
            string query = @"SELECT m.jenis_maggot,t.jumlah_kg,m.harga_per_kg,t.jumlah_kg * m.harga_per_kg AS total_harga
                            FROM transaksi_maggot t
                            JOIN maggot m ON m.id_maggot = t.id_maggot
                            WHERE t.id_transaksi_maggot = @idTransaksi;";

            List<HistoryDetailPy> details = new List<HistoryDetailPy>();

            using (var db = new DBConnection())
            {
                db.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, db.Connection))
                {
                    cmd.Parameters.AddWithValue("@idTransaksi", idTransaksi);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        HistoryDetailPy detail = new HistoryDetailPy
                        {
                            jenis_maggot = (string)reader["jenis_maggot"],
                            jumlah_kg = (int)reader["jumlah_kg"],
                            harga_per_kg = (decimal)reader["harga_per_kg"],
                            total_harga = (decimal)reader["total_harga"]
                        };
                        details.Add(detail);
                    }
                }
            }
            return details;
        }
    }
}
