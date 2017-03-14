using System;
using System.Web;
using System.Web.SessionState;

namespace Sign_in
{
    /// <summary>
    /// Sign 的摘要说明
    /// </summary>
    public class Sign :IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            HttpCookie usr = context.Request.Cookies["usr"];
            if (usr == null)
            {
                context.Response.Write("没有登录!");
                return;
            }

            string ip = GetIP.getIPAddress();
            string ip0 = DAL.InfoServer.GetExpIp();
            if (ip.Substring(0, 1) != ":" && ip.Substring(0, 7) != ip0.Substring(0, 7))
            {
                context.Response.Write("请在求索工作室登录!");
                return;
            }

            string sign = context.Request["sign"];

            if (sign == "add")
            {
                string last_id = DAL.UserServer.GetLastID(usr.Value);
                string datenow = DAL.UserServer.GetDate(last_id);
                string on = DAL.UserServer.CheckON(usr.Value);

                //判断是否是在同一星期 登陆，并且在8:00以后，并且当前在线。
                string date = DateTime.Now.DayOfWeek.ToString();
                if (date == datenow && on == "1"
                    && Convert.ToInt32(DateTime.Now.Hour.ToString()) > 7)
                {
                    DAL.UserServer.AddTime(last_id);
                    DAL.UserServer.SetON(usr.Value);

                    context.Response.Write("ON");
                }
                else
                {
                    context.Response.Write("notON");
                }

            }
            else if (sign == "endd")
            {
                
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