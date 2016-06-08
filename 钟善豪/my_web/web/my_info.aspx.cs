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
    public partial class my_info2 : System.Web.UI.Page
    {
        public string id;
        public string name;
        public string xingbie;
        public string age;
        public DataTable dt;
        public DataTable da;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie1 = Request.Cookies["id"];
            id = cookie1.Value;
            dt = Sqlhelper1.ExecuteDataTable("select * from student where id=@id", new SqlParameter("@id", id));
            da = Sqlhelper1.ExecuteDataTable("select * from student ", new SqlParameter("@id", id));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                name = dt.Rows[i]["name"].ToString();
                xingbie = dt.Rows[i]["sex"].ToString();
                age = dt.Rows[i]["age"].ToString();
            }
        }
    }
}