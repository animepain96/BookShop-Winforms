namespace GUI
{
    partial class frmBaoCao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCao));
            this.rptBaoCao = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptBaoCao
            // 
            this.rptBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptBaoCao.Location = new System.Drawing.Point(0, 0);
            this.rptBaoCao.Name = "rptBaoCao";
            this.rptBaoCao.ShowBackButton = false;
            this.rptBaoCao.ShowContextMenu = false;
            this.rptBaoCao.ShowCredentialPrompts = false;
            this.rptBaoCao.ShowDocumentMapButton = false;
            this.rptBaoCao.ShowParameterPrompts = false;
            this.rptBaoCao.ShowPromptAreaButton = false;
            this.rptBaoCao.Size = new System.Drawing.Size(1182, 673);
            this.rptBaoCao.TabIndex = 0;
            this.rptBaoCao.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // frmBaoCaoHoaDon
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1182, 673);
            this.Controls.Add(this.rptBaoCao);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "frmBaoCaoHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BÁO CÁO";
            this.Load += new System.EventHandler(this.frmBaoCaoHoaDon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer rptBaoCao;
    }
}