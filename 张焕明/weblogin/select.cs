
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Helper;

namespace sql
{
    public class  userservice
    {
        public static DataTable checkpass(string name)
        {
            return SqlHelper.ExecuteDataTable("select * from T_login where Name=@Name",
            new SqlParameter("@Name", name));
        }
        public static void somechange(string username, string password, string studyid,string iname,string myname)
        {
            SqlHelper.ExecuteDataTable("update T_login set Password=@password,studentnumber=@studyid ,peoplename=@iname,Idcard=@myname where Name=@username", new SqlParameter("@username", username), new SqlParameter("@password", password), new SqlParameter("@studyid", studyid), new SqlParameter("@iname", iname), new SqlParameter("@myname", myname));
        }
        public static void outnews(string Id)
        {
            SqlHelper.ExecuteDataTable("delete from T_login where Name=@Id", new SqlParameter("@Id", Id));
 
        }
        public static DataTable filedownload(long ID_dl)
        {
            return SqlHelper.ExecuteDataTable("select * from T_address where Id=@ID",
                    new SqlParameter("@ID", ID_dl));
        }
        public static DataTable admin()
        {
        return SqlHelper.ExecuteDataTable("select * from T_address");
    }
        public static DataTable table_admin(long ID, long Password)
        {
            return SqlHelper.ExecuteDataTable("select * from T_login where Id=@ID and Password=@Password",
             new SqlParameter("@ID", ID),
             new SqlParameter("@Password", Password));
        }
        public static void messageupdate(string id)
        {
            SqlHelper.ExecuteDataTable("Update T_praise set praise=praise+1 where Id =@id", new SqlParameter("@id", id));
        }
        public static string message(string id)
        {
            return (string)SqlHelper.ExecuteScalar("select praise from T_praise where Id =@id", new SqlParameter("@id", id));
        }
        public static void upload(string filepath,string fileorgname,string filename)
        {
            SqlHelper.ExecuteDataTable("insert into T_address(Fileswhere,Filesname,Filesguid) values (@Filewhere,@Filename,@Fileguid)", new SqlParameter("@Filewhere", filepath), new SqlParameter("@Filename", fileorgname), new SqlParameter("@Fileguid", filename));
        }
        public static void writemessage(string user,string message,string writetime)
        {
            SqlHelper.ExecuteDataTable("insert into T_message(username,message,writetime) values (@username,@message,@writetime)", new SqlParameter("@username", user), new SqlParameter("@message", message), new SqlParameter("@writetime", writetime));
        }

        public static void praisemessage(string message, int praise)
        {
                  SqlHelper.ExecuteDataTable("insert into T_praise(message,praise) values (@message,@praise)", new SqlParameter("@message", message), new SqlParameter("@praise", praise));
        }

    }
}
//userservice