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
using Microsoft.Reporting.WinForms;
using SortOrder = System.Data.SqlClient.SortOrder;

namespace GUI
{
    public partial class frmPhieuNhap : Form
    {
        private ColumnHeader SortingColumn = null;
        private NhanVien nv;
        private float total = 0;
        public frmPhieuNhap(NhanVien nv)
        {
            this.nv = nv;
            InitializeComponent();
        }

        private void ChiTietPhieuNhap()
        {
            using (frmChiTietPhieuNhap f = new frmChiTietPhieuNhap(Convert.ToInt32(lsvPhieuNhap.SelectedItems[0].Text)))
            {
                f.ShowDialog();
            }
        }

        private void LayDSPhieuNhap()
        {
            try
            {
                lsvPhieuNhap.SelectedItems.Clear();
                lsvPhieuNhap.Items.Clear();
                List<PhieuNhap> dsPN = new List<PhieuNhap>();
                dsPN = clsPhieuNhapBLL.Instance.LayDSPhieuNhap(nv.MaNV, dtpFrmDate.Value, dtpToDate.Value);
                if (dsPN != null)
                {
                    CultureInfo info = new CultureInfo("vi-VN");
                    foreach (PhieuNhap pn in dsPN)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = pn.MaPN.ToString();
                        item.SubItems.Add(clsNhanVienBLL.Instance.LayTenNVTheoMa(pn.MaNV));
                        item.SubItems.Add(pn.NgayNhap.ToString("dd-MM-yyyy"));
                        item.SubItems.Add(clsChiTietPhieuNhapBLL.Instance.LaySoLuongSachTheoMaPN(pn.MaPN).ToString());
                        item.SubItems.Add(clsChiTietPhieuNhapBLL.Instance.TinhTongTienTheoMaPN(pn.MaPN)
                            .ToString("c0", info));
                        lsvPhieuNhap.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LamMoi()
        {
            txtMaSach.Text = txtTenSach.Text = "";
            lsvSach.SelectedItems.Clear();
        }

        private void DatNgay()
        {
            dtpFrmDate.Value = DateTime.Today.AddDays(-1);
            dtpToDate.Value = DateTime.Today;
        }

        private void TienViet()
        {
            CultureInfo info = new CultureInfo("vi-VN");
            lblTongTien.Text = 0.ToString("c0", info);
        }

        private void CaiDatMacDinh()
        {
            btnThemSach.Enabled = false;
            btnThanhToan.Enabled = false;
            btnHuyPN.Enabled = false;
            btnXoaSach.Enabled = false;
        }

        private void TimDSSach()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            TimDSSach();
            CaiDatMacDinh();
            TienViet();
            DatNgay();
            LayDSPhieuNhap();
        }

        private void txtTimSach_TextChanged(object sender, EventArgs e)
        {
            TimDSSach();
        }

        private void btnTimSach_Click(object sender, EventArgs e)
        {
            TimDSSach();
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
                            btnHuyPN.Enabled = true;
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
                    btnHuyPN.Enabled = true;
                    btnThanhToan.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                        btnHuyPN.Enabled = false;
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
            lsvChiTiet.Items.Clear();
            total = 0;
            CultureInfo info = new CultureInfo("vi-VN");
            lblTongTien.Text = total.ToString("c0", info);
            btnHuyPN.Enabled = false;
            btnXoaSach.Enabled = false;
            btnThanhToan.Enabled = false;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn thêm Phiếu nhập này vào hệ thống?", "Thông báo",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (clsPhieuNhapBLL.Instance.ThemPhieuNhap(DateTime.Today, nv.MaNV))
                    {
                        int mapn = clsPhieuNhapBLL.Instance.LayMaPNMoiNhat();
                        foreach (ListViewItem item in lsvChiTiet.Items)
                        {
                            clsChiTietPhieuNhapBLL.Instance.ThemChiTietPhieuNhap(mapn, (int) item.Tag,
                                Convert.ToInt32(item.SubItems[3].Text));
                        }

                        frmMain.notiIcon.ShowBalloonTip(1500, "BookShop Management", "Thêm Phiếu nhập thành công.",
                            ToolTipIcon.Info);
                        MessageBox.Show("Thêm Phiếu nhập thành công", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        if (MessageBox.Show("Bạn có muốn In Phiếu nhập này?", "Thông báo", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            using (frmBaoCao f = new frmBaoCao())
                            {
                                try
                                {
                                    DataTable dt = new DataTable();
                                    PhieuNhap pn = clsPhieuNhapBLL.Instance.LayPhieuNhapTheoMa(mapn);
                                    dt = clsChiTietPhieuNhapBLL.Instance.BaoCaoPhieuNhapTheoMa(pn.MaPN);
                                    f.rptBaoCao.ProcessingMode = ProcessingMode.Local;
                                    f.rptBaoCao.LocalReport.ReportPath = "Report\\rptPhieuNhapSach.rdlc";
                                    ReportParameter[] rp = new ReportParameter[]
                                    {
                                        new ReportParameter("mapn", mapn.ToString()),
                                        new ReportParameter("hoten", clsNhanVienBLL.Instance.LayTenNVTheoMa(pn.MaNV)),
                                        new ReportParameter("ngaynhap", pn.NgayNhap.ToString("dd/MM/yyyy"))
                                    };
                                    f.rptBaoCao.LocalReport.SetParameters(rp);
                                    ReportDataSource rds = new ReportDataSource();
                                    rds.Name = "PhieuNhapSach";
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

                        btnHuyPN.PerformClick();
                        TimDSSach();

                    }
                    else
                    {
                        MessageBox.Show("Thêm Hóa đơn thất bại", "Thông báo", MessageBoxButtons.OK,
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                TimDSSach();
                return;
            }

            if (tabControl1.SelectedIndex == 1)
            {
                LayDSPhieuNhap();
            }
        }

        private void dtpFrmDate_ValueChanged(object sender, EventArgs e)
        {
            LayDSPhieuNhap();
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            LayDSPhieuNhap();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmBaoCao f = new frmBaoCao())
                {
                    try
                    {
                        f.Text = "BÁO CÁO PHIẾU NHẬP SÁCH";
                        DataTable dt = new DataTable();
                        PhieuNhap pn =
                            clsPhieuNhapBLL.Instance.LayPhieuNhapTheoMa(
                                Convert.ToInt32(lsvPhieuNhap.SelectedItems[0].Text));
                        dt = clsChiTietPhieuNhapBLL.Instance.BaoCaoPhieuNhapTheoMa(pn.MaPN);
                        f.rptBaoCao.ProcessingMode = ProcessingMode.Local;
                        f.rptBaoCao.LocalReport.ReportPath = "Report\\rptPhieuNhapSach.rdlc";
                        ReportParameter[] rp = new ReportParameter[]
                        {
                            new ReportParameter("mapn", pn.MaPN.ToString()),
                            new ReportParameter("hoten", clsNhanVienBLL.Instance.LayTenNVTheoMa(pn.MaNV)),
                            new ReportParameter("ngaynhap", pn.NgayNhap.ToString("dd/MM/yyyy"))
                        };
                        f.rptBaoCao.LocalReport.SetParameters(rp);
                        ReportDataSource rds = new ReportDataSource();
                        rds.Name = "PhieuNhapSach";
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

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            ChiTietPhieuNhap();
        }

        private void lsvPhieuNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvPhieuNhap.SelectedItems.Count > 0)
            {
                btnXemChiTiet.Enabled = btnIn.Enabled = true;
            }
            else
            {
                btnXemChiTiet.Enabled = btnIn.Enabled = false;
            }
        }

        private void tsiXem_Click(object sender, EventArgs e)
        {
            ChiTietPhieuNhap();
        }

        private void tsiIn_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmBaoCao f = new frmBaoCao())
                {
                    try
                    {
                        f.Text = "BÁO CÁO PHIẾU NHẬP SÁCH";
                        DataTable dt = new DataTable();
                        PhieuNhap pn =
                            clsPhieuNhapBLL.Instance.LayPhieuNhapTheoMa(
                                Convert.ToInt32(lsvPhieuNhap.SelectedItems[0].Text));
                        dt = clsChiTietPhieuNhapBLL.Instance.BaoCaoPhieuNhapTheoMa(pn.MaPN);
                        f.rptBaoCao.ProcessingMode = ProcessingMode.Local;
                        f.rptBaoCao.LocalReport.ReportPath = "Report\\rptPhieuNhapSach.rdlc";
                        ReportParameter[] rp = new ReportParameter[]
                        {
                            new ReportParameter("mapn", pn.MaPN.ToString()),
                            new ReportParameter("hoten", clsNhanVienBLL.Instance.LayTenNVTheoMa(pn.MaNV)),
                            new ReportParameter("ngaynhap", pn.NgayNhap.ToString("dd/MM/yyyy"))
                        };
                        f.rptBaoCao.LocalReport.SetParameters(rp);
                        ReportDataSource rds = new ReportDataSource();
                        rds.Name = "PhieuNhapSach";
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
            if (lsvPhieuNhap.SelectedItems.Count > 0)
            {
                mnsMain.Enabled = true;
            }
            else
            {
                mnsMain.Enabled = false;
            }
        }

        private void lsvPhieuNhap_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Get the new sorting column.
            ColumnHeader new_sorting_column = lsvPhieuNhap.Columns[e.Column];

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
            lsvPhieuNhap.ListViewItemSorter =
                new ListViewComparer(e.Column, sort_order);

            // Sort.
            lsvPhieuNhap.Sort();
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
