﻿using Helper;
using sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2;
using weblogin.web_view;

namespace WebApplication2
{
    public partial class _using : System.Web.UI.Page, IRequiresSessionState

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
            //HttpCookie cookie = Request.Cookies["user"];
            //HttpCookie login = Request.Cookies["password"];
            //HttpCookie id = Request.Cookies["Id"];
            //username = cookie.Value;
            //usertype = id.Value;
            //string password = login.Value;

            string conStr = ConfigurationManager.ConnectionStrings["ipname"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                //if (vip == "1")

                DataTable table = userservice.returnlogin(username);
                //{
                tables = userservice.returnusing();
                int a = table.Rows.Count;
                DataRow row = table.Rows[a - 1];
                {


                    name = (string)row["Name"];
                    mima = (string)row["Password"];
                    xingming = Convert.ToString(row["peoplename"]);
                    xuehao = Convert.ToString(row["studentnumber"]);
                    shenfengzhen = Convert.ToString(row["Idcard"]);
                }
                List<Person> list = new List<Person>();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                string json = jss.Serialize(new Person { Name = name, PassWord = mima, UserName = xingming, StudyId = xuehao, Personname = shenfengzhen });
                //}
                //else {
                //    tables = Sqlhelper.ExecuteDataTable("select * from T_xuesheng where Name=@Name", new SqlParameter("@Name", username));
                //}
            }
        }
    }

}
