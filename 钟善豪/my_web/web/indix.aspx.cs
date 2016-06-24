using my_web.cs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace my_web.web
{
    public partial class indix : System.Web.UI.Page
    {
        public int use;
        public int id;
        public DataTable da;
        protected void Page_Load(object sender, EventArgs e)
        {
            use = (int)Context.Session["use"];
            id = Convert.ToInt32(Request["id"]);
            da = UserServer.GetStuendt_list(id);
        }
    }
}