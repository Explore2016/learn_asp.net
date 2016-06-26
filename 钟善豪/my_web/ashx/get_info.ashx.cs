using my_web.cs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace my_web.ashx
{
    /// <summary>
    /// get_info 的摘要说明
    /// </summary>
    public class get_info : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";       
            int ID =Convert.ToInt32(context.Session["id"].ToString());
            context.Session["use"] = ID;
            DataTable table  = UserServer.GetTable(ID);
            object info = new object();
            DataRow row = table.Rows[0];
            info = new
            {
                id = row["id"],
                name = row["name"],
                sex = row["sex"],
                age = row["age"],
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