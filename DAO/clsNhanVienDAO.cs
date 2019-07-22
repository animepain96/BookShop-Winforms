using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class clsNhanVienDAO
    {
        private static clsNhanVienDAO instance;

        public static clsNhanVienDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new clsNhanVienDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private clsNhanVienDAO() { }

        public List<NhanVien> LayDSNhanVien(int manv)
        {

            List<NhanVien> dsNV = new List<NhanVien>();
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_LayDanhSachNhanVien @manv", new object[] {manv});
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dsNV.Add(new NhanVien(row));
                }
            }

            return dsNV;

        }

        public NhanVien LayThongTinNV(string user, string pass)
        {
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("exec sp_LayThongTinNhanVien @tendangnhap , @matkhau", new object[] {user, pass});
            NhanVien nv = new NhanVien(dt.Rows[0]);
            return nv;
        }

        public bool DangNhap(string user, string pass)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_DangNhap @user , @pass", new object[] {user, pass});
                return dt.Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool DatLaiMatKhau(string user, string oldpass, string newpass)
        {
            if (DangNhap(user, oldpass))
            {
                int result = clsDataProvider.Instance.ExcuteNonQuerry("", new object[] {user, oldpass, newpass});
                return result > 0;
            }
            else
            {
                return false;
            }
        }

        public bool CapNhatNhanVien(int manv, string tendangnhap, string hoten, DateTime ngaysinh, bool gioitinh,
            string sdt, string diachi)
        {
            int result = clsDataProvider.Instance.ExcuteNonQuerry(
                "EXEC sp_CapNhatThongTinNhanVien @manv , @tendangnhap , @hoten , @ngaysinh , @gioitinh , @sdt , @diachi",
                new object[] {manv, tendangnhap, hoten, ngaysinh, gioitinh, sdt, diachi});
            return result>0;
        }

        public bool XoaNhanVien(int manv)
        {
            int result = clsDataProvider.Instance.ExcuteNonQuerry("EXEC sp_XoaNhanVien @manv", new object[] {manv});
            return result > 0;
        }

        public bool ThemNhanVien(string tendangnhap, string hoten, DateTime ngaysinh, bool gioitinh,
            string sdt, string diachi)
        {
            int result = clsDataProvider.Instance.ExcuteNonQuerry(
                "EXEC sp_ThemNhanVien @tendangnhap , @hoten , @ngaysinh , @gioitinh , @sdt , @diachi",
                new object[] {tendangnhap, hoten, ngaysinh, gioitinh, sdt, diachi});
            return result > 0;
        }

        public List<NhanVien> TimNhanVien(int manv, string chuoi)
        {
            List<NhanVien> dsNV = new List<NhanVien>();
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_TimNhanVien @manv , @chuoi",
                new object[] {manv, "%" + chuoi + "%"});
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dsNV.Add(new NhanVien(row));
                }
            }

            return dsNV;
        }

        public NhanVien LayNVTheoMa(int manv)
        {
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_LayNhanVienTheoMa @manv", new object[] {manv});
            NhanVien nv = new NhanVien(dt.Rows[0]);
            return nv;
        }

        public bool MatKhauMacDinh(int manv)
        {
            int result = clsDataProvider.Instance.ExcuteNonQuerry("EXEC sp_DatLaiMatKhau @manv", new object[] {manv});
            return result>0;
        }

        public string LayTenNVTheoMa(int manv)
        {
            string hoten = clsDataProvider.Instance
                .ExcuteScalar("EXEC sp_LayTenNhanVienTheoMa @manv", new object[] {manv}).ToString();
            return hoten;
        }

        public bool DoiMatKhau(int manv, string matkhaumoi)
        {
            int result =
                clsDataProvider.Instance.ExcuteNonQuerry("EXEC sp_DoiMatKhau @manv , @matkhaumoi ",
                    new object[] {manv, matkhaumoi});
            return result > 0;
        }

        public DataTable BaoCaoNangSuatNhanVien(DateTime frmdate, DateTime todate)
        {
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_BaoCaoNangSuatNhanVien @frmdate , @todate",
                new object[] {frmdate, todate});
            return dt;
        }

        public DataTable LayDoanhThuCuaHang(DateTime frmdate, DateTime todate)
        {
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_BaoCaoDoanhThuCuaHang @frmdate , @todate",
                new object[] {frmdate, todate});
            return dt;
        }

        public DataTable LayThongTinTong(int manv, int thang, int nam)
        {
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_LayThongTinTong @manv , @thang , @nam",
                new object[] {manv, thang, nam});
            return dt;
        }

        public DataTable LayHoaDonThang(int manv, int thang)
        {
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_LayHoaDonThang @manv , @thang",
                new object[] {manv, thang});
            return dt;
        }

        public DataTable LaySachBanChayThang(int manv, int thang)
        {
            DataTable dt = new DataTable();
            dt = clsDataProvider.Instance.ExcuteQuerry("EXEC sp_LaySachBanChayThang @manv , @thang",
                new object[] {manv, thang});
            return dt;
        }
    }
}
