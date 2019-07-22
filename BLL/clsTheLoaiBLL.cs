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
    public class clsTheLoaiBLL
    {
        private static clsTheLoaiBLL instance;

        public static clsTheLoaiBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new clsTheLoaiBLL();
                }

                return instance;
            }

            private set { instance = value; }
        }

        private clsTheLoaiBLL()
        {
        }

        public List<TheLoai> LayDSTheLoai()
        {
            return clsTheLoaiDAO.Instance.LayDSTheLoai();
        }

        public bool ThemTheLoai(string tentl)
        {
            return clsTheLoaiDAO.Instance.ThemTheLoai(tentl);
        }

        public bool SuaTheLoai(int matl, string tentl)
        {
            return clsTheLoaiDAO.Instance.SuaTheLoai(matl, tentl);
        }

        public bool XoaTheLoai(int matl)
        {
            return clsTheLoaiDAO.Instance.XoaTheLoai(matl);
        }

        public TheLoai LayTLTheoMa(int matl)
        {
            return clsTheLoaiDAO.Instance.LayTLTheoMa(matl);
        }

        public List<TheLoai> TimDSTheLoai(string chuoi)
        {
            return clsTheLoaiDAO.Instance.TimDSTheLoai(chuoi);
        }
    }
}
