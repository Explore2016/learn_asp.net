using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Message_Board : System.Web.UI.Page
    {
        public DataTable table;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.Session["ID"] == null)
            {
                Context.Response.Redirect("../GL_login.html");
                return;
            }
            table = Use_way.select_all_T();
                //SqlHelpers.SqlHelper.ExecuteDataTable("select * from T_MessageBoard");
        }
    }
}