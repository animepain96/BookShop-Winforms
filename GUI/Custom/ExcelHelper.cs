using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace GUI.Custom
{
    public class ExcelHelper
    {
        public static bool ExportPublisherToExcel(DataTable source, string savepath)
        {
            if (savepath == "")
            {
                return false;
            }

            if (source == null)
            {
                return false;
            }

            Excel.Application xlApp = new Excel.Application();
            object misValue = System.Reflection.Missing.Value;
            Workbook wb = xlApp.Workbooks.Add(misValue);
            Worksheet ws = (Worksheet)wb.Worksheets[1];


            try
            {
                

                if (xlApp == null)
                {
                    return false;
                }

                xlApp.Visible = false;
                

                if (ws == null)
                {
                    return false;
                }

                int row = 1;
                string fontName = "Calibri";
                int fontSizeTieuDe = 18;
                int fontSizeTenTruong = 14;
                int fontSizeNoiDung = 12;

                double cotRong = 18;
                double cotSTTRong = 6.5;
                double cotTenSachRong = 65;
                double hangRong = 19;

                //Ten danh sach
                Range row1_TieuDe = ws.get_Range("A1", "H1");
                row1_TieuDe.Merge();
                row1_TieuDe.Font.Size = fontSizeTieuDe;
                row1_TieuDe.Font.Name = fontName;
                row1_TieuDe.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                row1_TieuDe.Value2 = "THỐNG KÊ SÁCH TỒN TRONG KHO";

                //Ngay xuat
                Range row2_Ngay = ws.get_Range("A2", "A2");
                row2_Ngay.Font.Size = fontSizeNoiDung;
                row2_Ngay.Font.Name = fontName;
                row2_Ngay.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                row2_Ngay.Value2 = "Ngày " + DateTime.Today.ToString("dd/MM/yyyy");

                //Row3
                Range row3 = ws.get_Range("A3", "H3");
                row3.Font.Size = fontSizeTenTruong;
                row3.Font.Name = fontName;
                row3.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                //STT
                Range row3_STT = ws.get_Range("A3", "A3");
                row3_STT.Value2 = "STT";

                //Ten sach
                Range row3_TenSach = ws.get_Range("B3", "B3");
                row3_TenSach.Value2 = "Tên sách";

                //Gia ban
                Range row3_GiaBan = ws.get_Range("C3", "C3");
                row3_GiaBan.Value2 = "Giá bán";

                //Nam xuat ban
                Range row3_NamXB = ws.get_Range("D3", "D3");
                row3_NamXB.Value2 = "Năm xuất bản";

                //So luong ton
                Range row3_SLT = ws.get_Range("E3", "E3");
                row3_SLT.Value2 = "Số lượng tồn";

                //Nha xuat ban
                Range row3_NXB = ws.get_Range("F3", "F3");
                row3_NXB.Value2 = "Nhà xuất bản";

                //The loai
                Range row3_TL = ws.get_Range("G3", "G3");
                row3_TL.Value2 = "Thể loại";

                //Tac gia
                Range row3_TG = ws.get_Range("H3", "H3");
                row3_TG.Value2 = "Tác giả";

                //Nen tieu de
                row3.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                row3.Font.Bold = true;
                row3.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.White);

                //Dinh dang cot
                ws.Columns[1].ColumnWidth = cotSTTRong;
                ws.Columns[2].ColumnWidth = cotTenSachRong;
                for (int i = 3; i <= 8; i++)
                {
                    ws.Columns[i].ColumnWidth = cotRong;
                }

                int stt = 0;
                row = 3;
                CultureInfo info = new CultureInfo("vi-VN");
                if (source != null)
                {
                    foreach (DataRow myrow in source.Rows)
                    {
                        stt++;
                        row++;
                        dynamic[] arr =
                        {
                            stt, myrow["TenSach"].ToString(), ((Double) myrow["GiaBan"]).ToString("c0", info),
                            myrow["NamXB"].ToString(), myrow["SoLuongTon"].ToString(), myrow["TenNXB"].ToString(),
                            myrow["TenTL"].ToString(), myrow["TenTG"].ToString()
                        };
                        Range rowData = ws.get_Range("A" + row, "H" + row);
                        //Lấy dòng thứ row ra để đổ dữ liệu
                        rowData.Font.Size = fontSizeNoiDung;
                        rowData.Font.Name = fontName;
                        rowData.Value2 = arr;

                    }
                    //BorderAround(ws.get_Range("A3", "H" + row));
                    //Canh le du lieu
                    Range tmpstt = ws.get_Range("A4", "A" + row);
                    tmpstt.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    Range tmpgiaban = ws.get_Range("C4", "C" + row);
                    tmpgiaban.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    Range tmpnam = ws.get_Range("D4", "D" + row);
                    tmpnam.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    Range tmpslt = ws.get_Range("E4", "E" + row);
                    tmpslt.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                }

                //Dinh dang hang
                ws.Rows[1].RowHeight = 24;
                for (int i = 2; i <= row; i++)
                {
                    ws.Rows[i].RowHeight = hangRong;
                }

                //Ap dung dinh dang table
                Excel.Range SourceRange = (Excel.Range)ws.get_Range("A3", "H" + row);
                FormatAsTable(SourceRange, "Table1", "TableStyleMedium1");

                //Lưu file excel xuống Ổ cứng
                wb.SaveAs(savepath);

                //đóng file để hoàn tất quá trình lưu trữ
                wb.Close(true, misValue, misValue);
                //thoát và thu hồi bộ nhớ cho COM
                xlApp.Quit();
                releaseObject(ws);
                releaseObject(wb);
                releaseObject(xlApp);

                return true;
            }
            catch
            {
                xlApp.Quit();
                releaseObject(ws);
                releaseObject(wb);
                releaseObject(xlApp);
                return false;
            }
            
        }

        public static bool ExportBookToExcel(DataTable source, string savepath)
        {
            if (savepath == "")
            {
                return false;
            }

            if (source == null)
            {
                return false;
            }

            try
            {
                Excel.Application xlApp = new Excel.Application();

                if (xlApp == null)
                {
                    return false;
                }

                xlApp.Visible = false;

                object misValue = System.Reflection.Missing.Value;

                Workbook wb = xlApp.Workbooks.Add(misValue);

                Worksheet ws = (Worksheet)wb.Worksheets[1];

                if (ws == null)
                {
                    return false;
                }

                int row = 1;
                string fontName = "Calibri";
                int fontSizeTieuDe = 18;
                int fontSizeTenTruong = 14;
                int fontSizeNoiDung = 12;

                double cotRong = 18;
                double cotSTTRong = 6.5;
                double cotTenSachRong = 65;
                double hangRong = 19;

                //Ten danh sach
                Range row1_TieuDe = ws.get_Range("A1", "H1");
                row1_TieuDe.Merge();
                row1_TieuDe.Font.Size = fontSizeTieuDe;
                row1_TieuDe.Font.Name = fontName;
                row1_TieuDe.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                row1_TieuDe.Value2 = "THỐNG KÊ SÁCH TỒN KHO";

                //Ngay xuat
                Range row2_Ngay = ws.get_Range("A2", "A2");
                row2_Ngay.Font.Size = fontSizeNoiDung;
                row2_Ngay.Font.Name = fontName;
                row2_Ngay.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                row2_Ngay.Value2 = "Ngày " + DateTime.Today.ToString("dd/MM/yyyy");

                //Row3
                Range row3 = ws.get_Range("A3", "H3");
                row3.Font.Size = fontSizeTenTruong;
                row3.Font.Name = fontName;
                row3.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                //STT
                Range row3_STT = ws.get_Range("A3", "A3");
                row3_STT.Value2 = "STT";

                //Ten sach
                Range row3_TenSach = ws.get_Range("B3", "B3");
                row3_TenSach.Value2 = "Tên sách";

                //Gia ban
                Range row3_GiaBan = ws.get_Range("C3", "C3");
                row3_GiaBan.Value2 = "Giá bán";

                //Nam xuat ban
                Range row3_NamXB = ws.get_Range("D3", "D3");
                row3_NamXB.Value2 = "Năm xuất bản";

                //So luong ton
                Range row3_SLT = ws.get_Range("E3", "E3");
                row3_SLT.Value2 = "Số lượng tồn";

                //Nha xuat ban
                Range row3_NXB = ws.get_Range("F3", "F3");
                row3_NXB.Value2 = "Nhà xuất bản";

                //The loai
                Range row3_TL = ws.get_Range("G3", "G3");
                row3_TL.Value2 = "Thể loại";

                //Tac gia
                Range row3_TG = ws.get_Range("H3", "H3");
                row3_TG.Value2 = "Tác giả";

                //Nen tieu de
                row3.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                row3.Font.Bold = true;
                row3.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.White);

                //Dinh dang cot
                ws.Columns[1].ColumnWidth = cotSTTRong;
                ws.Columns[2].ColumnWidth = cotTenSachRong;
                for (int i = 3; i <= 8; i++)
                {
                    ws.Columns[i].ColumnWidth = cotRong;
                }

                int stt = 0;
                row = 3;
                CultureInfo info = new CultureInfo("vi-VN");
                if (source != null)
                {
                    foreach (DataRow myrow in source.Rows)
                    {
                        stt++;
                        row++;
                        dynamic[] arr =
                        {
                            stt, myrow["TenSach"].ToString(), ((Double) myrow["GiaBan"]).ToString("c0", info),
                            myrow["NamXB"].ToString(), myrow["SoLuongTon"].ToString(), myrow["TenNXB"].ToString(),
                            myrow["TenTL"].ToString(), myrow["TenTG"].ToString()
                        };
                        Range rowData = ws.get_Range("A" + row, "H" + row);
                        //Lấy dòng thứ row ra để đổ dữ liệu
                        rowData.Font.Size = fontSizeNoiDung;
                        rowData.Font.Name = fontName;
                        rowData.Value2 = arr;

                    }
                    //BorderAround(ws.get_Range("A3", "H" + row));
                    //Canh le du lieu
                    Range tmpstt = ws.get_Range("A4", "A" + row);
                    tmpstt.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    Range tmpgiaban = ws.get_Range("C4", "C" + row);
                    tmpgiaban.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    Range tmpnam = ws.get_Range("D4", "D" + row);
                    tmpnam.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    Range tmpslt = ws.get_Range("E4", "E" + row);
                    tmpslt.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                }

                //Dinh dang hang
                ws.Rows[1].RowHeight = 24;
                for (int i = 2; i <= row; i++)
                {
                    ws.Rows[i].RowHeight = hangRong;
                }

                //Ap dung dinh dang table
                Excel.Range SourceRange = (Excel.Range)ws.get_Range("A3", "H" + row);
                FormatAsTable(SourceRange, "Table1", "TableStyleMedium1");

                //Lưu file excel xuống Ổ cứng
                wb.SaveAs(savepath);

                //đóng file để hoàn tất quá trình lưu trữ
                wb.Close(true, misValue, misValue);
                //thoát và thu hồi bộ nhớ cho COM
                xlApp.Quit();
                releaseObject(ws);
                releaseObject(wb);
                releaseObject(xlApp);

                return true;
            }
            catch
            {
                
                return false;
            }
        }

        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch
            {
                obj = null;
            }
            finally
            {
                GC.Collect(); 
            }
        }


        private static void BorderAround(Range range)
        {
            Borders borders = range.Borders;
            borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            borders.Color = Color.Black;
            borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlDiagonalUp].LineStyle = XlLineStyle.xlLineStyleNone;
            borders[XlBordersIndex.xlDiagonalDown].LineStyle = XlLineStyle.xlLineStyleNone;
        }

        private static void FormatAsTable(Excel.Range SourceRange, string TableName, string TableStyleName)
        {
            SourceRange.Worksheet.ListObjects.Add(XlListObjectSourceType.xlSrcRange, SourceRange, System.Type.Missing,
                XlYesNoGuess.xlYes, System.Type.Missing).Name = TableName;
            SourceRange.Select();
            SourceRange.Worksheet.ListObjects[TableName].TableStyle = TableStyleName;
            SourceRange.Worksheet.ListObjects[TableName].ShowAutoFilter = false;
        }
    }
}
