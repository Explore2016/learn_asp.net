using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SqlHelpers;

namespace WebApplication1
{
    /// <summary>
    /// Message_approve 的摘要说明
    /// </summary>
    public class Message_approve : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {          
            context.Response.ContentType = "text/plain";
            long ID = long.Parse(context.Request["id"]);
            //SqlHelpers.SqlHelper.ExecuteNonQuery("Update T_MessageBoard set Approve=Approve+1 where ID=@ID",
            //    new SqlParameter("@ID", ID));
            Use_way.Message_approve_updata(ID);
            long count=Use_way.Message_approve_select_ID(ID);
            //long.Parse(SqlHelpers.SqlHelper.ExecuteScalar("Select Approve from T_MessageBoard where ID=@ID",
            //     new SqlParameter("@ID", ID)).ToString());
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