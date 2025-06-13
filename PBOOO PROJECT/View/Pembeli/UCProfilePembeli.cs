using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using PBOOO_PROJECT.Controller.Penjual;
using PBOOO_PROJECT.Models.Admin;
using PBOOO_PROJECT.Models.Pembeli;
using PBOOO_PROJECT.Tools;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PBOOO_PROJECT.View.Pembeli
{
    public partial class UCProfilePembeli : UserControl
    {
        private int _userId;

        ProfilePY ProfilePy;

        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
              
            }
        }
        public UCProfilePembeli()
        {
            InitializeComponent();
            disabledProfile();
        }

        public void disabledProfile()
        {
            textBoxUsername.Enabled = false;
            textBoxNoHP.Enabled = false;
            textBoxAlamat.Enabled = false;
        }

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxUsername.Enabled = true;
            textBoxNoHP.Enabled = true;
            textBoxAlamat.Enabled = true;
           
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void UCProfilePenyewa_Load(object sender, EventArgs e)
        {
            string selectQuery = "SELECT nama_pembeli, no_telp, alamat_pembeli FROM pembeli WHERE id_pembeli = @userId";
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
                            ProfilePY profilePy = new ProfilePY();
                  
                            profilePy.nama_pembeli = (string)reader["nama_pembeli"];
                            profilePy.no_telp = (string)reader["no_telp"];
                            profilePy.alamat_pembeli = (string)reader["alamat_penmbeli"];
                            textBoxUsername.Text = profilePy.nama_pembeli;
                            textBoxNoHP.Text = profilePy.no_telp;
                            textBoxAlamat.Text = profilePy.alamat_pembeli;

                        }
                    }
                }
            }
        }


        private void NamaPenyewa_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBoxUsername.Enabled == false || textBoxNoHP.Enabled == false || textBoxAlamat.Enabled == false)
            {
                MessageBox.Show("Klik edit terlebih dahulu", "Edit Data",
                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(textBoxUsername.Text.Trim()) || string.IsNullOrEmpty(textBoxNoHP.Text.Trim()) || string.IsNullOrEmpty(textBoxAlamat.Text.Trim()))
            {
                MessageBox.Show("Nama penyewa dan No hp tidak boleh kosong", "Edit Data",
                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string cekQuery = "SELECT COUNT(*) FROM penyewa WHERE nama_penyewa = @nama_penyewa AND id_penyewa != @userId";
            string updateQuery = "UPDATE penyewa SET nama_penyewa = @nama_penyewa, no_telepon_penyewa = @no_hp, alamat_penyewa = @alamat_penyewa WHERE id_penyewa = @userId";

            try
            {
                using (var db = new DBConnection())
                {
                    db.Open();
                    using (NpgsqlCommand checkCmd = new NpgsqlCommand(cekQuery, db.Connection))
                    {
                        checkCmd.Parameters.AddWithValue("@nama_penyewa", textBoxUsername.Text.Trim());
                        checkCmd.Parameters.AddWithValue("@userId", UserId);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Nama penyewa sudah ada", "Edit Data",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    using (NpgsqlCommand cmd = new NpgsqlCommand(updateQuery, db.Connection))
                    {
                        cmd.Parameters.AddWithValue("@nama_penyewa", textBoxUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@userId", UserId);
                        cmd.Parameters.AddWithValue("@no_hp", textBoxNoHP.Text.Trim());
                        cmd.Parameters.AddWithValue("@alamat_penyewa", textBoxAlamat.Text.Trim());
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil diubah", "Edit Data",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBoxUsername.Enabled = false;
                            textBoxNoHP.Enabled = false;
                            textBoxAlamat.Enabled = false;
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
       
    }

       
    }


