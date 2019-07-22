using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class clsPhanQuyenDAO
    {
        private static clsPhanQuyenDAO instance;

        public static clsPhanQuyenDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new clsPhanQuyenDAO();
                }
                return instance;
            }
            private set { instance = value; }
        }

        private clsPhanQuyenDAO() { }

        public List<PhanQuyen> LayDSPhanQuyen()
        {
            List<PhanQuyen> dsPQ = new List<PhanQuyen>();
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_LayDanhSachPhanQuyen");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dsPQ.Add(new PhanQuyen(row));
                }
            }

            return dsPQ;
        }

        public List<PhanQuyen> TimDSPhanQuyen(string chuoi)
        {
            List<PhanQuyen> dsPQ = new List<PhanQuyen>();
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_TimDanhSachPhanQuyen @chuoi",
                new object[] {"%" + chuoi + "%"});
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dsPQ.Add(new PhanQuyen(row));
                }
            }

            return dsPQ;
        }

        public bool ThayDoiQuyen(int maquyen, int manv)
        {
            int result = clsDataProvider.Instance.ExcuteNonQuerry("", new object[] {maquyen, manv});
            return result > 0;
        }

        public bool SuaDoiQuyen(int manv, int maquyen)
        {
            int result = clsDataProvider.Instance.ExcuteNonQuerry("EXEC sp_SuaDoiQuyen @manv , @maquyen",
                new object[] {manv, maquyen});
            return result > 0;
        }

        public PhanQuyen LayPhanQuyenTheoMaNV(int manv)
        {
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_LayPhanQuyenTheoMaNV @manv", new object[] {manv});
            if (dt.Rows.Count > 0)
            {
                PhanQuyen pq= new PhanQuyen(dt.Rows[0]);
                return pq;
            }
            else
            {
                return null;
            }
        }
    }
}
