using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.exception
{
    /// <summary>
    /// 蔵書管理システムの例外ハンドラクラス
    /// </summary>
    public static class ExceptionHandler
    {
        public static void ApplicationThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            // 入力系の例外だった場合には、業務エラーメッセージを表示して、例外箇所にフォーカスを設定する
            if(e.Exception is InputException)
            {
                var ex = e.Exception as InputException;

                MessageBox.Show(ex.Message);
                ex.ERROR_TEXTBOX.Clear();
                ex.ERROR_TEXTBOX.Focus();
            }
            else
            {
                MessageBox.Show(e.Exception.GetType().ToString());
                Environment.FailFast("FailFastのテストです");
            }
        }
    }
}
