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

namespace login.web_forms
{
    public partial class admin : System.Web.UI.Page
    {
        public DataTable table;
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpCookie id = Context.Request.Cookies["id"];
            //HttpCookie password = Context.Request.Cookies["password"];
            //long ID = long.Parse(id.Value);
            //long Password = long.Parse(password.Value);
            if (Context.Session["id"] == null || Context.Session["password"] == null)
            {
                Context.Response.Redirect("login.html");
                return;
            }
            long ID = long.Parse(Session["id"].ToString());
            string Password = Session["password"].ToString();
            int admin_ID = UserServer.CheckAdmin_ID(ID, Password);
            if (admin_ID == 1)
            {
                if (Request["ID_del"] != null)
                {
                    long ID_del = long.Parse(Request["ID_Del"]);
                    int row = UserServer.DelStudent(ID_del);
                }
                table = UserServer.GetStudents_list(); 
            }
        }
    }
}