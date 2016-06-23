using login.handler;
using SqlHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace login.html
{
    public partial class login : System.Web.UI.Page,IRequiresSessionState
    {
        public DataTable table;
        public string admin_btn;
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpCookie id = Context.Request.Cookies["id"];
            //HttpCookie password = Context.Request.Cookies["password"];
            //long ID = long.Parse(id.Value);
            //long Password = long.Parse(password.Value);
            if (Context.Session["id"] == null || Context.Session["password"]==null)
            {
                Context.Response.Redirect("login.html");
                return;
            }
            long ID = long.Parse(Session["id"].ToString());
            long Password = long.Parse(Session["password"].ToString());
            table = UserServer.GetStudent_list(ID, Password);
            if (int.Parse(table.Rows[0]["Admin"].ToString()) == 1)
            {
                admin_btn="<input type='button' name='btnLeft' value='启用管理员身份' onclick='admin()'/>";
            }
            else
            {
                admin_btn = "";
            }
        }
    }
}