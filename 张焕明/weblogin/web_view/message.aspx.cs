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
    public partial class message : System.Web.UI.Page
    {
        public DataTable table;
        public DataTable tables;
        protected void Page_Load(object sender, EventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["ipname"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                table = userservice.returnmessage();
                tables = userservice.returnpraise();
            }
        }
    }
}