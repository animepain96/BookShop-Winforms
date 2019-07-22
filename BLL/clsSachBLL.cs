using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BLL
{
    public class clsSachBLL
    {
        private static clsSachBLL instance;

        public static clsSachBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new clsSachBLL();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private clsSachBLL() { }

        public List<Sach> LayDSSach()
        {
            return clsSachDAO.Instance.LayDSSach();
        }

        public bool ThemSach(string tensach, float giaban, int namxb, int manxb, int matl, int matg)
        {
            return clsSachDAO.Instance.ThemSach(tensach, giaban, namxb, manxb, matl, matg);
        }

        public bool SuaSach(int masach, string tensach, float giaban, int namxb, int soluongton, int manxb, int matl,
            int matg)
        {
            return clsSachDAO.Instance.SuaSach(masach, tensach, giaban, namxb, soluongton, manxb, matl, matg);
        }

        public bool XoaSach(int masach)
        {
            return clsSachDAO.Instance.XoaSach(masach);
        }

        public List<Sach> TimDSSach(string chuoi)
        {
            return clsSachDAO.Instance.TimDSSach(chuoi);
        }

        public bool KiemTraSoLuongSach(int masach, int soluongban)
        {
            return clsSachDAO.Instance.KiemTraSoLuongSach(masach, soluongban);
        }

        public Sach LaySachTheoMa(int masach)
        {
            return clsSachDAO.Instance.LaySachTheoMa(masach);
        }

        public DataTable LayDSSachBanChay(DateTime frmdate, DateTime todate)
        {
            return clsSachDAO.Instance.LayDSSachBanChay(frmdate, todate);
        }

        public DataTable LayDSSachTonKho(DateTime frmdate, DateTime todate)
        {
            return clsSachDAO.Instance.LayDSSachTonKho(frmdate, todate);
        }

        public DataTable LayDSSachNhap(DateTime frmdate, DateTime todate)
        {
            return clsSachDAO.Instance.LayDSSachNhap(frmdate, todate);
        }

        public DataTable LayDSSachChiTiet()
        {
            return clsSachDAO.Instance.LayDSSachChiTiet();
        }
    }
}
