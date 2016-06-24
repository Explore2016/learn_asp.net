using sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace weblogin.web_view
{
    public partial class index : System.Web.UI.Page, IRequiresSessionState
    {
        public DataTable table;
        public DataTable tables;
        public string username;
        public string usertype;
        protected void Page_Load(object sender, EventArgs e)
        {
            username =  (string)Session["user"]; ;
            usertype = (string)Session["Id"];
            if (usertype == "1")
            {
                usertype = "管理员";
            }
            else if (usertype == "0")
            {
                usertype = "普通用户";
            }
            else
            {
                usertype = "游客";
            }
            string conStr = ConfigurationManager.ConnectionStrings["ipname"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                table = userservice.returnmessage();
                tables = userservice.returnpraise();
            }
        }
    }
}