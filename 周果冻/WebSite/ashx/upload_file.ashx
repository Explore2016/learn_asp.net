<%@ WebHandler Language="C#" Class="upload_file" %>

using System;
using System.Web;
using System.IO;

public class upload_file : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";

        HttpPostedFile file = context.Request.Files["upload"]; //获取上传的文件
        if (file == null)
            return;
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

        context.Response.Write("上传成功");
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}