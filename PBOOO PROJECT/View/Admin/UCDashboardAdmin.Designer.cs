namespace PBOOO_PROJECT.View.Admin
{
    partial class UCDashboardAdmin
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
            guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            Total_TRE = new Label();
            label2 = new Label();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            Total_TO = new Label();
            label1 = new Label();
            paneltopdashboard = new Guna.UI2.WinForms.Guna2Panel();
            juduldashboard = new Label();
            guna2ShadowPanel2.SuspendLayout();
            guna2ShadowPanel1.SuspendLayout();
            paneltopdashboard.SuspendLayout();
            SuspendLayout();
            // 
            // guna2ShadowPanel2
            // 
            guna2ShadowPanel2.BackColor = Color.Transparent;
            guna2ShadowPanel2.Controls.Add(Total_TRE);
            guna2ShadowPanel2.Controls.Add(label2);
            guna2ShadowPanel2.FillColor = Color.White;
            guna2ShadowPanel2.Location = new Point(394, 232);
            guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            guna2ShadowPanel2.Radius = 10;
            guna2ShadowPanel2.RightToLeft = RightToLeft.Yes;
            guna2ShadowPanel2.ShadowColor = Color.Black;
            guna2ShadowPanel2.ShadowDepth = 5;
            guna2ShadowPanel2.ShadowShift = 10;
            guna2ShadowPanel2.Size = new Size(300, 200);
            guna2ShadowPanel2.TabIndex = 49;
            guna2ShadowPanel2.Paint += guna2ShadowPanel2_Paint;
            // 
            // Total_TRE
            // 
            Total_TRE.AutoSize = true;
            Total_TRE.BackColor = Color.Transparent;
            Total_TRE.Font = new Font("Microsoft Sans Serif", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Total_TRE.ForeColor = Color.FromArgb(14, 115, 116);
            Total_TRE.ImageAlign = ContentAlignment.MiddleLeft;
            Total_TRE.Location = new Point(121, 83);
            Total_TRE.Name = "Total_TRE";
            Total_TRE.Size = new Size(42, 46);
            Total_TRE.TabIndex = 24;
            Total_TRE.Text = "0";
            Total_TRE.Click += Total_TRE_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(14, 115, 116);
            label2.ImageAlign = ContentAlignment.MiddleLeft;
            label2.Location = new Point(32, 28);
            label2.Name = "label2";
            label2.Size = new Size(131, 25);
            label2.TabIndex = 22;
            label2.Text = "Total Pembeli";
            label2.Click += label2_Click;
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(Total_TO);
            guna2ShadowPanel1.Controls.Add(label1);
            guna2ShadowPanel1.FillColor = Color.White;
            guna2ShadowPanel1.Location = new Point(34, 232);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 10;
            guna2ShadowPanel1.RightToLeft = RightToLeft.Yes;
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.ShadowDepth = 5;
            guna2ShadowPanel1.ShadowShift = 10;
            guna2ShadowPanel1.Size = new Size(300, 200);
            guna2ShadowPanel1.TabIndex = 48;
            guna2ShadowPanel1.Paint += guna2ShadowPanel1_Paint;
            // 
            // Total_TO
            // 
            Total_TO.AutoSize = true;
            Total_TO.BackColor = Color.Transparent;
            Total_TO.Font = new Font("Microsoft Sans Serif", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Total_TO.ForeColor = Color.FromArgb(14, 115, 116);
            Total_TO.ImageAlign = ContentAlignment.MiddleLeft;
            Total_TO.Location = new Point(134, 83);
            Total_TO.Name = "Total_TO";
            Total_TO.Size = new Size(42, 46);
            Total_TO.TabIndex = 22;
            Total_TO.Text = "0";
            Total_TO.Click += Total_TO_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(14, 115, 116);
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.Location = new Point(29, 28);
            label1.Name = "label1";
            label1.Size = new Size(126, 25);
            label1.TabIndex = 21;
            label1.Text = "Total Penjual";
            label1.Click += label1_Click;
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
            paneltopdashboard.Name = "paneltopdashboard";
            paneltopdashboard.ShadowDecoration.CustomizableEdges = customizableEdges2;
            paneltopdashboard.Size = new Size(1277, 131);
            paneltopdashboard.TabIndex = 47;
            paneltopdashboard.Paint += paneltopdashboard_Paint;
            // 
            // juduldashboard
            // 
            juduldashboard.AutoSize = true;
            juduldashboard.BackColor = Color.Transparent;
            juduldashboard.Font = new Font("Microsoft Sans Serif", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            juduldashboard.ForeColor = Color.FromArgb(91, 80, 80);
            juduldashboard.ImageAlign = ContentAlignment.MiddleLeft;
            juduldashboard.Location = new Point(34, 41);
            juduldashboard.Name = "juduldashboard";
            juduldashboard.Size = new Size(224, 46);
            juduldashboard.TabIndex = 20;
            juduldashboard.Text = "Dashboard";
            juduldashboard.Click += juduldashboard_Click;
            // 
            // UCDashboardAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2ShadowPanel2);
            Controls.Add(guna2ShadowPanel1);
            Controls.Add(paneltopdashboard);
            Name = "UCDashboardAdmin";
            Size = new Size(1277, 864);
            Load += UCDashboardAdmin_Load;
            guna2ShadowPanel2.ResumeLayout(false);
            guna2ShadowPanel2.PerformLayout();
            guna2ShadowPanel1.ResumeLayout(false);
            guna2ShadowPanel1.PerformLayout();
            paneltopdashboard.ResumeLayout(false);
            paneltopdashboard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private Label Total_TRE;
        private Label label2;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Label Total_TO;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Panel paneltopdashboard;
        private Label juduldashboard;
    }
}
