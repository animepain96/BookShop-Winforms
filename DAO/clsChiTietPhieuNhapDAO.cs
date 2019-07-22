using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class clsChiTietPhieuNhapDAO
    {
        private static clsChiTietPhieuNhapDAO instance;

        public static clsChiTietPhieuNhapDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new clsChiTietPhieuNhapDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private clsChiTietPhieuNhapDAO() { }

        public List<ChiTietPhieuNhap> LayDSCTPNTheoMaPN(int mapn)
        {
            List<ChiTietPhieuNhap> dsCTPN = new List<ChiTietPhieuNhap>();
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("", new object[] {mapn});
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dsCTPN.Add(new ChiTietPhieuNhap(row));
                }
            }

            return dsCTPN;
        }

        public bool ThemChiTietPhieuNhap(int mapn, int masach, int soluongnhap)
        {
            int result = clsDataProvider.Instance.ExcuteNonQuerry("EXEC sp_ThemChiTietPN @mapn , @soluongnhap , @manv",
                new object[] {mapn, masach, soluongnhap});
            return result > 0;
        }

        public int LaySoLuongSachTheoMaPN(int mapn)
        {
            int result =
                (int) clsDataProvider.Instance.ExcuteScalar("EXEC sp_LaySoLuongSachTheoMaPN @mapn",
                    new object[] {mapn});
            return result;
        }

        public double TinhTongTienTheoMaPN(int mapn)
        {
            double result =
                (Double) clsDataProvider.Instance.ExcuteScalar("EXEC sp_TinhTongTienTheoMaPN @mapn",
                    new object[] {mapn});
            return result;
        }

        public DataTable BaoCaoPhieuNhapTheoMa(int mapn)
        {
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_BaoCaoPhieuNhapTheoMa @mapn", new object[] {mapn});
            return dt;
        }
    }
}
