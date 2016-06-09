using Helper;
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
    public partial class change : System.Web.UI.Page, IRequiresSessionState
    {
        public DataTable tables;
        public string username;
        public string name;
        public string mima;
        public string xuehao;
        public string xingming;
        public string shenfengzhen;
        public string usertype;
        protected void Page_Load(object sender, EventArgs e, HttpContext context)
        {
            Response.ContentType = "text/html";
             username = (string)context.Session["user"];
             string password = (string)context.Session["password"];
             usertype = (string)context.Session["Id"];
            //HttpCookie login = Request.Cookies["password"];
            //HttpCookie id = Request.Cookies["Id"];
            //username = cookie.Value;
            //usertype = id.Value;
            //string password = login.Value;

            string conStr = ConfigurationManager.ConnectionStrings["ipname"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                //if (vip == "1")

                DataTable table = SqlHelper.ExecuteDataTable("select * from T_login where Name=@Name", new SqlParameter("@Name", username));
                //{
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
                //}
                //else {
                //    tables = Sqlhelper.ExecuteDataTable("select * from T_xuesheng where Name=@Name", new SqlParameter("@Name", username));
                //}
            }
        }
    }

}
