using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAO
{
    class clsDataProvider
    {
        private static clsDataProvider instance;

        public static clsDataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new clsDataProvider();
                }
                return instance;
            }
            private set { instance = value; }
        }

        private clsDataProvider() { }

        private static string strcon = @"Server=.\sqlexpress; Database=CuaHangSach; User Id=sa; pwd=123";

        public DataTable ExcuteQuerry(string querry, object[] paras = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(strcon))
                {
                    sqlcon.Open();
                    SqlCommand com = new SqlCommand(querry, sqlcon);
                    string[] para = querry.Split(' ');
                    if (para.Length > 0)
                    {
                        int i = 0;
                        foreach (string item in para)
                        {
                            if (item.Contains('@'))
                            {
                                com.Parameters.AddWithValue(item, paras[i]);
                                i++;
                            }
                        }
                    }
                    SqlDataAdapter adap = new SqlDataAdapter(com);
                    adap.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

        public int ExcuteNonQuerry(string querry, object[] paras = null)
        {
            int result = 0;
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(strcon))
                {
                    sqlcon.Open();
                    SqlCommand com = new SqlCommand(querry, sqlcon);
                    string[] para = querry.Split(' ');
                    if (para.Length > 0)
                    {
                        int i = 0;
                        foreach (string item in para)
                        {
                            if (item.Contains('@'))
                            {
                                com.Parameters.AddWithValue(item, paras[i]);
                                i++;
                            }
                        }
                    }

                    result = com.ExecuteNonQuery();
                }

                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        public object ExcuteScalar(string querry, object[] paras = null)
        {
            object result = 0;
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(strcon))
                {
                    sqlcon.Open();
                    SqlCommand com = new SqlCommand(querry, sqlcon);
                    string[] para = querry.Split(' ');
                    if (para.Length > 0)
                    {
                        int i = 0;
                        foreach (string item in para)
                        {
                            if (item.Contains('@'))
                            {
                                com.Parameters.AddWithValue(item, paras[i]);
                                i++;
                            }
                        }
                    }

                    result = com.ExecuteScalar();
                }

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
