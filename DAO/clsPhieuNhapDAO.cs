using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class clsPhieuNhapDAO
    {
        private static clsPhieuNhapDAO instance;

        public static clsPhieuNhapDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new clsPhieuNhapDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private clsPhieuNhapDAO() { }

        public List<PhieuNhap> LayDSPhieuNhap(int manv, DateTime frmdate, DateTime todate)
        {
            List<PhieuNhap> dsPN = new List<PhieuNhap>();
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_LayDanhSachPhieuNhap @manv , @frmdate , @todate",
                new object[] {manv, frmdate, todate});
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dsPN.Add(new PhieuNhap(row));
                }
            }

            return dsPN;
        }

        public bool ThemPhieuNhap(DateTime ngaynhap, int manv)
        {
            int result = clsDataProvider.Instance.ExcuteNonQuerry("EXEC sp_ThemPhieuNhap @ngaynhap , @manv",
                new object[] {ngaynhap, manv});
            return result > 0;
        }

        public int LayMaPNMoiNhat()
        {
            int mapn = (int) clsDataProvider.Instance.ExcuteScalar("EXEC sp_LayMaPNMoiNhat");
            return mapn;
        }

        public List<PhieuNhap> LayDSPhieuNhapTheoNgay(DateTime frmdate, DateTime todate, int manv)
        {
            List<PhieuNhap> dsPN = new List<PhieuNhap>();
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("", new object[] {frmdate, todate, manv});
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dsPN.Add(new PhieuNhap(row));
                }
            }

            return dsPN;
        }

        public PhieuNhap LayPhieuNhapTheoMa(int mapn)
        {
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_LayPhieuNhapTheoMa @mapn", new object[] {mapn});
            if (dt != null)
            {
                return new PhieuNhap(dt.Rows[0]);
            }

            return null;
        }
    }
}
