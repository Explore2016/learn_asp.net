using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace my_web
{
    public partial class change : System.Web.UI.Page
    {
        public int id;
        public DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
             id = Convert.ToInt32(Request["id"]);
             dt = Sqlhelper1.ExecuteDataTable("select * from student where id=@id", new SqlParameter("@id", id));

        }
    }
}