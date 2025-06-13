using Npgsql;
using PBOOO_PROJECT.Controller.Penjual;
using PBOOO_PROJECT.Tools;
using PBOOO_PROJECT.View.Pembeli;
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
    public partial class UCHomePembeli : UserControl
    {

        private int _userId;

        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;

            }
        }
        public UCHomePembeli()
        {
            InitializeComponent();
            LoadProducts();

            AddCategory();
        }

        private void AddCategory()
        {
            string query = "SELECT DISTINCT jenis_maggot FROM maggot ORDER BY jenis_maggot";
            using (var db = new DBConnection())
            {
                db.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, db.Connection))
                {
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        panelkategori.Controls.Clear();

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                                b.FillColor = Color.FromArgb(220, 225, 189);
                                b.Size = new Size(180, 45);
                                b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                                b.Text = dr["jenis_maggot"].ToString();


                                b.Click += new EventHandler(b_click);

                                panelkategori.Controls.Add(b);
                            }
                        }
                    }
                }
            }
        }

        private void b_click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button b = (Guna.UI2.WinForms.Guna2Button)sender;
            foreach (var item in panelItem.Controls)
            {
                var pro = (UCItemHome)item;
                pro.Visible = pro.jenis_maggot.ToLower().Contains(b.Text.Trim().ToLower());
            }
        }

        private void AddItems(string id, string jenis, string harga, string desc, string id_penjual)
        {
            if (panelItem == null)
            {
                throw new InvalidOperationException("panelitem or datagridTransaction is not initialized.");
            }

            var w = new UCItemHome()
            {
                id_maggot = Convert.ToInt32(id),
                id_penjual = Convert.ToInt32(id_penjual),
                jenis_maggot = jenis,
                harga_per_kg = Convert.ToDecimal(harga),
                deskripsi = desc
            };

            panelItem.Controls.Add(w);
        }

        private void LoadProducts()
        {
            string query = "SELECT m.id_maggot,m.jenis_maggot,m.harga_per_kg,COALESCE(sm.jumlah_kg, 0) AS stok_kg, m.id_penjual,'Maggot berkualitas tinggi' AS deskripsi\r\nFROM maggot m\r\nLEFT JOIN stok_maggot sm ON sm.id_maggot = m.id_maggot\r\nWHERE COALESCE(sm.jumlah_kg, 0) > 0;";
            using (var db = new DBConnection())
            {
                db.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, db.Connection))
                {
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        foreach (DataRow item in dt.Rows)
                        {
                            //var card = new UCItemMaggot
                            //{
                            //    id_maggot = int.Parse(item["id_maggot"].ToString()),
                            //    id_penjual = int.Parse(item["id_penjual"].ToString()),
                            //    jenis_maggot = item["jenis_maggot"].ToString(),
                            //    harga_per_kg = (decimal)item["harga_per_kg"],
                            //    stok_kg = int.Parse(item["stok_kg"].ToString()),
                            //    //jenis_sampah = "Sampah Organik" // contoh, jika tersedia
                            //};
                            //card.onSelect += Card_onSelect;
                            //panelItem.Controls.Add(card);
                            AddItems(
                                item["id_maggot"].ToString(),
                                item["jenis_maggot"].ToString(),
                                item["harga_per_kg"].ToString(), // Fix: Convert decimal to string
                                item["deskripsi"].ToString(),      // Fix: Correct column name and convert to string
                                item["id_penjual"].ToString()
                            );

                        }
                    }
                }
            }
        }
        private void paneltopdashboard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UCHomePenyewa_Load(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panelItem_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
