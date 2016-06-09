using Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace weblogin.web_view
{
    public partial class info : System.Web.UI.Page
    {
        public DataTable tables;
        public string username;
        public string name;
        public string mima;
        public string xuehao;
        public string xingming;
        public string shenfengzhen;
        public string usertype;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "text/html";
            username = Session["user"].ToString();
            string password = (string)Session["password"];
            usertype = (string)Session["Id"];

            DataTable table = SqlHelper.ExecuteDataTable("select * from T_login where Name=@Name", new SqlParameter("@Name", username));
            tables = SqlHelper.ExecuteDataTable("select * from T_login ");
            int a = table.Rows.Count;
            DataRow row = table.Rows[a - 1];
            {
                name = (string)row["Name"];
                mima = (string)row["Password"];
                xingming = Convert.ToString(row["peoplename"]);
                xuehao = Convert.ToString(row["studentnumber"]);
                shenfengzhen = Convert.ToString(row["Idcard"]);
            }

        }
    }
}