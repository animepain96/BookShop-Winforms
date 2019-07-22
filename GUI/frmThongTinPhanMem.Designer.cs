namespace GUI
{
    partial class frmThongTinPhanMem
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongTinPhanMem));
            this.btnDong = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabThongTinPhanMem = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cbtnEmail = new GUI.Custom.CircleButton();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.cbtnInstagram = new GUI.Custom.CircleButton();
            this.cbtnTwitter = new GUI.Custom.CircleButton();
            this.cbtnFacebook = new GUI.Custom.CircleButton();
            this.elipsePictureBox2 = new GUI.ElipsePictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabDoAn = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.elipsePictureBox1 = new GUI.ElipsePictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabThongTinPhanMem.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elipsePictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabDoAn.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elipsePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDong
            // 
            this.btnDong.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(63)))), ((int)(((byte)(159)))));
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.Location = new System.Drawing.Point(163, 488);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(113, 40);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "ĐÓNG";
            this.btnDong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabThongTinPhanMem);
            this.tabControl1.Controls.Add(this.tabDoAn);
            this.tabControl1.Location = new System.Drawing.Point(2, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(436, 482);
            this.tabControl1.TabIndex = 3;
            // 
            // tabThongTinPhanMem
            // 
            this.tabThongTinPhanMem.Controls.Add(this.panel5);
            this.tabThongTinPhanMem.Controls.Add(this.elipsePictureBox2);
            this.tabThongTinPhanMem.Controls.Add(this.panel2);
            this.tabThongTinPhanMem.Controls.Add(this.panel1);
            this.tabThongTinPhanMem.Location = new System.Drawing.Point(4, 31);
            this.tabThongTinPhanMem.Name = "tabThongTinPhanMem";
            this.tabThongTinPhanMem.Padding = new System.Windows.Forms.Padding(3);
            this.tabThongTinPhanMem.Size = new System.Drawing.Size(428, 447);
            this.tabThongTinPhanMem.TabIndex = 0;
            this.tabThongTinPhanMem.Text = "Thông Tin";
            this.tabThongTinPhanMem.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel5.Controls.Add(this.cbtnEmail);
            this.panel5.Controls.Add(this.cbtnInstagram);
            this.panel5.Controls.Add(this.cbtnTwitter);
            this.panel5.Controls.Add(this.cbtnFacebook);
            this.panel5.Location = new System.Drawing.Point(3, 372);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(425, 60);
            this.panel5.TabIndex = 4;
            this.toolTip.SetToolTip(this.panel5, "Instagram");
            // 
            // cbtnEmail
            // 
            this.cbtnEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbtnEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cbtnEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbtnEmail.FlatAppearance.BorderSize = 0;
            this.cbtnEmail.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbtnEmail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbtnEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbtnEmail.ImageIndex = 3;
            this.cbtnEmail.ImageList = this.imageList;
            this.cbtnEmail.Location = new System.Drawing.Point(313, 5);
            this.cbtnEmail.Name = "cbtnEmail";
            this.cbtnEmail.Size = new System.Drawing.Size(50, 50);
            this.cbtnEmail.TabIndex = 3;
            this.toolTip.SetToolTip(this.cbtnEmail, "Email");
            this.cbtnEmail.UseVisualStyleBackColor = true;
            this.cbtnEmail.Click += new System.EventHandler(this.cbtnEmail_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "facebook.png");
            this.imageList.Images.SetKeyName(1, "twitter.png");
            this.imageList.Images.SetKeyName(2, "instagram.png");
            this.imageList.Images.SetKeyName(3, "email.png");
            // 
            // cbtnInstagram
            // 
            this.cbtnInstagram.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbtnInstagram.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cbtnInstagram.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbtnInstagram.FlatAppearance.BorderSize = 0;
            this.cbtnInstagram.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbtnInstagram.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbtnInstagram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbtnInstagram.ImageIndex = 2;
            this.cbtnInstagram.ImageList = this.imageList;
            this.cbtnInstagram.Location = new System.Drawing.Point(224, 5);
            this.cbtnInstagram.Name = "cbtnInstagram";
            this.cbtnInstagram.Size = new System.Drawing.Size(50, 50);
            this.cbtnInstagram.TabIndex = 2;
            this.toolTip.SetToolTip(this.cbtnInstagram, "Instagram");
            this.cbtnInstagram.UseVisualStyleBackColor = true;
            this.cbtnInstagram.Click += new System.EventHandler(this.cbtnInstagram_Click);
            // 
            // cbtnTwitter
            // 
            this.cbtnTwitter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbtnTwitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cbtnTwitter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbtnTwitter.FlatAppearance.BorderSize = 0;
            this.cbtnTwitter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbtnTwitter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbtnTwitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbtnTwitter.ImageIndex = 1;
            this.cbtnTwitter.ImageList = this.imageList;
            this.cbtnTwitter.Location = new System.Drawing.Point(135, 5);
            this.cbtnTwitter.Name = "cbtnTwitter";
            this.cbtnTwitter.Size = new System.Drawing.Size(50, 50);
            this.cbtnTwitter.TabIndex = 1;
            this.toolTip.SetToolTip(this.cbtnTwitter, "Twitter");
            this.cbtnTwitter.UseVisualStyleBackColor = true;
            this.cbtnTwitter.Click += new System.EventHandler(this.cbtnTwitter_Click);
            // 
            // cbtnFacebook
            // 
            this.cbtnFacebook.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbtnFacebook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cbtnFacebook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbtnFacebook.FlatAppearance.BorderSize = 0;
            this.cbtnFacebook.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbtnFacebook.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbtnFacebook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbtnFacebook.ImageIndex = 0;
            this.cbtnFacebook.ImageList = this.imageList;
            this.cbtnFacebook.Location = new System.Drawing.Point(46, 5);
            this.cbtnFacebook.Name = "cbtnFacebook";
            this.cbtnFacebook.Size = new System.Drawing.Size(50, 50);
            this.cbtnFacebook.TabIndex = 0;
            this.toolTip.SetToolTip(this.cbtnFacebook, "Facebook");
            this.cbtnFacebook.UseVisualStyleBackColor = true;
            this.cbtnFacebook.Click += new System.EventHandler(this.cbtnFacebook_Click);
            // 
            // elipsePictureBox2
            // 
            this.elipsePictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.elipsePictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("elipsePictureBox2.Image")));
            this.elipsePictureBox2.Location = new System.Drawing.Point(91, -9);
            this.elipsePictureBox2.Name = "elipsePictureBox2";
            this.elipsePictureBox2.Size = new System.Drawing.Size(239, 215);
            this.elipsePictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.elipsePictureBox2.TabIndex = 3;
            this.elipsePictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(34, 292);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(361, 74);
            this.panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(361, 74);
            this.label2.TabIndex = 0;
            this.label2.Text = "Phiên bản: 1.0.0.0\r\nLiên hệ: 70, Nguyễn Huệ, TP. Huế\r\nEmail: dangvandau2014@gmail" +
    ".com";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(36, 191);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 104);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 104);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phần mềm\r\nQuản lí cửa hàng bán Sách";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabDoAn
            // 
            this.tabDoAn.Controls.Add(this.panel3);
            this.tabDoAn.Controls.Add(this.elipsePictureBox1);
            this.tabDoAn.Location = new System.Drawing.Point(4, 25);
            this.tabDoAn.Name = "tabDoAn";
            this.tabDoAn.Padding = new System.Windows.Forms.Padding(3);
            this.tabDoAn.Size = new System.Drawing.Size(428, 453);
            this.tabDoAn.TabIndex = 1;
            this.tabDoAn.Text = "Đồ Án";
            this.tabDoAn.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(3, 260);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(419, 189);
            this.panel3.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Location = new System.Drawing.Point(4, 52);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(412, 134);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "\r\nSinh viên: ĐẶNG VĂN ĐẨU\r\nMSSV: 17603111043\r\n\r\nGiảng viên Hướng dẫn: SỬ MINH ĐẠT" +
    "";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.BackColor = System.Drawing.Color.Gray;
            this.panel4.Location = new System.Drawing.Point(2, 44);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(414, 2);
            this.panel4.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(419, 37);
            this.label3.TabIndex = 0;
            this.label3.Text = "ĐỒ ÁN LẬP TRÌNH C# NÂNG CAO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // elipsePictureBox1
            // 
            this.elipsePictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.elipsePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("elipsePictureBox1.Image")));
            this.elipsePictureBox1.Location = new System.Drawing.Point(87, 10);
            this.elipsePictureBox1.Name = "elipsePictureBox1";
            this.elipsePictureBox1.Size = new System.Drawing.Size(252, 234);
            this.elipsePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.elipsePictureBox1.TabIndex = 0;
            this.elipsePictureBox1.TabStop = false;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 2000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 100;
            // 
            // frmThongTinPhanMem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(440, 534);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnDong);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThongTinPhanMem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THÔNG TIN PHẦN MỀM";
            this.Load += new System.EventHandler(this.frmThongTinPhanMem_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabThongTinPhanMem.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.elipsePictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabDoAn.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elipsePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabThongTinPhanMem;
        private System.Windows.Forms.TabPage tabDoAn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private ElipsePictureBox elipsePictureBox1;
        private ElipsePictureBox elipsePictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ImageList imageList;
        private Custom.CircleButton cbtnFacebook;
        private Custom.CircleButton cbtnEmail;
        private Custom.CircleButton cbtnInstagram;
        private Custom.CircleButton cbtnTwitter;
        private System.Windows.Forms.ToolTip toolTip;
    }
}