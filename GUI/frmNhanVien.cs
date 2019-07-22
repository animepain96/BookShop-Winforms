using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using GUI.Custom;

namespace GUI
{
    public partial class frmNhanVien : Form
    {
        private int manv;
        private ColumnHeader SortingColumn = null;
        public frmNhanVien(int manv)
        {
            this.manv = manv;
            InitializeComponent();
        }

        private void PhanQuyen()
        {
            if (manv != 1)
            {
                tabNhanVien.TabPages.Remove(tabQLQuyen);
            }
        }

        private void TimDSPhanQuyen()
        {
            try
            {
                lsvQuyen.Items.Clear();
                List<PhanQuyen> dsPQ = new List<PhanQuyen>();
                dsPQ = clsPhanQuyenBLL.Instance.TimDSPhanQuyen(txt_TimNV.Text);
                if (dsPQ != null)
                {
                    foreach (PhanQuyen pq in dsPQ)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = pq.MaNV.ToString();
                        NhanVien _nv = clsNhanVienBLL.Instance.LayNVTheoMa(pq.MaNV);
                        item.SubItems.Add(_nv.TenDangNhap);
                        item.SubItems.Add(_nv.HoTen);
                        item.SubItems.Add(clsQuyenBLL.Instance.LayTenQuyenTheoMa(pq.MaQuyen));
                        item.Tag = pq.MaQuyen;
                        lsvQuyen.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LamMoiQuyen()
        {
            try
            {
                txt_MaNV.Text = txt_TenNV.Text = "";
                cmb_Quyen.SelectedIndex = 0;
                lsvQuyen.SelectedItems.Clear();
                btn_SuaQuyen.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CoTheSuaQuyen(bool check)
        {
            btn_SuaQuyen.Enabled = check;
        }

        private void LoadQuyen()
        {
            try
            {
                List<Quyen> dsQ = new List<Quyen>();
                dsQ = clsQuyenBLL.Instance.LayDSQuyen();
                cmb_Quyen.DataSource = dsQ;
                cmb_Quyen.DisplayMember = "TenQuyen";
                cmb_Quyen.ValueMember = "MaQuyen";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadPhanQuyen()
        {
            try
            {
                lsvQuyen.Items.Clear();
                List<PhanQuyen> dsPQ = new List<PhanQuyen>();
                dsPQ = clsPhanQuyenBLL.Instance.LayDSPhanQuyen();
                if (dsPQ != null)
                {
                    foreach (PhanQuyen pq in dsPQ)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = pq.MaNV.ToString();
                        NhanVien _nv = clsNhanVienBLL.Instance.LayNVTheoMa(pq.MaNV);
                        item.SubItems.Add(_nv.TenDangNhap);
                        item.SubItems.Add(_nv.HoTen);
                        item.SubItems.Add(clsQuyenBLL.Instance.LayTenQuyenTheoMa(pq.MaQuyen));
                        item.Tag = pq.MaQuyen;
                        lsvQuyen.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void TimnDSNhanVien(string chuoi)
        {
            try
            {
                lsvNhanVien.Items.Clear();
                List<NhanVien> dsNV = new List<NhanVien>();
                dsNV = clsNhanVienBLL.Instance.TimNhanVien(manv, chuoi);
                if (dsNV != null)
                {
                    foreach (NhanVien nv in dsNV)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = nv.MaNV.ToString();
                        item.SubItems.Add(nv.TenDangNhap);
                        item.SubItems.Add(nv.HoTen);
                        item.SubItems.Add(nv.NgaySinh.ToString("dd-MM-yyyy"));
                        string gt;
                        if (nv.GioiTinh)
                        {
                            gt = "Nam";
                        }
                        else
                        {
                            gt = "Nữ";
                        }
                        item.SubItems.Add(gt);
                        item.SubItems.Add(nv.SDT);
                        item.SubItems.Add(nv.DiaChi);
                        item.Tag = nv.MaNV;
                        lsvNhanVien.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CoTheSua(bool check)
        {
            if (check)
            {
                txtTenDangNhap.Enabled = txtHoTen.Enabled = radNam.Enabled =
                    radNu.Enabled = dtpNgaySinh.Enabled = txtSDT.Enabled = txtDiaChi.Enabled = true;
            }
            btnSuaNV.Enabled = btnXoaNV.Enabled = check;
        }

        private void CoTheThem(bool check)
        {
            if (check)
            {
                LamMoi();
                btnThemNV.Text = "Lưu";
                btnLMNV.Text = "Hủy";
                txtTenDangNhap.Enabled = txtHoTen.Enabled = radNam.Enabled =
                    radNu.Enabled = dtpNgaySinh.Enabled = txtSDT.Enabled = txtDiaChi.Enabled = true;
            }
            else
            {
                btnThemNV.Text = "Thêm";
                btnLMNV.Text = "Làm mới";
                txtTenDangNhap.Enabled = txtHoTen.Enabled = radNam.Enabled =
                    radNu.Enabled = dtpNgaySinh.Enabled = txtSDT.Enabled = txtDiaChi.Enabled = false;
            }
        }

        private void LamMoi()
        {
            txtMaNV.Text = txtTenDangNhap.Text = txtHoTen.Text = txtDiaChi.Text = txtSDT.Text = "";
            dtpNgaySinh.Value = DateTime.Today;
            radNam.Checked = radNu.Checked = false;
            lsvNhanVien.SelectedItems.Clear();
            CoTheSua(false);
            CoTheThem(false);
        }

        private void LoadNhanVien()
        {
            try
            {
                lsvNhanVien.Items.Clear();
                List<NhanVien> dsNV = new List<NhanVien>();
                dsNV = clsNhanVienBLL.Instance.LayDSNhanVien(manv);
                if (dsNV != null)
                {
                    foreach (NhanVien nv in dsNV)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = nv.MaNV.ToString();
                        item.SubItems.Add(nv.TenDangNhap);
                        item.SubItems.Add(nv.HoTen);
                        item.SubItems.Add(nv.NgaySinh.ToString("dd-MM-yyyy"));
                        string gt;
                        if (nv.GioiTinh)
                        {
                            gt = "Nam";
                        }
                        else
                        {
                            gt = "Nữ";
                        }

                        item.SubItems.Add(gt);
                        item.SubItems.Add(nv.SDT);
                        item.SubItems.Add(nv.DiaChi);
                        item.Tag = nv.MaNV;
                        lsvNhanVien.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            LoadNhanVien();
            LoadPhanQuyen();
            LoadQuyen();
        }

        private void CaiDatMacDinh()
        {
            CoTheSua(false);
            CoTheThem(false);
            CoTheSuaQuyen(false);
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            PhanQuyen();
            LoadData();
            CaiDatMacDinh();
        }

        private void lsvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNhanVien.SelectedItems.Count > 0)
            {
                ListViewItem item = lsvNhanVien.SelectedItems[0];
                txtMaNV.Text = item.Text;
                txtTenDangNhap.Text = item.SubItems[1].Text;
                txtHoTen.Text = item.SubItems[2].Text;
                if (item.SubItems[4].Text == "Nam")
                {
                    radNam.Checked = true;
                }
                else
                {
                    radNu.Checked = true;
                }
                dtpNgaySinh.Value = DateTime.ParseExact(item.SubItems[3].Text, "dd-MM-yyyy", null);
                txtSDT.Text = item.SubItems[5].Text;
                txtDiaChi.Text = item.SubItems[6].Text;
                CoTheThem(false);
                CoTheSua(true);
            }
            else
            {
                LamMoi();
            }
        }

        private void btnLMNV_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnThemNV.Text == "Thêm")
                {
                    CoTheThem(true);
                    CoTheSua(false);
                    txtTenDangNhap.Focus();
                }
                else
                {
                    if (txtTenDangNhap.Text != "" && txtHoTen.Text != "" && (radNam.Checked || radNu.Checked) &&
                        txtSDT.Text != "" && txtDiaChi.Text != "")
                    {
                        if (MessageBox.Show("Bạn có muốn thêm Nhân viên này?", "Thông báo", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            if (clsNhanVienBLL.Instance.ThemNhanVien(txtTenDangNhap.Text, txtHoTen.Text,
                                dtpNgaySinh.Value,
                                radNam.Checked, txtSDT.Text, txtDiaChi.Text))
                            {
                                MessageBox.Show("Thêm Nhân viên thành công", "Thông báo", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                CoTheThem(false);
                                CoTheSua(false);
                                LamMoi();
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvNhanVien.SelectedItems.Count > 0 && txtMaNV.Text != "")
                {
                    if (txtMaNV.Text != "" && txtTenDangNhap.Text != "" && txtHoTen.Text != "" &&
                        (radNam.Checked == true || radNu.Checked == true) && txtSDT.Text != "" && txtDiaChi.Text != "")
                    {
                        if (MessageBox.Show("Bạn có muốn sửa thông tin Nhân viên này không?", "Thông báo",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (clsNhanVienBLL.Instance.CapNhatNhanVien(Convert.ToInt32(txtMaNV.Text),
                                txtTenDangNhap.Text,
                                txtHoTen.Text, dtpNgaySinh.Value, radNam.Checked == true, txtSDT.Text, txtDiaChi.Text))
                            {
                                MessageBox.Show("Cập nhật thông tin Nhân viên thành công", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CoTheSua(false);
                                CoTheThem(false);
                                LamMoi();
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvNhanVien.SelectedItems.Count > 0 && txtMaNV.Text != "")
                {
                    if (MessageBox.Show("Bạn có muốn xóa Nhân viên này không?", "Thông báo",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (clsNhanVienBLL.Instance.XoaNhanVien(Convert.ToInt32(txtMaNV.Text)))
                        {
                            MessageBox.Show("Xóa Nhân viên thành công", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CoTheSua(false);
                            CoTheThem(false);
                            LamMoi();
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnTimNV_Click(object sender, EventArgs e)
        {
            TimnDSNhanVien(txtTimNV.Text);
        }

        private void txtTimNV_TextChanged(object sender, EventArgs e)
        {
            TimnDSNhanVien(txtTimNV.Text);
        }

        private void btnDatLaiMK_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvNhanVien.SelectedItems.Count > 0 && txtMaNV.Text != "")
                {
                    if (MessageBox.Show("Bạn có muốn đặt lại mật khẩu mặc định cho Nhân viên này?", "Thông báo",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (clsNhanVienBLL.Instance.MatKhauMacDinh(Convert.ToInt32(txtMaNV.Text)))
                        {
                            MessageBox.Show("Đặt lại mật khẩu mặc định thành công", "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Đặt lại mật khẩu thất bại", "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không có Nhân viên nào được chọn", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void lsvQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvQuyen.SelectedItems.Count > 0)
            {
                txt_MaNV.Text = lsvQuyen.SelectedItems[0].Text;
                txt_TenNV.Text = lsvQuyen.SelectedItems[0].SubItems[1].Text;
                cmb_Quyen.SelectedValue = (int) lsvQuyen.SelectedItems[0].Tag;
                CoTheSuaQuyen(true);
            }
            else
            {
                LamMoiQuyen();
            }
        }

        private void btn_SuaQuyen_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvQuyen.SelectedItems.Count > 0 && txt_MaNV.Text != "")
                {
                    if (MessageBox.Show("Bạn có muốn sửa đổi Quyền cho Nhân viên này?", "Thông báo",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (clsPhanQuyenBLL.Instance.SuaDoiQuyen(Convert.ToInt32(txt_MaNV.Text),
                            (int) cmb_Quyen.SelectedValue))
                        {
                            MessageBox.Show("Sửa đổi Quyền thành công", "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            LoadPhanQuyen();
                            CoTheSuaQuyen(false);
                            LamMoiQuyen();
                        }
                        else
                        {
                            MessageBox.Show("Sửa đổi Quyền thất bại", "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập tất cả thông tin", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btn_LMNV_Click(object sender, EventArgs e)
        {
            LamMoiQuyen();
            CoTheSuaQuyen(false);
        }

        private void btn_TimNV_Click(object sender, EventArgs e)
        {
            LamMoiQuyen();
            CoTheSuaQuyen(false);
            TimDSPhanQuyen();
        }

        private void txt_TimNV_TextChanged(object sender, EventArgs e)
        {
            LamMoiQuyen();
            CoTheSuaQuyen(false);
            TimDSPhanQuyen();
        }

        private void lsvNhanVien_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Get the new sorting column.
            ColumnHeader new_sorting_column = lsvNhanVien.Columns[e.Column];

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
            lsvNhanVien.ListViewItemSorter =
                new ListViewComparer(e.Column, sort_order);

            // Sort.
            lsvNhanVien.Sort();
        }

        private void lsvQuyen_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Get the new sorting column.
            ColumnHeader new_sorting_column = lsvQuyen.Columns[e.Column];

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
            lsvQuyen.ListViewItemSorter =
                new ListViewComparer(e.Column, sort_order);

            // Sort.
            lsvQuyen.Sort();
        }
    }
}
