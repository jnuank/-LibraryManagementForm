using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.exception;
using Common.define;


namespace Common.ErrorCheck
{
    public static class InputCheck
    {
        public static void IsSingleQuotation(TextBox chkTarget)
        {
            // シングルクォーテーションが入っていたら(ユーザ名)
            if ( chkTarget.Text.IndexOf('\'') >= 0 )
                throw new InputException(GlobalDefine.ERROR_CODE[0], chkTarget);
        }
    }
}
