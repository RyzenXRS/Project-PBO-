using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBOOO_PROJECT.Controller.Penjual;
using PBOOO_PROJECT.Controller.Pembeli;
using static PBOOO_PROJECT.View.Penjual.UCStockPenjual;

namespace PBOOO_PROJECT.View.Pembeli
{
    public partial class UCHistoryPembeli : UserControl
    {
        private int _userId;

        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                historyController.UserId = _userId;
                // Load data or perform operations based on the new UserId value
            }
        }
        HistoryController historyController;
        private int idhistorySelected = -1;
        public UCHistoryPembeli()
        {
            historyController = new HistoryController();
            InitializeComponent();
        }

        private void UCHistoryPenyewa_Load(object sender, EventArgs e)
        {
            DataHistory();
        }
        public void DataHistory()
        {
            historyController.Read();
            DataTable table = new DataTable();
            table.Columns.Add("Id Transaksi", typeof(int));
            table.Columns.Add("Tanggal Transaksi", typeof(string));
            table.Columns.Add("Status Transaksi", typeof(string));
            table.Columns.Add("Nomor E-wallet", typeof(string));
            table.Columns.Add("Jenis E-wallet", typeof(string));
            table.Columns.Add("Total Harga", typeof(int));
            foreach (var histori in historyController.ListHistory)
            {
                table.Rows.Add(histori.id_transaksi_maggot, histori.tanggal, histori.status_transaksi, 
                                histori.nomor_ewallet,histori.jenis_ewallet,
                                histori.total_harga_keseluruhan);
            }

            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dataGridView2.Visible = true;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                idhistorySelected = Convert.ToInt32(row.Cells[0].Value);

                var details = historyController.GetDetailPeminjaman(idhistorySelected);

                dataGridView2.Controls.Clear();
                DataTable table2 = new DataTable();

                table2.Columns.Add("Nama Maggot", typeof(string));
                table2.Columns.Add("Stock", typeof(int));
                table2.Columns.Add("Harga ", typeof(int));
                table2.Columns.Add("Total Harga", typeof(string));
                dataGridView2.DataSource = table2;

                foreach (var detail in details)
                {
                    table2.Rows.Add(detail.jenis_maggot, detail.jumlah_kg,
                        detail.harga_per_kg, detail.total_harga);
                }
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
