namespace PBOOO_PROJECT.View.Penjual
{
    partial class UCProdukPenjual
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            paneltopdashboard = new Guna.UI2.WinForms.Guna2Panel();
            juduldashboard = new Label();
            button1tambah = new Button();
            button2edit = new Button();
            textBoxKategori = new TextBox();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            comboBox1Status = new ComboBox();
            label1 = new Label();
            paneltopdashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // paneltopdashboard
            // 
            paneltopdashboard.BackColor = Color.FromArgb(245, 248, 241);
            paneltopdashboard.BorderColor = Color.FromArgb(91, 80, 80);
            paneltopdashboard.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            paneltopdashboard.Controls.Add(juduldashboard);
            paneltopdashboard.CustomBorderColor = Color.FromArgb(217, 224, 184);
            paneltopdashboard.CustomBorderThickness = new Padding(0, 0, 0, 1);
            paneltopdashboard.CustomizableEdges = customizableEdges1;
            paneltopdashboard.Dock = DockStyle.Top;
            paneltopdashboard.Location = new Point(0, 0);
            paneltopdashboard.Margin = new Padding(4, 5, 4, 5);
            paneltopdashboard.Name = "paneltopdashboard";
            paneltopdashboard.ShadowDecoration.CustomizableEdges = customizableEdges2;
            paneltopdashboard.Size = new Size(1824, 218);
            paneltopdashboard.TabIndex = 45;
            // 
            // juduldashboard
            // 
            juduldashboard.AutoSize = true;
            juduldashboard.BackColor = Color.Transparent;
            juduldashboard.Font = new Font("Microsoft Sans Serif", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            juduldashboard.ForeColor = Color.FromArgb(91, 80, 80);
            juduldashboard.ImageAlign = ContentAlignment.MiddleLeft;
            juduldashboard.Location = new Point(49, 68);
            juduldashboard.Margin = new Padding(4, 0, 4, 0);
            juduldashboard.Name = "juduldashboard";
            juduldashboard.Size = new Size(243, 69);
            juduldashboard.TabIndex = 20;
            juduldashboard.Text = "Product";
            // 
            // button1tambah
            // 
            button1tambah.BackColor = Color.FromArgb(97, 191, 143);
            button1tambah.FlatStyle = FlatStyle.Flat;
            button1tambah.Font = new Font("Microsoft Sans Serif", 20.25F);
            button1tambah.ForeColor = Color.White;
            button1tambah.Location = new Point(1314, 665);
            button1tambah.Name = "button1tambah";
            button1tambah.Size = new Size(163, 98);
            button1tambah.TabIndex = 51;
            button1tambah.Text = "Add";
            button1tambah.UseVisualStyleBackColor = false;
            button1tambah.Click += button1tambah_Click;
            // 
            // button2edit
            // 
            button2edit.BackColor = Color.RoyalBlue;
            button2edit.FlatStyle = FlatStyle.Flat;
            button2edit.Font = new Font("Microsoft Sans Serif", 20.25F);
            button2edit.ForeColor = Color.White;
            button2edit.Location = new Point(1544, 665);
            button2edit.Name = "button2edit";
            button2edit.Size = new Size(163, 98);
            button2edit.TabIndex = 49;
            button2edit.Text = "Edit";
            button2edit.UseVisualStyleBackColor = false;
            button2edit.Click += button2edit_Click;
            // 
            // textBoxKategori
            // 
            textBoxKategori.BorderStyle = BorderStyle.FixedSingle;
            textBoxKategori.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxKategori.Location = new Point(1264, 368);
            textBoxKategori.Name = "textBoxKategori";
            textBoxKategori.Size = new Size(488, 41);
            textBoxKategori.TabIndex = 48;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(1264, 298);
            label2.Name = "label2";
            label2.Size = new Size(211, 36);
            label2.TabIndex = 47;
            label2.Text = "Nama Kategori";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(97, 191, 143);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.CausesValidation = false;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(14, 115, 116);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(14, 115, 116);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeight = 34;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(97, 191, 143);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(49, 280);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1150, 1085);
            dataGridView1.TabIndex = 46;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // comboBox1Status
            // 
            comboBox1Status.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1Status.FormattingEnabled = true;
            comboBox1Status.Items.AddRange(new object[] { "Aktif", "Tidak Aktif" });
            comboBox1Status.Location = new Point(1264, 535);
            comboBox1Status.Margin = new Padding(4, 5, 4, 5);
            comboBox1Status.Name = "comboBox1Status";
            comboBox1Status.Size = new Size(487, 44);
            comboBox1Status.TabIndex = 52;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(1264, 473);
            label1.Name = "label1";
            label1.Size = new Size(99, 36);
            label1.TabIndex = 53;
            label1.Text = "Status";
            // 
            // UCProdukPenjual
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(comboBox1Status);
            Controls.Add(button1tambah);
            Controls.Add(button2edit);
            Controls.Add(textBoxKategori);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(paneltopdashboard);
            Margin = new Padding(4, 5, 4, 5);
            Name = "UCProdukPenjual";
            Size = new Size(3000, 3000);
            Load += UCCategoriesPemilik_Load;
            paneltopdashboard.ResumeLayout(false);
            paneltopdashboard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel paneltopdashboard;
        private Label juduldashboard;
        private Button button1tambah;
        private Button button2edit;
        private TextBox textBoxKategori;
        private Label label2;
        private DataGridView dataGridView1;
        private ComboBox comboBox1Status;
        private Label label1;
    }
}
