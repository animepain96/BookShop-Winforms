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
    public class clsChiTietPhieuNhapBLL
    {
        private static clsChiTietPhieuNhapBLL instance;

        public static clsChiTietPhieuNhapBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new clsChiTietPhieuNhapBLL();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private clsChiTietPhieuNhapBLL() { }

        public List<ChiTietPhieuNhap> LayDSCTPNTheoMaPN(int mapn)
        {
            return clsChiTietPhieuNhapDAO.Instance.LayDSCTPNTheoMaPN(mapn);
        }

        public bool ThemChiTietPhieuNhap(int mapn, int masach, int soluongnhap)
        {
            return clsChiTietPhieuNhapDAO.Instance.ThemChiTietPhieuNhap(mapn, masach, soluongnhap);
        }

        public int LaySoLuongSachTheoMaPN(int mapn)
        {
            return clsChiTietPhieuNhapDAO.Instance.LaySoLuongSachTheoMaPN(mapn);
        }

        public double TinhTongTienTheoMaPN(int mapn)
        {
            return clsChiTietPhieuNhapDAO.Instance.TinhTongTienTheoMaPN(mapn);
        }

        public DataTable BaoCaoPhieuNhapTheoMa(int mapn)
        {
            return clsChiTietPhieuNhapDAO.Instance.BaoCaoPhieuNhapTheoMa(mapn);
        }
    }
}
