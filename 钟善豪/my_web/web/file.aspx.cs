using my_web.cs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace my_web.web
{
    public partial class file : System.Web.UI.Page
    {
        public DataTable table;
        public string path;
        protected void Page_Load(object sender, EventArgs e)
        {
            //table = Sqlhelper1.ExecuteDataTable("select * from T_file ");
            table=UserServer.GetTable_files();
            if (Request["id"]!=null)
            {
                long id = long.Parse(Request["id"]);
                table = UserServer.GetTable_file(id);
                // table = Sqlhelper1.ExecuteDataTable("select * from T_file where id=@id",new SqlParameter("@id",id));
                //writefile实现下载，要有Using system.IO
                string fileName = table.Rows[0]["filename"].ToString();//客户端保存的文件名
                string filePath = Server.MapPath(table.Rows[0]["filepath"].ToString());

                //string fileName = table.Rows[0]["FilesOrgName"].ToString();//客户端保存的文件名
                //string filePath = Server.MapPath(table.Rows[0]["FilesPath"].ToString());//路径
                //string filePath = Server.MapPath("") + path;//路径        
                // string filePath =@"C:\Users\Public\Pictures\Sample Pictures\1.jpg";
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
        }
    }
}