using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.define;

namespace Common.dialog
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 閉じる前の確認ダイアログ表示
        /// </summary>
        /// <returns></returns>
        protected bool IsCancelClosing()
        {
            return IsCancelClosing(GlobalDefine.MESSAGE_ASK_CLOSE);
        }

        /// <summary>
        /// 閉じる前の確認ダイアログ表示
        /// </summary>
        /// <returns></returns>
        protected bool IsCancelClosing(string message)
        {
            DialogResult dr = MessageBox.Show(message,
                                                    "質問",
                                                    MessageBoxButtons.OKCancel,
                                                    MessageBoxIcon.Exclamation,
                                                    MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.OK)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// 確認画面
        /// </summary>
        /// <returns></returns>
        protected bool AskMessageBox(string message)
        {
            DialogResult result = MessageBox.Show(message,
            "確認",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

            bool flag = true;
            switch ( result )
            {
                case DialogResult.OK:
                    flag = true;
                    break;
                case DialogResult.Cancel:
                    flag = false;
                    break;
            }
            return flag;

        }
    }
}
