using PBOOO_PROJECT.Controller.Admin;
//using PBOOO_PROJECT.Controller.Pembeli; // Wajib
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBOOO_PROJECT.View.Admin
{
    public partial class UCRentersAdmin : UserControl
    {

        private int _userId;

        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                LoadDataGrid();
            }
        }

        ListPembeliController listPembeliController;
        public UCRentersAdmin()
        {
            listPembeliController = new ListPembeliController();
            InitializeComponent();

        }
        DataTable table = new DataTable();
        private void UCRentersAdmin_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = table;
            ShowListRenters();
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            listPembeliController.Read();
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Nama Penyewa", typeof(string));
            table.Columns.Add("Nomor Telepon", typeof(string));
            table.Columns.Add("Alamat", typeof(string));
            table.Columns.Add("Jumlah Peminjaman", typeof(long));
            foreach (var renters in listPembeliController.ListPembeli)
            {
                table.Rows.Add(renters.ID, renters.Nama_Pembeli, renters.no_telp
                                , renters.alamat_pembeli, renters.jumlah_pembeli);
            }

            guna2DataGridView1.DataSource = table;
        }

        public void ShowListRenters()
        {
            LoadDataGrid();
            listPembeliController.Read();
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = listPembeliController.ListPembeli;
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
