using login.handler;
using SqlHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace login.html
{
    public partial class MB2 : System.Web.UI.Page
    {
        public DataTable table;
        public string Name;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.Session["id"] == null || Context.Session["password"] == null)
            {
                Context.Response.Redirect("login.html");
                return;
            }
            long ID = long.Parse(Context.Session["id"].ToString());
            long Password = long.Parse(Context.Session["password"].ToString());
            Name = UserServer.GetMessageName(ID, Password);
            table = SqlHelper.ExecuteDataTable("select * from T_MessageBoard");
        }
    }
}