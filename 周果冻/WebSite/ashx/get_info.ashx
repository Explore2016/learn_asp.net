<%@ WebHandler Language="C#" Class="get_info" %>

using System;
using System.Web;
using System.Data;
using System.Web.Script.Serialization;
using DAL;

public class get_info : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";

        string username = "zogodo";
        
        DataTable dt = SqlHelper.ExecuteDataTable("select * from Table_People where Username='" + username + "'");
        object info = new object();
        DataRow row = dt.Rows[0];
        info = new
        {
            username = row["Username"],
            password = row["Password"],
            name = row["Name"],
            studentid = row["StudentID"],
            department = row["Department"],
            post = row["Post"],
            phone = row["Phone"]
        };

        string json = new JavaScriptSerializer().Serialize(info);
        context.Response.Write(json);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}