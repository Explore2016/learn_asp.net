using Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace weblogin.ashx
{
    /// <summary>
    /// message 的摘要说明
    /// </summary>
    public class message : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string id = context.Request["Id"];
            SqlHelper.ExecuteDataTable("Update T_praise set praise=praise+1 where Id =@id", new SqlParameter("@id", id));
            string number = (string)SqlHelper.ExecuteScalar("select praise from T_praise where Id =@id", new SqlParameter("@id",id));
            context.Response.Write(number);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}