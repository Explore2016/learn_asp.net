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
    /// change 的摘要说明
    /// </summary>
    public class change : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            HttpCookie cookie = context.Request.Cookies["user"];
            string username = cookie.Value;
            string password = context.Request["mima"];
            string studyid = context.Request["xuehao"];
            string iname = context.Request["people"];
            string myname = context.Request["myname"];
            string conStr = ConfigurationManager.ConnectionStrings["ipname"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                SqlHelper.ExecuteDataTable("update T_login set Password=@password,studentnumber=@studyid ,peoplename=@iname,Idcard=@myname where Name=@username", new SqlParameter("@username", username), new SqlParameter("@password", password), new SqlParameter("@studyid", studyid), new SqlParameter("@iname", iname), new SqlParameter("@myname", myname));
                context.Response.Write("成功更改");
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