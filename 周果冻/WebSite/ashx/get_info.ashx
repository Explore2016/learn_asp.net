<%@ WebHandler Language="C#" Class="get_info" %>

using System;
using System.Web;
using System.Data;
using System.Web.Script.Serialization;
using CRUDTest1;

public class get_info : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";

        HttpCookie login = context.Request.Cookies["login"];
        if (login == null)
        {
            context.Response.SetCookie(new HttpCookie("login", "no"));
            login = context.Request.Cookies["login"];
            context.Response.Write("have not login");
        }
        else if (login.Value != "no")
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from Table_People where Username='" + login.Value + "'");
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
        else
        {
            context.Response.Write("不明错误！");
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}