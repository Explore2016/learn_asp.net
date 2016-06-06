using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    /// <summary>
    /// register1 的摘要说明
    /// </summary>
    public class register1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int class_ID, password, student_number;
            string name, major, college, cookie;
            int ID = Convert.ToInt32(context.Request["ID"]);
            if (context.Request["myname"] != "" && context.Request["class_ID"] != "" && context.Request["student_number"] != "" && context.Request["password"] != "" && context.Request["major"] != "" && context.Request["college"] != "" && context.Request["cookie"] != "")
                try
                {
                    name = context.Request["myname"];
                    student_number = Convert.ToInt32(context.Request["student_number"]);
                    password = Convert.ToInt32(context.Request["password"]);
                    class_ID = Convert.ToInt32(context.Request["class_ID"]);
                    major = context.Request["major"];
                    college = context.Request["college"];
                    cookie = context.Request["cookie"];
                }
                catch
                {
                    name = "aaa"; student_number = 102; password = 123456; class_ID = 102; major = "dsa"; college = "pri"; cookie = "aaa";
                    context.Response.Write("由于某些原因1输入不正确，请重新输入！");
                    return;
                }
            else
            {
                name = "aaa"; student_number = 102; password = 123456; class_ID = 102; major = "dsa"; college = "pri"; cookie = "aaa";
                context.Response.Write("由于某些原因2输入不正确，请重新输入！");
                return;
            }
            try
            {
                use_change.Executechange("insert into T_student(name,[class ID],stdent_number,pass_word,major,college,VIP,Cookie) values (@name,@class_ID,@student_number,@password,@major,@college,'False',@cookie)",
                        new SqlParameter("@name", name), new SqlParameter("@student_number", student_number), new SqlParameter("@password", password), new SqlParameter("@major", major), new SqlParameter("@college", college), new SqlParameter("@cookie", cookie), new SqlParameter("@class_ID", class_ID));
                context.Response.Write("注册成功！");
                return;
            }
            catch
            {
                context.Response.Write("由于某些原因3输入不正确，请重新输入！");
                return;
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