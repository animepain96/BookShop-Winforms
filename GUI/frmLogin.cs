using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using BLL;
using DTO;

namespace GUI
{
    public partial class frmLogin : Form
    {
        private frmLoading load;
        Assembly myAssembly = Assembly.GetExecutingAssembly();

        public frmLogin()
        {
            InitializeComponent();
        }

        #region Ham

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Focus();
        }

        private NhanVien _Login()
        {
            try
            {
                string encrypt_pass = Encrypt.Encrypt.Instance.MD5Encrypt(txtMatKhau.Text);
                if (clsNhanVienBLL.Instance.DangNhap(txtTenDangNhap.Text, encrypt_pass))
                {
                    NhanVien nv = clsNhanVienBLL.Instance.LayThongTinNV(txtTenDangNhap.Text, encrypt_pass);
                    Thread.Sleep(1500);
                    return nv;
                }
                else
                {
                    Thread.Sleep(1500);
                    return null;
                }
            }
            catch
            {
                Thread.Sleep(1500);
                return null;
            }

        }

        private void IsLogging(bool check)
        {
            if (check)
            {
                if (load == null || load.IsDisposed)
                {
                    load = new frmLoading("Đang đăng nhập ...");
                }
                load.Cursor = Cursors.WaitCursor;
                load.Show();
                this.Hide();
            }
            else
            {
                load.Cursor = Cursors.Default;
                load.Close();
                this.Show();
            }

        }

        #endregion

        #region Sukien

        private async void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text != "" && txtMatKhau.Text != "")
            {
                IsLogging(true);
                Task<NhanVien> _logintask = new Task<NhanVien>(_Login);
                _logintask.Start();
                NhanVien nv = await _logintask;
                IsLogging(false);
                if (nv != null)
                {
                    MessageBox.Show("Đăng nhập thành công.", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    using (frmMain fmain = new frmMain(nv))
                    {
                        this.Hide();
                        fmain.ShowDialog();
                        fmain.TopLevel = true;
                        this.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.TopLevel = true;
                }

                txtTenDangNhap.Text = txtMatKhau.Text = "";
                txtTenDangNhap.Focus();
            }
            else
            {
                MessageBox.Show("Nhập thông tin đăng nhập hệ thống.", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtTenDangNhap.Focus();
            }
        }

        private void txtTenDangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtMatKhau.Focus();
            }
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnDangNhap.PerformClick();
            }
        }

        #endregion

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
