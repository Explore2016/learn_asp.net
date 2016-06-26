using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Use_way
    {
        public static readonly string connstr =
            ConfigurationManager.ConnectionStrings["pzk"].ConnectionString;
        public static DataTable Land(int action, int password)
        {
            return SqlHelpers.SqlHelper.ExecuteDataTable("select * from T_student where stdent_number=@number and pass_word=@password",
                        new SqlParameter("@number", action), new SqlParameter("@password", password));
        }
        public static int delete(int ID)
        {
            SqlHelpers.SqlHelper.ExecuteNonQuery("delete from T_student where ID=@ID", new SqlParameter("@ID", ID));
            return 0;
        }
        public static int file_up_load(string filepath,string file_name )
        {
            SqlHelpers.SqlHelper.ExecuteNonQuery("insert into F_address(Address,file_name) values(@Address,@file_name)",
                new SqlParameter("@Address", filepath), new SqlParameter("@file_name", file_name));
            return 0;
        }
        public static int Message_approve_updata(long ID)
        {
            SqlHelpers.SqlHelper.ExecuteNonQuery("Update T_MessageBoard set Approve=Approve+1 where ID=@ID",
               new SqlParameter("@ID", ID));
            return 0;
        }
        public static long Message_approve_select_ID(long ID)
        {
            return long.Parse(SqlHelpers.SqlHelper.ExecuteScalar("Select Approve from T_MessageBoard where ID=@ID",
               new SqlParameter("@ID", ID)).ToString());
        }
        public static int Message_Board_insert(string Name,string Msg)
        {
           SqlHelpers.SqlHelper.ExecuteNonQuery("Insert into T_MessageBoard(Name,MessageContents,Approve,DataTime) values(@Name,@MessageContents,0,GetDate())",
                new SqlParameter("@Name", Name),
                new SqlParameter("@MessageContents", Msg)
                 );
           return 0;
        }
        public static int register(int class_ID,int password,int student_number,string name,string major,string college,string cookie)
        {
            SqlHelpers.SqlHelper.ExecuteNonQuery("insert into T_student(name,[class ID],stdent_number,pass_word,major,college,VIP,Cookie) values (@name,@class_ID,@student_number,@password,@major,@college,'False',@cookie)",
                        new SqlParameter("@name", name), new SqlParameter("@student_number", student_number), new SqlParameter("@password", password), new SqlParameter("@major", major), new SqlParameter("@college", college), new SqlParameter("@cookie", cookie), new SqlParameter("@class_ID", class_ID));
            return 0;
        }
        public static int use_to_change_my_information_delete(int ID)
        {
            SqlHelpers.SqlHelper.ExecuteNonQuery("delete from T_student where ID=@ID", new SqlParameter("@ID", ID));
            return 0;
        }
        public static DataTable select(int id)
        {
           return  SqlHelpers.SqlHelper.ExecuteDataTable("select * from T_student where ID=@ID",
                        new SqlParameter[] { new SqlParameter("@ID", id) });
        }
        public static DataTable select_all()
        {
            return SqlHelpers.SqlHelper.ExecuteDataTable("select * from T_student");
        }
        public static DataTable select_all_F()
        {
            return SqlHelpers.SqlHelper.ExecuteDataTable("select * from F_address");
        }
        public static DataTable select_all_T()
        {
            return SqlHelpers.SqlHelper.ExecuteDataTable("select * from T_MessageBoard");
        }
    }
}