using Microsoft.VisualBasic.ApplicationServices;
using PBOOO_PROJECT.View.Penjual;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBOOO_PROJECT.View.Pembeli
{
    public partial class FormPembeli : Form
    {
        private int _userId;
        public FormPembeli(int userId)
        {
            InitializeComponent();;
            _userId = userId;
            ucProfilePembeli1.UserId = _userId; 
            ucHistoryPembeli1.UserId = _userId;
            ucHomePembeli1.UserId = _userId;
            ucTransactionsPembeli1.UserId = _userId;    
        }
        private void ShowUserControl(UserControl uc)
        {
            // Sembunyikan semua UserControl
            ucProfilePembeli1.Visible = false;
            ucHistoryPembeli1.Visible = false;
            ucHomePembeli1.Visible = false;
            ucTransactionsPembeli1.Visible = false; 


            // Tampilkan UserControl yang dipilih
            uc.Visible = true;
            uc.BringToFront();
        }
        private void FormPembeli_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void buttonhomepenyewa_Click(object sender, EventArgs e)
        {
            ShowUserControl(ucHomePembeli1);
        }

        private void buttontransactionpenyewa_Click(object sender, EventArgs e)
        {
            ShowUserControl(ucTransactionsPembeli1);
        }

        private void buttohistorypenyewa_Click(object sender, EventArgs e)
        {
            ShowUserControl(ucHistoryPembeli1);
        }

        private void buttonReportsPy_Click(object sender, EventArgs e)
        {

        }

        private void buttonprofilpeyewa_Click(object sender, EventArgs e)
        {
            ShowUserControl(ucProfilePembeli1);
        }

        private void sidebardashboard_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
