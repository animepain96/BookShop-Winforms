using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TacGia
    {
        private int maTG;
        private string tenTG;
        private string sDT;
        private string diaChi;

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

        public string TenTG
        {
            get
            {
                return tenTG;
            }

            set
            {
                tenTG = value;
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

        public TacGia(int matg, string tentg, string sdt, string diachi)
        {
            this.MaTG = matg;
            this.TenTG = tentg;
            this.SDT = sdt;
            this.DiaChi = diachi;
        }

        public TacGia(DataRow row)
        {
            this.MaTG = (int)row["MaTG"];
            this.TenTG = row["TenTG"].ToString();
            this.SDT = row["SDT"].ToString();
            this.DiaChi = row["DiaChi"].ToString();
        }
    }
}
