using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using PBOOO_PROJECT.Controller.Penjual;
//using PBOOO_PROJECT.Controller.Pembeli;
using PBOOO_PROJECT.Models.Penjual;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PBOOO_PROJECT.View.Penjual
{
    public partial class UCStatusPenjual : UserControl
    {
        private int _userId;

        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                statusController.UserId = _userId;
                LoadDataGrid();
            }
        }

        int index;
        private int idMaggotSelected = -1;
        StatusProdukController statusController;

        public UCStatusPenjual()
        {
            statusController = new StatusProdukController();
            InitializeComponent();
        }

        private void LoadDataGrid()
        {
            statusController.Read();
            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Nama Pembeli", typeof(string));
            table.Columns.Add("Nomor E-wallet", typeof(string));
            table.Columns.Add("Tanggal Transaksi", typeof(string));
            table.Columns.Add("Status Transaksi", typeof(string));
            table.Columns.Add("Total Harga", typeof(int));

            foreach (var transaksi in statusController.statusProduk)
            {
                table.Rows.Add(transaksi.id_transaksi_maggot,
                                transaksi.nama_pembeli,
                                transaksi.nomor_ewallet,
                                transaksi.tanggal,
                                transaksi.Status,
                                transaksi.total_harga);
            }
            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1Clear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        public void ClearAll()
        {
            tb1.Text = string.Empty; // Nama Pembeli
            tb2.Text = string.Empty; // Nomor E-wallet
            tb3.Text = string.Empty; // Tanggal Transaksi
            tb4.Text = string.Empty; // Total Harga
            cbstatustransaksi.SelectedIndex = -1; // Combobox untuk status
        }

        private void button2edit_Click(object sender, EventArgs e)
        {
            if (idMaggotSelected == -1)
            {
                MessageBox.Show("Pilih transaksi maggot yang ingin diedit!", "Edit Data",
                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string status_transaksi_string = cbstatustransaksi.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(status_transaksi_string))
            {
                MessageBox.Show("Silakan pilih status terlebih dahulu.", "Edit Data",
                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parse the selected status string into the TransaksiStatus enum
            TransaksiStatus statusTransaksi;
            if (!Enum.TryParse(status_transaksi_string, out statusTransaksi))
            {
                MessageBox.Show("Status transaksi tidak valid.", "Edit Data",
                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Fix: Pass both required arguments to UpdateStatusTransaksi
            statusController.UpdateStatusTransaksi(idMaggotSelected, statusTransaksi);

            ClearAll();
            LoadDataGrid();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[index];
                idMaggotSelected = Convert.ToInt32(row.Cells[0].Value);
                tb1.Text = row.Cells[1].Value.ToString(); // Nama Pembeli
                tb2.Text = row.Cells[2].Value.ToString(); // Nomor E-Wallet
                tb4.Text = row.Cells[5].Value.ToString(); // Tanggal Transaksi
                tb3.Text = row.Cells[3].Value.ToString(); // Total Harga
                string status_transaksi = row.Cells[4].Value.ToString();

                cbstatustransaksi.SelectedItem = status_transaksi;

                // Mengunci field yang memang gak boleh diedit
                tb1.Enabled = false;
                tb2.Enabled = false;
                tb4.Enabled = false;
                tb3.Enabled = false;

                // Jika status = "Dikirim", comboBox gak boleh diubah
                if (cbstatustransaksi.Text == "Dikirim")
                {
                    cbstatustransaksi.Enabled = false;
                }
                else
                {
                    cbstatustransaksi.Enabled = true;
                }
            }
            dataGridView2.Visible = true;
            label3.Visible = true;

            var details = statusController.GetTransaksiMaggotDetails(idMaggotSelected);
            DataTable table2 = new DataTable();
            table2.Columns.Add("Jenis Maggot", typeof(string)); // sesuai field yang lu punya
            table2.Columns.Add("Jumlah (Kg)", typeof(int));
            table2.Columns.Add("Harga per Kg", typeof(int));
            table2.Columns.Add("Total", typeof(int));
            dataGridView2.DataSource = table2;

            foreach (var detail in details)
            {
                table2.Rows.Add(detail.jenis_maggot, detail.jumlah_kg, detail.harga_per_kg, detail.jumlah_kg * detail.harga_per_kg);
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void paneltopdashboard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void tb2_TextChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tb4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
