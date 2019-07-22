using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Custom
{

    public class ListViewComparer : System.Collections.IComparer
    {
        private int ColumnNumber;
        private SortOrder SortOrder;

        public ListViewComparer(int column_number,
            SortOrder sort_order)
        {
            ColumnNumber = column_number;
            SortOrder = sort_order;
        }

        // Compare two ListViewItems.
        public int Compare(object object_x, object object_y)
        {
            // Get the objects as ListViewItems.
            ListViewItem item_x = object_x as ListViewItem;
            ListViewItem item_y = object_y as ListViewItem;

            // Get the corresponding sub-item values.
            string string_x;
            if (item_x.SubItems.Count <= ColumnNumber)
            {
                string_x = "";
            }
            else
            {
                string_x = item_x.SubItems[ColumnNumber].Text;
            }

            string string_y;
            if (item_y.SubItems.Count <= ColumnNumber)
            {
                string_y = "";
            }
            else
            {
                string_y = item_y.SubItems[ColumnNumber].Text;
            }

            // Compare them.
            int result;
            double double_x, double_y;
            if (double.TryParse(string_x, out double_x) &&
                double.TryParse(string_y, out double_y))
            {
                // Treat as a number.
                result = double_x.CompareTo(double_y);
            }
            else
            {
                DateTime date_x, date_y;
                if (DateTime.TryParseExact(string_x, "dd-MM-yyyy", null, DateTimeStyles.None, out date_x) &&
                    DateTime.TryParseExact(string_y, "dd-MM-yyyy", null, DateTimeStyles.None, out date_y))
                {
                    // Treat as a date.
                    result = date_x.CompareTo(date_y);
                }
                else
                {
                    double price_x, price_y;

                    string[] price_x_arr_1 = string_x.Split(' ');
                    string[] price_x_arr_2 = price_x_arr_1[0].Split('.');
                    string tmp_x = "";
                    foreach (string tmp1 in price_x_arr_2)
                    {
                        tmp_x = tmp_x + tmp1;
                    }

                    string[] price_y_arr_1 = string_y.Split(' ');
                    string[] price_y_arr_2 = price_y_arr_1[0].Split('.');
                    string tmp_y = "";
                    foreach (string tmp2 in price_y_arr_2)
                    {
                        tmp_y = tmp_y + tmp2;
                    }

                    if (Double.TryParse(tmp_x, out price_x) && Double.TryParse(tmp_y, out price_y))
                    {
                        result = price_x.CompareTo(price_y);
                    }
                    else
                    {
                        // Treat as a string.
                        result = string_x.CompareTo(string_y);
                    }
                }
            }

            // Return the correct result depending on whether
            // we're sorting ascending or descending.
            if (SortOrder == SortOrder.Ascending)
            {
                return result;
            }
            else
            {
                return -result;
            }
        }
    }
}

