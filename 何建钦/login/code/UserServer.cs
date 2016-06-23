using SqlHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace login.handler
{
    public static class UserServer
    {
        public static int CheckID(long ID)
        {
            return (int)SqlHelper.ExecuteScalar("select count(*) from T_Students where ID=@ID", new SqlParameter("@ID", ID));
        }
        public static int CheckIDandPassword(long ID, string Password)
        {
            return (int)SqlHelper.ExecuteScalar("select count(*) from T_Students where ID=@ID and Password=@Password",
                    new SqlParameter("@ID", ID),
                    new SqlParameter("@Password", Password));
        }
        public static DataTable GetStudent_list(long ID, long Password)
        {
             return SqlHelper.ExecuteDataTable("select * from T_Students where ID=@ID and Password=@Password",
             new SqlParameter("@ID", ID),
             new SqlParameter("@Password", Password));
        }
        public static int CheckAdmin_ID(long ID,string Password)
        {
            return int.Parse(SqlHelper.ExecuteScalar("select Admin from T_Students where ID=@ID and Password=@Password",
             new SqlParameter("@ID", ID),
             new SqlParameter("@Password", Password)).ToString());
        }
        public static int DelStudent(long ID_del)
        {
            return SqlHelper.ExecuteNonQuery("Delete from T_Students where ID=@ID ",
                        new SqlParameter("@ID", ID_del)
                    );
        }
        public static DataTable GetStudents_list()
        {
            return SqlHelper.ExecuteDataTable("select * from T_Students");
        }
        public static int SaveFile(string FileOrgName, string FileName, string FilePath)
        {
            return SqlHelpers.SqlHelper.ExecuteNonQuery("Insert into T_FilesList(FilesOrgName,FilesName,FilesPath) values(@FilesOrgName,@FilesName,@FilesPath)",
                new SqlParameter("@FilesOrgName", FileOrgName),
                new SqlParameter("@FilesName", FileName),
                new SqlParameter("@FilesPath", FilePath)
                );
        }
        public static void Support(long ID)
        {
            SqlHelpers.SqlHelper.ExecuteNonQuery("Update T_MessageBoard set Supports=Supports+1 where ID=@ID",
                new SqlParameter("@ID", ID));
        }
        public static long GetSupportsCount(long ID)
        {
            return long.Parse(SqlHelpers.SqlHelper.ExecuteScalar("Select Supports from T_MessageBoard where ID=@ID",
                new SqlParameter("@ID", ID)).ToString());
        }
        public static string GetMessageName(long ID,long Password)
        {
            return SqlHelper.ExecuteScalar("select Name from T_Students where ID=@ID and Password=@Password",
             new SqlParameter("@ID", ID),
             new SqlParameter("@Password", Password)).ToString();
        }
        public static int LeaveAMessage(string Name,string Msg)
        {
            return SqlHelpers.SqlHelper.ExecuteNonQuery("Insert into T_MessageBoard(Name,MessageContents,Supports,DataTime) values(@Name,@MessageContents,0,GetDate())",
                new SqlParameter("@Name", Name),
                new SqlParameter("@MessageContents", Msg)
                 );
        }
    }
}