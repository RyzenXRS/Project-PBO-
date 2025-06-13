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
    public partial class UCItemMaggot : UserControl
    {

        public UCItemMaggot()
        {
            InitializeComponent();
        }

        public event EventHandler onSelect;
        public int id_maggot { get; set; }
        public int id_penjual { get; set; }

        public decimal harga_per_kg
        {
            get
            {
                decimal value;
                if (decimal.TryParse(lblStock.Text, out value))
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
                lblStock.Text = value.ToString("N0");
            }
        }
        public int stok_kg
        {
            get
            {
                int value;
                if (int.TryParse(lblStock.Text, out value))
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
                lblStock.Text = value.ToString();
            }
        }

        public string jenis_maggot
        {
            get { return lblItemName.Text; }
            set { lblItemName.Text = value; }
        }
        public string nama_penjual
        {
            get { return lblItemCategory.Text; }
            set { lblItemCategory.Text = value; }
        }

        private void UCItemCamping_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private void lblItemName_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private void lblItemCategory_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private void guna2ShadowPanel1_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }
    }
}
