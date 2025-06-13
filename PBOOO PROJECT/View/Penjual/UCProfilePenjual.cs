using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using PBOOO_PROJECT.Controller.Penjual;
using PBOOO_PROJECT.Models.Penjual;
//using PBOOO_PROJECT.Models.Pembeli;
using PBOOO_PROJECT.Tools;

namespace PBOOO_PROJECT.View.Penjual
{
    public partial class UCProfilePenjual : UserControl
    {
        private int _userId;

        ProfilePm ProfilePm;

        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;

            }
        }
        public UCProfilePenjual()
        {
            InitializeComponent();
            disabledProfile();
        }

        public void disabledProfile()
        {
            textBoxNamePm.Enabled = false;
            textBoxNoPm.Enabled = false;
            textBoxAlamatPm.Enabled = false;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            textBoxNamePm.Enabled = true;
            textBoxNoPm.Enabled = true;
            textBoxAlamatPm.Enabled = true;
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (textBoxNamePm.Enabled == false || textBoxNoPm.Enabled == false || textBoxAlamatPm.Enabled == false)
            {
                MessageBox.Show("Klik edit terlebih dahulu", "Edit Data",
                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(textBoxNamePm.Text.Trim()) || string.IsNullOrEmpty(textBoxNoPm.Text.Trim()) || string.IsNullOrEmpty(textBoxAlamatPm.Text.Trim()))
            {
                MessageBox.Show("Nama pemilik dan No hp tidak boleh kosong", "Edit Data",
                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string cekQuery = "SELECT COUNT(*) FROM penjual WHERE nama_penjual = @nama_penjual AND id_penjual != @userId";
            string updateQuery = "UPDATE penjual SET nama_penjual = @nama_penjual, no_telp = @no_hp, alamat = @alamat WHERE id_penjual = @userId";

            try
            {
                using (var db = new DBConnection())
                {
                    db.Open();
                    using (NpgsqlCommand checkCmd = new NpgsqlCommand(cekQuery, db.Connection))
                    {
                        checkCmd.Parameters.AddWithValue("@nama_penjual", textBoxNamePm.Text.Trim());
                        checkCmd.Parameters.AddWithValue("@userId", UserId);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Nama pemilik sudah ada", "Edit Data",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    using (NpgsqlCommand cmd = new NpgsqlCommand(updateQuery, db.Connection))
                    {
                        cmd.Parameters.AddWithValue("@nama_penjual", textBoxNamePm.Text.Trim());
                        cmd.Parameters.AddWithValue("@userId", UserId);
                        cmd.Parameters.AddWithValue("@no_hp", textBoxNoPm.Text.Trim());
                        cmd.Parameters.AddWithValue("@alamat", textBoxAlamatPm.Text.Trim());
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil diubah", "Edit Data",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBoxNamePm.Enabled = false;
                            textBoxNoPm.Enabled = false;
                            textBoxAlamatPm.Enabled = false;
                            // Optional: Update DataGridView if it exists
                        }
                        else
                        {
                            MessageBox.Show("Data gagal diubah", "Edit Data",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxAlamat_TextChanged(object sender, EventArgs e)
        {

        }

        private void UCProfilePemilik_Load_1(object sender, EventArgs e)
        {
            string selectQuery = "SELECT nama_penjual, no_telp, alamat FROM penjual WHERE id_penjual = @userId";
            using (var db = new DBConnection())
            {
                db.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(selectQuery, db.Connection))
                {
                    cmd.Parameters.AddWithValue("@userId", _userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ProfilePm profilePm = new ProfilePm();
                            //profileA.id_admin = (int)reader["id_admin"];
                            profilePm.nama_penjual = (string)reader["nama_penjual"];
                            profilePm.no_telp = (string)reader["no_telp"];
                            profilePm.alamat = (string)reader["alamat"];
                            textBoxNamePm.Text = profilePm.nama_penjual;
                            textBoxNoPm.Text = profilePm.no_telp;
                            textBoxAlamatPm.Text = profilePm.alamat;

                        }
                    }
                }
            }
        }

        private void paneltopdashboard_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
