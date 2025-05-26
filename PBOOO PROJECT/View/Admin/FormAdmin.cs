using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class FormAdmin : Form
    {
        private int _userId;
        // Assuming ucDashboardAdmin is a UserControl that needs to be added to the form
        private UCDashboardAdmin ucDashboardAdmin = new UCDashboardAdmin();
        public FormAdmin(int userId)
        {
            _userId = userId;
            InitializeComponent();
            ucDashboardAdmin.UserId = _userId;
            ucDashboardAdmin.Dock = DockStyle.Fill; // Adjust as needed
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {

        }

        private void buttohistorypenyewa_Click(object sender, EventArgs e)
        {

        }

        private void buttonhomepenyewa_Click(object sender, EventArgs e)
        {

        }

        private void buttontransactionpenyewa_Click(object sender, EventArgs e)
        {

        }

        private void buttonReportsPy_Click(object sender, EventArgs e)
        {

        }

        private void buttonprofilpeyewa_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
