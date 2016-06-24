using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace weblogin.ashx
{
    /// <summary>
    /// indix 的摘要说明
    /// </summary>
    public class indix : IHttpHandler
    {
        public string username;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
             username = (string)context.Session["user"];
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