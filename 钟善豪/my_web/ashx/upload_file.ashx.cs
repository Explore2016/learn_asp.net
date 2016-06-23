using my_web.cs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace my_web.ashx
{
    /// <summary>
    /// upload_file 的摘要说明
    /// </summary>
    public class upload_file : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.ContentType = "text/html";
            HttpPostedFile file = context.Request.Files["upload"]; //获取上传的文件
            if (file.FileName=="")
            {
                context.Response.Write("<script>alert('请选择文件 ');location.href = '../web/file.aspx';</script>");
                return;
            }
            string file_name = file.FileName;
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
            UserServer.upload_file(file_name, filepath);
            //Sqlhelper1.ExecuteNonQuery("Insert into T_file(filename,filepath) values(@filename,@filepath)", new SqlParameter("@filename", file_name), new SqlParameter("@filepath", filepath));
            context.Response.Write("<script>alert('上传成功 ');location.href = '../web/file.aspx';</script>");
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