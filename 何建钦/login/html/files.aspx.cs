using SqlHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace login.html
{
    public partial class fles : System.Web.UI.Page
    {
        public DataTable table;
        public int admin;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.Session["id"] == null || Context.Session["password"] == null)
            {
                Context.Response.Redirect("login.html");
                return;
            }
            if (Request["ID_dl"] != null)
            {
                long ID_dl = long.Parse(Request["ID_dl"]);
                DataTable table_dl = SqlHelper.ExecuteDataTable("select * from T_FilesList where ID=@ID",
                    new SqlParameter("@ID",ID_dl));
                //writefile实现下载，要有Using system.IO
                string fileName = table_dl.Rows[0]["FilesOrgName"].ToString();//客户端保存的文件名
                string filePath = Server.MapPath(table_dl.Rows[0]["FilesPath"].ToString());//路径
                FileInfo fileInfo = new FileInfo(filePath);
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.AddHeader("Content-Transfer-Encoding", "binary");
                Response.ContentType = "application/octet-stream";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                Response.WriteFile(fileInfo.FullName);
                Response.Flush();
                Response.End();
            }
            DataTable table_Admin;
            table = SqlHelper.ExecuteDataTable("select * from T_FilesList");
            long ID = long.Parse(Session["id"].ToString());
            long Password = long.Parse(Session["password"].ToString());
            table_Admin = SqlHelper.ExecuteDataTable("select * from T_Students where ID=@ID and Password=@Password",
             new SqlParameter("@ID", ID),
             new SqlParameter("@Password", Password));
            if (int.Parse(table_Admin.Rows[0]["Admin"].ToString()) == 1)
            {
                admin = 1;
            }
        }
    }
}