using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int action;
            int password;
            if (context.Request["student_number"] != "")
                try
                    {
                        action = Convert.ToInt32(context.Request["student_number"]);
                    }
                    catch
                    {
                        action=0;
                    }
            else
                action = 0;
            if (context.Request["password"] != "")       
                 try
                    {
                        password = Convert.ToInt32(context.Request["password"]);
                    }
                    catch
                    {
                        password=0;
                    }
            else
                password = 0;
            //context.Response.Write("<font color='red'>Hello World ，"+action+"</font><br/>");
            //context.Response.Write("<font color='red'> 年龄为：" + age + "</font><br/>");
            DataTable ds = SqlHelper.ExecuteDataTable("select * from T_student where stdent_number=@number and pass_word=@password",
                        new SqlParameter("@number", action), new SqlParameter("@password",password));
            if (ds.Rows.Count == 0)
            {
                context.Response.Write("账号不存在或者密码错误");
                //context.Response.Write("<script>confirm('账号不存在或者密码错误');location.href='../html/Html1.html';</script>");
                //context.Response.Redirect("Html1.html");跳转
                //js跳转location.href='Html1.html';
            }
            foreach (DataRow row in ds.Rows)
            {
               // string name = (string)row["name"];
               // string major = (string)row["major"];
               // int classID = (int)row["class ID"];
                //string college = (string)row["college"];
                string cookie=(string)row["cookie"];
                context.Response.SetCookie(new HttpCookie("user",cookie));
                context.Response.Write("欢迎");
                //context.Response.Write("<script>alert('欢迎');location.href='../web/land.aspx';</script>");
                //context.Response.Write("姓名：" + name + "<br/>班级：" + classID + "<br/>专业：" + major + "<br/>学院：" + college);
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