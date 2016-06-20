using SqlHelpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace login.handler
{
    public static class UserServer
    {
        public static int GetUserCount(long ID)
        {
            return (int)SqlHelper.ExecuteScalar("select count(*) from T_Students where ID=@ID", new SqlParameter("@ID", ID));
        }
    }
}