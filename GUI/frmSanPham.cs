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
using GUI.Custom;

namespace GUI
{
    public partial class frmSanPham : Form
    {
        private string savepath = "";
        private ColumnHeader SortingColumn = null;
        public frmSanPham()
        {
            InitializeComponent();
        }

        private bool ExportBookToExcel()
        {
            return ExcelHelper.ExportBookToExcel(clsSachBLL.Instance.LayDSSachChiTiet(),
                savepath + "\\DanhSachSach_" + DateTime.Today.ToString("dd-MM-yyyy") + ".xlsx");
        }

        private void CoTheThemTG(bool check)
        {
            if (check)
            {
                LamMoiTG();
                btnThemTG.Text = "Lưu";
                btnLMTG.Text = "Hủy";
                txtTenTG.Enabled = txtDiaChiTG.Enabled = txtSDT.Enabled = true;
            }
            else
            {
                btnThemTG.Text = "Thêm";
                btnLMTG.Text = "Làm mới";
                txtTenTG.Enabled = txtDiaChiTG.Enabled = txtSDT.Enabled = false;
            }
        }

        private void CoTheThemTL(bool check)
        {
            if (check)
            {
                LamMoiTL();
                btnThemTL.Text = "Lưu";
                btnLMTL.Text = "Hủy";
                txtTenTL.Enabled = true;
            }
            else
            {
                btnThemTL.Text = "Thêm";
                btnLMTL.Text = "Làm mới";
                txtTenTL.Enabled = false;
            }
        }

        private void CoTheThemNXB(bool check)
        {
            if (check)
            {
                LamMoiNXB();
                btnThemNXB.Text = "Lưu";
                btnLMNXB.Text = "Hủy";
                txtTenNXB.Enabled = txtDiaChi.Enabled = true;
            }
            else
            {
                btnThemNXB.Text = "Thêm";
                btnLMNXB.Text = "Làm mới";
                txtTenNXB.Enabled = txtDiaChi.Enabled = false;
            }
        }

        private void CoTheThemSach(bool check)
        {
            if (check)
            {
                LamMoiSach();
                btnThemSach.Text = "Lưu";
                btnLMSach.Text = "Hủy";
                txtTenSach.Enabled = numGiaBan.Enabled = numSoLuong.Enabled = 
                    numNamXB.Enabled = cmbNXB.Enabled = cmbTL.Enabled = cmbTG.Enabled = true;
            }
            else
            {
                btnThemSach.Text = "Thêm";
                btnLMSach.Text = "Làm mới";
                txtTenSach.Enabled = numGiaBan.Enabled = numSoLuong.Enabled =
                    numNamXB.Enabled = cmbNXB.Enabled = cmbTL.Enabled = cmbTG.Enabled = false;
            }
        }

        private void CoTheSuaTG(bool check)
        {
            if (check)
            {
                txtTenTG.Enabled = txtDiaChiTG.Enabled = txtSDT.Enabled = true;
            }
            btnSuaTG.Enabled = btnXoaTG.Enabled = check;
        }

        private void CoTheSuaTL(bool check)
        {
            if (check)
            {
                txtTenTL.Enabled = true;
            }
            btnSuaTL.Enabled = btnXoaTL.Enabled = check;
        }

        private void CoTheSuaNXB(bool check)
        {
            if (check)
            {
                txtTenNXB.Enabled = txtDiaChi.Enabled = true;
            }
            btnSuaNXB.Enabled = btnXoaNXB.Enabled = check;
        }

        private void CoTheSuaSach(bool check)
        {
            if (check)
            {
                txtTenSach.Enabled = numGiaBan.Enabled = numSoLuong.Enabled =
                    numNamXB.Enabled = cmbNXB.Enabled = cmbTL.Enabled = cmbTG.Enabled = true;
            }
            btnSuaSach.Enabled = btnXoaSach.Enabled = check;
        }

        private void CaiDatMacDinh()
        {
            CoTheSuaSach(false);
            CoTheSuaNXB(false);
            CoTheSuaTL(false);
            CoTheSuaTG(false);
        }

        private void LamMoiTG()
        {
            txtMaTG.Text = txtTenTG.Text = txtSDT.Text = txtDiaChiTG.Text = "";
            lsvTacGia.SelectedItems.Clear();
            CoTheSuaTG(false);
            CoTheThemTG(false);
        }

        private void LamMoiTL()
        {
            txtMaTL.Text = txtTenTL.Text = "";
            lsvTheLoai.SelectedItems.Clear();
            CoTheSuaTL(false);
            CoTheThemTL(false);
        }

        private void LamMoiNXB()
        {
            txtMaNXB.Text = txtTenNXB.Text = txtDiaChi.Text = "";
            lsvNXB.SelectedItems.Clear();
            CoTheSuaNXB(false);
            CoTheThemNXB(false);
        }

        private void LamMoiSach()
        {
            txtMaSach.Text = txtTenSach.Text = "";
            numSoLuong.Value = numGiaBan.Value = 0;
            numNamXB.Value = DateTime.Today.Year;
            cmbNXB.SelectedIndex = cmbTL.SelectedIndex = cmbTG.SelectedIndex = -1;
            lsvSach.SelectedItems.Clear();
            CoTheSuaSach(false);
            CoTheThemSach(false);
        }

        private void TaiDuLieuLenCMB()
        {
            try
            {
                List<NhaXuatBan> dsNXB = clsNhaXuatBanBLL.Instance.LayDSNhaXuatBan();
                List<TheLoai> dsTL = clsTheLoaiBLL.Instance.LayDSTheLoai();
                List<TacGia> dsTG = clsTacGiaBLL.Instance.LayDSTacGia();
                cmbNXB.DataSource = dsNXB;
                cmbNXB.DisplayMember = "TenNXB";
                cmbNXB.ValueMember = "MaNXB";
                cmbTL.DataSource = dsTL;
                cmbTL.DisplayMember = "TenTL";
                cmbTL.ValueMember = "MaTL";
                cmbTG.DataSource = dsTG;
                cmbTG.DisplayMember = "TenTG";
                cmbTG.ValueMember = "MaTG";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void TimDSTacGia()
        {
            try
            {
                lsvTacGia.Items.Clear();
                List<TacGia> dsTG = new List<TacGia>();
                dsTG = clsTacGiaBLL.Instance.TimDSTacGia(txtTimTG.Text);
                if (dsTG != null)
                {
                    foreach (TacGia tg in dsTG)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = tg.MaTG.ToString();
                        item.SubItems.Add(tg.TenTG);
                        item.SubItems.Add(tg.SDT);
                        item.SubItems.Add(tg.DiaChi);
                        item.Tag = tg.MaTG;
                        lsvTacGia.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LayDSTacGia()
        {
            try
            {
                lsvTacGia.Items.Clear();
                List<TacGia> dsTG = new List<TacGia>();
                dsTG = clsTacGiaBLL.Instance.LayDSTacGia();
                if (dsTG != null)
                {
                    foreach (TacGia tg in dsTG)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = tg.MaTG.ToString();
                        item.SubItems.Add(tg.TenTG);
                        item.SubItems.Add(tg.SDT);
                        item.SubItems.Add(tg.DiaChi);
                        item.Tag = tg.MaTG;
                        lsvTacGia.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void TimDSTheLoai()
        {
            try
            {
                lsvTheLoai.Items.Clear();
                List<TheLoai> dsTL = new List<TheLoai>();
                dsTL = clsTheLoaiBLL.Instance.TimDSTheLoai(txtTimTL.Text);
                if (dsTL != null)
                {
                    foreach (TheLoai tl in dsTL)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = tl.MaTL.ToString();
                        item.SubItems.Add(tl.TenTL);
                        item.Tag = tl.MaTL;
                        lsvTheLoai.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LayDSTheLoai()
        {
            try
            {
                lsvTheLoai.Items.Clear();
                List<TheLoai> dsTL = new List<TheLoai>();
                dsTL = clsTheLoaiBLL.Instance.LayDSTheLoai();
                if (dsTL != null)
                {
                    foreach (TheLoai tl in dsTL)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = tl.MaTL.ToString();
                        item.SubItems.Add(tl.TenTL);
                        item.Tag = tl.MaTL;
                        lsvTheLoai.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LayDanhSachNXB()
        {
            try
            {
                lsvNXB.Items.Clear();
                List<NhaXuatBan> dsNXB = new List<NhaXuatBan>();
                dsNXB = clsNhaXuatBanBLL.Instance.LayDSNhaXuatBan();
                if (dsNXB != null)
                {
                    foreach (NhaXuatBan nxb in dsNXB)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = nxb.MaNXB.ToString();
                        item.SubItems.Add(nxb.TenNXB);
                        item.SubItems.Add(nxb.DiaChi);
                        item.Tag = nxb.MaNXB;
                        lsvNXB.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LayDSSach()
        {
            try
            {
                lsvSach.Items.Clear();
                List<Sach> dsS = new List<Sach>();
                dsS = clsSachBLL.Instance.LayDSSach();
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

        private void TimDSNhaXuatBan()
        {
            try
            {
                lsvNXB.Items.Clear();
                List<NhaXuatBan> dsNXB = new List<NhaXuatBan>();
                dsNXB = clsNhaXuatBanBLL.Instance.TimDSNhaXuatBan(txtTimNXB.Text);
                if (dsNXB != null)
                {
                    foreach (NhaXuatBan nxb in dsNXB)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = nxb.MaNXB.ToString();
                        item.SubItems.Add(nxb.TenNXB);
                        item.SubItems.Add(nxb.DiaChi);
                        item.Tag = nxb.MaNXB;
                        lsvNXB.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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

        private void LoadData()
        {
            LayDSSach();
            LayDanhSachNXB();
            LayDSTheLoai();
            LayDSTacGia();
            TaiDuLieuLenCMB();
            numNamXB.Maximum = DateTime.Today.Year;
            numNamXB.Value = DateTime.Today.Year;
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            LoadData();
            CaiDatMacDinh();
        }

        private void lsvSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvSach.SelectedItems.Count > 0)
            {
                txtMaSach.Text = lsvSach.SelectedItems[0].Text;
                txtTenSach.Text = lsvSach.SelectedItems[0].SubItems[1].Text;
                numGiaBan.Value = Convert.ToInt32(lsvSach.SelectedItems[0].SubItems[2].Text);
                numNamXB.Value = Convert.ToInt32(lsvSach.SelectedItems[0].SubItems[3].Text);
                numSoLuong.Value = Convert.ToInt32(lsvSach.SelectedItems[0].SubItems[4].Text);
                cmbNXB.SelectedValue = (int)lsvSach.SelectedItems[0].SubItems[5].Tag;
                cmbTL.SelectedValue = (int)lsvSach.SelectedItems[0].SubItems[6].Tag;
                cmbTG.SelectedValue = (int)lsvSach.SelectedItems[0].SubItems[7].Tag;
                CoTheThemSach(false);
                CoTheSuaSach(true);
            }

            else
            {
                LamMoiSach();
            }
        }

        private void btnLMSach_Click(object sender, EventArgs e)
        {
            LamMoiSach();
        }

        private void txtTimSach_TextChanged(object sender, EventArgs e)
        {
            LamMoiSach();
            TimDSSach();
        }

        private void btnTimSach_Click(object sender, EventArgs e)
        {
            LamMoiSach();
            TimDSSach();
        }

        private void lsvNXB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNXB.SelectedItems.Count > 0)
            {
                txtMaNXB.Text = lsvNXB.SelectedItems[0].Text;
                txtTenNXB.Text = lsvNXB.SelectedItems[0].SubItems[1].Text;
                txtDiaChi.Text = lsvNXB.SelectedItems[0].SubItems[2].Text;
                CoTheThemNXB(false);
                CoTheSuaNXB(true);
            }

            else
            {
                LamMoiNXB();
            }
        }

        private void btnLMNXB_Click(object sender, EventArgs e)
        {
            LamMoiNXB();
        }

        private void btnTimNXB_Click(object sender, EventArgs e)
        {
            LamMoiNXB();
            TimDSNhaXuatBan();
        }

        private void txtTimNXB_TextChanged(object sender, EventArgs e)
        {
            LamMoiNXB();
            TimDSNhaXuatBan();
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnThemSach.Text == "Thêm")
                {
                    CoTheThemSach(true);
                    CoTheSuaSach(false);
                    txtTenSach.Focus();
                }
                else
                {
                    if (txtTenSach.Text != "" && numGiaBan.Value != 0)
                    {
                        if (MessageBox.Show("Bạn có muốn thêm Sách này?", "Thông báo", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (clsSachBLL.Instance.ThemSach(txtTenSach.Text, (float) numGiaBan.Value,
                                (int) numNamXB.Value,
                                (int) cmbNXB.SelectedValue, (int) cmbTL.SelectedValue, (int) cmbTG.SelectedValue))
                            {
                                MessageBox.Show("Thêm Sách thành công", "Thông báo", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                CoTheThemSach(false);
                                CoTheSuaSach(false);
                                LamMoiSach();
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

        private void btnSuaSach_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvSach.SelectedItems.Count > 0 && txtMaSach.Text != "")
                {
                    if (txtMaSach.Text != "" && txtTenSach.Text != "" && (int) numGiaBan.Value != 0)
                    {
                        if (MessageBox.Show("Bạn có muốn sửa thông tin Sách này không?", "Thông báo",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (clsSachBLL.Instance.SuaSach(Convert.ToInt32(txtMaSach.Text), txtTenSach.Text,
                                (float) numGiaBan.Value, (int) numNamXB.Value, (int) numSoLuong.Value, (int) cmbNXB.SelectedValue,
                                (int) cmbTL.SelectedValue, (int) cmbTG.SelectedValue))
                            {
                                MessageBox.Show("Cập nhật thông tin Sách thành công", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CoTheSuaSach(false);
                                CoTheThemSach(false);
                                LamMoiSach();
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

        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvSach.SelectedItems.Count > 0 && txtMaSach.Text != "")
                {
                    if (MessageBox.Show("Bạn có muốn xóa Sách này không?", "Thông báo",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (clsSachBLL.Instance.XoaSach(Convert.ToInt32(txtMaSach.Text)))
                        {
                            MessageBox.Show("Xóa Sách thành công", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CoTheSuaSach(false);
                            CoTheThemSach(false);
                            LamMoiSach();
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

        private void btnThemNXB_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnThemNXB.Text == "Thêm")
                {
                    CoTheThemNXB(true);
                    CoTheSuaNXB(false);
                    txtTenNXB.Focus();
                }
                else
                {
                    if (txtTenNXB.Text != "")
                    {
                        if (MessageBox.Show("Bạn có muốn thêm Nhà xuất bản này?", "Thông báo", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (clsNhaXuatBanBLL.Instance.ThemNhaXuatBan(txtTenNXB.Text, txtDiaChi.Text))
                            {
                                MessageBox.Show("Thêm Nhà xuất bản thành công", "Thông báo", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                CoTheThemNXB(false);
                                CoTheSuaNXB(false);
                                LamMoiNXB();
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

        private void btnSuaNXB_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvNXB.SelectedItems.Count > 0 && txtMaNXB.Text != "")
                {
                    if (txtMaNXB.Text != "" && txtTenNXB.Text != "")
                    {
                        if (MessageBox.Show("Bạn có muốn sửa thông tin Nhà xuất bản này không?", "Thông báo",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (clsNhaXuatBanBLL.Instance.SuaNhaXuatBan(Convert.ToInt32(txtMaNXB.Text), txtTenNXB.Text, txtDiaChi.Text))
                            {
                                MessageBox.Show("Cập nhật thông tin Nhà xuất bản thành công", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CoTheSuaNXB(false);
                                CoTheThemNXB(false);
                                LamMoiNXB();
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

        private void btnXoaNXB_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvNXB.SelectedItems.Count > 0 && txtMaNXB.Text != "")
                {
                    if (MessageBox.Show("Bạn có muốn xóa Nhà xuất bản này không?", "Thông báo",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (clsNhaXuatBanBLL.Instance.XoaNhaXuatBan(Convert.ToInt32(txtMaNXB.Text)))
                        {
                            MessageBox.Show("Xóa Nhà xuất bản thành công", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CoTheSuaNXB(false);
                            CoTheThemNXB(false);
                            LamMoiNXB();
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

        private void btnThemTL_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnThemTL.Text == "Thêm")
                {
                    CoTheThemTL(true);
                    CoTheSuaTL(false);
                    txtTenTL.Focus();
                }
                else
                {
                    if (txtTenTL.Text != "")
                    {
                        if (MessageBox.Show("Bạn có muốn thêm Thể loại này?", "Thông báo", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (clsTheLoaiBLL.Instance.ThemTheLoai(txtTenTL.Text))
                            {
                                MessageBox.Show("Thêm Thể loại thành công", "Thông báo", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                CoTheThemTL(false);
                                CoTheSuaTL(false);
                                LamMoiTL();
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

        private void btnSuaTL_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvTheLoai.SelectedItems.Count > 0 && txtMaTL.Text != "")
                {
                    if (txtMaTL.Text != "" && txtTenTL.Text != "")
                    {
                        if (MessageBox.Show("Bạn có muốn sửa thông tin Thể loại này không?", "Thông báo",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (clsTheLoaiBLL.Instance.SuaTheLoai(Convert.ToInt32(txtMaTL.Text), txtTenTL.Text))
                            {
                                MessageBox.Show("Cập nhật thông tin Thể loại thành công", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CoTheSuaTL(false);
                                CoTheThemTL(false);
                                LamMoiTL();
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

        private void btnXoaTL_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvTheLoai.SelectedItems.Count > 0 && txtMaTL.Text != "")
                {
                    if (MessageBox.Show("Bạn có muốn xóa Thể loại này không?", "Thông báo",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (clsTheLoaiBLL.Instance.XoaTheLoai(Convert.ToInt32(txtMaTL.Text)))
                        {
                            MessageBox.Show("Xóa Thể loại thành công", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CoTheSuaTL(false);
                            CoTheThemTL(false);
                            LamMoiTL();
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

        private void btnLMTL_Click(object sender, EventArgs e)
        {
            LamMoiTL();
        }

        private void btnThemTG_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnThemTG.Text == "Thêm")
                {
                    CoTheThemTG(true);
                    CoTheSuaTG(false);
                    txtTenTG.Focus();
                }
                else
                {
                    if (txtTenTG.Text != "")
                    {
                        if (MessageBox.Show("Bạn có muốn thêm Tác giả này?", "Thông báo", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (clsTacGiaBLL.Instance.ThemTacGia(txtTenTG.Text, txtSDT.Text, txtDiaChiTG.Text))
                            {
                                MessageBox.Show("Thêm Tác giả thành công", "Thông báo", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                CoTheThemTG(false);
                                CoTheSuaTG(false);
                                LamMoiTG();
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

        private void btnSuaTG_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvTacGia.SelectedItems.Count > 0 && txtMaTG.Text != "")
                {
                    if (txtMaTG.Text != "" && txtTenTG.Text != "")
                    {
                        if (MessageBox.Show("Bạn có muốn sửa thông tin Tác giả này không?", "Thông báo",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (clsTacGiaBLL.Instance.SuaTacGia(Convert.ToInt32(txtMaTG.Text), txtTenTG.Text, txtSDT.Text, txtDiaChiTG.Text))
                            {
                                MessageBox.Show("Cập nhật thông tin Tác giả thành công", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CoTheSuaTG(false);
                                CoTheThemTG(false);
                                LamMoiTG();
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

        private void btnXoaTG_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvTacGia.SelectedItems.Count > 0 && txtMaTG.Text != "")
                {
                    if (MessageBox.Show("Bạn có muốn xóa Tác giả này không?", "Thông báo",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (clsTacGiaBLL.Instance.XoaTacGia(Convert.ToInt32(txtMaTG.Text)))
                        {
                            MessageBox.Show("Xóa Tác giả thành công", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CoTheSuaTG(false);
                            CoTheThemTG(false);
                            LamMoiTG();
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

        private void btnLMTG_Click(object sender, EventArgs e)
        {
            LamMoiTG();
        }

        private void lsvTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvTheLoai.SelectedItems.Count > 0)
            {
                txtMaTL.Text = lsvTheLoai.SelectedItems[0].Text;
                txtTenTL.Text = lsvTheLoai.SelectedItems[0].SubItems[1].Text;
                CoTheThemTL(false);
                CoTheSuaTL(true);
            }
            else
            {
                LamMoiTL();
            }
        }

        private void lsvTacGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvTacGia.SelectedItems.Count > 0)
            {
                txtMaTG.Text = lsvTacGia.SelectedItems[0].Text;
                txtTenTG.Text = lsvTacGia.SelectedItems[0].SubItems[1].Text;
                txtSDT.Text = lsvTacGia.SelectedItems[0].SubItems[2].Text;
                txtDiaChiTG.Text = lsvTacGia.SelectedItems[0].SubItems[3].Text;
                CoTheThemTG(false);
                CoTheSuaTG(true);
            }
            else
            {
                LamMoiTG();
            }
        }

        private void txtTimTL_TextChanged(object sender, EventArgs e)
        {
            LamMoiTL();
            TimDSTheLoai();
        }

        private void btnTimTL_Click(object sender, EventArgs e)
        {
            LamMoiTL();
            TimDSTheLoai();
        }

        private void txtTimTG_TextChanged(object sender, EventArgs e)
        {
            LamMoiTG();
            TimDSTacGia();
        }

        private void btnTimTG_Click(object sender, EventArgs e)
        {
            LamMoiTG();
            TimDSTacGia();
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

        private void lsvNXB_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Get the new sorting column.
            ColumnHeader new_sorting_column = lsvNXB.Columns[e.Column];

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
            lsvNXB.ListViewItemSorter =
                new ListViewComparer(e.Column, sort_order);

            // Sort.
            lsvNXB.Sort();
        }

        private void lsvTheLoai_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Get the new sorting column.
            ColumnHeader new_sorting_column = lsvTheLoai.Columns[e.Column];

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
            lsvTheLoai.ListViewItemSorter =
                new ListViewComparer(e.Column, sort_order);

            // Sort.
            lsvTheLoai.Sort();
        }

        private void lsvTacGia_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Get the new sorting column.
            ColumnHeader new_sorting_column = lsvTacGia.Columns[e.Column];

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
            lsvTacGia.ListViewItemSorter =
                new ListViewComparer(e.Column, sort_order);

            // Sort.
            lsvTacGia.Sort();
        }

        private async void btnXuatSach_Click(object sender, EventArgs e)
        {
            btnXuatSach.Enabled = false;
            using (FolderBrowserDialog folder = new FolderBrowserDialog())
            {
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        savepath = folder.SelectedPath;
                        frmMain.notiIcon.ShowBalloonTip(1500, "BookShop Management", "Đang xuất sang tập tin Excel...",
                            ToolTipIcon.Info);
                        Task<bool> export = new Task<bool>(ExportBookToExcel);
                        export.Start();
                        bool isSuccess = await export;
                        if (isSuccess)
                        {
                            frmMain.notiIcon.ShowBalloonTip(1200, "BookShop Management",
                                "Xuất tập tin Excel thành công.",
                                ToolTipIcon.Info);
                            MessageBox.Show("Xuất sang file Excel thành công.", "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            if (MessageBox.Show("Bạn có muốn mở không?", "Thông báo", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //Mở File excel sau khi Xuất thành công
                                try
                                {
                                    System.Diagnostics.Process.Start(
                                        savepath + "\\DanhSachSach_" + DateTime.Today.ToString("dd-MM-yyyy") +
                                        ".xlsx");
                                }
                                catch
                                {
                                    MessageBox.Show("Có lỗi khi mở file.", "Thông báo", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Đã xảy ra lỗi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            btnXuatSach.Enabled = true;
        }
    }
}
