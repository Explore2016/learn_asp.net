using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    /// <summary>
    /// delete 的摘要说明
    /// </summary>
    public class delete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int ID = Convert.ToInt32(context.Request["ID"]);
            use_change.Executechange("delete from T_student where ID=@ID",new SqlParameter("@ID", ID));
            context.Response.Write("<script>confirm('删除成功！');location.href='../html/central frame.aspx';</script>");
            //if (ds.Rows.Count == 0)
            //{
            //    context.Response.Write("<script>confirm('删除成功！'),location.href='view_string.aspx';");
            //}
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