using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Common.singleton;

namespace BCMT02.src.db
{
    class Category
    {
        static public DataTable GetAllData()
        {
            DataTable dt = new DataTable();

            string query = "SELECT * FROM BOOK_GENRE_MASTER;";

            dt = SingletonObject.GetDbAdapter().execSQL(query);

            return dt;
        }
    }
}
