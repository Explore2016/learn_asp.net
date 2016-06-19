using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace my_web.web
{
    public partial class message_board : System.Web.UI.Page
    {
        public int id;
        public DataTable da;
        protected void Page_Load(object sender, EventArgs e)
        {
           id = Convert.ToInt32(Request["id"]);
          // Context.Session["id"] = id;
           da = Sqlhelper1.ExecuteDataTable("select * from messageboard where id=@id", new SqlParameter("@id", id));        
        }
    }
}