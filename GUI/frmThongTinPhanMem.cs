using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmThongTinPhanMem : Form
    {
        public frmThongTinPhanMem()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThongTinPhanMem_Load(object sender, EventArgs e)
        {

        }

        private void cbtnFacebook_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://facebook.com/xepcmnhinh");
        }

        private void cbtnTwitter_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com");
        }

        private void cbtnInstagram_Click(object sender, EventArgs e)
        {
            Process.Start("https://instagram.com");
        }

        private void cbtnEmail_Click(object sender, EventArgs e)
        {
            Process.Start("mailto:dau.dangvan@students.hueic.edu.vn");
        }
    }
}
