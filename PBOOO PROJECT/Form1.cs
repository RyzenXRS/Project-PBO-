using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using PBOOO_PROJECT.Controller;
using PBOOO_PROJECT.View.Admin;
using PBOOO_PROJECT.View.Penjual;
using PBOOO_PROJECT.View.Pembeli;

namespace PBOOO_PROJECT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void usernamebox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(usernamebox.Text.Trim()) || string.IsNullOrEmpty(passwordbox.Text.Trim())
                || string.IsNullOrEmpty(comboBox1.Text.Trim()))
            {
                MessageBox.Show("Username dan password tidak boleh kosong", "Login Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string selectedTable = comboBox1.SelectedItem.ToString();
            string username = usernamebox.Text;
            string password = passwordbox.Text;
            LoginController loginController = new LoginController();
            var (result, userId) = loginController.AuthLogin(selectedTable, username, password);

            if (result == "Admin") 
            {
                MessageBox.Show("Login Berhasil Sebagai Admin", "Login Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormAdmin menuAdmin = new FormAdmin(userId);
                menuAdmin.Show();
                this.Hide();
            }
            if (result == "Penjual") 
            {
                MessageBox.Show("Login Berhasil Sebagai Penjual", "Login Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormPenjual menuPenjual = new FormPenjual(userId);
                menuPenjual.Show();
                this.Hide();
            }
            if (result == "Pembeli") 
            {
                MessageBox.Show("Login Berhasil Sebagai Pembeli", "Login Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormPembeli menuPembeli = new FormPembeli(userId);
                menuPembeli.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(result);
            }

        }
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }
    }
}
