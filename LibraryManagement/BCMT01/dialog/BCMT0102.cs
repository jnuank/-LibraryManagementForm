using System;
using System.Data;
using System.Windows.Forms;
using Common.db;
using Common.define;
using Common.dialog;
using Common.singleton;
using Common.ErrorCheck;
using Common.exception;
using BCCM01.dialog;
using static BCMT01.dialog.BookMasterDataGridView;


namespace BCMT01.dialog
{
    public partial class BCMT0102 : BaseForm
    {
    
        #region フィールド

        // 【編集時】初期値保存用
        private string      title       = "";
        private string      cate1       = "";
        private string      cate2       = "";
        private string      cate3       = "";
        private string      userName    = "";
        private DateTime    arrivalDate = DateTime.Now;
        private string      userId      = "";

        // 新規作成or編集モードor削除モード
        MODE mode;

        #endregion

        /// <summary>
        /// 新規作成コンストラクタ
        /// </summary>
        public BCMT0102()
        {
            mode = MODE.ADD;

            InitializeComponent();
            InitDialog();

            this.txtId.ReadOnly = true;

            SaveTempValue();
        }

        /// <summary>
        /// 編集用コンストラクタ
        /// </summary>
        /// <param name="row"></param>
        public BCMT0102(DataGridViewRow row)
        {
            mode = MODE.MOD;

            InitializeComponent();
            InitDialog();

            this.txtId.Text = row.Cells[(int)COLUMNS.BOOK_ID].Value.ToString();
            this.txtId.ReadOnly     = true;
            this.txtTitle.Text      = row.Cells[(int)COLUMNS.BOOK_NAME].Value.ToString();

            // グリッドビューからは   分類名しか取れない為、分類名→分類IDを取得して、コンボボックスにID突っ込む。
            string categoryId1 = GetCategoryId(row.Cells[(int)COLUMNS.DIVISION_NAME1].Value.ToString());
            string categoryId2 = GetCategoryId(row.Cells[(int)COLUMNS.DIVISION_NAME2].Value.ToString());
            string categoryId3 = GetCategoryId(row.Cells[(int)COLUMNS.DIVISION_NAME3].Value.ToString());

            // nullだった場合には、コンボボックスの初期状態を表示
            this.cmbCategory1.SelectedValue = categoryId1 ?? "";
            this.cmbCategory2.SelectedValue = categoryId2 ?? "";
            this.cmbCategory3.SelectedValue = categoryId3 ?? "";

            this.txtUserName.Text  = row.Cells[(int)COLUMNS.ARRIVAL_USER_NAME].Value.ToString();
            this.dateArrival.Value = DateTime.Parse(row.Cells[(int)COLUMNS.ARRIVAL_DATE].Value.ToString());
            
            this.userId = GetUserId(this.txtUserName.Text);

            SaveTempValue();

        }

        /// <summary>
        /// 画面の初期化
        /// </summary>
        private void InitDialog()
        {
            DBAdapter dba = SingletonObject.GetDbAdapter();

            this.Text = GlobalDefine.FORM_NAME;

            this.cmbCategory1.InitControl();
            this.cmbCategory2.InitControl();
            this.cmbCategory3.InitControl();

            bool delFuncEnable = (mode == MODE.ADD) ? false     // 新規作成時
                               : (mode == MODE.MOD) ? true      // 編集時
                                                    : false;    // それ以外

            FormControlsEnabledOnLoad(delFuncEnable);
        }

        #region イベント
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
        /// 確定ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            
            ApplyButtonCheck();
        
            if(mode == MODE.ADD)
            {
                if ( !base.AskMessageBox(GlobalDefine.MESSAGE_ASK_REGISTRATION) )
                    return;

                // ID MAX値取得
                DbQuery dc = SingletonObject.GetDbQuery();
                DBAdapter dba = SingletonObject.GetDbAdapter();

                // 新規ID取得(MAX値+1)
                string newStringId = dba.GetMaxID(nameof(GlobalDefine.BOOK_ID), GlobalDefine.BOOK_MASTER);
                newStringId = newStringId.Substring(1);

                int newId = int.Parse(newStringId) + 1;

                // 0埋めして新規ID作成
                string newIdText = string.Format("B{0:D3}", newId);

                // テーブルに新規レコードを追加する
                dc.InsertBookMaster(newIdText,
                                    this.txtTitle.Text,
                                    this.userId,
                                    this.dateArrival.Value,
                                    this.cmbCategory1.SelectedValue.ToString(),
                                    this.cmbCategory2.SelectedValue.ToString(),
                                    this.cmbCategory3.SelectedValue.ToString()
                                    );

                dc.InsertBookStatus(newIdText);


                MessageBox.Show(GlobalDefine.MESSAGE_COMPLETE_REGISTRATION);

                this.txtId.Text = newIdText;

                FormControlsEnabledOnLoad(true);

                SaveTempValue();

                mode = MODE.MOD;
                return;
            }

            if (mode == MODE.MOD)
            {
                if ( !base.AskMessageBox(GlobalDefine.MESSAGE_ASK_UPDATE) )
                    return;

                // テーブル更新
                DbQuery dc = SingletonObject.GetDbQuery();
                DBAdapter dba = SingletonObject.GetDbAdapter();

                dc.UpdateBookMaster(this.txtTitle.Text,
                                    this.userId,
                                    this.dateArrival.Value,
                                    this.cmbCategory1.SelectedValue.ToString(),
                                    this.cmbCategory2.SelectedValue.ToString(),
                                    this.cmbCategory3.SelectedValue.ToString(),
                                    this.txtId.Text
                                    );

                MessageBox.Show(GlobalDefine.MESSAGE_COMPLETE_UPDATE);

                SaveTempValue();
            }
        }

        /// <summary>
        /// フォームのクロージング処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BCMT0102_FormClosing(object sender, FormClosingEventArgs e)
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
        /// ユーザ検索ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUserSearch_Click(object sender, EventArgs e)
        {
            BCCM0101 userSearchForm = new BCCM0101(SetUser);
            userSearchForm.ShowDialog();
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

            DbQuery dc = SingletonObject.GetDbQuery();

            dc.DeleteBook(txtId.Text);

            MessageBox.Show(GlobalDefine.MESSAGE_COMPLETE_DELETE);

            mode = MODE.DEL;
            this.Close();
        }

        #endregion


        #region チェック

        /// <summary>
        /// 確定ボタン押下時のチェック
        /// </summary>
        private void ApplyButtonCheck()
        {
            InputCheck.IsSingleQuotation(this.txtTitle);

            if ( string.IsNullOrEmpty(this.txtTitle.Text) )
                throw new InputException(GlobalDefine.ERROR_CODE[23].message, GlobalDefine.ERROR_CODE[23].code, this.txtTitle);
        }

        #endregion

        #region メソッド

        /// <summary>
        /// 起動時のフォームコントロール有効/無効化
        /// </summary>
        /// <param name="flag"></param>
        private void FormControlsEnabledOnLoad(bool flag)
        {
            this.btnDelete.Enabled = flag;
        }

        /// <summary>
        /// 分類名から分類ID取得
        /// </summary>
        /// <param name="categroyName"></param>
        /// <returns></returns>
        private string GetCategoryId(string categroyName)
        {
            DbQuery dc = SingletonObject.GetDbQuery();

            string[] data = dc.SelectGenreId(categroyName);

            return (data == null) ? null : data[0];
        }

        /// <summary>
        /// ユーザ名からユーザID取得
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        private string GetUserId(string userName)
        {
            DbQuery dc = SingletonObject.GetDbQuery();

            string[] data = dc.SelectUserId(userName);

            return (data == null) ? null : data[0];
        }

        /// <summary>
        /// 値比較
        /// </summary>
        /// <returns></returns>
        private bool ValueCompare()
        {
            bool equal = (
                this.title.Equals(this.txtTitle.Text) &&
                this.cate1.Equals(this.cmbCategory1.SelectedValue.ToString()) &&
                this.cate2.Equals(this.cmbCategory2.SelectedValue.ToString()) &&
                this.cate3.Equals(this.cmbCategory3.SelectedValue.ToString()) &&
                this.userName.Equals(this.txtUserName.Text) &&
                this.arrivalDate.Date.Equals(this.dateArrival.Value.Date)
            );

            return equal;
        }

        /// <summary>
        /// ユーザ名セット
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        private void SetUser(string userId, string userName)
        {
            this.userId = userId;
            txtUserName.Text = userName;
        }

        /// <summary>
        /// 一時変数の保存
        /// </summary>
        private void SaveTempValue()
        {
            // 変数保持
            this.title       = this.txtTitle.Text;
            this.cate1       = this.cmbCategory1.SelectedValue?.ToString();
            this.cate2       = this.cmbCategory2.SelectedValue?.ToString();
            this.cate3       = this.cmbCategory3.SelectedValue?.ToString();
            this.userName    = this.txtUserName.Text;
            this.arrivalDate = this.dateArrival.Value;
        }

        #endregion


    }
}
