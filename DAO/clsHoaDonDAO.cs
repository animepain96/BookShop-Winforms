using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class clsHoaDonDAO
    {
        private static clsHoaDonDAO instance;

        public static clsHoaDonDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new clsHoaDonDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private clsHoaDonDAO() { }

        public List<HoaDon> LayDSHoaDon(int manv, DateTime frmdate, DateTime todate)
        {
            List<HoaDon> dsHD = new List<HoaDon>();
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_LayDanhSachHoaDon @manv , @frmdate , @todate",
                new object[] {manv, frmdate, todate});
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dsHD.Add(new HoaDon(row));
                }
            }

            return dsHD;
        }

        public bool ThemHoaDon(DateTime ngayban, int giamgia, int manv)
        {
            int result = clsDataProvider.Instance.ExcuteNonQuerry("EXEC sp_ThemHoaDon @ngayban , @giamgia , @manv",
                new object[] {ngayban, giamgia, manv});
            return result > 0;
        }

        public int LayMaHDMoiNhat()
        {
            int mahd = (int)clsDataProvider.Instance.ExcuteScalar("EXEC sp_LayHoaDonMoiNhat");
            return mahd;
        }

        public List<HoaDon> LayDSHoaDonTheoNgay(DateTime frmdate, DateTime todate, int manv)
        {
            List<HoaDon> dsHD = new List<HoaDon>();
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("", new object[] {frmdate, todate, manv});
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dsHD.Add(new HoaDon(row));
                }
            }

            return dsHD;
        }

        public HoaDon LayHoaDonTheoMa(int mahd)
        {
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_LayHoaDonTheoMa @mahd", new object[] {mahd});
            if (dt != null)
            {
                return new HoaDon(dt.Rows[0]);
            }
            else
            {
                return null;
            }
        }
    }
}
