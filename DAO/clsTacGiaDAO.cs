using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class clsTacGiaDAO
    {
        private static clsTacGiaDAO instance;

        public static clsTacGiaDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new clsTacGiaDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private clsTacGiaDAO() { }

        public List<TacGia> LayDSTacGia()
        {
            List<TacGia> dsTG = new List<TacGia>();
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_LayDanhSachTacGia");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dsTG.Add(new TacGia(row));
                }
            }

            return dsTG;
        }

        public bool ThemTacGia(string tentg, string sdt, string diachi)
        {
            int result = clsDataProvider.Instance.ExcuteNonQuerry("EXEC sp_ThemTacGia @tentg , @sdt , @diachi", new object[] {tentg,sdt,diachi});
            return result > 0;
        }

        public bool SuaTacGia(int matg, string tentg, string sdt, string diachi)
        {
            int result = clsDataProvider.Instance.ExcuteNonQuerry("EXEC sp_CapNhatTacGia @matg , @tentg , @sdt , @diachi", new object[] {matg, tentg, sdt, diachi});
            return result > 0;
        }

        public bool XoaTacGia(int matg)
        {
            int result = clsDataProvider.Instance.ExcuteNonQuerry("EXEC sp_XoaTacGia @matg", new object[] {matg});
            return result > 0;
        }

        public TacGia LayTGTheoMa(int matg)
        {
            TacGia tg = null;
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_LayTGTheoMa @matg", new object[] {matg});
            if (dt.Rows.Count > 0)
            {
                tg = new TacGia(dt.Rows[0]);
            }

            return tg;
        }

        public List<TacGia> TimDSTacGia(string chuoi)
        {
            List<TacGia> dsTG = new List<TacGia>();
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_TimTacGia @chuoi", new object[] {"%" + chuoi + "%"});
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dsTG.Add(new TacGia(row));
                }
            }

            return dsTG;
        }
    }
}
