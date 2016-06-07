using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class view_string : System.Web.UI.Page
    {
        public string str;
        public DataTable stdent_info;
        public DataTable all_info;
        public bool VIP;
        public int  VIP_ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie login=Request.Cookies["user"];
            str = login.Value;
            stdent_info = SqlHelper.ExecuteDataTable("select * from T_student where Cookie=@ID",
                         new SqlParameter[] { new SqlParameter("@ID",str)});
            VIP_ID = Convert.ToInt32(stdent_info.Rows[0]["ID"]);
            if ((bool)stdent_info.Rows[0]["VIP"])
                VIP = true;
            else        
                VIP = false;
            all_info = SqlHelper.ExecuteDataTable("select * from T_student");
            
        }
    }
}