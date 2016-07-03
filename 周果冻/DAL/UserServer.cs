using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
    public static class UserServer
    {
        public static DataTable GetUserInfo()
        {
            return SqlHelper.ExecuteDataTable("select * from Table_People where Username = 'zogodo'");
        }
    }
}
