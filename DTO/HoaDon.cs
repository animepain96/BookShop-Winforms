using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon
    {
        private int maHD;
        private DateTime ngayBan;
        private int giamGia;
        private int maNV;

        public int MaHD
        {
            get
            {
                return maHD;
            }

            set
            {
                maHD = value;
            }
        }

        public DateTime NgayBan
        {
            get
            {
                return ngayBan;
            }

            set
            {
                ngayBan = value;
            }
        }

        public int GiamGia
        {
            get
            {
                return giamGia;
            }

            set
            {
                giamGia = value;
            }
        }

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

        public HoaDon(int mahd, DateTime ngayban, int giamgia, int manv)
        {
            this.MaHD = mahd;
            this.NgayBan = ngayban;
            this.GiamGia = giamgia;
            this.MaNV = manv;
        }

        public HoaDon(DataRow row)
        {
            this.MaHD = (int) row["MaHD"];
            this.NgayBan = (DateTime)row["NgayBan"];
            this.GiamGia = (int) row["GiamGia"];
            this.MaNV = (int) row["MaNV"];
        }
    }
}
