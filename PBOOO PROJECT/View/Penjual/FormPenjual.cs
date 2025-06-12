using PBOOO_PROJECT.View.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBOOO_PROJECT.View.Penjual
{
    public partial class FormPenjual : Form
    {
        private int _userId;
        public FormPenjual(int userId)
        {
            InitializeComponent();
            _userId = userId;
            ucProfilePenjual1.UserId = userId;
        }

        private void ShowUserControl(UserControl uc)
        {
            // Sembunyikan semua UserControl
            ucProfilePenjual1.Visible = false;

            // Tampilkan UserControl yang dipilih
            uc.Visible = true;
            uc.BringToFront();
        }

        private void FormPenjual_Load(object sender, EventArgs e)
        {

        }

        private void panellogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GO_CAMP_Click(object sender, EventArgs e)
        {

        }

        private void LogoGoCamp_Click(object sender, EventArgs e)
        {

        }

        private void buttondashboardPemilik_Click(object sender, EventArgs e)
        {

        }

        private void buttonstocksPemilik_Click(object sender, EventArgs e)
        {

        }

        private void buttoncategoriesPemilik_Click(object sender, EventArgs e)
        {

        }

        private void buttonrentersPemilik_Click(object sender, EventArgs e)
        {

        }

        private void buttonTransactionsPemilik_Click(object sender, EventArgs e)
        {

        }

        private void buttonprofilepemilik_Click(object sender, EventArgs e)
        {
            ShowUserControl(ucProfilePenjual1);
        }

        private void sidebardashboard_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
