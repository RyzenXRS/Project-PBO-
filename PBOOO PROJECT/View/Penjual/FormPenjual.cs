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
        }

        private void FormPenjual_Load(object sender, EventArgs e)
        {

        }
    }
}
