using my_web.cs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace my_web.ashx
{
    /// <summary>
    /// zancai 的摘要说明
    /// </summary>
    public class zancai : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];
            string name = context.Request["name"];     
            if (action == "zan")
            {
                UserServer.Update_zan(name);
                int zancount = UserServer.zancount(name);
                //Sqlhelper1.ExecuteNonQuery("Update messageboard set zancount=zancount+1 where name=@name ", new SqlParameter("@name", name));
                //int zancount = (int)Sqlhelper1.ExecuteScalar("select top 1 zancount from messageboard  where name=@name", new SqlParameter("@name", name));
                context.Response.Write(zancount);
            }
            else
            {
                UserServer.Update_cai(name);
                int caicount = UserServer.caicount(name);
                //Sqlhelper1.ExecuteNonQuery("Update messageboard set caicount=caicount+1 where name=@name ", new SqlParameter("@name", name));
                //int caicount = (int)Sqlhelper1.ExecuteScalar("select top 1 caicount from messageboard  where name=@name", new SqlParameter("@name", name));
                context.Response.Write(caicount);
            }
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