using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien
    {
        private int maNV;
        private string tenDangNhap;
        private string hoTen;
        private DateTime ngaySinh;
        private bool gioiTinh;
        private string sDT;
        private string diaChi;

        public int MaNV
        {
            get
            {
                return maNV;
            }

            set
            {
                maNV = value;
            }
        }

        public string TenDangNhap
        {
            get
            {
                return tenDangNhap;
            }

            set
            {
                tenDangNhap = value;
            }
        }

        public string HoTen
        {
            get
            {
                return hoTen;
            }

            set
            {
                hoTen = value;
            }
        }

        public DateTime NgaySinh
        {
            get
            {
                return ngaySinh;
            }

            set
            {
                ngaySinh = value;
            }
        }

        public bool GioiTinh
        {
            get
            {
                return gioiTinh;
            }

            set
            {
                gioiTinh = value;
            }
        }

        public string SDT
        {
            get
            {
                return sDT;
            }

            set
            {
                sDT = value;
            }
        }

        public string DiaChi
        {
            get
            {
                return diaChi;
            }

            set
            {
                diaChi = value;
            }
        }

        public NhanVien(int manv, string tendangnhap, string hoten, DateTime ngaysinh, bool gioitinh,
            string sdt, string diachi)
        {
            this.MaNV = manv;
            this.TenDangNhap = tendangnhap;
            this.HoTen = hoten;
            this.NgaySinh = ngaysinh;
            this.GioiTinh = gioitinh;
            this.SDT = sdt;
            this.DiaChi = diachi;
        }

        public NhanVien(DataRow row)
        {
            this.MaNV = (int)row["MaNV"];
            this.TenDangNhap = row["TenDangNhap"].ToString();
            this.HoTen = row["HoTen"].ToString();
            this.NgaySinh = (DateTime)row["NgaySinh"];
            this.GioiTinh = (bool)row["GioiTinh"];
            this.SDT = row["SDT"].ToString();
            this.DiaChi = row["DiaChi"].ToString();
        }
    }
}
