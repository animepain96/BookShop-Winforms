using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuNhap
    {
        private int maPN;
        private DateTime ngayNhap;
        private int maNV;

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

        public DateTime NgayNhap
        {
            get
            {
                return ngayNhap;
            }

            set
            {
                ngayNhap = value;
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

        public PhieuNhap(int mapn, DateTime ngaynhap, int manv)
        {
            this.MaPN = mapn;
            this.NgayNhap = ngaynhap;
            this.MaNV = manv;
        }

        public PhieuNhap(DataRow row)
        {
            this.MaPN = (int) row["MaPN"];
            this.NgayNhap = (DateTime)row["NgayNhap"];
            this.MaNV = (int) row["MaNV"];
        }
    }
}
