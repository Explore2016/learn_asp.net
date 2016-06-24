using my_web.cs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace my_web
{
    /// <summary>
    /// login 的摘要说明
    /// </summary>
    public class login : IHttpHandler,IRequiresSessionState
    {
        public void  ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string use = context.Request["use"];
             string password = context.Request["password"];
            DataTable ds = UserServer.login(use,password);
            //DataTable ds = Sqlhelper1.ExecuteDataTable("select * from student where id=@id and  keys=@keys", new SqlParameter("@id", use), new SqlParameter("@keys", password));
            if (ds.Rows.Count == 1)
            {
                context.Response.Write("ok");
                foreach (DataRow row in ds.Rows)
                {
                    int id = (int)row["id"];
                    string keys = (string)row["keys"];
                    string name = (string)row["name"];
                    string sex = row["sex"].ToString();
                    int age = (int)row["age"];                
                    //context.Response.SetCookie(new HttpCookie("id", id.ToString()));
                    context.Session["id"] = id;
                }
            }
            else
                context.Response.Write("error");
            
            
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