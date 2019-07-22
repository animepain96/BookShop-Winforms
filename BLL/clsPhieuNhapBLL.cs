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
    public class clsPhieuNhapBLL
    {
        private static clsPhieuNhapBLL instance;

        public static clsPhieuNhapBLL Instance
        {
            get
            {
                if (instance==null)
                {
                    return instance = new clsPhieuNhapBLL();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private clsPhieuNhapBLL() { }

        public List<PhieuNhap> LayDSPhieuNhap(int manv, DateTime frmdate, DateTime todate)
        {
            return clsPhieuNhapDAO.Instance.LayDSPhieuNhap(manv,frmdate,todate);
        }

        public bool ThemPhieuNhap(DateTime ngaynhap, int manv)
        {
            return clsPhieuNhapDAO.Instance.ThemPhieuNhap(ngaynhap, manv);
        }

        public int LayMaPNMoiNhat()
        {
            return clsPhieuNhapDAO.Instance.LayMaPNMoiNhat();
        }

        public List<PhieuNhap> LayDSPhieuNhapTheoNgay(DateTime frmdate, DateTime todate, int manv)
        {
            return clsPhieuNhapDAO.Instance.LayDSPhieuNhapTheoNgay(frmdate, todate, manv);
        }

        public PhieuNhap LayPhieuNhapTheoMa(int mapn)
        {
            return clsPhieuNhapDAO.Instance.LayPhieuNhapTheoMa(mapn);
        }
    }
}
