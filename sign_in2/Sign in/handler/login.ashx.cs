using System.Web;
using System.Web.SessionState;

namespace Sign_in
{
    /// <summary>
    /// login 的摘要说明
    /// </summary>
    public class login :IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            string ip = GetIP.getIPAddress();
            string ip0 = DAL.InfoServer.GetExpIp();
            if (ip.Substring(0, 1) != ":" && ip.Substring(0, 7) != ip0.Substring(0, 7))
            {
                context.Response.Write("请在求索工作室登录!<br>" + ip + "<br>" + ip0);
                return;
            }

            string userid = context.Request["userid"];
            int check_studi = DAL.UserServer.CheckStuID(userid);
            if (check_studi == 1)
            {
                context.Response.SetCookie(new HttpCookie("usr", userid));

                DAL.UserServer.StartSignIn(userid);

                context.Response.Redirect("../html/sign_in.html");
            }
            else
            {
                context.Response.Write("<script>alert('学号未注册，请联系果冻');location.href='../html/login.html'</script>");
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