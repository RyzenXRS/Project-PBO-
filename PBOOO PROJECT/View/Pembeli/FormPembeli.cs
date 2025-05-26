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
            InitializeComponent();
            _userId = userId;
        }

        private void FormPembeli_Load(object sender, EventArgs e)
        {

        }
    }
}
