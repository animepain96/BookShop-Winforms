using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BLL
{
    public class clsChiTietHoaDonBLL
    {
        private static clsChiTietHoaDonBLL instance;

        public static clsChiTietHoaDonBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new clsChiTietHoaDonBLL();
                }
                return instance;
            }
            private set { instance = value; }
        }

        private clsChiTietHoaDonBLL() { }

        public List<ChiTietHoaDon> LayDSCTHDTheoMaHD(int mahd)
        {
            return clsChiTietHoaDonDAO.Instance.LayDSCTHDTheoMaHD(mahd);
        }

        public bool ThemChiTietHD(int mahd, int masach, int soluongban)
        {
            return clsChiTietHoaDonDAO.Instance.ThemChiTietHD(mahd, masach, soluongban);
        }

        public int LaySoLuongSachTheoMaHD(int mahd)
        {
            return clsChiTietHoaDonDAO.Instance.LaySoLuongSachTheoMaHD(mahd);
        }

        public double LayTongTienTheoMaHD(int mahd)
        {
            return clsChiTietHoaDonDAO.Instance.LayTongTienTheoMaHD(mahd);
        }

        public DataTable BaoCaoHoaDonTheoMa(int mahd)
        {
            return clsChiTietHoaDonDAO.Instance.BaoCaoHoaDonTheoMa(mahd);
        }
    }
}
