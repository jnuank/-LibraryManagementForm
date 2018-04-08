using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.db;

namespace Common.singleton
{
    public class SingletonObject
    {
        private static DataTable MemberList = new DataTable();
        private static DBAdapter DbAdapter  = new DBAdapter();
        private static DbQuery dbQuery      = new DbQuery();

        private SingletonObject()
        {
            // do nothing
        }

        /// <summary>
        /// メンバーリストの取得
        /// </summary>
        /// <returns></returns>
        public static DataTable GetMemberList()
        {
            if ( MemberList == null )
                MemberList  = new DataTable();

            return MemberList;
        }

        /// <summary>
        /// DBアダプタの取得
        /// </summary>
        /// <returns></returns>
        public static DBAdapter GetDbAdapter()
        {
            if ( DbAdapter == null )
                DbAdapter  = new DBAdapter();

            return DbAdapter;
        }


        public static DbQuery GetDbQuery()
        {
            if (dbQuery == null)
                dbQuery = new DbQuery();

            return dbQuery;
        }
    }
}
