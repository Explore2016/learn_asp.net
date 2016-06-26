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
using weblogin.web_view;

namespace weblogin.ashx
{
    /// <summary>
    /// nameuser 的摘要说明
    /// </summary>
    public class nameuser : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string username = (string)context.Session["user"]; 
            string conStr = ConfigurationManager.ConnectionStrings["ipname"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                //if (vip == "1")

                //{
                DataTable table = userservice.returnlogin(username);
                int a = table.Rows.Count;
                DataRow row = table.Rows[a - 1];
                {


                    string name = (string)row["Name"];
                    string mima = (string)row["Password"];
                    string xingming = Convert.ToString(row["peoplename"]);
                    string xuehao = Convert.ToString(row["studentnumber"]);
                    string shenfengzhen = Convert.ToString(row["Idcard"]);
                    List<Person> list = new List<Person>();
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    string json = jss.Serialize(new Person { Name = username, PassWord = mima, UserName = xingming, StudyId = xuehao, Personname = shenfengzhen });
                    //}
                    context.Response.Write(json);
                }

                //else {
                //    tables = Sqlhelper.ExecuteDataTable("select * from T_xuesheng where Name=@Name", new SqlParameter("@Name", username));
                //}
            }
        }
    



        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}