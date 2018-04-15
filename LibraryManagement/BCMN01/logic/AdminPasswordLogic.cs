using Common.db;
using Common.define;
using Common.singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCMN01.logic
{
    public class AdminPasswordLogic
    {
        public string Apply(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return GlobalDefine.ERROR_CODE[7].message;
            }

            DbQuery dc = SingletonObject.GetDbQuery();

            if (dc.IsAdminPassword(password))
            {
                return GlobalDefine.MESSAGE_ADMIN_MODE_ENABLE;
            }
            else
            {
                return GlobalDefine.ERROR_CODE[8].message;
            }
        }

    }
}
