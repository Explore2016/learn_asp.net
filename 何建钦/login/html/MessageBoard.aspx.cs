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
    public partial class MessageBoard : System.Web.UI.Page
    {
        public DataTable table;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.Session["id"] == null || Context.Session["password"] == null)
            {
                Context.Response.Redirect("login.html");
                return;
            }
            table = SqlHelper.ExecuteDataTable("select * from T_MessageBoard");
        }
    }
}