using Helper;
using sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace weblogin.web_view
{
    public partial class download : System.Web.UI.Page
    {
        public DataTable table;
        protected void Page_Load(object sender, EventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["ipname"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                //if (vip == "1")
                //DataTable table = SqlHelper.ExecuteDataTable("select * from T_address where Name=@Name", new SqlParameter("@Name", username));
                //{
                table = userservice.returnaddress();
                int a = table.Rows.Count;
                //DataRow row = table.Rows[a - 1];
                //{



                //}

            }
        }
    }
}