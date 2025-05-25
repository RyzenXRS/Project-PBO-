//using PBOOO_PROJECT.Controller;

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
