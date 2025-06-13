using Npgsql;
using PBOOO_PROJECT.Controller.Penjual;
using PBOOO_PROJECT.Models.Pembeli;
using PBOOO_PROJECT.Models.Penjual;
using PBOOO_PROJECT.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PBOOO_PROJECT.View.Pembeli
{
    public partial class UCTransactionsPembeli : UserControl
    {

        private int _userId;

        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;

            }
        }
        public UCTransactionsPembeli()
        {
            InitializeComponent();
            itemPanel.Controls.Clear();
            LoadProducts();
        }

        private void UCTransactionsPenyewa_Load(object sender, EventArgs e)
        {
            datagridTransaction.BorderStyle = BorderStyle.FixedSingle;
        }

        private void AddItems(string id, string jenis, string harga, string stok, string idPenjual)
        {
            if (itemPanel == null || datagridTransaction == null)
            {
                throw new InvalidOperationException("itemPanel or datagridTransaction is not initialized.");
            }

            var w = new UCItemMaggot()
            {
                id_maggot = int.Parse(id),
                id_penjual = int.Parse(idPenjual),
                jenis_maggot = jenis,
                harga_per_kg = decimal.Parse(harga),
                stok_kg = int.Parse(stok)
            };
            itemPanel.Controls.Add(w);

            w.onSelect += (ss, ee) =>
            {
                var wdg = (UCItemMaggot)ss;

                foreach (DataGridViewRow item in datagridTransaction.Rows)
                {
                    if (item.Cells["dgvId"].Value != null && Convert.ToInt32(item.Cells["dgvId"].Value) == wdg.id_maggot)
                    {
                        if (item.Cells["dgvQty"].Value != null && item.Cells["dgvPrice"].Value != null)
                        {
                            item.Cells["dgvQty"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) + 1;
                            item.Cells["dgvAmount"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) * Convert.ToDouble(item.Cells["dgvPrice"].Value.ToString());
                            GetTotal();
                            return;
                        }
                    }
                }

                datagridTransaction.Rows.Add(new object[] { 0, wdg.id_maggot, wdg.jenis_maggot, 1, wdg.harga_per_kg, wdg.harga_per_kg});
                GetTotal();
            };
        }

        private void GetTotal()
        {
            double tot = 0;

            foreach (DataGridViewRow item in datagridTransaction.Rows)
            {
                if (item.Cells["dgvQty"].Value != null && item.Cells["dgvPrice"].Value != null)
                {
                    //tot += double.Parse(item.Cells["dgvAmount"].Value.ToString());
                    int qty = Convert.ToInt32(item.Cells["dgvQty"].Value);
                    double price = Convert.ToDouble(item.Cells["dgvPrice"].Value);                    tot += qty * price;
                }
            }

            lblTotal.Text = $"Rp {tot:N0}";
        }

        private void LoadProducts()
        {

            string query = @"SELECT m.id_maggot,m.jenis_maggot,m.harga_per_kg,COALESCE(sm.jumlah_kg, 0) AS stok_kg,m.id_penjual
                            FROM maggot m
                            LEFT JOIN stok_maggot sm ON sm.id_maggot = m.id_maggot
                            WHERE COALESCE(sm.jumlah_kg, 0) > 0";
            using (var db = new DBConnection())
            {
                db.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, db.Connection))
                {
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        foreach (DataRow item in dt.Rows)
                        {
                            AddItems(item["id_maggot"].ToString(), item["jenis_maggot"].ToString(), item["harga_per_kg"].ToString(),
                                item["stok_kg"].ToString(), item["id_penjual"].ToString());
                        }
                    }
                }
            }
        }

        private void datagridTransaction_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < datagridTransaction.Rows.Count; i++)
            {
                datagridTransaction.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxEWallet.Text.Trim()) || string.IsNullOrEmpty(boxNoEWallet.Text.Trim()))
            {
                MessageBox.Show("Nomor e-wallet atau jenis e-wallet harus ada", "Tambah Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (datagridTransaction.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada item yang ditambahkan ke transaksi.", "Transaksi Gagal",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            InsertTransaction();
        }

        public void InsertTransaction()
        {
            string conStr = "Server=localhost;Port=5432;User Id=postgres;Password=321;Database=MaggotPBO;CommandTimeout=10";
            using (NpgsqlConnection conn = new NpgsqlConnection(conStr))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        DialogResult result = MessageBox.Show("Lanjutkan transaksi pembelian maggot?", "Konfirmasi",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            string insertPembayaranEwalletQuery = @"
                        INSERT INTO pembayaran_ewallet (nomor_ewallet, jenis_ewallet)
                        VALUES (@nomer_ewallet, @jenis_ewallet)
                        RETURNING id_ewallet";

                            int idEwallet;
                            using (var cmd = new NpgsqlCommand(insertPembayaranEwalletQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@nomor_ewallet", boxNoEWallet.Text.Trim());
                                cmd.Parameters.AddWithValue("@jenis_ewallet", comboBoxEWallet.Text.Trim());
                                idEwallet = (int)cmd.ExecuteScalar();
                            }


                            string insertTransaksi = @"INSERT INTO transaksi_maggot (id_pembeli_maggot, id_ewallet, id_maggot, jumlah_kg, status, tanggal)
                                                       VALUES (@idPembeli, @idEwallet, @idMaggot, @jumlahKg, @status, @tanggal)
                                                        RETURNING id_transaksi_maggot";
                            int idTransaksi;
                            using (var cmd = new NpgsqlCommand(insertTransaksi, conn))
                            {
                                // Ambil baris pertama untuk ambil id_maggot
                                var row = datagridTransaction.Rows[0];
                                cmd.Parameters.AddWithValue("@idPembeli", _userId);
                                cmd.Parameters.AddWithValue("@idEwallet", idEwallet);
                                cmd.Parameters.AddWithValue("@idMaggot", Convert.ToInt32(row.Cells["dgvId"].Value));
                                cmd.Parameters.AddWithValue("@jumlahKg", Convert.ToInt32(row.Cells["dgvQty"].Value));
                                cmd.Parameters.AddWithValue("@status", "dikirim");
                                cmd.Parameters.AddWithValue("@tanggal", DateTime.Now);
                                idTransaksi = (int)cmd.ExecuteScalar();
                            }
                            string insertDetail = @"INSERT INTO detail_transaksi_maggot (id_transaksi_maggot, id_maggot, jumlah_kg)
                                                    VALUES (@idTransaksi, @idMaggot, @jumlahKg)";
                            foreach (DataGridViewRow row in datagridTransaction.Rows)
                            {
                                if (row.Cells["dgvId"].Value != null)
                                {
                                    using (var cmd = new NpgsqlCommand(insertDetail, conn))
                                    {
                                        cmd.Parameters.AddWithValue("@idTransaksi", idTransaksi);
                                        cmd.Parameters.AddWithValue("@idMaggot", Convert.ToInt32(row.Cells["dgvId"].Value));
                                        cmd.Parameters.AddWithValue("@jumlahKg", Convert.ToInt32(row.Cells["dgvQty"].Value));
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            transaction.Commit();
                            clearAll();
                            MessageBox.Show("Transaksi Berhasil Ditambahkan", "Sukses");
                        }
                        else
                        {
                            MessageBox.Show("Transaction Cancelled", "Transaction",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error occurred: " + ex.Message);
                    }
                }
            }
        }

        public void clearAll()
        {
            datagridTransaction.Rows.Clear();
            boxNoEWallet.Text = string.Empty;
            comboBoxEWallet.SelectedIndex = -1;
            lblTotal.Text = string.Empty;
        }
        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            datagridTransaction.Rows.Clear();
            boxNoEWallet.Text = string.Empty;
            comboBoxEWallet.SelectedIndex = -1;
            lblTotal.Text = string.Empty;
        }

        private void guna2TextBoxRent_TextChanged(object sender, EventArgs e)
        {
            GetTotal();
        }

        private void itemPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
