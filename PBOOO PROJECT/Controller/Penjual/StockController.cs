using Npgsql;
using PBOOO_PROJECT.Models.Penjual;
using PBOOO_PROJECT.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace PBOOO_PROJECT.Controller.Penjual
{
    internal class StockController
    {
        public int UserId { get; set; }
        public List<Stock> ListStock { get; private set; } = new List<Stock>();

        public void Read()
        {
            //try { // debug userId ygy
            //    if (UserId <= 0)
            //    {
            //        throw new InvalidOperationException("UserId belum diatur.");
            //    }
            //}
            //catch (InvalidOperationException ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
        
        string query = @"SELECT s.id_stok_maggot, m.jenis_maggot, m.harga_per_kg, s.jumlah_kg,s.status,s.deskripsi, p.nama_penjual,p.id_penjual
                             FROM stok_maggot s
                             JOIN maggot m ON s.id_maggot = m.id_maggot
                             JOIN penjual p ON m.id_penjual = p.id_penjual
                             WHERE p.id_penjual = @userId
                             ORDER BY s.id_stok_maggot DESC;";
            using (var db = new DBConnection())
            {
                db.Open();
                using (NpgsqlCommand data = new NpgsqlCommand(query, db.Connection))
                {
                    data.Parameters.AddWithValue("@userId", UserId);
                    NpgsqlDataReader reader = data.ExecuteReader();
                    ListStock.Clear();
                    while (reader.Read())
                    {
                        Stock stock = new Stock();
                        stock.id_stok_maggot = (int)reader["id_stok_maggot"];  // gunakan id stok karena itu ID utama di stok_maggot
                        stock.jenis_maggot = (string)reader["jenis_maggot"];
                        stock.harga_per_kg = Convert.ToInt32(reader["harga_per_kg"]);
                        stock.jumlah_kg = (int)(reader["jumlah_kg"]);
                        stock.status = (string)reader["status"];
                        stock.deskripsi = reader["deskripsi"] == DBNull.Value ? null : (string)reader["deskripsi"];
                        stock.nama_penjual = (string)reader["nama_penjual"];
                        stock.id_penjual = (int)(reader["id_penjual"]);
                        ListStock.Add(stock);
                    }
                }
            }
        }
        public void TambahProdukDanStok(Stock stock)
        {
            string cek = @"SELECT COUNT(*) FROM maggot WHERE jenis_maggot = @jenis_maggot AND id_penjual = @id_penjual;";
            string insertMaggot = @"INSERT INTO maggot (jenis_maggot, harga_per_kg, id_penjual)
                            VALUES (@jenis_maggot, @harga_per_kg, @id_penjual)
                            RETURNING id_maggot;";
            string insertStok = @"INSERT INTO stok_maggot (id_maggot, jumlah_kg, status, deskripsi, id_penjual, tanggal_update)
                          VALUES (@id_maggot, @jumlah_kg, @status, @deskripsi, @id_penjual, NOW());";

            using (var db = new DBConnection())
            {
                db.Open();

                // Cek duplikat
                using (var cekCmd = new NpgsqlCommand(cek, db.Connection))
                {
                    cekCmd.Parameters.AddWithValue("@jenis_maggot", stock.jenis_maggot);
                    cekCmd.Parameters.AddWithValue("@id_penjual", UserId);

                    int count = Convert.ToInt32(cekCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Nama maggot sudah digunakan.", "Tambah Produk", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                int newIdMaggot;
                // Insert ke tabel maggot
                using (var insertCmd = new NpgsqlCommand(insertMaggot, db.Connection))
                {
                    insertCmd.Parameters.AddWithValue("@jenis_maggot", stock.jenis_maggot);
                    insertCmd.Parameters.AddWithValue("@harga_per_kg", stock.harga_per_kg);
                    insertCmd.Parameters.AddWithValue("@id_penjual", UserId);

                    newIdMaggot = Convert.ToInt32(insertCmd.ExecuteScalar());
                }

                // Insert ke stok_maggot
                using (var stokCmd = new NpgsqlCommand(insertStok, db.Connection))
                {
                    stokCmd.Parameters.AddWithValue("@id_maggot", newIdMaggot);
                    stokCmd.Parameters.AddWithValue("@jumlah_kg", stock.jumlah_kg);
                    StatusStok statusEnum = Enum.Parse<StatusStok>(stock.status);
                    stokCmd.Parameters.AddWithValue("@status", statusEnum.ToString());
                    stokCmd.Parameters.AddWithValue("@deskripsi", stock.deskripsi);
                    stokCmd.Parameters.AddWithValue("@id_penjual", UserId);

                    stokCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Produk dan stok berhasil ditambahkan!", "Tambah", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void EditProduk(Stock stock)
        {
            string cek = @"SELECT COUNT(*) FROM maggot 
                   WHERE jenis_maggot = @jenis_maggot AND id_maggot != @id_maggot AND id_penjual = @id_penjual;";

            string updateMaggot = @"UPDATE maggot
                            SET jenis_maggot = @jenis_maggot,
                                harga_per_kg = @harga_per_kg
                            WHERE id_maggot = @id_maggot;";

            string updateStok = @"UPDATE stok_maggot
                                 SET status = @status::status_stok,
                                 deskripsi = @deskripsi,
                                 jumlah_kg = @jumlah_kg
                                 WHERE id_stok_maggot = @id_stok_maggot;";

            using (var db = new DBConnection())
            {
                db.Open();
                // Update ke tabel maggot
                using (var updateCmd = new NpgsqlCommand(updateMaggot, db.Connection))
                {
                    updateCmd.Parameters.AddWithValue("@jenis_maggot", stock.jenis_maggot);
                    updateCmd.Parameters.AddWithValue("@harga_per_kg", stock.harga_per_kg);
                    updateCmd.Parameters.AddWithValue("@id_maggot", stock.id_maggot);

                    updateCmd.ExecuteNonQuery();
                }

                // Update ke tabel stok_maggot
                using (var stokCmd = new NpgsqlCommand(updateStok, db.Connection))
                {
                    StatusStok statusEnum = Enum.Parse<StatusStok>(stock.status);
                    stokCmd.Parameters.AddWithValue("@status", statusEnum.ToString());
                    stokCmd.Parameters.AddWithValue("@deskripsi", stock.deskripsi);
                    stokCmd.Parameters.AddWithValue("@jumlah_kg", stock.jumlah_kg);
                    stokCmd.Parameters.AddWithValue("@id_stok_maggot", stock.id_stok_maggot);

                    stokCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Produk berhasil diperbarui.", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void TambahStokBaru(int id_maggot, int tambahanKg)
        {
            string insertStok = @"INSERT INTO stok_maggot (id_maggot, jumlah_kg, status, tanggal_update)
                           VALUES (@id_maggot, @jumlah_kg, @status::status_stok, NOW())";

            using (var db = new DBConnection()) // pastikan DBConnection punya Connection yang terbuka
            {
                db.Open();

                using (var cmd = new NpgsqlCommand(insertStok, db.Connection))
                {
                    cmd.Parameters.AddWithValue("@id_maggot", id_maggot);
                    cmd.Parameters.AddWithValue("@jumlah_kg", tambahanKg);
                    cmd.Parameters.AddWithValue("@status", StatusStok.tersedia.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
