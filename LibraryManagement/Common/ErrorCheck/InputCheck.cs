using Common.define;
using Common.exception;
using System.Windows.Forms;


namespace Common.ErrorCheck
{
    /// <summary>
    /// 入力チェック用クラス
    /// </summary>
    public static class InputCheck
    {
        public static void IsSingleQuotation(TextBox chkTarget)
        {
            // シングルクォーテーションが入っていたら(ユーザ名)
            if ( chkTarget.Text.IndexOf('\'') >= 0 )
                throw new InputException(GlobalDefine.ERROR_CODE[0], chkTarget);
        }

        public static bool CheckSingleQuotation(this TextBox textBox)
        {
            return textBox.Text.IndexOf('\'') >= 0;
        }
    }
}
