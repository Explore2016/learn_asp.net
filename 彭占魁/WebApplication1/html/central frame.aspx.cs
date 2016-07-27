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
    public partial class view_string : System.Web.UI.Page, IRequiresSessionState
    {
        public int id;
        public DataTable stdent_info;
        public DataTable all_info;
        public bool VIP;
        public int  VIP_ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpCookie login=Request.Cookies["user"];
            id =Convert.ToInt32(Session["ID"]);
            //str = (string)Session["user"];
            stdent_info = Use_way.select(id);
            //SqlHelpers.SqlHelper.ExecuteDataTable("select * from T_student where ID=@ID",
            //     new SqlParameter[] { new SqlParameter("@ID",id)});
            VIP_ID = Convert.ToInt32(stdent_info.Rows[0]["ID"]);
            if ((bool)stdent_info.Rows[0]["VIP"])
                VIP = true;
            else        
                VIP = false;
            all_info = Use_way.select_all();
            //SqlHelpers.SqlHelper.ExecuteDataTable("select * from T_student");
           
            
        }
    }
}