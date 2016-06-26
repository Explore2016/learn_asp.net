using SqlHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace WebApplication1
{
    /// <summary>
    /// land1 的摘要说明
    /// </summary>
    public class land1 : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int ID = Convert.ToInt32(context.Session["ID"]);
            DataTable dt = Use_way.select(ID);
            object info = new object();
            DataRow row = dt.Rows[0];
            info = new
            {
                ID = row["ID"],
                name = row["name"],
                class_ID=row["class ID"],
                student_number=row["stdent_number"],
                password = row["pass_word"],
                major=row["major"],
                college=row["college"],
                VIP=row["VIP"],
                Cookie = row["Cookie"]
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