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
    public partial class frmThayDoiMatKhau : Form
    {
        private NhanVien nv;
        public frmThayDoiMatKhau(NhanVien nv)
        {
            this.nv = nv;
            InitializeComponent();
        }

        private void LamMoi()
        {
            txtMatKhauCu.Text = txtMatKhauMoi.Text = txtXacNhan.Text = "";
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMatKhauCu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtMatKhauMoi.Focus();
            }
        }

        private void txtXacNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnCapNhat.PerformClick();
            }
        }

        private void txtMatKhauMoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtXacNhan.Focus();
            }
        }

        private void frmThayDoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMatKhauMoi.Text == txtXacNhan.Text)
                {
                    string encrypt_mkcu = Encrypt.Encrypt.Instance.MD5Encrypt(txtMatKhauCu.Text);
                    if (clsNhanVienBLL.Instance.DangNhap(nv.TenDangNhap, encrypt_mkcu))
                    {
                        if (MessageBox.Show("Bạn có muốn thay đổi Mật khẩu?", "Thông báo", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string encrypt_mkmoi = Encrypt.Encrypt.Instance.MD5Encrypt(txtMatKhauMoi.Text);
                            if (clsNhanVienBLL.Instance.DoiMatKhau(nv.MaNV, encrypt_mkmoi))
                            {
                                MessageBox.Show("Thay đổi Mật khẩu thành công", "Thông báo", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                LamMoi();
                                txtMatKhauCu.Focus();
                                frmMain.notiIcon.ShowBalloonTip(1500, "BookShop Management",
                                    "Thay đổi mật khẩu thành công.", ToolTipIcon.Info);
                            }
                            else
                            {
                                MessageBox.Show("Thay đổi Mật khẩu thất bại", "Thông báo", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ không chính xác", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới không khớp", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
