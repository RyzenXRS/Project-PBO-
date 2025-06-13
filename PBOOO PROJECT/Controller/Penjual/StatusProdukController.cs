using Npgsql;
using PBOOO_PROJECT.Models.Penjual;
//using PBOOO_PROJECT.Models.Pembeli;
using PBOOO_PROJECT.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PBOOO_PROJECT.Controller.Penjual
{
    internal class StatusProdukController
    {
        private int _userId;
        public List<StatusProduk> statusProduk = new List<StatusProduk>();

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public void Read()
        {
            string query = @"SELECT t.id_transaksi_maggot, p.nama_penjual, m.jenis_maggot, t.jumlah_kg, m.harga_per_kg,(t.jumlah_kg * m.harga_per_kg) AS total_harga, t.status, b.nama_pembeli
                            FROM transaksi_maggot t
                            JOIN penjual p ON p.id_penjual = p.id_penjual
                            JOIN maggot m ON t.id_maggot = m.id_maggot
                            JOIN pembeli b ON b.id_pembeli = b.id_pembeli
                            WHERE p.id_penjual = @id_penjual
                            ORDER BY t.id_transaksi_maggot ASC;";

            using (var db = new DBConnection())
            {
                db.Open();
                using (NpgsqlCommand data = new NpgsqlCommand(query, db.Connection))
                {
                    data.Parameters.AddWithValue("@userId", _userId);
                    NpgsqlDataReader reader = data.ExecuteReader();
                    statusProduk.Clear();
                    while (reader.Read())
                    {
                        StatusProduk statproduk = new StatusProduk();
                        statproduk.id_transaksi_maggot = (int)reader["id_transaksi_maggot"];
                        statproduk.nama_pembeli = (string)reader["nama_pembeli"];
                        statproduk.nomor_ewallet = (string)reader["nomor_ewallet"];
                        statproduk.tanggal = ((DateTime)reader["tanggal"]).ToString("yyyy-MM-dd");
                        statproduk.Status = Enum.Parse<TransaksiStatus>(reader["status"].ToString(), true);
                        statproduk.total_harga = Convert.ToInt32(reader["total_harga"]);
                    }
                }
            }
        }
        public void UpdateStatusTransaksi(int id_transaksi, TransaksiStatus status)
        {
            string query = @"UPDATE transaksi_maggot SET status = @status WHERE id_transaksi_maggot = @id_transaksi";

            using (var db = new DBConnection())
            {
                db.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, db.Connection))
                {
                    cmd.Parameters.AddWithValue("@status", NpgsqlTypes.NpgsqlDbType.Text, status.ToString()); // menyimpan sesuai enum
                    cmd.Parameters.AddWithValue("@id_transaksi", id_transaksi);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"Status transaksi berhasil diupdate menjadi {status}.", "Edit Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        public List<StatusDetail> GetTransaksiMaggotDetails(int id_transaksi_maggot)
        {
            string query = @"SELECT m.jenis_maggot, dt.jumlah_kg, m.harga_per_kg, (dt.jumlah_kg * m.harga_per_kg) AS total_harga
                     FROM detail_transaksi_maggot dt
                     JOIN maggot m ON dt.id_maggot = m.id_maggot
                     WHERE dt.id_transaksi_maggot = @id_transaksi_maggot";

            List<StatusDetail> details = new List<StatusDetail>();

            using (var db = new DBConnection()) // sesuai controller lu
            {
                db.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, db.Connection))
                {
                    cmd.Parameters.AddWithValue("@id_transaksi_maggot", id_transaksi_maggot);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        StatusDetail detail = new StatusDetail()
                        {
                            jenis_maggot = (string)reader["jenis_maggot"].ToString(),
                            jumlah_kg = (int)reader["jumlah_kg"],
                            harga_per_kg = (int)reader["harga_per_kg"],
                            total_harga = (int)reader["total_harga"]
                        };
                        details.Add(detail);
                    }
                }
            }
            return details;
        }
    }
}
