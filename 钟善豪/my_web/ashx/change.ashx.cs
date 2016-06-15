using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace my_web
{
    /// <summary>
    /// change1 的摘要说明
    /// </summary>
    public class change1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.ContentType = "text/html";
            string id = context.Request["id"];          
            string keys = context.Request["keys"];
            string name = context.Request["name"];
            string sex = context.Request["sex"];
            string age = context.Request["age"];
            Sqlhelper1.ExecuteScalar("delete from student where id=@id", new SqlParameter("@id", id));           
            Sqlhelper1.ExecuteScalar("insert into student (id,keys,name,sex,age)values (@id,@keys,@name,@sex,@age)", new SqlParameter("@id", id), new SqlParameter("@keys", keys), new SqlParameter("@name", name), new SqlParameter("@sex", sex ), new SqlParameter("@age", age));
            context.Response.Write("修改成功!");
           
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