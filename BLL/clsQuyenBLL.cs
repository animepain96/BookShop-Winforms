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
    public class clsQuyenBLL
    {
        private static clsQuyenBLL instance;

        public static clsQuyenBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new clsQuyenBLL();
                }
                return instance;
            }
            private set { instance = value; }
        }

        private clsQuyenBLL() { }

        public List<Quyen> LayDSQuyen()
        {
            return clsQuyenDAO.Instance.LayDSQuyen();
        }

        public string LayTenQuyenTheoMa(int maquyen)
        {
            return clsQuyenDAO.Instance.LayTenQuyenTheoMa(maquyen);
        }
    }
}
