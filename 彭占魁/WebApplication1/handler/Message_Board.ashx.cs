using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WebApplication1
{
    /// <summary>
    /// Message_Board1 的摘要说明
    /// </summary>
    public class Message_Board1 : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";         
            int ID = Convert.ToInt32(context.Session["ID"].ToString());
            DataTable message = SqlHelpers.SqlHelper.ExecuteDataTable("select * from T_student where ID=@ID",
                         new SqlParameter[] { new SqlParameter("@ID", ID) });
            string Msg = context.Request["Msg"];
            string Name = message.Rows[0]["name"].ToString();
            //string Data = DateTime.Now.ToLongTimeString();获得当前时间ashx方式，GetDate()是SQl方式
            Use_way.Message_Board_insert(Name,Msg);
                //SqlHelpers.SqlHelper.ExecuteNonQuery("Insert into T_MessageBoard(Name,MessageContents,Approve,DataTime) values(@Name,@MessageContents,0,GetDate())",
                //new SqlParameter("@Name", Name),
                //new SqlParameter("@MessageContents", Msg)
                // );
            context.Response.Redirect("../html/Message_Board.aspx");
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