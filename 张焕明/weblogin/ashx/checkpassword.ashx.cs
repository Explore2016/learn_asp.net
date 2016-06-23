using Helper;
using sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using weblogin;

namespace weblogin
{
    /// <summary>
    /// checkmima 的摘要说明
    /// </summary>
    public class checkmima : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string username = context.Request["username"];
            string password = context.Request["password"];
            string conStr = ConfigurationManager.ConnectionStrings["ipname"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                DataTable table = userservice.checkpass(username);
                foreach (DataRow row in table.Rows)
                {
                    string name = (string)row["Name"];
                    string password2 = (string)row["Password"];
                    string Id = (string)row["Administrator"];
                    if (password == password2)
                    {
                        context.Session["user"]=username;
                        context.Session["password"] = password2;
                        context.Session["Id"] = Id;
                        context.Response.Write("yes");
                       return;
                    }
                }
                context.Response.Write("no");
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