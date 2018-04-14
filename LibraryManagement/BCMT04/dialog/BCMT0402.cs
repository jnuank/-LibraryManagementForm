using Common.db;
using Common.define;
using Common.dialog;
using Common.ErrorCheck;
using Common.exception;
using Common.singleton;
using System;
using System.Data;
using System.Windows.Forms;

namespace BCMT04.dialog
{
    public partial class BCMT0402 : BaseForm
    {

        #region フィールド
        MODE mode;

        private string tmpUserName;
        private string tmpCompany;
        private string tmpMailAddress;

        #endregion

        /// <summary>
        /// 新規作成用コンストラクタ
        /// </summary>
        public BCMT0402()
        {
            InitializeComponent();
            InitDialog();

            mode = MODE.ADD;

            this.textId.ReadOnly = true;
            this.btnDelete.Enabled = false;

            SaveTempVariable();
        }

        /// <summary>
        /// 編集用コンストラクタ
        /// </summary>
        /// <param name="row"></param>
        public BCMT0402(DataRow row)
        {
            InitializeComponent();
            InitDialog();

            mode = MODE.MOD;

            this.textId.ReadOnly = true;

            textId.Text = row.Field<string>("USER_ID");
            textUser.Text = row.Field<string>("USER_NAME");
            cmbCompany.SelectedValue = GetCompanyId(row.Field<string>("COMPANY_NAME"));
            textMail.Text = row.Field<string>("USER_MAILADDRESS");

            SaveTempVariable();
        }

        /// <summary>
        /// ダイアログ初期化
        /// </summary>
        private void InitDialog()
        {
            DBAdapter dba = SingletonObject.GetDbAdapter();

            string query = "SELECT * FROM COMPANY_MASTER";

            cmbCompany.DataSource = dba.execSQL(query);

            // 実際に表示するのは会社略称
            cmbCompany.DisplayMember = "COMPANY_ABBREVIATION";
            // 内部的に渡すのは、会社ID
            cmbCompany.ValueMember = "COMPANY_ID";
        }

        #region イベント
        private void btnApply_Click(object sender, EventArgs e)
        {
            if ( mode == MODE.MOD )
            {
                bool valueEqual = ValueCompare();
                if ( valueEqual )
                {
                    MessageBox.Show(GlobalDefine.MESSAGE_NOT_CHANGE_UPDATE);
                    return;
                }
            }

            try
            {
                ApplyButtonCheckes();
            }
            catch(InputException ex)
            {
                MessageBox.Show(ex.Message);
                if(ex.ERROR_CODE == 27)
                {
                    this.cmbCompany.SelectedValue = this.tmpCompany;
                    return;
                }
                ex.ERROR_TEXTBOX.Clear();
                ex.ERROR_TEXTBOX.Focus();
                return;
            }

            // 更新処理

            if ( mode == MODE.ADD )
            {
                if ( !base.AskMessageBox(GlobalDefine.MESSAGE_ASK_REGISTRATION) )
                    return;

                // ID MAX値取得
                DBAdapter dba = SingletonObject.GetDbAdapter();

                // 新規ID取得(MAX値+1)
                string newStringId = dba.GetMaxID("USER_ID", "USER_MASTER");
                newStringId = newStringId.Substring(1);

                int newId = int.Parse(newStringId) + 1;

                // 0埋めして新規ID作成
                string newIdText = string.Format("U{0:D3}", newId);

                // テーブル更新
                string query = string.Format("INSERT INTO USER_MASTER VALUES('{0}', '{1}', '{2}', '{3}', 0) ",
                                             newIdText,
                                             this.textUser.Text,
                                             this.cmbCompany.SelectedValue,
                                             this.textMail.Text
                                             );

                dba.nonExecSQL(query);

                MessageBox.Show(GlobalDefine.MESSAGE_COMPLETE_REGISTRATION);

                this.textId.Text = newIdText;

                SaveTempVariable();

                this.btnDelete.Enabled = true;

                mode = MODE.MOD;
                return;                
            }

            if ( mode == MODE.MOD )
            {
                if ( !base.AskMessageBox(GlobalDefine.MESSAGE_ASK_UPDATE) )
                    return;

                // テーブル更新

                string query = string.Format("UPDATE USER_MASTER SET USER_NAME='{0}', COMPANY_ID='{1}', " +
                                             "USER_MAILADDRESS='{2}', RETIREMENT_FLAG=0 " +
                                             "WHERE USER_ID='{3}'",
                                             this.textUser.Text,
                                             this.cmbCompany.SelectedValue,
                                             this.textMail.Text,
                                             this.textId.Text
                                             );

                DBAdapter dba = SingletonObject.GetDbAdapter();
                dba.nonExecSQL(query);

                MessageBox.Show(GlobalDefine.MESSAGE_COMPLETE_UPDATE);

                // 変数保持
                SaveTempVariable();
            }


        }
        /// <summary>
        /// フォームのクロージング処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BCMT0402_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 削除モードなら、ダイアログ出さずに画面閉じる
            if ( mode == MODE.DEL )
                return;

            // コントロールの初期値が変更されていたらダイアログメッセージを変更する
            bool valueEqual = ValueCompare();
            bool cancelPressed = false;

            // 三項演算子…[条件式] ? [trueの場合] : [falseの場合]
            cancelPressed = valueEqual ? base.IsCancelClosing(GlobalDefine.MESSAGE_ASK_CLOSE)
                                       : base.IsCancelClosing(GlobalDefine.MESSAGE_ASK_CLOSE_CHANGE);

            if ( cancelPressed )
                e.Cancel = true;

        }
        
        /// <summary>
        /// 削除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool valueEqual = ValueCompare();

            bool cancelSelected = valueEqual ? !base.AskMessageBox(GlobalDefine.MESSAGE_ASK_DELETE)
                                             : !base.AskMessageBox(GlobalDefine.MESSAGE_ASK_DELETE_CHANGE);

            if ( cancelSelected )
                return;

            string query = string.Format("UPDATE USER_MASTER SET RETIREMENT_FLAG=1 WHERE USER_ID='{0}'", textId.Text);
            DBAdapter dba = SingletonObject.GetDbAdapter();

            dba.nonExecSQL(query);

            MessageBox.Show(GlobalDefine.MESSAGE_COMPLETE_DELETE);

            mode = MODE.DEL;
            this.Close();

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

        #endregion

        #region チェック

        /// <summary>
        /// 確定ボタン押下時のチェック処理
        /// </summary>
        private void ApplyButtonCheckes()
        {
            InputCheck.IsSingleQuotation(this.textUser);
            if ( string.IsNullOrEmpty(this.textUser.Text) )
                throw new InputException(GlobalDefine.ERROR_CODE[24].message, GlobalDefine.ERROR_CODE[24].code, this.textUser);

            InputCheck.IsSingleQuotation(this.textMail);
            if ( string.IsNullOrEmpty(this.textMail.Text) )
                throw new InputException(GlobalDefine.ERROR_CODE[25].message, GlobalDefine.ERROR_CODE[25].code, this.textMail);

            // SelectedIndexが0以下は未選択状態
            if(cmbCompany.SelectedIndex <= 0)
                throw new InputException(GlobalDefine.ERROR_CODE[26].message, GlobalDefine.ERROR_CODE[26].code);
        }


        #endregion

        #region メソッド

        /// <summary>
        /// 一時変数に保存
        /// </summary>
        private void SaveTempVariable()
        {
            this.tmpUserName = this.textUser.Text;
            this.tmpCompany = this.cmbCompany.SelectedValue.ToString();
            this.tmpMailAddress = this.textMail.Text;
            
        }

        /// <summary>
        /// 値比較
        /// </summary>
        /// <returns></returns>
        private bool ValueCompare()
        {
            bool equal = (
                this.tmpUserName.Equals(this.textUser.Text) &&
                this.tmpCompany.Equals(this.cmbCompany.SelectedValue.ToString()) &&
                this.tmpMailAddress.Equals(this.textMail.Text)
            );

            return equal;
        }

        /// <summary>
        /// 会社名から会社ID取得
        /// </summary>
        /// <param name="companyName"></param>
        /// <returns></returns>
        private string GetCompanyId(string companyName)
        {
            DBAdapter dba = SingletonObject.GetDbAdapter();
            string query = string.Format("SELECT COMPANY_ID FROM COMPANY_MASTER WHERE COMPANY_NAME='{0}'", companyName);

            string[] data = dba.GetRecord(query);

            return (data == null) ? null : data[0];
        }




        #endregion

    }
}
