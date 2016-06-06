using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class SqlHelper
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["dbConnStr"].ConnectionString;
        //public static DataTable ExecuteDataTable(string sql, params SqlParameter[] pa)
        //{
        //    using (SqlConnection conn = new SqlConnection(connStr))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = sql;
        //            //foreach (SqlParameter param in pa)
        //            //{
        //            //    cmd.Parameters.Add(pa);
        //            //}
        //            cmd.Parameters.AddRange(pa);
        //            // ExecuteScalar()
        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //            DataSet dataset = new DataSet();
        //            try
        //            {
        //                adapter.Fill(dataset);
        //            }
        //            catch
        //            {
        //                ;
        //            }
        //            return dataset.Tables[0];

        //      }
        //  }
        // }

        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dataset = new DataSet();
                   adapter.Fill(dataset);
                    //try
                    //{
                    //    adapter.Fill(dataset);
                    //}
                    //catch
                    //{
                    //    ;
                    //}
                    return dataset.Tables[0];
                }
            }
        }
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