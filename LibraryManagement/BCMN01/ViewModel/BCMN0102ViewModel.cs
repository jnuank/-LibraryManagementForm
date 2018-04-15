using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using BCMN01.logic;
using System.Windows.Forms;
using Common.define;

namespace BCMN01.ViewModel
{
    /// <summary>
    /// 管理者パスワード入力画面のViewModel
    /// </summary>
    public class BCMN0102ViewModel : NofityPropertyChanged
    {
        private AdminPasswordLogic logic = new AdminPasswordLogic();

        private string password;
        private bool applyBtnEnable = true;
        private bool clearBtnEnable = true;
        private string message;
        private Action action;


        /// <summary>
        /// パスワード用のテキストボックス
        /// </summary>
        public string Password
        {
            get { return this.password; }
            set
            {
                if (this.password == value)
                    return;

                this.password = value;
                NotifyPropertyChanged(nameof(Password));
            }
        }

        public bool ApplyEnable
        {
            get { return this.applyBtnEnable; }
            set
            {
                if (this.applyBtnEnable == value)
                    return;

                this.applyBtnEnable = value;
                NotifyPropertyChanged(nameof(ApplyEnable));
            }
        }

        public bool ClearEnable
        {
            get { return this.clearBtnEnable; }
            set
            {
                if (this.clearBtnEnable == value)
                    return;

                this.clearBtnEnable = value;
                NotifyPropertyChanged(nameof(ClearEnable));
            }
        }
        public string Message
        {
            get { return this.message; }
            private set
            {
                this.message = value;
                NotifyPropertyChanged(nameof(Message));
            }
        }

        public Action MenuEnableAction
        {
            get { return this.action;  }
            set { this.action = value; }
        }

        #region イベント
        public void ApplyButton_Click(object sender, EventArgs e)
        {
            Message = logic.Apply(this.Password);
            // Todo:この判定他に方法ないか…？
            if (Message == GlobalDefine.MESSAGE_ADMIN_MODE_ENABLE)
                MenuEnableAction();
        }


        #endregion
    }
}
