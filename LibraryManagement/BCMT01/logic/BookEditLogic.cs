using Common.db;
using Common.define;
using Common.ErrorCheck;
using Common.exception;
using Common.singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BCMT01.logic
{
    public class BookEditLogic
    {
        public void ApplyButtonCheck(TextBox txtTitle)
        {
            InputCheck.IsSingleQuotation(txtTitle);

            if(string.IsNullOrEmpty(txtTitle.Text))
                throw new InputException(GlobalDefine.ERROR_CODE[23].message, GlobalDefine.ERROR_CODE[23].code, txtTitle);
        }

        public string GetNewId(string columName, string tableName)
        {
            DBAdapter dba = SingletonObject.GetDbAdapter();

            // DBのIDのMAX値を取得する
            string MaxId = dba.GetMaxID(nameof(GlobalDefine.BOOK_ID), GlobalDefine.BOOK_MASTER);
            // IDのPrefixに付いている'B'を省く
            string prefix = MaxId.Substring(0, 1);
            // MAX値から+1する
            int newId = int.Parse(MaxId.Substring(1)) + 1;
            // 0埋めして新規ID作成
            return ($"{prefix}{newId:D3}");
        }

    }
}
