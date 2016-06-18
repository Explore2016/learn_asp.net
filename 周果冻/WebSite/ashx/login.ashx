<%@ WebHandler Language="C#" Class="login" %>

using System;
using System.Web;

public class login : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";

        string username = context.Request["username"];
        string password = context.Request["password"];

        if (username == password)
        {
            context.Response.Write("OK");
        }
        else
        {
            context.Response.Write("NO");
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}