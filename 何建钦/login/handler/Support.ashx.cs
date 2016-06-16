using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace login.handler
{
    /// <summary>
    /// Support 的摘要说明
    /// </summary>
    public class Support : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            long ID = long.Parse(context.Request["id"]);
            SqlHelpers.SqlHelper.ExecuteNonQuery("Update T_MessageBoard set Supports=Supports+1 where ID=@ID",
                new SqlParameter("@ID", ID));
            long count = long.Parse(SqlHelpers.SqlHelper.ExecuteScalar("Select Supports from T_MessageBoard where ID=@ID",
                new SqlParameter("@ID", ID)).ToString());
            context.Response.Write(count);
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