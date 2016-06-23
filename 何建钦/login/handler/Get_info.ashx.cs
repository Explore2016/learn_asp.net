using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace login.handler
{
    /// <summary>
    /// Get_info 的摘要说明
    /// </summary>
    public class Get_info : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            if (context.Session["id"] == null || context.Session["password"] == null)
            {
                context.Response.Redirect("login.html");
                return;
            }
            long ID = long.Parse(context.Session["id"].ToString());
            long Password = long.Parse(context.Session["password"].ToString());
            DataTable table = UserServer.GetStudent_list(ID, Password);
            object info = new object();
            DataRow row = table.Rows[0];
            info = new
            {
                Id = row["ID"],
                Name = row["Name"],
                Gender=row["Gender"],
                Major=row["Major"],
            };
            string json = new JavaScriptSerializer().Serialize(info);
            context.Response.Write(json);
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