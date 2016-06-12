using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace login.handler
{
    /// <summary>
    /// upload_files 的摘要说明
    /// </summary>
    public class upload_files : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            HttpPostedFile file = context.Request.Files["upload"];
            string FileOrgName = file.FileName;
            string FileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string FilePath = "../files/" + FileName;
            string manpath = context.Server.MapPath(FilePath);
            try
            {
                file.SaveAs(manpath); //保存文件，SaveAs()方法需要绝对路径
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
                return;
            }
            int row = SqlHelpers.SqlHelper.ExecuteNonQuery("Insert into T_FilesList(FilesOrgName,FilesName,FilesPath) values(@FilesOrgName,@FilesName,@FilesPath)",
                new SqlParameter("@FilesOrgName", FileOrgName),
                new SqlParameter("@FilesName", FileName),
                new SqlParameter("@FilesPath", FilePath)
                );
            context.Response.Redirect("../html/Files.aspx");
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