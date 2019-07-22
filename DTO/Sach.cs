using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Sach
    {
        private int maSach;
        private string tenSach;
        private float giaBan;
        private int namXB;
        private int soLuongTon;
        private int maNXB;
        private int maTL;
        private int maTG;

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

        public string TenSach
        {
            get
            {
                return tenSach;
            }

            set
            {
                tenSach = value;
            }
        }

        public float GiaBan
        {
            get
            {
                return giaBan;
            }

            set
            {
                giaBan = value;
            }
        }

        public int NamXB
        {
            get
            {
                return namXB;
            }

            set
            {
                namXB = value;
            }
        }

        public int SoLuongTon
        {
            get
            {
                return soLuongTon;
            }

            set
            {
                soLuongTon = value;
            }
        }

        public int MaNXB
        {
            get
            {
                return maNXB;
            }

            set
            {
                maNXB = value;
            }
        }

        public int MaTL
        {
            get
            {
                return maTL;
            }

            set
            {
                maTL = value;
            }
        }

        public int MaTG
        {
            get
            {
                return maTG;
            }

            set
            {
                maTG = value;
            }
        }

        public Sach(DataRow row)
        {
            this.MaSach = (int) row["MaSach"];
            this.TenSach = row["TenSach"].ToString();
            this.GiaBan = float.Parse(row["GiaBan"].ToString());
            this.NamXB = (int) row["NamXB"];
            this.SoLuongTon = (int) row["SoLuongTon"];
            this.MaNXB = (int) row["MaNXB"];
            this.MaTL = (int) row["MaTL"];
            this.MaTG = (int) row["MaTG"];
        }

        public Sach(int masach, string tensach, float giaban, int namxb, int soluongton, int manxb, int matl, int matg)
        {
            this.MaSach = masach;
            this.TenSach = tensach;
            this.GiaBan = giaban;
            this.NamXB = namxb;
            this.SoLuongTon = soluongton;
            this.MaNXB = manxb;
            this.MaTL = matl;
            this.MaTG = matg;
        }
    }
}
