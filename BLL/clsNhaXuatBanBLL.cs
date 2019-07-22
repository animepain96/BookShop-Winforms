using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BLL
{
    public class clsNhaXuatBanBLL
    {
        private static clsNhaXuatBanBLL instance;

        public static clsNhaXuatBanBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new clsNhaXuatBanBLL();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private clsNhaXuatBanBLL() { }

        public List<NhaXuatBan> LayDSNhaXuatBan()
        {
            return clsNhaXuatBanDAO.Instance.LayDSNhaXuatBan();
        }

        public bool ThemNhaXuatBan(string tennxb, string diachi)
        {
            return clsNhaXuatBanDAO.Instance.ThemNhaXuatBan(tennxb,diachi);
        }

        public bool SuaNhaXuatBan(int manxb, string tennxb, string diachi)
        {
            return clsNhaXuatBanDAO.Instance.SuaNhaXuatBan(manxb, tennxb, diachi);
        }

        public bool XoaNhaXuatBan(int manxb)
        {
            return clsNhaXuatBanDAO.Instance.XoaNhaXuatBan(manxb);
        }

        public NhaXuatBan LayNXBTheoMa(int manxb)
        {
            return clsNhaXuatBanDAO.Instance.LayNXBTheoMa(manxb);
        }

        public List<NhaXuatBan> TimDSNhaXuatBan(string chuoi)
        {
            return clsNhaXuatBanDAO.Instance.TimDSNhaXuatBan(chuoi);
        }
    }
}
