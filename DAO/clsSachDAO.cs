using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class clsSachDAO
    {
        private static clsSachDAO instance;

        public static clsSachDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new clsSachDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private clsSachDAO() { }

        public List<Sach> LayDSSach()
        {
            List<Sach> dsSach = new List<Sach>();
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_LayDanhSachSach");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dsSach.Add(new Sach(row));
                }
            }

            return dsSach;
        }

        public bool ThemSach(string tensach, float giaban, int namxb, int manxb, int matl, int matg)
        {
            int result = clsDataProvider.Instance.ExcuteNonQuerry("EXEC sp_ThemSach @tensach , @giaban , @namxb , @manxb , @matl , @matg", new object[] {tensach, giaban, namxb, manxb, matl, matg});
            return result > 0;
        }

        public bool SuaSach(int masach, string tensach, float giaban, int namxb, int soluongton, int manxb, int matl, int matg)
        {
            int result = clsDataProvider.Instance.ExcuteNonQuerry("EXEC sp_CapNhatSach @masach , @tensach , @giaban , @namxb , @soluongton , @manxb , @matl , @matg",
                new object[] { masach, tensach, giaban, namxb, soluongton, manxb, matl, matg });
            return result > 0;
        }

        public bool XoaSach(int masach)
        {
            int result = clsDataProvider.Instance.ExcuteNonQuerry("EXEC sp_XoaSach @masach", new object[] { masach });
            return result > 0;
        }

        public List<Sach> TimDSSach(string chuoi)
        {
            List<Sach> dsSach = new List<Sach>();
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_TimSach @chuoi", new object[] {"%" + chuoi + "%"});
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dsSach.Add(new Sach(row));
                }
            }

            return dsSach;
        }

        public bool KiemTraSoLuongSach(int masach, int soluongban)
        {
            int result = (int)clsDataProvider.Instance.ExcuteScalar("EXEC sp_KiemTraSoLuong @masach , @soluongban",
                new object[] {masach, soluongban});
            return result > 0;
        }

        public Sach LaySachTheoMa(int masach)
        {
            DataTable dt= new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_LaySachTheoMa @masach", new object[] {masach});
            if (dt != null)
            {
                Sach s = new Sach(dt.Rows[0]);
                return s;
            }

            return null;
        }

        public DataTable LayDSSachBanChay(DateTime frmdate, DateTime todate)
        {
            DataTable dt= new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_LayDSSachBanChay @frmdate , @todate",
                new object[] {frmdate, todate});
            return dt;
        }

        public DataTable LayDSSachTonKho(DateTime frmdate, DateTime todate)
        {
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_LaySachTonKho @frmdate , @todate",
                new object[] {frmdate, todate});
            return dt;
        }

        public DataTable LayDSSachNhap(DateTime frmdate, DateTime todate)
        {
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_LaySachNhap @frmdate , @todate",
                new object[] { frmdate, todate });
            return dt;
        }

        public DataTable LayDSSachChiTiet()
        {
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_LayDSSachChiTiet");
            return dt;
        }

    }
}
