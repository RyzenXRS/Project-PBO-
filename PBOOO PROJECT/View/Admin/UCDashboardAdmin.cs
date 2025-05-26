using PBOOO_PROJECT.Controller.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBOOO_PROJECT.Controller;
using PBOOO_PROJECT.Controller.Admin;

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
            //Owners();
            //Renters();
            //Rentals();
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
    }
}
