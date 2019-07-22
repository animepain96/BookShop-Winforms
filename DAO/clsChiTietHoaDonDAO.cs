using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class clsChiTietHoaDonDAO
    {
        private static clsChiTietHoaDonDAO instance;

        public static clsChiTietHoaDonDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new clsChiTietHoaDonDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private clsChiTietHoaDonDAO() { }

        public List<ChiTietHoaDon> LayDSCTHDTheoMaHD(int mahd)
        {
            List<ChiTietHoaDon> dsCTHD = new List<ChiTietHoaDon>();
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("", new object[] {mahd});
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dsCTHD.Add(new ChiTietHoaDon(row));
                }
            }

            return dsCTHD;
        }

        public bool ThemChiTietHD(int mahd, int masach, int soluongban)
        {
            int result = clsDataProvider.Instance.ExcuteNonQuerry(
                "EXEC sp_ThemChiTietHoaDon @mahd , @masach , @soluongban", new object[] {mahd, masach, soluongban});
            return result > 0;
        }

        public int LaySoLuongSachTheoMaHD(int mahd)
        {
            int result = (int)clsDataProvider.Instance.ExcuteScalar("EXEC sp_LaySoLuongSachHD @mahd", new object[] {mahd});
            return result;
        }

        public double LayTongTienTheoMaHD(int mahd)
        {
            double result =
                Math.Round(
                    Double.Parse(clsDataProvider.Instance
                        .ExcuteScalar("EXEC sp_LayTongTienHD @mahd", new object[] {mahd}).ToString()), 0);
            return result;
        }

        public DataTable BaoCaoHoaDonTheoMa(int mahd)
        {
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_BaoCaoHoaDonTheoMa @mahd", new object[] {mahd});
            return dt;
        }
    }
}
