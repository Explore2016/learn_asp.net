using my_web.cs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace my_web
{
    /// <summary>
    /// zzzz 的摘要说明
    /// </summary>
    public class zzzz : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";         
            context.Response.ContentType = "text/html";
            string id = context.Request["id"];
            string key_1 = context.Request["key_1"];
            string key_2 = context.Request["key_2"];
            string name = context.Request["name"];
            string sex = context.Request["sex"];
            string age = context.Request["age"];
          
            if (key_1 != key_2)
                context.Response.Write("<script>alert('两次输入密码不一致！！');location.href = 'register.ashx';</script>");
            else
            {
                UserServer.change(id,key_1,name,sex,age);
               // Sqlhelper1.ExecuteScalar("insert into student (id,keys,name,sex,age)values (@id,@keys,@name,@sex,@age)", new SqlParameter("@id", id), new SqlParameter("@keys", key_1), new SqlParameter("@name", name), new SqlParameter("@sex", sex), new SqlParameter("@age", age));
                context.Response.Write("注册成功！");
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