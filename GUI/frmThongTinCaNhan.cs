using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class frmThongTinCaNhan : Form
    {
        private int manv;
        public frmThongTinCaNhan(int manv)
        {
            this.manv = manv;
            InitializeComponent();
        }

        private void LayThongTinNhanVien()
        {
            try
            {
                NhanVien nv = clsNhanVienBLL.Instance.LayNVTheoMa(manv);
                txtTenDangNhap.Text = nv.TenDangNhap;
                txtHoTen.Text = nv.HoTen;
                txtSDT.Text = nv.SDT;
                txtDiaChi.Text = nv.DiaChi;
                dtpNgaySinh.Value = nv.NgaySinh;
                if (nv.GioiTinh)
                {
                    radNam.Checked = true;
                }
                else
                {
                    radNu.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThongTinCaNhan_Load(object sender, EventArgs e)
        {
            LayThongTinNhanVien();
        }
    }
}
