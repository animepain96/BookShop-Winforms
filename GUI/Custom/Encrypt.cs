using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;

namespace Encrypt
{
    class Encrypt
    {
        private static Encrypt instance;

        public static Encrypt Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new Encrypt();
                }

                return instance;
            }
            private set { instance = value; }
        }

        private Encrypt() { }

        public string MD5Encrypt(string text)
        {
            StringBuilder result = new StringBuilder();
            MD5 md5 = MD5.Create();
            byte[] bytes = ASCIIEncoding.ASCII.GetBytes(text);
            byte[] hash = md5.ComputeHash(bytes);
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("x2"));
            }
            return result.ToString();
        }
    }
}
