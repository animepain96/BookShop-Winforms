using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class clsNhaXuatBanDAO
    {
        private static clsNhaXuatBanDAO instance;

        public static clsNhaXuatBanDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new clsNhaXuatBanDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private clsNhaXuatBanDAO() { }

        public List<NhaXuatBan> LayDSNhaXuatBan()
        {
            List<NhaXuatBan> dsNXB = new List<NhaXuatBan>();
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_LayDanhSachNXB");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dsNXB.Add(new NhaXuatBan(row));
                }
            }

            return dsNXB;
        }

        public bool ThemNhaXuatBan(string tennxb, string diachi)
        {
            int result = clsDataProvider.Instance.ExcuteNonQuerry("EXEC sp_ThemNhaXuatBan @tennxb , @diachi", new object[] {tennxb,diachi});
            return result > 0;
        }

        public bool SuaNhaXuatBan(int manxb, string tennxb, string diachi)
        {
            int result = clsDataProvider.Instance.ExcuteNonQuerry("EXEC sp_CapNhatNhaXuatBan @manxb , @tennxb , @diachi", new object[] {manxb, tennxb, diachi});
            return result > 0;
        }

        public bool XoaNhaXuatBan(int manxb)
        {
            int result = clsDataProvider.Instance.ExcuteNonQuerry("EXEC sp_XoaNhaXuatBan @manxb", new object[] {manxb});
            return result > 0;
        }

        public NhaXuatBan LayNXBTheoMa(int manxb)
        {
            NhaXuatBan nxb = null;
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_LayNXBTheoMa @manxb", new object[] {manxb});
            if (dt.Rows.Count > 0)
            {
                nxb = new NhaXuatBan(dt.Rows[0]);
            }

            return nxb;
        }

        public List<NhaXuatBan> TimDSNhaXuatBan(string chuoi)
        {
            List<NhaXuatBan> dsNXB = new List<NhaXuatBan>();
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_TimNhaXuatBan @chuoi",
                new object[] {"%" + chuoi + "%"});
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dsNXB.Add(new NhaXuatBan(row));
                }
            }

            return dsNXB;
        }
    }
}
