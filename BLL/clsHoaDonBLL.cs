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
    public class clsHoaDonBLL
    {
        private static clsHoaDonBLL instance;

        public static clsHoaDonBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new clsHoaDonBLL();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private clsHoaDonBLL() { }

        public List<HoaDon> LayDSHoaDon(int manv, DateTime frmdate, DateTime todate)
        {
            return clsHoaDonDAO.Instance.LayDSHoaDon(manv,frmdate,todate);
        }

        public bool ThemHoaDon(DateTime ngayban, int giamgia, int manv)
        {
            return clsHoaDonDAO.Instance.ThemHoaDon(ngayban, giamgia, manv);
        }

        public int LayMaHDMoiNhat()
        {
            return clsHoaDonDAO.Instance.LayMaHDMoiNhat();
        }

        public List<HoaDon> LayDSHoaDonTheoNgay(DateTime frmdate, DateTime todate, int manv)
        {
            return clsHoaDonDAO.Instance.LayDSHoaDonTheoNgay(frmdate, todate, manv);
        }
        public HoaDon LayHoaDonTheoMa(int mahd)
        {
            return clsHoaDonDAO.Instance.LayHoaDonTheoMa(mahd);
        }
    }
}
