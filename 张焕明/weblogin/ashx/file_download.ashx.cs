using Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace weblogin.ashx
{
    /// <summary>
    /// file_download 的摘要说明
    /// </summary>
    public class file_download : IHttpHandler, IRequiresSessionState
    {

        public DataTable table;
        public int admin;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Session["user"] == null || context.Session["password"] == null)
            {
                context.Response.Redirect("login.html");
                return;
            }
            if (context.Request["ID_dl"] != null)
            {
                long ID_dl = long.Parse(context.Request["ID_dl"]);
                DataTable table_dl = SqlHelper.ExecuteDataTable("select * from T_address where Id=@ID",
                    new SqlParameter("@ID", ID_dl));
                //writefile实现下载，要有Using system.IO
                string fileName = table_dl.Rows[0]["Filesname"].ToString();//客户端保存的文件名
                string filePath = System.Web.HttpContext.Current.Server.MapPath(table_dl.Rows[0]["Fileswhere"].ToString());//路径
                FileInfo fileInfo = new FileInfo(filePath);
                context.Response.Clear();
                context.Response.ClearContent();
                context.Response.ClearHeaders();
                context.Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                context.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                context.Response.AddHeader("Content-Transfer-Encoding", "binary");
                context.Response.ContentType = "application/octet-stream";
                context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                context.Response.WriteFile(fileInfo.FullName);
                context.Response.Flush();
                context.Response.End();
            }
            DataTable table_Admin;
            table = SqlHelper.ExecuteDataTable("select * from T_address");
            long ID = long.Parse(context.Session["id"].ToString());
            long Password = long.Parse(context.Session["password"].ToString());
            table_Admin = SqlHelper.ExecuteDataTable("select * from T_login where Id=@ID and Password=@Password",
             new SqlParameter("@ID", ID),
             new SqlParameter("@Password", Password));
            if (int.Parse(table_Admin.Rows[0]["Admin"].ToString()) == 1)
            {
                admin = 1;
            }
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