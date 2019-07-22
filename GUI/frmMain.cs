using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using GUI.Custom;
using GUI.Properties;

namespace GUI
{
    public partial class frmMain : Form
    {
        public static NotifyIcon notiIcon = null;
        private NhanVien nv = null;
        private ColumnHeader SortingColumn = null;

        public frmMain(NhanVien nv)
        {
            if (notiIcon == null)
            {
                notiIcon = new NotifyIcon();
            }
            this.nv = nv;
            InitializeComponent();
        }

        private void LoadHoaDonThang()
        {
            lsvHoaDonThang.Items.Clear();
            DataTable dt = new DataTable();
            try
            {
                dt = clsNhanVienBLL.Instance.LayHoaDonThang(nv.MaNV, DateTime.Today.Month);
                if (dt != null)
                {
                    int i = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = i.ToString();
                        string mahd = row["MaHD"].ToString();
                        string slban = row["SoLuongBan"].ToString();
                        string giamgia = row["GiamGia"].ToString();
                        double doanhthu = (double) row["DoanhThu"];
                        CultureInfo info = new CultureInfo("vi-VN");
                        item.SubItems.AddRange(new string[]
                        {
                            mahd,slban,giamgia+"%",doanhthu.ToString("c0",info)
                        });
                        lsvHoaDonThang.Items.Add(item);
                        i++;

                    }
                }
            }
            catch

            {
                lsvHoaDonThang.Items.Clear();
            }
        }

        private void LoadSachBanChayThang()
        {
            lsvSach.Items.Clear();
            DataTable dt = new DataTable();
            try
            {
                dt = clsNhanVienBLL.Instance.LaySachBanChayThang(nv.MaNV, DateTime.Today.Month);
                if (dt != null)
                {
                    int i = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = i.ToString();
                        string tensach = row["TenSach"].ToString();
                        string slban = row["SoLuongBan"].ToString();
                        string slton = row["SoLuongTon"].ToString();
                        item.SubItems.AddRange(new string[]
                        {
                            tensach, slban, slton
                        });
                        lsvSach.Items.Add(item);
                        i++;
                    }
                }
            }
            catch
            {
                lsvSach.Items.Clear();
            }
        }

        private void LoadThongTinTong()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = clsNhanVienBLL.Instance.LayThongTinTong(nv.MaNV, DateTime.Today.Month, DateTime.Today.Year);
                if (dt != null)
                {

                    DataRow row = dt.Rows[0];
                    lblSoSach.Text = "  " + row["SoSach"].ToString();
                    lblSoHD.Text = "  " + row["SoHD"].ToString();
                    lblSoPN.Text = "  " + row["SoPN"].ToString();
                    if ((int) row["SoNV"] >= 0)
                    {
                        lblSoNV.Text = "  " + row["SoNV"].ToString();
                    }
                    else
                    {
                        lblSoNV.Text = "  " + "Không đủ quyền";
                    }

                    CultureInfo info = new CultureInfo("vi-VN");
                    double doanhthu = (double) row["DoanhThu"];
                    lblDoanhThu.Text = "  " + doanhthu.ToString("c0", info);
                }

            }
            catch
            {
                lblSoSach.Text = lblSoHD.Text = lblSoPN.Text = lblSoNV.Text = lblDoanhThu.Text = "  " + "Lỗi";
            }
        }

        private void LoadThongKe()
        {
            LoadThongTinTong();
            LoadHoaDonThang();
            LoadSachBanChayThang();
        }

        private void LoadThongTinChung()
        {
            lblTitle1.Text = lblTitle1.Text + " " + DateTime.Now.Month;
            lblTitle2.Text = lblTitle2.Text + " " + DateTime.Now.Month;
        }

        private void NotifiIconInit()
        {
            notiIcon.Visible = true;
            notiIcon.Icon = Resources.icon;
            notiIcon.ContextMenuStrip = mnusNotification;
            notiIcon.Text = "BookShop Management";
            notiIcon.ShowBalloonTip(2000, "BookShop Management", "Phần mềm Quản lí Cửa hàng sách đang chạy.",
                ToolTipIcon.Info);
        }

        private void PhanQuyen()
        {
            try
            {
                int maquyen = clsPhanQuyenBLL.Instance.LayPhanQuyenTheoMaNV(nv.MaNV).MaQuyen;
                if (maquyen > 0)
                {
                    switch (maquyen)
                    {
                        case 1: mnuQLNhanVien.Enabled = mnuBaoCao.Enabled = true;
                            break;
                        case 2:
                            mnuQLNhanVien.Enabled = mnuBaoCao.Enabled = mnuQLSanPham.Enabled = false;
                            mnuQLNhanVien.Visible = mnuBaoCao.Visible = mnuQLSanPham.Visible = false;
                            break;
                        default:
                            mnuMain.Enabled =
                                tsbThemHoaDon.Enabled = tsbThemPhieuNhap.Enabled = false;
                            mnuMain.Visible =
                                tsbThemHoaDon.Visible = tsbThemPhieuNhap.Visible = false;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void HienThiThoiGian()
        {
            DateTime t= DateTime.Now;
            tslThoiGian.Text = "Đồng hồ: " + t.ToString("HH:mm:ss dd-MM-yyyy");
        }

        private void LayNhanVienTheoMa()
        {
            try
            {
                NhanVien nv = clsNhanVienBLL.Instance.LayNVTheoMa(this.nv.MaNV);
                tslTenNhanVien.Text = "Nhân viên: " + nv.HoTen;
                tslQuyen.Text = "Quyền: " +
                                clsQuyenBLL.Instance.LayTenQuyenTheoMa(clsPhanQuyenBLL.Instance
                                    .LayPhanQuyenTheoMaNV(this.nv.MaNV).MaQuyen);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuThongTinPhanMem_Click(object sender, EventArgs e)
        {
            using (frmThongTinPhanMem fthongtin = new frmThongTinPhanMem())
            {
                fthongtin.ShowDialog();
            }
        }

        private void mnuThongTinCaNhan_Click(object sender, EventArgs e)
        {
            using (frmThongTinCaNhan fcanhan = new frmThongTinCaNhan(this.nv.MaNV))
            {
                fcanhan.ShowDialog();
            }
        }

        private void mnuThayDoiMatKhau_Click(object sender, EventArgs e)
        {
            using (frmThayDoiMatKhau fmatkhau = new frmThayDoiMatKhau(nv))
            {
                fmatkhau.ShowDialog();
            }
        }

        private void mnuQLSanPham_Click(object sender, EventArgs e)
        {
            using (frmSanPham fsp = new frmSanPham())
            {
                tsmQuanLiSP.Enabled = false;
                fsp.ShowDialog();
                tsmQuanLiSP.Enabled = true;
            }
            LoadThongKe();

        }

        private void mnuQLHoaDon_Click(object sender, EventArgs e)
        {
            using (frmHoaDon fhoadon = new frmHoaDon(nv))
            {
                tsmThemHD.Enabled = false;
                fhoadon.ShowDialog();
                tsmThemHD.Enabled = true;
            }
            LoadThongKe();
        }

        private void mnuQLPhieuNhap_Click(object sender, EventArgs e)
        {
            using(frmPhieuNhap frmPhieuNhap = new frmPhieuNhap(nv))
            {
                tsmThemPN.Enabled = false;
                frmPhieuNhap.ShowDialog();
                tsmThemPN.Enabled = true;
            }
            LoadThongKe();
        }

        private void mnuQLNhanVien_Click(object sender, EventArgs e)
        {
            using (frmNhanVien fnhanvien = new frmNhanVien(nv.MaNV))
            {
                tsmQuanLiNV.Enabled = false;
                fnhanvien.ShowDialog();
                tsmQuanLiNV.Enabled = true;
            }
            LoadThongKe();
        }

        private void tsbThemHoaDon_Click(object sender, EventArgs e)
        {
            using (frmHoaDon fhoadon = new frmHoaDon(nv))
            {
                tsmThemHD.Enabled = false;
                fhoadon.ShowDialog();
                tsmThemHD.Enabled = true;
            }
            LoadThongKe();
        }

        private void tsbThemPhieuNhap_Click(object sender, EventArgs e)
        {
            using (frmPhieuNhap fphieunhap = new frmPhieuNhap(nv))
            {
                tsmThemPN.Enabled = false;
                fphieunhap.ShowDialog();
                tsmThemPN.Enabled = true;
            }
            LoadThongKe();
        }



        private void frmMain_Load(object sender, EventArgs e)
        {
            PhanQuyen();
            LayNhanVienTheoMa();
            HienThiThoiGian();
            NotifiIconInit();
            LoadThongTinChung();
            LoadThongKe();
        }

        private void tmMain_Tick(object sender, EventArgs e)
        {
            HienThiThoiGian();
        }

        private void mnuSachBan_Click(object sender, EventArgs e)
        {
            using (frmSachBanChay f = new frmSachBanChay())
            {
                f.ShowDialog();
            }
        }

        private void mnuSachTon_Click(object sender, EventArgs e)
        {
            using (frmSachKhongBanDuoc f = new frmSachKhongBanDuoc())
            {
                f.ShowDialog();
            }
        }

        private void mnuSachNhap_Click(object sender, EventArgs e)
        {
            using (frmSachNhap f = new frmSachNhap())
            {
                f.ShowDialog();
            }
        }

        private void mnuNangSuatNV_Click(object sender, EventArgs e)
        {
            using (frmNangSuatNhanVien f = new frmNangSuatNhanVien())
            {
                f.ShowDialog();
            }
        }

        private void mnuDoanhThuCuaHang_Click(object sender, EventArgs e)
        {
            using (frmDoanhThuCuaHang f = new frmDoanhThuCuaHang())
            {
                f.ShowDialog();
            }
        }

        private void tsmThoat_Click(object sender, EventArgs e)
        {
            List<Form> openedform = new List<Form>();
            foreach (Form _form in Application.OpenForms)
            {
                openedform.Add(_form);
            }

            foreach (Form _form in openedform)
            {
                if (_form.Name != "frmLogin" && _form.Name!="frmMain")
                {
                    _form.Close();
                }
            }
            this.Close();
        }

        private void tsmQuanLiSP_Click(object sender, EventArgs e)
        {
            using (frmSanPham fsp = new frmSanPham())
            {
                tsmQuanLiSP.Enabled = false;
                fsp.ShowDialog();
                tsmQuanLiSP.Enabled = true;
            }
            LoadThongKe();
        }

        private void tsmQuanLiNV_Click(object sender, EventArgs e)
        {
            using (frmNhanVien fnv = new frmNhanVien(nv.MaNV))
            {
                tsmQuanLiNV.Enabled = false;
                fnv.ShowDialog();
                tsmQuanLiNV.Enabled = true;
            }
            LoadThongKe();
        }

        private void tsmThemHD_Click(object sender, EventArgs e)
        {
            using (frmHoaDon fhd = new frmHoaDon(nv))
            {
                tsmThemHD.Enabled = false;
                fhd.ShowDialog();
                tsmThemHD.Enabled = true;
            }
            LoadThongKe();
        }

        private void tsmThemPN_Click(object sender, EventArgs e)
        {
            using (frmPhieuNhap fpn = new frmPhieuNhap(nv))
            {
                tsmThemPN.Enabled = false;
                fpn.ShowDialog();
                tsmThemPN.Enabled = true;
            }
            LoadThongKe();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            notiIcon.Dispose();
            notiIcon = null;
        }

        private void lsvHoaDonThang_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Get the new sorting column.
            ColumnHeader new_sorting_column = lsvHoaDonThang.Columns[e.Column];

            // Figure out the new sorting order.
            System.Windows.Forms.SortOrder sort_order;
            if (SortingColumn == null)
            {
                // New column. Sort ascending.
                sort_order = System.Windows.Forms.SortOrder.Ascending;
            }
            else
            {
                // See if this is the same column.
                if (new_sorting_column == SortingColumn)
                {
                    // Same column. Switch the sort order.
                    if (SortingColumn.Text.StartsWith("> "))
                    {
                        sort_order = System.Windows.Forms.SortOrder.Descending;
                    }
                    else
                    {
                        sort_order = System.Windows.Forms.SortOrder.Ascending;
                    }
                }
                else
                {
                    // New column. Sort ascending.
                    sort_order = System.Windows.Forms.SortOrder.Ascending;
                }

                // Remove the old sort indicator.
                SortingColumn.Text = SortingColumn.Text.Substring(2);
            }

            // Display the new sort order.
            SortingColumn = new_sorting_column;
            if (sort_order == System.Windows.Forms.SortOrder.Ascending)
            {
                SortingColumn.Text = "> " + SortingColumn.Text;
            }
            else
            {
                SortingColumn.Text = "< " + SortingColumn.Text;
            }

            // Create a comparer.
            lsvHoaDonThang.ListViewItemSorter =
                new ListViewComparer(e.Column, sort_order);

            // Sort.
            lsvHoaDonThang.Sort();
        }

        private void lsvSach_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Get the new sorting column.
            ColumnHeader new_sorting_column = lsvSach.Columns[e.Column];

            // Figure out the new sorting order.
            System.Windows.Forms.SortOrder sort_order;
            if (SortingColumn == null)
            {
                // New column. Sort ascending.
                sort_order = System.Windows.Forms.SortOrder.Ascending;
            }
            else
            {
                // See if this is the same column.
                if (new_sorting_column == SortingColumn)
                {
                    // Same column. Switch the sort order.
                    if (SortingColumn.Text.StartsWith("> "))
                    {
                        sort_order = System.Windows.Forms.SortOrder.Descending;
                    }
                    else
                    {
                        sort_order = System.Windows.Forms.SortOrder.Ascending;
                    }
                }
                else
                {
                    // New column. Sort ascending.
                    sort_order = System.Windows.Forms.SortOrder.Ascending;
                }

                // Remove the old sort indicator.
                SortingColumn.Text = SortingColumn.Text.Substring(2);
            }

            // Display the new sort order.
            SortingColumn = new_sorting_column;
            if (sort_order == System.Windows.Forms.SortOrder.Ascending)
            {
                SortingColumn.Text = "> " + SortingColumn.Text;
            }
            else
            {
                SortingColumn.Text = "< " + SortingColumn.Text;
            }

            // Create a comparer.
            lsvSach.ListViewItemSorter =
                new ListViewComparer(e.Column, sort_order);

            // Sort.
            lsvSach.Sort();
        }

        private void tsmDongCuaSo_Click(object sender, EventArgs e)
        {
            List<Form> openedform = new List<Form>();
            foreach (Form _form in Application.OpenForms)
            {
                openedform.Add(_form);
            }

            foreach (Form _form in openedform)
            {
                if (_form.Name != "frmLogin" && _form.Name != "frmMain")
                {
                    _form.Close();
                }
            }
        }
    }
}
