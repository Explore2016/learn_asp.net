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
            context.Response.ContentType = "text/html";
            long ID = long.Parse(context.Session["id"].ToString());
            long Password = long.Parse(context.Session["password"].ToString());
            string Name = SqlHelper.ExecuteScalar("select Name from T_Students where ID=@ID and Password=@Password",
             new SqlParameter("@ID", ID),
             new SqlParameter("@Password", Password)).ToString();
            string Msg = context.Request["Msg"];
            int row = SqlHelpers.SqlHelper.ExecuteNonQuery("Insert into T_MessageBoard(Name,MessageContents,Supports,DataTime) values(@Name,@MessageContents,0,0)",
                new SqlParameter("@Name",Name),
                new SqlParameter("@MessageContents", Msg)
                 );
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