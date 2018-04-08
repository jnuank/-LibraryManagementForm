using Common.define;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.exception
{
    /// <summary>
    /// 入力チェック用のExceptionの子クラス
    /// </summary>
    public class InputException : Exception
    {
        /// <summary>
        /// エラーコード
        /// </summary>
        public int ERROR_CODE { get; private set; }

        /// <summary>
        /// チェックエラーを出したテキストボックス
        /// </summary>
        public TextBox ERROR_TEXTBOX { get; private set; }

        public InputException(ErrorCodes error, TextBox textBox = null) 
            : this(error.message, error.code, textBox)
        {

        }

        /// <summary>
        /// コンストラクタ(messageのみ継承)
        /// </summary>
        /// <param name="message"></param>
        /// <param name="code"></param>
        public InputException(string message, int code, TextBox textbox = null) : base(message)
        {
            ERROR_CODE = code;

            if(textbox != null)
                ERROR_TEXTBOX = textbox;
        }

    }
}
