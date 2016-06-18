using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Fire : System.Web.UI.Page
    {
        public DataTable table;
        public int admin;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["ID_dl"] != null)
            {
                long ID_dl = long.Parse(Request["ID_dl"]);
                DataTable table_dl = SqlHelpers.SqlHelper.ExecuteDataTable("select * from F_address where ID=@ID",
                    new SqlParameter("@ID", ID_dl));
                //writefile实现下载，要有Using system.IO
                string fileName = "text";//客户端保存的文件名
                string filePath = Server.MapPath(table_dl.Rows[0]["Address"].ToString());//路径
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
            table = SqlHelpers.SqlHelper.ExecuteDataTable("select * from F_address");
        }
    }
}