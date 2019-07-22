using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class clsTheLoaiDAO
    {
        private static clsTheLoaiDAO instance;

        public static clsTheLoaiDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new clsTheLoaiDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private clsTheLoaiDAO() { }

        public List<TheLoai> LayDSTheLoai()
        {
            List<TheLoai> dsTL = new List<TheLoai>();
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_LayDanhSachTheLoai");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dsTL.Add(new TheLoai(row));
                }
            }

            return dsTL;
        }

        public bool ThemTheLoai(string tentl)
        {
            int result = clsDataProvider.Instance.ExcuteNonQuerry("EXEC sp_ThemTheLoai @tentl", new object[] {tentl});
            return result > 0;
        }

        public bool SuaTheLoai(int matl, string tentl)
        {
            int result = clsDataProvider.Instance.ExcuteNonQuerry("EXEC sp_CapNhatTheLoai @matl , @tentl", new object[] {matl, tentl});
            return result > 0;
        }

        public bool XoaTheLoai(int matl)
        {
            int result = clsDataProvider.Instance.ExcuteNonQuerry("EXEC sp_XoaTheLoai @matl", new object[] {matl});
            return result > 0;
        }

        public TheLoai LayTLTheoMa(int matl)
        {
            TheLoai tl = null;
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_LayTLTheoMa @matl", new object[] {matl});
            if (dt.Rows.Count > 0)
            {
                tl = new TheLoai(dt.Rows[0]);
            }

            return tl;
        }

        public List<TheLoai> TimDSTheLoai(string chuoi)
        {
            List<TheLoai> dsTL = new List<TheLoai>();
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_TimTheLoai @chuoi", new object[] {"%" + chuoi + "%"});
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dsTL.Add(new TheLoai(row));
                }
            }

            return dsTL;
        }
    }
}
