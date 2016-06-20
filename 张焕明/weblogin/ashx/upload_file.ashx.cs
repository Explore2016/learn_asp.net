using Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace weblogin.ashx
{
    /// <summary>
    /// upload_file 的摘要说明
    /// </summary>
    public class upload_file : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            HttpPostedFile file = context.Request.Files["upload"]; //获取上传的文件
            if (file == null)
                return;
            string fileorgname = file.FileName;
            string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName); //将文件名设置成guid值，避免重复
            string filepath = "../upload_files/" + filename; //生成文件路径
            //filename = GetMD5HashFromFile(file);
            string manpath = context.Server.MapPath(filepath); //用context.Server.MapPath()生成绝对路径

            try
            {
                file.SaveAs(manpath); //保存文件，SaveAs()方法需要绝对路径
            }
            catch (Exception ex)
            {
                filename = null;
                context.Response.Write(ex.Message);
                return;
            }

             string conStr = ConfigurationManager.ConnectionStrings["ipname"].ConnectionString;
             using (SqlConnection conn = new SqlConnection(conStr))
             {
                 SqlHelper.ExecuteDataTable("insert into T_address(Fileswhere,Filesname,Filesguid) values (@Filewhere,@Filename,@Fileguid)", new SqlParameter("@Filewhere", filepath), new SqlParameter("@Filename", fileorgname), new SqlParameter("@Fileguid", filename));
                 context.Response.Write("上传成功");
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