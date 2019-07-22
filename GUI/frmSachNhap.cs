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
using GUI.Custom;
using Microsoft.Reporting.WinForms;

namespace GUI
{
    public partial class frmSachNhap : Form
    {
        private ColumnHeader SortingColumn = null;
        public frmSachNhap()
        {
            InitializeComponent();
        }

        private void DatNgay()
        {
            DateTime t = DateTime.Today;
            dtpFrmDate.Value = new DateTime(t.Year, t.Month, 1);
            if (DateTime.Today.Month == 12)
            {
                dtpToDate.Value = new DateTime(t.Year + 1, 1, 1).AddDays(-1);
            }
            else
            {
                dtpToDate.Value = new DateTime(t.Year, t.Month + 1, 1).AddDays(-1);
            }
        }

        private void LayDSSachNhap()
        {
            try
            {
                lsvChiTiet.Items.Clear();
                DataTable dt = new DataTable();
                dt = clsSachBLL.Instance.LayDSSachNhap(dtpFrmDate.Value, dtpToDate.Value);
                if (dt != null)
                {
                    int i = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        CultureInfo info = new CultureInfo("vi-VN");
                        ListViewItem item = new ListViewItem();
                        item.Text = i.ToString();
                        item.SubItems.Add(row["TenSach"].ToString());
                        double giaban = (Double) row["GiaBan"];
                        item.SubItems.Add(giaban.ToString("c0", info));
                        item.SubItems.Add(row["SoLuongNhap"].ToString());
                        double tongtien = (Double) row["TongTien"];
                        item.SubItems.Add(tongtien.ToString("c0", info));
                        lsvChiTiet.Items.Add(item);
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmBaoCao f = new frmBaoCao())
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        dt = clsSachBLL.Instance.LayDSSachNhap(dtpFrmDate.Value, dtpToDate.Value);
                        f.Text = "BÁO CÁO DANH SÁCH SÁCH NHẬP";
                        f.rptBaoCao.ProcessingMode = ProcessingMode.Local;
                        f.rptBaoCao.LocalReport.ReportPath = "Report\\rptSachNhap.rdlc";
                        ReportParameter[] rp = new ReportParameter[]
                        {
                            new ReportParameter("frmdate", dtpFrmDate.Value.ToString("dd-MM-yyyy")),
                            new ReportParameter("todate", dtpToDate.Value.ToString("dd-MM-yyyy"))
                        };
                        f.rptBaoCao.LocalReport.SetParameters(rp);
                        ReportDataSource rds = new ReportDataSource();
                        rds.Name = "SachNhap";
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

        private void dtpFrmDate_ValueChanged(object sender, EventArgs e)
        {
            LayDSSachNhap();
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            LayDSSachNhap();
        }

        private void frmSachNhap_Load(object sender, EventArgs e)
        {
            DatNgay();
            LayDSSachNhap();
        }

        private void lsvChiTiet_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Get the new sorting column.
            ColumnHeader new_sorting_column = lsvChiTiet.Columns[e.Column];

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
            lsvChiTiet.ListViewItemSorter =
                new ListViewComparer(e.Column, sort_order);

            // Sort.
            lsvChiTiet.Sort();
        }
    }
}
