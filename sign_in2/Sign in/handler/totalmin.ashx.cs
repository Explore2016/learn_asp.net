using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace Sign_in.handler
{
    /// <summary>
    /// totalmin 的摘要说明
    /// </summary>
    public class totalmin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            HttpCookie login = context.Request.Cookies["usr"];
            if (login == null)
            {
                context.Response.Write("no login");
            }

            string time = context.Request["time"];
            int total = 0;

            if (time == "week")
            {
                DataTable user_time = DAL.UserServer.GetUserWeekTime(login.Value);

                for (int i = 0; i < user_time.Rows.Count; ++i)
                {
                    DataRow row = user_time.Rows[i];
                    total += Convert.ToInt32(row["Today"]);
                }
            }
            else if (time == "day")
            {
                string now = DAL.UserServer.GetUserDayTime(login.Value);
                total = Convert.ToInt32(now);
            }
            context.Response.Write(total.ToString());
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