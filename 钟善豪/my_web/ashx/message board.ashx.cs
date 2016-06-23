using my_web.cs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace my_web.ashx
{
    /// <summary>
    /// message_board 的摘要说明
    /// </summary>
    public class message_board : IHttpHandler
    {
        public string id;
        public string text;
        public string name;
        public string time;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.ContentType = "text/html";
            //id = context.Request["id"];
            id = context.Request["ID"];
            name = context.Request["name"];
            text = context.Request["message"];
            UserServer.insert(id,name,text);
            //Sqlhelper1.ExecuteNonQuery("insert into messageboard (id,name,text,time,zancount,caicount)values(@id,@name,@text,GetDate(),0,0)", new SqlParameter("@id", id), new SqlParameter("@name", name), new SqlParameter("@text", text));
            context.Response.Redirect("../web/message board.aspx?id="+id);
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