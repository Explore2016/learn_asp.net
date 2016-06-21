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
            UserServer.Support(ID);
            long count = UserServer.GetSupportsCount(ID);
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