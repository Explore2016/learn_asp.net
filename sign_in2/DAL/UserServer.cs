using Helper;
using System.Data.SqlClient;
using System;
using System.Data;

namespace DAL
{
    public class UserServer
    {
        public static string week = SqlHelper.ExecuteScalar("select MAX(week) from T_everyday").ToString();

        public static void StartSignIn(string userid)
        {
            string now_time = DateTime.Now.ToString();
            string date = DateTime.Now.DayOfWeek.ToString();

            var Id = SqlHelper.ExecuteScalar(@"Insert into T_everyday(Stuid, Start, DayOfWeek, Week, today)
                                             values(@Stuid, @Start, @DayOfWeek,
                                             (DATEDIFF(DY,(select first_day_of_term from T_info),@Start))/7, 0);
                                             select @@IDENTITY",
                        new SqlParameter("@Stuid", userid),
                        new SqlParameter("@Start", now_time),
                        new SqlParameter("@DayOfWeek", date));

            SqlHelper.ExecuteNonQuery("Update T_user set [On]=1,LastID=@lastid where StuID=@Stuid",
                    new SqlParameter("@Stuid", userid),
                    new SqlParameter("@lastid", Id.ToString()));
        }

        public static DataTable GetUserWeekTime(string username)
        {
            return SqlHelper.ExecuteDataTable("select today from T_everyday where stuid=@stuid and Week=@week and today>0",
                        new SqlParameter("@stuid", username),
                        new SqlParameter("@week", week));
        }

        public static string GetUserDayTime(string username)
        {
            string lastid = SqlHelper.ExecuteScalar("select LastID from T_user where StuID=@Stuid",
                    new SqlParameter("@Stuid", username)).ToString();

            string now = SqlHelper.ExecuteScalar("select today from T_everyday where id=@id",
                new SqlParameter("@id", lastid)).ToString();

            return now;
        }

        public static int CheckStuID(string stuid)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select Stuid from T_user where Stuid=@Stuid",
                    new SqlParameter("@Stuid", stuid));

            return dt.Rows.Count;
        }

        public static string GetLastID(string stuid)
        {
            return SqlHelper.ExecuteScalar("select LastID from T_user where StuID=@Stuid",
                        new SqlParameter("@Stuid", stuid)).ToString();
        }

        public static string GetDate(string last_id)
        {
            return SqlHelper.ExecuteScalar("select dayofweek from T_everyday where id=@id",
                        new SqlParameter("@id", last_id)).ToString();
        }

        public static string CheckON(string stuid)
        {
            return SqlHelper.ExecuteScalar("select [on] from T_user where StuID=@Stuid",
                    new SqlParameter("@Stuid", stuid)).ToString();
        }

        public static void AddTime(string last_id)
        {
            string now_time = DateTime.Now.ToString();

            SqlHelper.ExecuteNonQuery("update T_everyday set today=DATEDIFF(MI,Start,@Endd), Endd=@Endd where id = @lastid",
                new SqlParameter("@Endd", now_time),
                new SqlParameter("@lastid", last_id));
        }

        public static void SetON(string stuid)
        {
            string now_time = DateTime.Now.ToString();

            SqlHelper.ExecuteNonQuery("update T_user set LastTime=@time, [On]=1 where StuID=@Stuid",
                new SqlParameter("@time", now_time),
                new SqlParameter("@Stuid", stuid));

            SqlHelper.ExecuteNonQuery("update T_user set [On]=0 where DATEDIFF(MI,LastTime,@now)>2",
                new SqlParameter("@now", now_time));
        }
    }
}
