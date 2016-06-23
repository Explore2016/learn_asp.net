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
    /// change 的摘要说明
    /// </summary>
    public class change : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string username = (string)context.Session["user"];
            //string username = cookie.Value;
            string password = context.Request["mima"];
            string studyid = context.Request["xuehao"];
            string iname = context.Request["people"];
            string myname = context.Request["myname"];
            string conStr = ConfigurationManager.ConnectionStrings["ipname"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                userservice.somechange(username, password, studyid, iname, myname);
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