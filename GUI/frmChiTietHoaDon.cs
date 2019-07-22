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

namespace GUI
{
    public partial class frmChiTietHoaDon : Form
    {
        private ColumnHeader SortingColumn = null;
        private int mahd;

        public frmChiTietHoaDon(int mahd)
        {
            this.mahd = mahd;
            InitializeComponent();
        }

        private void LayChiTietHoaDon()
        {

            lsvChiTiet.Items.Clear();
            DataTable dt = new DataTable();
            dt = clsChiTietHoaDonBLL.Instance.BaoCaoHoaDonTheoMa(mahd);
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = i.ToString();
                item.SubItems.Add(row["TenSach"].ToString());
                item.SubItems.Add(row["SoLuong"].ToString());
                CultureInfo info = new CultureInfo("vi-VN");
                double giaban = (Double) row["Gia"];
                item.SubItems.Add(giaban.ToString("c0", info));
                lsvChiTiet.Items.Add(item);
                i++;
            }
        }

        private void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            LayChiTietHoaDon();
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
