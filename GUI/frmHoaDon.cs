using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using GUI.Custom;
using Microsoft.Reporting.WinForms;

namespace GUI
{
    public partial class frmHoaDon : Form
    {
        private ColumnHeader SortingColumn = null;
        private float total = 0;
        private NhanVien nv;
        public frmHoaDon(NhanVien nv)
        {
            this.nv = nv;
            InitializeComponent();
        }

        private void XemChiTietHD()
        {
            using (frmChiTietHoaDon f = new frmChiTietHoaDon(Convert.ToInt32(lsvHoaDon.SelectedItems[0].Text)))
            {
                f.ShowDialog();
            }
        }

        private void LayDSHoaDon()
        {
            try
            {
                lsvHoaDon.SelectedItems.Clear();
                lsvHoaDon.Items.Clear();
                List<HoaDon> dsHD = new List<HoaDon>();
                dsHD = clsHoaDonBLL.Instance.LayDSHoaDon(nv.MaNV, dtpFrmDate.Value, dtpToDate.Value);
                if (dsHD != null)
                {
                    CultureInfo info = new CultureInfo("vi-VN");
                    foreach (HoaDon hd in dsHD)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = hd.MaHD.ToString();
                        item.SubItems.Add(clsNhanVienBLL.Instance.LayTenNVTheoMa(hd.MaNV));
                        item.SubItems.Add(hd.NgayBan.ToString("dd-MM-yyyy"));
                        item.SubItems.Add(clsChiTietHoaDonBLL.Instance.LaySoLuongSachTheoMaHD(hd.MaHD).ToString());
                        item.SubItems.Add(
                            clsChiTietHoaDonBLL.Instance.LayTongTienTheoMaHD(hd.MaHD).ToString("c0", info));
                        item.SubItems.Add(hd.GiamGia + " %");
                        lsvHoaDon.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DatNgay()
        {
            dtpFrmDate.Value = DateTime.Today.AddDays(-1);
            dtpToDate.Value = DateTime.Today;
        }

        private void LamMoi()
        {
            txtMaSach.Text = txtTenSach.Text = "";
            lsvSach.SelectedItems.Clear();
        }

        private void CaiDatMacDinh()
        {
            btnThemSach.Enabled = false;
            btnThanhToan.Enabled = false;
            btnHuyHoaDon.Enabled = false;
            btnXoaSach.Enabled = false;
        }

        private void TimDSSach()
        {
            lsvSach.Items.Clear();
            List<Sach> dsS = new List<Sach>();
            dsS = clsSachBLL.Instance.TimDSSach(txtTimSach.Text);
            if (dsS != null)
            {
                foreach (Sach sach in dsS)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = sach.MaSach.ToString();
                    item.SubItems.Add(sach.TenSach);
                    item.SubItems.Add(sach.GiaBan.ToString());
                    item.SubItems.Add(sach.NamXB.ToString());
                    item.SubItems.Add(sach.SoLuongTon.ToString());
                    item.SubItems.Add(clsNhaXuatBanBLL.Instance.LayNXBTheoMa(sach.MaNXB).TenNXB);
                    item.SubItems.Add(clsTheLoaiBLL.Instance.LayTLTheoMa(sach.MaTL).TenTL);
                    item.SubItems.Add(clsTacGiaBLL.Instance.LayTGTheoMa(sach.MaTG).TenTG);
                    item.SubItems[5].Tag = sach.MaNXB;
                    item.SubItems[6].Tag = sach.MaTL;
                    item.SubItems[7].Tag = sach.MaTG;
                    if (sach.SoLuongTon < 10)
                    {
                        item.BackColor = Color.Bisque;
                    }
                    lsvSach.Items.Add(item);
                }
            }
        }

        private void TienViet()
        {
            CultureInfo info = new CultureInfo("vi-VN");
            lblTongTien.Text = 0.ToString("c0", info);
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                TimDSSach();
                CaiDatMacDinh();
                TienViet();
                DatNgay();
                LayDSHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txtTimSach_TextChanged(object sender, EventArgs e)
        {
            TimDSSach();
        }

        private void btnTimSach_Click(object sender, EventArgs e)
        {
            TimDSSach();
        }

        private void lsvSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvSach.SelectedItems.Count > 0)
            {
                btnThemSach.Enabled = true;
                txtMaSach.Text = lsvSach.SelectedItems[0].Text;
                txtTenSach.Text = lsvSach.SelectedItems[0].SubItems[1].Text;
            }
            else
            {
                btnThemSach.Enabled = false;
                txtMaSach.Text = txtTenSach.Text = "";
            }
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvSach.SelectedItems.Count > 0 && txtMaSach.Text != "")
                {

                    if (numSoLuong.Value == 0)
                    {
                        MessageBox.Show("Số lượng Sách phải lớn hơn 0.", "Thông báo");
                        return;
                    }

                    if (numSoLuong.Value > Convert.ToInt32(lsvSach.SelectedItems[0].SubItems[4].Text))
                    {
                        MessageBox.Show("Số lượng Sách còn lại không đủ.", "Thông báo");
                        return;
                    }
                    else
                    {
                        if (lsvChiTiet.Items.Count > 0)
                        {
                            foreach (ListViewItem item in lsvChiTiet.Items)
                            {
                                if (item.Tag.ToString() == txtMaSach.Text)
                                {
                                    if (Convert.ToInt32(item.SubItems[3].Text) + numSoLuong.Value >
                                        Convert.ToInt32(lsvSach.SelectedItems[0].SubItems[4].Text))
                                    {
                                        MessageBox.Show("Số lượng Sách còn lại không đủ.", "Thông báo");
                                        return;
                                    }
                                }
                            }
                        }
                    }

                    int i;
                    if (lsvChiTiet.Items.Count > 0)
                    {
                        i = Convert.ToInt32(lsvChiTiet.Items[lsvChiTiet.Items.Count - 1].Text);
                        i++;
                    }
                    else
                    {
                        i = 1;
                    }

                    foreach (ListViewItem item in lsvChiTiet.Items)
                    {
                        if ((int) item.Tag == Convert.ToInt32(lsvSach.SelectedItems[0].Text))
                        {
                            item.SubItems[3].Text =
                                (Convert.ToInt32(item.SubItems[3].Text) + (int) numSoLuong.Value).ToString();
                            total += float.Parse(item.SubItems[2].Text) * (int) numSoLuong.Value;
                            CultureInfo cul = new CultureInfo("vi-VN");
                            lblTongTien.Text = total.ToString("c0", cul);
                            numSoLuong.Value = 0;
                            LamMoi();
                            btnHuyHoaDon.Enabled = true;
                            btnThanhToan.Enabled = true;
                            return;
                        }

                    }

                    ListViewItem tmp = new ListViewItem();
                    tmp.Text = i.ToString();
                    tmp.SubItems.Add(txtTenSach.Text);
                    tmp.SubItems.Add(lsvSach.SelectedItems[0].SubItems[2].Text);
                    tmp.SubItems.Add(numSoLuong.Value.ToString());
                    tmp.Tag = Convert.ToInt32(txtMaSach.Text);
                    lsvChiTiet.Items.Add(tmp);
                    total += Convert.ToInt32(tmp.SubItems[2].Text) * float.Parse(tmp.SubItems[3].Text);
                    CultureInfo culture = new CultureInfo("vi-VN");
                    lblTongTien.Text = total.ToString("c0", culture);
                    numSoLuong.Value = 0;
                    LamMoi();
                    btnHuyHoaDon.Enabled = true;
                    btnThanhToan.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void lsvChiTiet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvChiTiet.SelectedItems.Count > 0)
            {
                btnXoaSach.Enabled = true;
                LamMoi();

            }
            else
            {
                btnXoaSach.Enabled = false;
            }

        }

        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvChiTiet.SelectedItems.Count > 0)
                {
                    total -= Convert.ToInt32(lsvChiTiet.SelectedItems[0].SubItems[2].Text) *
                             float.Parse(lsvChiTiet.SelectedItems[0].SubItems[3].Text);
                    CultureInfo info = new CultureInfo("vi-VN");
                    lblTongTien.Text = total.ToString("c0", info);
                    lsvChiTiet.SelectedItems[0].Remove();
                    if (lsvChiTiet.Items.Count <= 0)
                    {
                        btnHuyHoaDon.Enabled = false;
                        btnThanhToan.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                lsvChiTiet.Items.Clear();
                total = 0;
                CultureInfo info = new CultureInfo("vi-VN");
                lblTongTien.Text = total.ToString("c0", info);
                btnHuyHoaDon.Enabled = false;
                btnXoaSach.Enabled = false;
                btnThanhToan.Enabled = false;
                numGiamGia.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn thanh toán cho Hóa đơn này không?", "Thông báo",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (clsHoaDonBLL.Instance.ThemHoaDon(DateTime.Today, (int) numGiamGia.Value, nv.MaNV))
                    {
                        int mahd = clsHoaDonBLL.Instance.LayMaHDMoiNhat();
                        foreach (ListViewItem item in lsvChiTiet.Items)
                        {
                            clsChiTietHoaDonBLL.Instance.ThemChiTietHD(mahd, (int) item.Tag,
                                Convert.ToInt32(item.SubItems[3].Text));
                        }

                        frmMain.notiIcon.ShowBalloonTip(1200, "BookShop Management", "Thêm Hóa đơn thành công.",
                            ToolTipIcon.Info);
                        MessageBox.Show("Thêm Hóa đơn thành công", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        if (MessageBox.Show("Bạn có muốn In Hóa đơn này?", "Thông báo", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            using (frmBaoCao f = new frmBaoCao())
                            {
                                try
                                {
                                    DataTable dt = new DataTable();
                                    HoaDon hd = clsHoaDonBLL.Instance.LayHoaDonTheoMa(mahd);
                                    dt = clsChiTietHoaDonBLL.Instance.BaoCaoHoaDonTheoMa(hd.MaHD);
                                    f.Text = "HÓA ĐƠN BÁN HÀNG";
                                    f.rptBaoCao.ProcessingMode = ProcessingMode.Local;
                                    f.rptBaoCao.LocalReport.ReportPath = "Report\\rptHoaDonBan.rdlc";
                                    ReportParameter[] rp = new ReportParameter[]
                                    {
                                        new ReportParameter("mahd", mahd.ToString()),
                                        new ReportParameter("giamgia", hd.GiamGia.ToString()),
                                        new ReportParameter("hoten", clsNhanVienBLL.Instance.LayTenNVTheoMa(hd.MaNV)),
                                        new ReportParameter("ngayban", hd.NgayBan.ToString("dd/MM/yyyy"))
                                    };
                                    f.rptBaoCao.LocalReport.SetParameters(rp);
                                    ReportDataSource rds = new ReportDataSource();
                                    rds.Name = "HoaDonBan";
                                    rds.Value = dt;
                                    f.rptBaoCao.LocalReport.DataSources.Add(rds);
                                    f.rptBaoCao.RefreshReport();
                                    f.ShowDialog();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                                }
                            }
                        }
                        btnHuyHoaDon.PerformClick();
                        TimDSSach();
                        numGiamGia.Value = 0;
                    }
                    else
                    {
                        MessageBox.Show("Thêm Hóa đơn thất bại", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }

                lsvSach.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnXemHD_Click(object sender, EventArgs e)
        {
            XemChiTietHD();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                TimDSSach();
                return;
            }

            if (tabControl1.SelectedIndex == 1)
            {
                LayDSHoaDon();
                return;
            }
        }

        private void numGiamGia_ValueChanged(object sender, EventArgs e)
        {
            CultureInfo info = new CultureInfo("vi-VN");
            lblTongTien.Text = (total * (100 - (int)numGiamGia.Value) / 100).ToString("c0",info);
        }

        private void dtpFrmDate_ValueChanged(object sender, EventArgs e)
        {
            LayDSHoaDon();
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            LayDSHoaDon();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmBaoCao f = new frmBaoCao())
                {
                    try
                    {
                        f.Text = "HÓA ĐƠN BÁN HÀNG";
                        int mahd = Convert.ToInt32(lsvHoaDon.SelectedItems[0].Text);
                        DataTable dt = new DataTable();
                        HoaDon hd = clsHoaDonBLL.Instance.LayHoaDonTheoMa(mahd);
                        dt = clsChiTietHoaDonBLL.Instance.BaoCaoHoaDonTheoMa(hd.MaHD);
                        f.rptBaoCao.ProcessingMode = ProcessingMode.Local;
                        f.rptBaoCao.LocalReport.ReportPath = "Report\\rptHoaDonBan.rdlc";
                        ReportParameter[] rp = new ReportParameter[]
                        {
                            new ReportParameter("mahd", mahd.ToString()),
                            new ReportParameter("giamgia", hd.GiamGia.ToString()),
                            new ReportParameter("hoten", clsNhanVienBLL.Instance.LayTenNVTheoMa(hd.MaNV)),
                            new ReportParameter("ngayban", hd.NgayBan.ToString("dd/MM/yyyy"))
                        };
                        f.rptBaoCao.LocalReport.SetParameters(rp);
                        ReportDataSource rds = new ReportDataSource();
                        rds.Name = "HoaDonBan";
                        rds.Value = dt;
                        f.rptBaoCao.LocalReport.DataSources.Add(rds);
                        f.rptBaoCao.RefreshReport();
                        f.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void lsvHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvHoaDon.SelectedItems.Count > 0)
            {
                btnIn.Enabled = btnHD.Enabled = mnsMain.Enabled = true;
            }
            else
            {
                btnIn.Enabled = btnHD.Enabled = mnsMain.Enabled = false;
            }
        }

        private void tsiXem_Click(object sender, EventArgs e)
        {
            XemChiTietHD();
        }

        private void tsiIn_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmBaoCao f = new frmBaoCao())
                {
                    try
                    {
                        f.Text = "HÓA ĐƠN BÁN HÀNG";
                        int mahd = Convert.ToInt32(lsvHoaDon.SelectedItems[0].Text);
                        DataTable dt = new DataTable();
                        HoaDon hd = clsHoaDonBLL.Instance.LayHoaDonTheoMa(mahd);
                        dt = clsChiTietHoaDonBLL.Instance.BaoCaoHoaDonTheoMa(hd.MaHD);
                        f.rptBaoCao.ProcessingMode = ProcessingMode.Local;
                        f.rptBaoCao.LocalReport.ReportPath = "Report\\rptHoaDonBan.rdlc";
                        ReportParameter[] rp = new ReportParameter[]
                        {
                            new ReportParameter("mahd", mahd.ToString()),
                            new ReportParameter("giamgia", hd.GiamGia.ToString()),
                            new ReportParameter("hoten", clsNhanVienBLL.Instance.LayTenNVTheoMa(hd.MaNV)),
                            new ReportParameter("ngayban", hd.NgayBan.ToString("dd/MM/yyyy"))
                        };
                        f.rptBaoCao.LocalReport.SetParameters(rp);
                        ReportDataSource rds = new ReportDataSource();
                        rds.Name = "HoaDonBan";
                        rds.Value = dt;
                        f.rptBaoCao.LocalReport.DataSources.Add(rds);
                        f.rptBaoCao.RefreshReport();
                        f.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void mnsMain_Opening(object sender, CancelEventArgs e)
        {
            if (lsvHoaDon.SelectedItems.Count > 0)
            {
                mnsMain.Enabled = true;
            }
            else
            {
                mnsMain.Enabled = false;
            }
        }

        private void lsvHoaDon_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Get the new sorting column.
            ColumnHeader new_sorting_column = lsvHoaDon.Columns[e.Column];

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
            lsvHoaDon.ListViewItemSorter =
                new ListViewComparer(e.Column, sort_order);

            // Sort.
            lsvHoaDon.Sort();
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
    }
}
