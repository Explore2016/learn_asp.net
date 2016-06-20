using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace weblogin.web_view
{
    
    public partial class write_massage : System.Web.UI.Page
    {
        public string username;
        public string password;
        protected void Page_Load(object sender, EventArgs e)
        {
             username = (string)Session["user"];
             password = (string)Session["password"];
        }
    }
}