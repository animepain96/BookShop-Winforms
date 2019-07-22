using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class clsQuyenDAO
    {
        private static clsQuyenDAO instance;

        public static clsQuyenDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new clsQuyenDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private clsQuyenDAO() { }

        public List<Quyen> LayDSQuyen()
        {
            List<Quyen> dsQ = new List<Quyen>();
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_LayDanhSachQuyen");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dsQ.Add(new Quyen(row));
                }
            }

            return dsQ;
        }

        public string LayTenQuyenTheoMa(int maquyen)
        {
            string tenquyen = clsDataProvider.Instance.ExcuteScalar("EXEC sp_LayTenQuyenTheoMa @maquyen", new object[] {maquyen}).ToString();
            return tenquyen;
        }
    }
}
