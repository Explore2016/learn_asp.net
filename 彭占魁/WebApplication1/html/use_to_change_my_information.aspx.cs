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
    public partial class use_to_change_my_information : System.Web.UI.Page, IRequiresSessionState
    {
        public string string_info;
        public DataTable student_info;
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpCookie login = Request.Cookies["user"];
            string_info = (string)Session["user"];
            student_info = SqlHelper.ExecuteDataTable("select * from T_student where Cookie=@ID",
                         new SqlParameter[] { new SqlParameter("@ID", string_info) });
        }
    }
}