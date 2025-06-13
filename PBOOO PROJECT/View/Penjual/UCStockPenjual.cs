using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using PBOOO_PROJECT.Controller.Penjual;
using PBOOO_PROJECT.Models.Penjual;
using PBOOO_PROJECT.Tools;

namespace PBOOO_PROJECT.View.Penjual
{
    public partial class UCStockPenjual : UserControl
    {
        private int _userId;

        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                stockController.UserId = _userId;
            }
        }

        private int idMaggotSelected = -1;
        StockController stockController;

        public UCStockPenjual()
        {
            stockController = new StockController();
            InitializeComponent();
            // Contoh: set UserId ke 1
            DataMaggot();
        }

        public class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private Stock StockForm()
        {
            string status = guna2ComboBoxStatus.SelectedItem?.ToString();

            return new Stock
            {
                jenis_maggot = guna2nama.Text.Trim(),
                harga_per_kg = int.Parse(guna2Harga.Text.Trim()),
                jumlah_kg = int.Parse(guna2Stok.Text.Trim()),
                deskripsi = richTextDeskripsi.Text.Trim(), // <- sesuai properti di Stock
                status = status // <- sesuai properti di Stock
            };
        }

        private void button1tambah_Click(object sender, EventArgs e)
        {
            if (FormValidasi())
            {
                var newform = StockForm();
                stockController.TambahProdukDanStok(newform); // Use the instance of StockController instead of calling it statically
                ClearAll();
                DataMaggot();
            }
        }

        private void UCStockPemilik_Load(object sender, EventArgs e)
        {
            DataMaggot();
        }

        public void DataMaggot()
        {
            stockController.Read();
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Jenis Maggot", typeof(string));
            table.Columns.Add("Harga per KG", typeof(int));
            table.Columns.Add("Jumlah KG", typeof(int));
            table.Columns.Add("Status", typeof(string));
            table.Columns.Add("Deskripsi", typeof(string));

            foreach (var maggot in stockController.ListStock)
            {
                table.Rows.Add(maggot.id_stok_maggot, maggot.jenis_maggot, maggot.harga_per_kg
                    , maggot.jumlah_kg, maggot.status, maggot.deskripsi);
            }
            dataGridView1.DataSource = table;
        }

        private void button1Clear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void button2edit_Click(object sender, EventArgs e)
        {
            if (idMaggotSelected == -1)
            {
                MessageBox.Show("Pilih Id yang ingin di edit!", "Edit Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(guna2nama.Text.Trim()) || string.IsNullOrEmpty(guna2Harga.Text.Trim()))
            {
                MessageBox.Show("Nama Product atau harga tidak boleh kosong", "Edit Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(guna2Stok.Text.Trim()) || string.IsNullOrEmpty(richTextDeskripsi.Text.Trim()))
            {
                MessageBox.Show("Stok atau deskirpsi tidak boleh kosong", "Edit Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(guna2Harga.Text.Trim(), out int harga))
            {
                MessageBox.Show("Harga harus berupa angka", "Edit Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(guna2Stok.Text.Trim(), out int stok))
            {
                MessageBox.Show("Jumlah stok harus berupa angka", "Edit Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!FormValidasi()) return;

            string status = guna2ComboBoxStatus.SelectedItem?.ToString();

            Stock stock = new Stock
            {
                id_stok_maggot = idMaggotSelected,
                jenis_maggot = guna2nama.Text.Trim(),
                harga_per_kg = int.Parse(guna2Harga.Text.Trim()),
                jumlah_kg = int.Parse(guna2Stok.Text.Trim()),
                deskripsi = richTextDeskripsi.Text.Trim(),
                status = status
            };
            stockController.EditProduk(stock);
            MessageBox.Show("Data maggot berhasil diedit.", "Edit Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearAll();
            DataMaggot();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                idMaggotSelected = Convert.ToInt32(row.Cells[0].Value);
                guna2nama.Text = row.Cells[1].Value.ToString();
                guna2Harga.Text = row.Cells[2].Value.ToString();
                guna2Stok.Text = row.Cells[3].Value.ToString();
                guna2ComboBoxStatus.SelectedItem = row.Cells[4].Value.ToString();
                richTextDeskripsi.Text = row.Cells[5].Value.ToString();
            }
        }
        public void ClearAll()
        {
            guna2nama.Text = string.Empty;
            guna2Harga.Text = string.Empty;
            guna2Stok.Text = string.Empty;
            richTextDeskripsi.Text = string.Empty;
            guna2ComboBoxStatus.SelectedIndex = -1;
        }

        private bool FormValidasi()
        {
            if (string.IsNullOrEmpty(guna2nama.Text.Trim()) || string.IsNullOrEmpty(guna2Harga.Text.Trim()))
            {
                MessageBox.Show("Nama maggot atau harga tidak boleh kosong", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(guna2Stok.Text.Trim()) || string.IsNullOrEmpty(richTextDeskripsi.Text.Trim()))
            {
                MessageBox.Show("Stok atau deskripsi tidak boleh kosong", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(guna2ComboBoxStatus.Text.Trim()) || string.IsNullOrEmpty(guna2ComboBoxStatus.Text.Trim()))
            {
                MessageBox.Show("Kategori atau status tidak boleh kosong", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(guna2Harga.Text.Trim(), out _))
            {
                MessageBox.Show("Harga harus berupa angka", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(guna2Stok.Text.Trim(), out _))
            {
                MessageBox.Show("Jumlah stok harus berupa angka", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void guna2Harga_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBoxKategori_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Stok_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextDeskripsi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
