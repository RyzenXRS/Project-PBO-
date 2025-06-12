using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace PBOOO_PROJECT
{
    public partial class Register : Form
    {
        Form1 form = new Form1();
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void passwordbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void namabox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void alamatbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void notelpbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void sebagai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void usernamebox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void konfirmasibox_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
             if (string.IsNullOrEmpty(usernamebox.Text.Trim()) || string.IsNullOrEmpty(passwordbox.Text.Trim())
                || string.IsNullOrEmpty(namabox.Text.Trim()) || string.IsNullOrEmpty(konfirmasibox.Text.Trim())
                || string.IsNullOrEmpty(alamatbox.Text.Trim()) || string.IsNullOrEmpty(notelpbox.Text.Trim())
                || string.IsNullOrEmpty(sebagai.Text.Trim()))
            {
                MessageBox.Show("Data tidak boleh ada yang kosong!", "Register Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string nama_penjual = namabox.Text;
            string alamat_penjual = alamatbox.Text;
            string no_telepon_penjual = notelpbox.Text;
            string nama_pembeli = namabox.Text;
            string alamat_pembeli = alamatbox.Text;
            string no_telepon_pembeli = notelpbox.Text;
            string username = usernamebox.Text;
            string password = passwordbox.Text;
            string konfirmasi = konfirmasibox.Text;
            string selectedTable = sebagai.SelectedItem.ToString();

            if (password == konfirmasi)
            {
                using (NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Username=postgres;Password=321;Database=MaggotPBOO"))
                {
                    if (selectedTable == "Pembeli")
                    {
                        con.Open();

                        string checkUsernameQuery = "SELECT COUNT(*) FROM pembeli WHERE username = @username";

                        using (NpgsqlCommand checkCmd = new NpgsqlCommand(checkUsernameQuery, con))
                        {
                            checkCmd.Parameters.AddWithValue("@username", username);
                            int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                            if (count > 0)
                            {
                                MessageBox.Show("Username sudah tersedia. Silakan ganti username anda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        string register = "INSERT INTO penjual (id_penjual, nama_penjual, alamat, no_telp, username, password) VALUES (nextval('id_penjual_seq'), @nama_penjual, @alamat, @no_telp, @username, @password)";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(register, con))
                        {
                            cmd.Parameters.AddWithValue("@nama_pembeli", nama_pembeli);
                            cmd.Parameters.AddWithValue("@alamat", alamat_pembeli);
                            cmd.Parameters.AddWithValue("@no_telp", no_telepon_pembeli);
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@password", password);
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Registrasi berhasil!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                form.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Registrasi gagal. Silakan coba lagi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else if (selectedTable == "Penjual")
                    {
                        con.Open();
                        string checkUsernameQuery = "SELECT COUNT(*) FROM penjual WHERE username = @username";
                        using (NpgsqlCommand checkCmd = new NpgsqlCommand(checkUsernameQuery, con))
                        {
                            checkCmd.Parameters.AddWithValue("@username", username);
                            int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                            if (count > 0)
                            {
                                MessageBox.Show("Username sudah tersedia. Silakan ganti username anda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        string register = "INSERT INTO penjual (id_penjual, nama_penjual, alamat, no_telp, username, password) VALUES (nextval('id_penjual_seq'), @nama_penjual, @alamat, @no_telp, @username, @password)";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(register, con))
                        { 
                            cmd.Parameters.AddWithValue("@nama_penjual", nama_penjual);
                            cmd.Parameters.AddWithValue("@alamat", alamat_penjual); // changed parameter name
                            cmd.Parameters.AddWithValue("@no_telp", no_telepon_penjual);
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@password", password);
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Registrasi berhasil!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                form.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Registrasi gagal. Silakan coba lagi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Silakan pilih jenis pengguna yang benar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Password dan konfirmasi password tidak cocok.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void label9_Click(object sender, EventArgs e)
        {
            form.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
