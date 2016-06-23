using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace my_web.cs
{
    public static class UserServer
    {
        public static DataTable GetTable(int id)
        {
            return Sqlhelper1.ExecuteDataTable("select * from student where id=@id", new SqlParameter("@id", id));
        }
        public static DataTable GetStuendt_list(int id)
        {
            return Sqlhelper1.ExecuteDataTable("select * from messageboard where id=@id", new SqlParameter("@id", id));        
        }
        public static DataTable GetStuendts_list()
        {
            return Sqlhelper1.ExecuteDataTable("select * from student "); 
        }
        public static DataTable GetTable_files()
        {
            return Sqlhelper1.ExecuteDataTable("select * from T_file ");
        }
        public static DataTable GetTable_file(long id)
        {
            return Sqlhelper1.ExecuteDataTable("select * from T_file where id=@id", new SqlParameter("@id", id));
        }
        public static void delete(string id)
        {
            Sqlhelper1.ExecuteScalar("delete from student where id=@id", new SqlParameter("@id", id));
        }
        public static void change(string id,string keys,string name,string sex,string age)
        {
           Sqlhelper1.ExecuteScalar("insert into student (id,keys,name,sex,age)values (@id,@keys,@name,@sex,@age)", new SqlParameter("@id", id), new SqlParameter("@keys", keys), new SqlParameter("@name", name), new SqlParameter("@sex", sex ), new SqlParameter("@age", age));
        }
        public static DataTable login(string id,string keys)
        {
            return Sqlhelper1.ExecuteDataTable("select * from student where id=@id and  keys=@keys", new SqlParameter("@id", id), new SqlParameter("@keys", keys));
        }
        public static void insert(string id,string name,string text)
        {
            Sqlhelper1.ExecuteNonQuery("insert into messageboard (id,name,text,time,zancount,caicount)values(@id,@name,@text,GetDate(),0,0)", new SqlParameter("@id", id), new SqlParameter("@name", name), new SqlParameter("@text", text));
        }
        public static void upload_file(string file_name, string filepath)
        {
            Sqlhelper1.ExecuteNonQuery("Insert into T_file(filename,filepath) values(@filename,@filepath)", new SqlParameter("@filename", file_name), new SqlParameter("@filepath", filepath));
        }
        public static void Update_zan(string name)
        {
            Sqlhelper1.ExecuteNonQuery("Update messageboard set zancount=zancount+1 where name=@name ", new SqlParameter("@name", name));
        }
        public static void Update_cai(string name)
        {
            Sqlhelper1.ExecuteNonQuery("Update messageboard set caicount=caicount+1 where name=@name ", new SqlParameter("@name", name));
        }
        public static int zancount(string name)
        {
            return (int)Sqlhelper1.ExecuteScalar("select top 1 zancount from messageboard  where name=@name", new SqlParameter("@name", name));
        }
        public static int caicount(string name)
        {
            return (int)Sqlhelper1.ExecuteScalar("select top 1 caicount from messageboard  where name=@name", new SqlParameter("@name", name));
        }
    }
}