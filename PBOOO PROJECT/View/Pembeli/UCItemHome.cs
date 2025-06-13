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
    public partial class UCItemHome : UserControl
    {
        public UCItemHome()
        {
            InitializeComponent();
        }
        public int id_maggot { get; set; }
        public int id_penjual { get; set; }
        public decimal harga_per_kg
        {
            get
            {
                decimal value;
                if (decimal.TryParse(lblPrice.Text, out value))
                {
                    return value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                lblPrice.Text = value.ToString("N0");
            }
        }

        public string jenis_maggot
        {
            get { return lblNama.Text; }
            set { lblNama.Text = value; }
        }

        public string deskripsi
        {
            get { return lblDesc.Text; }
            set { lblDesc.Text = value; }
        }

        private void lblNama_Click(object sender, EventArgs e)
        {

        }

        private void lblDesc_Click(object sender, EventArgs e)
        {

        }
    }
}
