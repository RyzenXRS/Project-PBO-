namespace PBOOO_PROJECT
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            comboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            usernamebox = new Guna.UI2.WinForms.Guna2TextBox();
            passwordbox = new Guna.UI2.WinForms.Guna2TextBox();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            label4 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            guna2ShadowPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImage = Properties.Resources.Desain_tanpa_judul;
            panel1.Location = new Point(79, 87);
            panel1.Name = "panel1";
            panel1.Size = new Size(503, 474);
            panel1.TabIndex = 63;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.None;
            comboBox1.BackColor = Color.FromArgb(138, 154, 91);
            comboBox1.BorderRadius = 9;
            comboBox1.BorderThickness = 0;
            comboBox1.CustomizableEdges = customizableEdges1;
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FillColor = Color.FromArgb(245, 248, 241);
            comboBox1.FocusedColor = Color.FromArgb(94, 148, 255);
            comboBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            comboBox1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            comboBox1.ForeColor = Color.FromArgb(74, 75, 67);
            comboBox1.HoverState.FillColor = Color.Transparent;
            comboBox1.IntegralHeight = false;
            comboBox1.ItemHeight = 40;
            comboBox1.Items.AddRange(new object[] { "Admin", "Pemilik", "Penyewa" });
            comboBox1.ItemsAppearance.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBox1.Location = new Point(767, 400);
            comboBox1.Margin = new Padding(6, 5, 6, 5);
            comboBox1.Name = "comboBox1";
            comboBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            comboBox1.Size = new Size(433, 46);
            comboBox1.TabIndex = 84;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // usernamebox
            // 
            usernamebox.Anchor = AnchorStyles.None;
            usernamebox.BackColor = Color.FromArgb(138, 154, 91);
            usernamebox.BorderColor = Color.Transparent;
            usernamebox.BorderRadius = 9;
            usernamebox.BorderThickness = 0;
            usernamebox.CustomizableEdges = customizableEdges3;
            usernamebox.DefaultText = "";
            usernamebox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            usernamebox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            usernamebox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            usernamebox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            usernamebox.FillColor = Color.FromArgb(245, 248, 241);
            usernamebox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            usernamebox.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold);
            usernamebox.ForeColor = Color.FromArgb(74, 75, 67);
            usernamebox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            usernamebox.Location = new Point(767, 207);
            usernamebox.Margin = new Padding(11, 9, 11, 9);
            usernamebox.Name = "usernamebox";
            usernamebox.PlaceholderText = "";
            usernamebox.SelectedText = "";
            usernamebox.ShadowDecoration.CustomizableEdges = customizableEdges4;
            usernamebox.Size = new Size(433, 45);
            usernamebox.TabIndex = 83;
            usernamebox.TextChanged += usernamebox_TextChanged;
            // 
            // passwordbox
            // 
            passwordbox.Anchor = AnchorStyles.None;
            passwordbox.BackColor = Color.FromArgb(138, 154, 91);
            passwordbox.BorderColor = Color.Transparent;
            passwordbox.BorderRadius = 9;
            passwordbox.BorderThickness = 0;
            passwordbox.CustomizableEdges = customizableEdges5;
            passwordbox.DefaultText = "";
            passwordbox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            passwordbox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            passwordbox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            passwordbox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            passwordbox.FillColor = Color.FromArgb(245, 248, 241);
            passwordbox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            passwordbox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            passwordbox.ForeColor = Color.FromArgb(74, 75, 67);
            passwordbox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            passwordbox.Location = new Point(767, 306);
            passwordbox.Margin = new Padding(6, 5, 6, 5);
            passwordbox.Name = "passwordbox";
            passwordbox.PlaceholderText = "";
            passwordbox.SelectedText = "";
            passwordbox.ShadowDecoration.CustomizableEdges = customizableEdges6;
            passwordbox.Size = new Size(433, 45);
            passwordbox.TabIndex = 82;
            passwordbox.TextChanged += passwordbox_TextChanged;
            // 
            // guna2Button1
            // 
            guna2Button1.Anchor = AnchorStyles.None;
            guna2Button1.BackColor = Color.FromArgb(138, 154, 91);
            guna2Button1.BorderRadius = 15;
            guna2Button1.CustomizableEdges = customizableEdges7;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.FromArgb(150, 160, 91);
            guna2Button1.Font = new Font("Microsoft Sans Serif", 17F, FontStyle.Bold);
            guna2Button1.ForeColor = Color.FromArgb(74, 75, 67);
            guna2Button1.Location = new Point(877, 520);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.Padding = new Padding(1, 0, 0, 0);
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Button1.Size = new Size(200, 50);
            guna2Button1.TabIndex = 81;
            guna2Button1.Text = "Submit";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(138, 154, 91);
            label4.Font = new Font("Microsoft Sans Serif", 15F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(767, 367);
            label4.Name = "label4";
            label4.Size = new Size(51, 25);
            label4.TabIndex = 80;
            label4.Text = "Role";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            label4.Click += label4_Click;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.BackColor = Color.FromArgb(138, 154, 91);
            label7.Font = new Font("Microsoft Sans Serif", 15F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(764, 272);
            label7.Name = "label7";
            label7.Size = new Size(98, 25);
            label7.TabIndex = 79;
            label7.Text = "Password";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            label7.Click += label7_Click;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.BackColor = Color.FromArgb(138, 154, 91);
            label8.Font = new Font("Microsoft Sans Serif", 15F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(764, 173);
            label8.Name = "label8";
            label8.Size = new Size(102, 25);
            label8.TabIndex = 78;
            label8.Text = "Username";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            label8.Click += label8_Click;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.BackColor = Color.FromArgb(138, 154, 91);
            label9.Font = new Font("Microsoft Sans Serif", 12F);
            label9.ForeColor = Color.White;
            label9.Location = new Point(1040, 601);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(69, 20);
            label9.TabIndex = 77;
            label9.Text = "Register";
            label9.Click += label9_Click;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.None;
            label10.AutoSize = true;
            label10.BackColor = Color.FromArgb(138, 154, 91);
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.FromArgb(217, 224, 184);
            label10.Location = new Point(850, 601);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(177, 20);
            label10.TabIndex = 76;
            label10.Text = "Don't have an account?";
            label10.Click += label10_Click;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.None;
            label11.AutoSize = true;
            label11.BackColor = Color.FromArgb(138, 154, 91);
            label11.Font = new Font("Microsoft Sans Serif", 30F, FontStyle.Bold);
            label11.ForeColor = Color.FromArgb(217, 224, 184);
            label11.Location = new Point(217, 46);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(123, 46);
            label11.TabIndex = 75;
            label11.Text = "Login";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            label11.Click += label11_Click;
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.Anchor = AnchorStyles.None;
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(label11);
            guna2ShadowPanel1.FillColor = Color.FromArgb(138, 154, 91);
            guna2ShadowPanel1.Location = new Point(719, 41);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 15;
            guna2ShadowPanel1.RightToLeft = RightToLeft.Yes;
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.ShadowDepth = 35;
            guna2ShadowPanel1.ShadowShift = 15;
            guna2ShadowPanel1.Size = new Size(530, 623);
            guna2ShadowPanel1.TabIndex = 85;
            guna2ShadowPanel1.Paint += guna2ShadowPanel1_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(138, 154, 91);
            BackgroundImage = Properties.Resources.Background;
            ClientSize = new Size(1261, 693);
            Controls.Add(comboBox1);
            Controls.Add(usernamebox);
            Controls.Add(passwordbox);
            Controls.Add(guna2Button1);
            Controls.Add(label4);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(guna2ShadowPanel1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            guna2ShadowPanel1.ResumeLayout(false);
            guna2ShadowPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2ComboBox comboBox1;
        private Guna.UI2.WinForms.Guna2TextBox usernamebox;
        private Guna.UI2.WinForms.Guna2TextBox passwordbox;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Label label4;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
    }
}
