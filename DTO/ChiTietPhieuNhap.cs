using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietPhieuNhap
    {
        private int maCTPN;
        private int maPN;
        private int maSach;
        private int soLuongNhap;

        public int MaCTPN
        {
            get
            {
                return maCTPN;
            }

            set
            {
                maCTPN = value;
            }
        }

        public int MaPN
        {
            get
            {
                return maPN;
            }

            set
            {
                maPN = value;
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

        public int SoLuongNhap
        {
            get
            {
                return soLuongNhap;
            }

            set
            {
                soLuongNhap = value;
            }
        }

        public ChiTietPhieuNhap(int mactpn, int mapn, int masach, int soluongnhap)
        {
            this.MaCTPN = mactpn;
            this.MaPN = mapn;
            this.MaSach = masach;
            this.SoLuongNhap = soluongnhap;
        }

        public ChiTietPhieuNhap(DataRow row)
        {
            this.MaCTPN = (int) row["MaCTPN"];
            this.MaPN = (int)row["MaPN"];
            this.MaSach = (int)row["MaSach"];
            this.SoLuongNhap = (int)row["SoLuongNhap"];
        }
    }
}
