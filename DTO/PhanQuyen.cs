using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhanQuyen
    {
        private int maQuyen;
        private int maNV;

        public int MaQuyen
        {
            get
            {
                return maQuyen;
            }

            set
            {
                maQuyen = value;
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

        public PhanQuyen(int maquyen, int manv)
        {
            this.MaQuyen = maquyen;
            this.MaNV = manv;
        }

        public PhanQuyen(DataRow row)
        {
            this.MaQuyen = (int) row["MaQuyen"];
            this.MaNV = (int) row["MaNV"];
        }
    }
}
