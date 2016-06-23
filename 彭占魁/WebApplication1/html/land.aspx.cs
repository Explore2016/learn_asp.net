using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class land : System.Web.UI.Page, IRequiresSessionState
    {
        public int string_info;
        public DataTable student_info;
        public bool VIP;
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpCookie login = Request.Cookies["user"];
            string_info = Convert.ToInt32(Session["ID"]);
            student_info = Use_way.select(string_info);
            //SqlHelpers.SqlHelper.ExecuteDataTable("select * from T_student where ID=@ID",
            //new SqlParameter[] { new SqlParameter("@ID",string_info) });
            if ((bool)student_info.Rows[0]["VIP"])
                VIP = true;
            else
                VIP = false;
        }
    }
}