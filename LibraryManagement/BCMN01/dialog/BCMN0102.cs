using Common.db;
using Common.define;
using Common.exception;
using Common.singleton;
using System;
using System.Windows.Forms;
using Common.Properties;

namespace BCMN01.dialog
{
    public partial class BCMN0102 : Form
    {

        // 引数なしのデリゲート変数を用意する（オーナーウィンドウ側の操作用）
        public delegate void DelegateFunc();
        public DelegateFunc menuEnable;

        public BCMN0102()
        {
            InitializeComponent();
        }

        #region メソッド

        /// <summary>
        /// 確定ボタンのロジック
        /// </summary>
        public void Apply(TextBox textBox)
        {
            if (CheckTextBox(textBox.Text))
            {
                MessageBox.Show(GlobalDefine.ERROR_CODE[7].message);
                textBox.Focus();
                return;
            }

            DbQuery dc = SingletonObject.GetDbQuery();

            if (dc.IsAdminPassword(textBox.Text))
            {
                MessageBox.Show(GlobalDefine.MESSAGE_ADMIN_MODE_ENABLE);
                menuEnable();
                this.Close();
            }
            else
            {
                MessageBox.Show(GlobalDefine.ERROR_CODE[8].message, GlobalDefine.CAUTION);
                textBox.Clear();
                textBox.Focus();
            }
        }

        /// <summary>
        /// チェックボックスに入力されているのが、nullか空文字だったらtrueを返す
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool CheckTextBox(string text)
        {
            return string.IsNullOrEmpty(text);
        }
        

        #endregion

        #region イベント
        /// <summary>
        /// 確定ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            Apply(this.txtPass);
        }


        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// クリアボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPass.Clear();
        }
        #endregion
    }
}
