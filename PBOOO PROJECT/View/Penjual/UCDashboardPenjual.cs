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
using PBOOO_PROJECT.Controller.Admin;
using PBOOO_PROJECT.Controller.Penjual;
using PBOOO_PROJECT.Tools;

namespace PBOOO_PROJECT.View.Penjual
{
    public partial class UCDashboardPenjual : UserControl
    {
        private int _userId;
        DashboardControllerPenjual dashboardControllerPenjual;
        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;

            }
        }
        public UCDashboardPenjual()
        {
            dashboardControllerPenjual = new DashboardControllerPenjual();
            InitializeComponent();
            Order();
            Dikirim();
            Maggot();
            Revenue();
        }


        public void Order()
        {
            int total = 0;
            string query = string.Format(@"SELECT COUNT(*) AS total_order
                                            FROM transaksi_maggot tm
                                            JOIN maggot m ON m.id_maggot = tm.id_maggot
                                            WHERE m.id_penjual = @id_penjual");
            using (var db = new DBConnection())
            {
                db.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, db.Connection))
                {
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int count = Convert.ToInt32(reader[0]);
                        Total_TP.Text = count.ToString();
                    }
                    reader.Close();
                }
            }
        }
        public void Dikirim()
        {
            string query = string.Format(@"SELECT COUNT(*) AS total_permintaan
                                           FROM transaksi_maggot tm
                                           JOIN maggot m ON m.id_maggot = tm.id_maggot
                                           WHERE m.id_penjual = @id_penjual
                                           AND tm.status = 'dikirim';");
            using (var db = new DBConnection())
            {
                db.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, db.Connection))
                {
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int count = Convert.ToInt32(reader[0]);
                        Total_TP.Text = count.ToString();
                    }
                    reader.Close();
                }
            }
        }
        public void Maggot()
        {
            string query = string.Format(@"SELECT COUNT(id_maggot) FROM maggot WHERE id_penjual = @id_penjual;");
            using (var db = new DBConnection())
            {
                db.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, db.Connection))
                {
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int count = Convert.ToInt32(reader[0]);
                        Total_TE.Text = count.ToString();
                    }
                    reader.Close();
                }
            }
        }
        public void Revenue()
        {
            string query = @"
        SELECT SUM(tm.jumlah_kg * m.harga_per_kg) AS total_revenue 
        FROM penjual pj
        JOIN maggot m ON pj.id_penjual = m.id_penjual
        JOIN detail_transaksi_maggot dt ON m.id_maggot = dt.id_maggot
        JOIN transaksi_maggot tm ON dt.id_transaksi_maggot = tm.id_transaksi_maggot
        WHERE tm.status = 'dikirim'
        AND pj.id_penjual = @id_penjual";

            using (var db = new DBConnection()) // db harus punya Open()
            {
                db.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, db.Connection))
                {
                    cmd.Parameters.AddWithValue("@id_penjual", UserId);

                    object result = cmd.ExecuteScalar();

                    if (result == DBNull.Value || result == null)
                    {
                        Total_TR.Text = "0.00";
                    }
                    else
                    {
                        double total = Convert.ToDouble(result);
                        Total_TR.Text = total.ToString("N2"); // 2 decimal
                    }
                }
            }
        }

        private void paneltopdashboard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UCDashboardPemilik_Load(object sender, EventArgs e)
        {

        }

        private void Total_TO_Click(object sender, EventArgs e)
        {

        }

        private void Total_TP_Click(object sender, EventArgs e)
        {

        }

        private void Total_TR_Click(object sender, EventArgs e)
        {

        }
    }
}
