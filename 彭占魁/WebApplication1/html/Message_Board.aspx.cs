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
        public DataTable user;
        public int user_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.Session["ID"] == null)
            {
                Context.Response.Redirect("../GL_login.html");
                return;
            }
           user_id = Convert.ToInt32(Session["ID"]);
            table = Use_way.select_all_T();
            user = Use_way.select(user_id);
                //SqlHelpers.SqlHelper.ExecuteDataTable("select * from T_MessageBoard");
        }
    }
}