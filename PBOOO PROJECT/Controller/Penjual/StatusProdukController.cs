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
            string query = @"SELECT t.id_transaksi_maggot,t.tanggal,p.nama_penjual,m.jenis_maggot,t.jumlah_kg,m.harga_per_kg,t.jumlah_kg * m.harga_per_kg AS total_harga,t.status,b.nama_pembeli,w.nomor_ewallet
                             FROM transaksi_maggot AS t
                             JOIN maggot  m ON m.id_maggot = t.id_maggot
                             JOIN penjual p ON p.id_penjual = m.id_penjual
                             LEFT JOIN pembayaran_ewallet w ON w.id_ewallet = t.id_ewallet
                             JOIN pembeli b ON b.id_pembeli = t.id_pembeli_maggot
                             WHERE p.id_penjual = @id_penjual    
                             ORDER BY t.id_transaksi_maggot;";

            using (var db = new DBConnection())
            {
                db.Open();
                using (var cmd = new NpgsqlCommand(query, db.Connection))
                {
                    cmd.Parameters.AddWithValue("@id_penjual", UserId);
                    using var reader = cmd.ExecuteReader();
                    statusProduk.Clear();

                    while (reader.Read())
                    {
                        StatusProduk statproduk = new StatusProduk
                        {
                            id_transaksi_maggot = reader.GetInt32(reader.GetOrdinal("id_transaksi_maggot")),
                            nama_pembeli = reader.GetString(reader.GetOrdinal("nama_pembeli")),
                            nomor_ewallet = reader.IsDBNull(reader.GetOrdinal("nomor_ewallet"))
                                            ? "-"
                                            : reader.GetString(reader.GetOrdinal("nomor_ewallet")),
                            tanggal = reader.GetDateTime(reader.GetOrdinal("tanggal"))
                                             .ToString("yyyy-MM-dd"),
                            Status = Enum.Parse<TransaksiStatus>(
                                        reader.GetString(reader.GetOrdinal("status")), true),
                            total_harga = reader.GetInt32(reader.GetOrdinal("total_harga"))
                        };
                        string statusStr = reader.GetString(reader.GetOrdinal("status")).ToLower();

                        switch (statusStr)
                        {
                            case "diproses":
                            case "dikirim":
                                statproduk.Status = TransaksiStatus.dikirim;
                                break;
                            case "diterima":
                                statproduk.Status = TransaksiStatus.diterima;
                                break;
                            case "dibatalkan":
                                statproduk.Status = TransaksiStatus.dibatalkan;
                                break;
                            default:
                                statproduk.Status = TransaksiStatus.dikirim; // fallback
                                break;
                        }
                        statusProduk.Add(statproduk);
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
            string query = @"SELECT m.jenis_maggot,t.jumlah_kg,m.harga_per_kg,t.jumlah_kg * m.harga_per_kg AS total_harga
                             FROM detail_transaksi_maggot AS dt
                             JOIN transaksi_maggot      AS t ON t.id_transaksi_maggot = dt.id_transaksi_maggot
                             JOIN maggot                AS m ON m.id_maggot           = dt.id_maggot
                             WHERE dt.id_transaksi_maggot = @id_transaksi_maggot;";

            var details = new List<StatusDetail>();

            using (var db = new DBConnection())
            {
                db.Open();
                using (var cmd = new NpgsqlCommand(query, db.Connection))
                {
                    cmd.Parameters.AddWithValue("@id_transaksi_maggot", id_transaksi_maggot);
                    using var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        details.Add(new StatusDetail
                        {
                            jenis_maggot = reader.GetString(reader.GetOrdinal("jenis_maggot")),
                            jumlah_kg = reader.GetInt32(reader.GetOrdinal("jumlah_kg")),
                            harga_per_kg = reader.GetDecimal(reader.GetOrdinal("harga_per_kg")),
                            total_harga = reader.GetDecimal(reader.GetOrdinal("total_harga"))
                        });
                    }
                }
            }
            return details;
        }
    }
}

