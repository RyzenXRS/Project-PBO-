using Npgsql;
using PBOOO_PROJECT.Controller;
using PBOOO_PROJECT.Controller.Admin;
using PBOOO_PROJECT.Tools;
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
    public partial class UCDashboardAdmin : UserControl
    {
        private int _userId;
        DashboardControllerA dashboardControllerA;
        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
            }
        }
        public UCDashboardAdmin()
        {
            dashboardControllerA = new DashboardControllerA();
            InitializeComponent();
            Owners();
            Pembeli();
            //Rentals();
        }
        public void Owners()
        {
            string query = string.Format(@"SELECT COUNT(id_penjual) FROM penjual;");
            using (var db = new DBConnection())
            {
                db.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, db.Connection))
                {
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int count = Convert.ToInt32(reader[0]);
                        Total_TO.Text = count.ToString();
                    }
                    reader.Close();
                }
            }
        }
        public void Pembeli()
        {
            string query = string.Format(@"SELECT COUNT(id_pembeli) FROM pembeli;");
            using (var db = new DBConnection())
            {
                db.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, db.Connection))
                {
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int count = Convert.ToInt32(reader[0]);
                        Total_TRE.Text = count.ToString();
                    }
                    reader.Close();
                }
            }
        }

        private void Total_TO_Click(object sender, EventArgs e)
        {

        }

        private void juduldashboard_Click(object sender, EventArgs e)
        {

        }

        private void paneltopdashboard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UCDashboardAdmin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Total_TRE_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Total_TRA_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
