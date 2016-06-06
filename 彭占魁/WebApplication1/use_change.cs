using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class use_change
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["pzk"].ConnectionString;
        public static int Executechange(string sql, params SqlParameter[] pa)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(pa);
                    cmd.ExecuteNonQuery();
                    return 0;
                }
            }
        }
    }
}