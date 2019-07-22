using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaXuatBan
    {
        private int maNXB;
        private string tenNXB;
        private string diaChi;

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

        public string TenNXB
        {
            get
            {
                return tenNXB;
            }

            set
            {
                tenNXB = value;
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

        public NhaXuatBan(int manxb, string tennxb, string diachi)
        {
            this.MaNXB = manxb;
            this.TenNXB = tennxb;
            this.DiaChi = diachi;
        }

        public NhaXuatBan(DataRow row)
        {
            this.MaNXB = (int) row["MaNXB"];
            this.TenNXB = row["TenNXB"].ToString();
            this.DiaChi = row["DiaChi"].ToString();
        }
    }
}
