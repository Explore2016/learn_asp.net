using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    /// <summary>
    /// up_file_load 的摘要说明
    /// </summary>
    public class up_file_load : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string file_name = context.Request["name"].ToString();
            HttpPostedFile file = context.Request.Files["upload"]; //获取上传的文件
            if (file == null)
            {
                context.Response.Write("文件为空,上传失败");
                return;
            }
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
            //SqlHelpers.SqlHelper.ExecuteNonQuery("insert into F_address(Address,file_name) values(@Address,@file_name)", new SqlParameter("@Address", filepath), new SqlParameter("@file_name", file_name));
            //context.Response.Write("上传成功");
            Use_way.file_up_load(filepath, file_name);
            context.Response.Write("上传成功");
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