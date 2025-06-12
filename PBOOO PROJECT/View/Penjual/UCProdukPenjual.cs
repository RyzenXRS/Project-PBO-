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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PBOOO_PROJECT.View.Penjual
{
    public partial class UCProdukPenjual : UserControl
    {
        private int _userId;

        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                ProductController.UserId = _userId;

            }
        }
        private int idMaggotSelected = -1;


        ProductController ProductController;
        int index;
        public UCProdukPenjual()
        {
            ProductController = new ProductController();
            InitializeComponent();
        }
        private NpgsqlConnection conn;

        DataTable table = new DataTable();
        private void button2edit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxKategori.Text.Trim()))
            {
                MessageBox.Show("Nama Produk tidak boleh kosong", "Tambah Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(comboBox1Status.Text.Trim()))
            {
                MessageBox.Show("Nama Produk tidak boleh kosong", "Tambah Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string status = comboBox1Status.SelectedItem.ToString();
            ProductController.Edit(idMaggotSelected, textBoxKategori.Text, status);
            ShowListKategori();
        }

        private void button1tambah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxKategori.Text.Trim()))
            {
                MessageBox.Show("Nama Produk tidak boleh kosong", "Tambah Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(comboBox1Status.Text.Trim()))
            {
                MessageBox.Show("Status Produk tidak boleh kosong", "Tambah Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string status = comboBox1Status.SelectedItem.ToString();
            ProductController.Tambah(textBoxKategori.Text, status);
            ShowListKategori();
        }

        private void UCCategoriesPemilik_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Nama Product", typeof(string));
            table.Columns.Add("Status", typeof(string));
            dataGridView1.DataSource = table;
            ShowListKategori();
        }
        public void ShowListKategori()
        {
            ProductController.Read();
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Jenis Maggot", typeof(string));
            table.Columns.Add("Harga Per Kg", typeof(decimal));
            table.Columns.Add("Stok", typeof(decimal));
            table.Columns.Add("ID Penjual", typeof(string));
            table.Columns.Add("Nama Penjual", typeof(string));
            table.Columns.Add("Status", typeof(string));

            foreach (var product in ProductController.ListProduct)
            {
                table.Rows.Add(
                    product.id_maggot,
                    product.jenis_maggot,
                    product.harga_per_kg,
                    product.stok,
                    product.id_penjual,
                    product.nama_penjual,
                    product.status
                );
            }

            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                idMaggotSelected = Convert.ToInt32(row.Cells[0].Value);
                textBoxKategori.Text = row.Cells[1].Value.ToString(); // jenis maggot
                comboBox1Status.SelectedItem = row.Cells[7].Value.ToString(); // status
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
