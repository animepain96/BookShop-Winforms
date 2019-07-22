using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BLL
{
    public class clsNhanVienBLL
    {
        private static clsNhanVienBLL instance;

        public static clsNhanVienBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new clsNhanVienBLL();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private clsNhanVienBLL() { }

        public List<NhanVien> LayDSNhanVien(int manv)
        {
            return clsNhanVienDAO.Instance.LayDSNhanVien(manv);
        }

        public NhanVien LayThongTinNV(string user, string pass)
        {
            return clsNhanVienDAO.Instance.LayThongTinNV(user, pass);
        }

        public bool DangNhap(string user, string pass)
        {
            return clsNhanVienDAO.Instance.DangNhap(user, pass);
        }

        public bool DatLaiMatKhau(string user, string oldpass, string newpass)
        {
            return clsNhanVienDAO.Instance.DatLaiMatKhau(user, oldpass, newpass);
        }

        public bool CapNhatNhanVien(int manv, string tendangnhap, string hoten, DateTime ngaysinh, bool gioitinh,
            string sdt, string diachi)
        {
            return clsNhanVienDAO.Instance.CapNhatNhanVien(manv, tendangnhap, hoten, ngaysinh, gioitinh, sdt, diachi);
        }

        public bool XoaNhanVien(int manv)
        {
            return clsNhanVienDAO.Instance.XoaNhanVien(manv);
        }

        public bool ThemNhanVien(string tendangnhap, string hoten, DateTime ngaysinh, bool gioitinh,
            string sdt, string diachi)
        {
            return clsNhanVienDAO.Instance.ThemNhanVien(tendangnhap, hoten, ngaysinh, gioitinh, sdt, diachi);
        }

        public List<NhanVien> TimNhanVien(int manv, string chuoi)
        {
            return clsNhanVienDAO.Instance.TimNhanVien(manv,chuoi);
        }

        public NhanVien LayNVTheoMa(int manv)
        {
            return clsNhanVienDAO.Instance.LayNVTheoMa(manv);
        }

        public bool MatKhauMacDinh(int manv)
        {
            return clsNhanVienDAO.Instance.MatKhauMacDinh(manv);
        }

        public string LayTenNVTheoMa(int manv)
        {
            return clsNhanVienDAO.Instance.LayTenNVTheoMa(manv);
        }

        public bool DoiMatKhau(int manv, string matkhaumoi)
        {
            return clsNhanVienDAO.Instance.DoiMatKhau(manv, matkhaumoi);
        }

        public DataTable BaoCaoNangSuatNhanVien(DateTime frmdate, DateTime todate)
        {
            return clsNhanVienDAO.Instance.BaoCaoNangSuatNhanVien(frmdate, todate);
        }

        public DataTable LayDoanhThuCuaHang(DateTime frmdate, DateTime todate)
        {
            return clsNhanVienDAO.Instance.LayDoanhThuCuaHang(frmdate, todate);
        }

        public DataTable LayThongTinTong(int manv, int thang, int nam)
        {
            return clsNhanVienDAO.Instance.LayThongTinTong(manv, thang, nam);
        }

        public DataTable LayHoaDonThang(int manv, int thang)
        {
            return clsNhanVienDAO.Instance.LayHoaDonThang(manv, thang);
        }

        public DataTable LaySachBanChayThang(int manv, int thang)
        {
            return clsNhanVienDAO.Instance.LaySachBanChayThang(manv, thang);
        }
    }
}
