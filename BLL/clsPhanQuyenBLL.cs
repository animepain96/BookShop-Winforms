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
    public class clsPhanQuyenBLL
    {
        private static clsPhanQuyenBLL instance;

        public static clsPhanQuyenBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new clsPhanQuyenBLL();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private clsPhanQuyenBLL() { }

        public List<PhanQuyen> LayDSPhanQuyen()
        {
            return clsPhanQuyenDAO.Instance.LayDSPhanQuyen();
        }

        public bool ThayDoiQuyen(int maquyen, int manv)
        {
            return clsPhanQuyenDAO.Instance.ThayDoiQuyen(maquyen, manv);
        }

        public bool SuaDoiQuyen(int manv, int maquyen)
        {
            return clsPhanQuyenDAO.Instance.SuaDoiQuyen(manv, maquyen);
        }

        public List<PhanQuyen> TimDSPhanQuyen(string chuoi)
        {
            return clsPhanQuyenDAO.Instance.TimDSPhanQuyen(chuoi);
        }

        public PhanQuyen LayPhanQuyenTheoMaNV(int manv)
        {
            return clsPhanQuyenDAO.Instance.LayPhanQuyenTheoMaNV(manv);
        }
    }
}
