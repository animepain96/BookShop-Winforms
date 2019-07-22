using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Quyen
    {
        private int maQuyen;
        private string tenQuyen;

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

        public string TenQuyen
        {
            get
            {
                return tenQuyen;
            }

            set
            {
                tenQuyen = value;
            }
        }

        public Quyen(int maquyen, string tenquyen)
        {
            this.MaQuyen = maquyen;
            this.TenQuyen = tenquyen;
        }

        public Quyen(DataRow row)
        {
            this.MaQuyen = (int) row["MaQuyen"];
            this.TenQuyen = row["TenQuyen"].ToString();
        }
    }
}
