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

        public FormAdmin(int userId)
        {
            _userId = userId;
            InitializeComponent();
            ucDashboardAdmin1.UserId = _userId;
            ucOwners1.UserId = _userId;
            ucProfileAdmin1.UserId = _userId;
            ucRentersAdmin1.UserId = _userId;

        }
        private void FormAdmin_Load(object sender, EventArgs e)
        {

        }

        private void ShowUserControl(UserControl uc)
        {
            // Sembunyikan semua UserControl
            ucDashboardAdmin1.Visible = false;
            ucOwners1.Visible = false;
            ucProfileAdmin1.Visible = false;
            ucRentersAdmin1.Visible = false;

            // Tampilkan UserControl yang dipilih
            uc.Visible = true;
            uc.BringToFront();
        }

        private void buttondashboardadmin_Click(object sender, EventArgs e)
        {
            ShowUserControl(ucDashboardAdmin1);
        }

        private void panellogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GO_CAMP_Click(object sender, EventArgs e)
        {

        }

        private void LogoGoCamp_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //ucDashboardAdmin1.Visible = true;
            //ucOwners1.Visible = false;
            //ucProfileAdmin1.Visible = false;
        }

        private void buttonowners_Click(object sender, EventArgs e)
        {
            ShowUserControl(ucOwners1);
        }

        private void buttonrenters_Click(object sender, EventArgs e)
        {
            ShowUserControl(ucRentersAdmin1);
        }

        private void buttonlaporan_Click(object sender, EventArgs e)
        {

        }

        private void buttonprofiladmin_Click(object sender, EventArgs e)
        {
            ShowUserControl(ucProfileAdmin1);
        }

        private void sidebardashboard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Anda yakin ingin keluar ?",
            "Konfirmasi Pesan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Form1 formLogin = new Form1();
                formLogin.Show();
                this.Hide();
            }
        }

        private void ucDashboardAdmin1_Load(object sender, EventArgs e)
        {

        }
    }
}
