using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Common.singleton;

namespace BCMT03.src.db
{
    class Company
    {
        static public DataTable GetAllData()
        {
            DataTable dt = new DataTable();

            string query = "SELECT * FROM COMPANY_MASTER;";

            dt = SingletonObject.GetDbAdapter().execSQL(query);

            return dt;
        }
    }
}
