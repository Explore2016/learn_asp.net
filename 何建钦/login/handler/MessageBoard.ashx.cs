using SqlHelpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace login.handler
{
    /// <summary>
    /// MessageBoard 的摘要说明
    /// </summary>
    public class MessageBoard : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request["Msg"] == null)
            {
                context.Response.Redirect("../html/MessageBoard.aspx");
                return;
            }
            context.Response.ContentType = "text/html";
            long ID = long.Parse(context.Session["id"].ToString());
            long Password = long.Parse(context.Session["password"].ToString());
            string Name = UserServer.GetMessageName(ID, Password);
            string Msg = context.Request["Msg"];
            int row = UserServer.LeaveAMessage(Name, Msg);
            context.Response.Redirect("../html/MessageBoard.aspx");
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