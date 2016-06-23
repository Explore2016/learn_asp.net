using my_web.cs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace my_web
{
    /// <summary>
    /// delete 的摘要说明
    /// </summary>
    public class delete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.ContentType = "text/html";         
            string id =context.Request["id"];
            UserServer.delete(id);
            //Sqlhelper1.ExecuteScalar("delete from student where id=@id",new SqlParameter("@id", id));
            context.Response.Write("<script>confirm('删除成功');location.href = '../web/my_info.aspx';</script>");
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