using Helper;
using sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace weblogin.ashx
{
    /// <summary>
    /// write_massage 的摘要说明
    /// </summary>
    public class write_massage : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //string writetime = context.Request["nowtime"];
            string writetime = "aaa";
            string user = (string)context.Session["user"];
            var praise = 0;
           
            string message = context.Request["message"];
            message = message.Replace("<.and.>", "&");
            message = message.Replace("<.shup.>", "#");

              //string message = java.net.URLDecoder.decode(pass,"utf-8");
              string conStr = ConfigurationManager.ConnectionStrings["ipname"].ConnectionString;
              using (SqlConnection conn = new SqlConnection(conStr))
              {
                  userservice.writemessage(user, message, writetime);
                  userservice.praisemessage(message, praise);
                  context.Response.Write("发表成功");
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