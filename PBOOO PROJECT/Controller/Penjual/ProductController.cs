using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBOOO_PROJECT.Models.Penjual;
using PBOOO_PROJECT.Tools;

namespace PBOOO_PROJECT.Controller.Penjual
{
    internal class ProductController
    {
        private int _userId;
        public List<ProductContext> ListProduct = new List<ProductContext>();

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        public void Read()
        {
            string query = string.Format(@"SELECT row_number() OVER () AS nomor, m.id_maggot, m.jenis_maggot, m.harga_per_kg, s.jumlah_kg AS stok, s.status, p.id_penjual, p.nama_penjual
                                           FROM maggot m
                                           JOIN stok_maggot s ON m.id_maggot = s.id_maggot
                                           JOIN penjual p ON m.id_penjual = p.id_penjual
                                           WHERE m.id_penjual = @userId
                                           ORDER BY m.id_maggot ASC;");
            using (var db = new DBConnection())
            {
                db.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, db.Connection))
                {
                    cmd.Parameters.AddWithValue("@userId", _userId);
                    //cmd.CommandText = query;
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    ListProduct.Clear();
                    while (reader.Read())
                    {
                        ProductContext product = new ProductContext();
                        product.id_maggot = Convert.ToInt32(reader["id_maggot"]);
                        product.jenis_maggot = reader["jenis_maggot"].ToString();
                        product.harga_per_kg = Convert.ToDecimal(reader["harga_per_kg"]);
                        product.stok = Convert.ToDecimal(reader["stok"]);
                        product.status = reader["status"].ToString();
                        product.id_penjual = Convert.ToInt32(reader["id_penjual"]);
                        product.nama_penjual = reader["nama_penjual"].ToString();
                        ListProduct.Add(product);
                    }
                }
            }
        }
        public void Tambah(string Namakategori, string stok)
        {

            //MessageBox.Show($"User ID: {_userId}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string cekQuery = "SELECT COUNT(*) FROM maggot WHERE jenis_maggot = @jenis_maggot";
            string insertQuery = "INSERT INTO maggot (jenis_maggot,id_penjual,status) VALUES (@jenis_maggot,@userId,@status)";

            try
            {
                using (var db = new DBConnection())
                {
                    db.Open();
                    using (NpgsqlCommand cmdcek = new NpgsqlCommand(cekQuery, db.Connection))
                    {

                        cmdcek.Parameters.AddWithValue("@jenis_maggot", Namakategori.Trim());

                        int count = Convert.ToInt32(cmdcek.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Nama Kategori sudah ada", "Insert Data",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                    }
                    using (NpgsqlCommand cmd = new NpgsqlCommand(insertQuery, db.Connection))
                    {

                        cmd.Parameters.AddWithValue("@jenis_maggot", Namakategori.Trim());
                        cmd.Parameters.AddWithValue("@userId", _userId);
                        cmd.Parameters.AddWithValue("@stok", stok);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil ditambah", "Insert Data",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Optional: Update DataGridView if it exists
                        }
                        else
                        {
                            MessageBox.Show("Data gagal diubah", "Insert Data",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Edit(int idmaggot, string namaproduk, string status)
        {
            if (string.IsNullOrEmpty(namaproduk.Trim()))
            {
                MessageBox.Show("Nama Produk tidak boleh kosong", "Edit Data",
                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string cekQuery = "SELECT COUNT(*) FROM maggot WHERE jenis_maggot = @jenis_maggot AND id_maggot != @id";
            string updateQuery = "UPDATE maggot SET jenis_maggot = @jenis_maggot, status = @status WHERE id_maggot = @id";

            try
            {
                using (var db = new DBConnection())
                {
                    db.Open();
                    using (NpgsqlCommand checkCmd = new NpgsqlCommand(cekQuery, db.Connection))
                    {
                        checkCmd.Parameters.AddWithValue("@jenis_produk", namaproduk.Trim());
                        checkCmd.Parameters.AddWithValue("@id", idmaggot);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Nama Kategori sudah ada", "Edit Data",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    using (NpgsqlCommand cmd = new NpgsqlCommand(updateQuery, db.Connection))
                    {
                        cmd.Parameters.AddWithValue("@jenis_produk", namaproduk.Trim());
                        cmd.Parameters.AddWithValue("@id", idmaggot);
                        cmd.Parameters.AddWithValue("@status", status);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil diubah", "Edit Data",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Optional: Update DataGridView if it exists
                        }
                        else
                        {
                            MessageBox.Show("Data gagal diubah", "Edit Data",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
