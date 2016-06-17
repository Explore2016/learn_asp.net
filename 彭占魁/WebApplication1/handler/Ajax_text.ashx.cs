using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AJAX;
using WebApplication1;
using System.Web.SessionState;

namespace AJAX
{
    /// <summary>
    /// Ajax_text 的摘要说明
    /// </summary>
    public class Ajax_text : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int action;
            int password;
            if (context.Request["name"] != "")
                try
                {
                    action = Convert.ToInt32(context.Request["student_number"]);
                }
                catch
                {
                    action = 0;
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
                    password = 0;
                }
            else
                password = 0;

            DataTable ds = SqlHelper.ExecuteDataTable("select * from T_student where stdent_number=@number and pass_word=@password",
                        new SqlParameter("@number", action), new SqlParameter("@password", password));
            if (ds.Rows.Count == 0)
            {
                context.Response.Write("账号不存在或者密码错误啦");
            }
            else
            {
                foreach (DataRow row in ds.Rows)
                {
                    string name = (string)row["name"];
                    string major = (string)row["major"];
                    int classID = (int)row["class ID"];
                    string college = (string)row["college"];
                    string cookie = (string)row["cookie"];
                    int ID = (int)row["ID"];
                    //context.Response.SetCookie(new HttpCookie("user", cookie));
                    //context.Session["user"] = cookie;
                    context.Session["ID"] = ID.ToString();
                    context.Response.Write("欢迎,学院:" +college+ "，专业：" + major + ",班级：" + classID + ",姓名：" + name+"同学");
                }
            }


            //context.Response,Write();
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