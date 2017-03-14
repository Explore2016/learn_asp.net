using Helper;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class InfoServer
    {
        public static string week = SqlHelper.ExecuteScalar("select MAX(week) from T_everyday").ToString();
        public static string GetMaxWeek()
        {
            return SqlHelper.ExecuteScalar("select MAX(week) from T_everyday").ToString();
        }


        public static DataTable GetAllInfon(int week)
        {
            /*return SqlHelper.ExecuteDataTable(@"select Name,dbo.T_everyday.Stuid, [On],SUM(Today) as total 
                                                from dbo.T_everyday,dbo.T_user where dbo.T_everyday.Stuid=dbo.T_user.Stuid 
                                   and Week=@week group by dbo.T_everyday.Stuid,Name, [On] order by total Desc",
                                            new SqlParameter("@week", week));
             
             select * from v_this_week order by total Desc*/

            return SqlHelper.ExecuteDataTable("select * from v_all_week where week=@week order by total Desc", new SqlParameter("@week", week));
        }

        public static DataTable GetYourInfon(string username,int week)
        {
            return SqlHelper.ExecuteDataTable("select * from T_everyday where week=@week and Today>-1 and Stuid=@stuid and Endd is not null order by id Desc",
                    new SqlParameter("@stuid", username),
                    new SqlParameter("@week", week));
        }

        public static DataTable GetAllDetail(int week)
        {
            return SqlHelper.ExecuteDataTable(@"select * from dbo.T_everyday,dbo.T_user 
                                                where T_user.Stuid=T_everyday.Stuid and Week=@week and today>-1 and Endd is not null
                                                order by T_everyday.Week Desc,T_everyday.Stuid,T_everyday.ID Desc",
                    new SqlParameter("@week", week));
        }

        public static string GetExpIp()
        {
            return SqlHelper.ExecuteScalar("select ip_of_exp from T_info").ToString();
        }
    }
}
