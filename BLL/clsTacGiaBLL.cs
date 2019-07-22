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
    public class clsTacGiaBLL
    {
        private static clsTacGiaBLL instance;

        public static clsTacGiaBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new clsTacGiaBLL();
                }

                return instance;
            }

            private set { instance = value; }
        }

        private clsTacGiaBLL()
        {
        }

        public List<TacGia> LayDSTacGia()
        {
            return clsTacGiaDAO.Instance.LayDSTacGia();
        }

        public bool ThemTacGia(string tentg, string sdt, string diachi)
        {
            return clsTacGiaDAO.Instance.ThemTacGia(tentg,sdt,diachi);
        }

        public bool SuaTacGia(int matg, string tentg, string sdt, string diachi)
        {
            return clsTacGiaDAO.Instance.SuaTacGia(matg, tentg, sdt, diachi);
        }

        public bool XoaTacGia(int matg)
        {
            return clsTacGiaDAO.Instance.XoaTacGia(matg);
        }

        public TacGia LayTGTheoMa(int matg)
        {
            return clsTacGiaDAO.Instance.LayTGTheoMa(matg);
        }

        public List<TacGia> TimDSTacGia(string chuoi)
        {
            return clsTacGiaDAO.Instance.TimDSTacGia(chuoi);
        }
    }
}
