using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
using SQL;

public partial class User : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable usr_info_dt = DAL.UserServer.GetUserInfo();

        string id = usr_info_dt.Rows[0]["id"].ToString();

        Table_People usr_info_class = new Table_People();
        IList<Table_People> usr_info_list = ModelConvertHelper<Table_People>.ConvertToModel(usr_info_dt);

        string name = usr_info_list[0].Name;
    }
}