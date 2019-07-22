using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietHoaDon
    {
        private int maCTHD;
        private int maHD;
        private int maSach;
        private int soLuongBan;

        public int MaCTHD
        {
            get
            {
                return maCTHD;
            }

            set
            {
                maCTHD = value;
            }
        }

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

        public int MaSach
        {
            get
            {
                return maSach;
            }

            set
            {
                maSach = value;
            }
        }

        public int SoLuongBan
        {
            get
            {
                return soLuongBan;
            }

            set
            {
                soLuongBan = value;
            }
        }

        public ChiTietHoaDon(int macthd, int mahd, int masach, int soluongban)
        {
            this.MaCTHD = macthd;
            this.MaHD = mahd;
            this.MaSach = masach;
            this.SoLuongBan = soluongban;
        }

        public ChiTietHoaDon(DataRow row)
        {
            this.MaCTHD = (int) row["MaCTHD"];
            this.MaHD = (int)row["MaHD"];
            this.MaSach = (int)row["MaSach"];
            this.SoLuongBan = (int)row["SoLuongBan"];
        }
    }
}
