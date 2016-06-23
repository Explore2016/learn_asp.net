using Helper;
using sql;
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
            userservice.messageupdate(id);
            string number = userservice.message(id);
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