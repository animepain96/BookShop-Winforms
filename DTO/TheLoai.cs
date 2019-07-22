using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TheLoai
    {
        private int maTL;
        private string tenTL;

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

        public string TenTL
        {
            get
            {
                return tenTL;
            }

            set
            {
                tenTL = value;
            }
        }

        public TheLoai(int matl, string tentl)
        {
            this.MaTL = matl;
            this.TenTL = tentl;
        }

        public TheLoai(DataRow row)
        {
            this.MaTL = (int) row["MaTL"];
            this.TenTL = row["TenTL"].ToString();
        }
    }
}
