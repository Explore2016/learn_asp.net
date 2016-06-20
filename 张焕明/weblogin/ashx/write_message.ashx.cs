using Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace weblogin.ashx
{
    /// <summary>
    /// write_massage 的摘要说明
    /// </summary>
    public class write_massage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //string writetime = context.Request["nowtime"];
            string writetime = "aaa";
            string user = context.Request["username"];
            var praise = 0;
           
            string message = context.Request["message"];
            message = message.Replace("<.and.>", "&");
            message = message.Replace("<.shup.>", "#");

              //string message = java.net.URLDecoder.decode(pass,"utf-8");
              string conStr = ConfigurationManager.ConnectionStrings["ipname"].ConnectionString;
              using (SqlConnection conn = new SqlConnection(conStr))
              {
                  SqlHelper.ExecuteDataTable("insert into T_message(username,message,writetime) values (@username,@message,@writetime)", new SqlParameter("@username", user), new SqlParameter("@message", message), new SqlParameter("@writetime", writetime));
                  SqlHelper.ExecuteDataTable("insert into T_praise(message,praise) values (@message,@praise)", new SqlParameter("@message", message), new SqlParameter("@praise", praise));
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