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
        public string name;
        public DataTable da;
        public DataTable table;
        protected void Page_Load(object sender, EventArgs e)
        {
            use = (int)Context.Session["use"];
            //Context.Session["name"] = use;
            id = Convert.ToInt32(Request["id"]);
            da = UserServer.GetStuendt_list(id);
            table = UserServer.GetTable(use);
            name = table.Rows[0]["name"].ToString();
            Context.Session["name"] = name;
        }
    }
}