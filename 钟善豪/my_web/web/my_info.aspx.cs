﻿using my_web.cs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace my_web
{
    public partial class my_info2 : System.Web.UI.Page,IRequiresSessionState
    {
        public int id;
        public string name;
        public string xingbie;
        public string age;
        public DataTable dt;
        public DataTable da;
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpCookie cookie1 = Request.Cookies["id"];
            //id = cookie1.Value;
            //id = Convert.ToInt32(Request["id"]);
            id = (int)Context.Session["id"];
            Context.Session["use"] = id;
            dt = UserServer.GetTable(id);
            da = UserServer.GetStuendts_list();
           // dt = Sqlhelper1.ExecuteDataTable("select * from student where id=@id", new SqlParameter("@id", id));
           // da = Sqlhelper1.ExecuteDataTable("select * from student ", new SqlParameter("@id", id));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                name = dt.Rows[i]["name"].ToString();
                xingbie = dt.Rows[i]["sex"].ToString();
                age = dt.Rows[i]["age"].ToString();
            }
          
        }
    }
}