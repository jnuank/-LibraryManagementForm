using BCCM01.dataset;
using Common.db;
using Common.define;
using Common.dialog;
using Common.ErrorCheck;
using Common.exception;
using Common.singleton;
using System;
using System.Text;
using System.Windows.Forms;


namespace BCCM01.dialog
{
    /// <summary>
    /// ユーザ検索画面
    /// </summary>
    public partial class BCCM0101 : BaseForm
    {

        #region フィールド

        // エラーコード
        private readonly static int COMPANY_EMPTY       = 0;
        private readonly static int COMPANY_NO_SELECTED = 15;
        
        // デリゲート変数を用意する（オーナーウィンドウ側の操作用）
        public delegate void DelegateFunc(string arg0, string arg1);
        private DelegateFunc applyFunc;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BCCM0101()
        {
            InitializeComponent();
            InitDialog();
        }

        /// <summary>
        /// デリゲート有りコンストラクタ
        /// </summary>
        /// <param name="func"></param>
        public BCCM0101(DelegateFunc func) : this()
        {
            this.applyFunc = func;
        }
        #endregion

        #region 初期化
        /// <summary>
        /// 画面の初期化
        /// </summary>
        private void InitDialog()
        {
            InitComboBox();

            btnApply.Enabled = false;
        }

        /// <summary>
        /// コンボボックスの初期化
        /// </summary>
        private void InitComboBox()
        {
            string query  = "SELECT * FROM COMPANY_MASTER";
            DBAdapter dba = SingletonObject.GetDbAdapter();

            cmbCompany.DataSource    = dba.ExecSQL(query);
            cmbCompany.DisplayMember = "COMPANY_ABBREVIATION";
            cmbCompany.ValueMember   = "COMPANY_ID";
        }

        /// <summary>
        /// DataGridView初期化
        /// </summary>
        private void InitGridView()
        {
            dtGridView.InitControl();
        }
        #endregion

        #region イベント

        /// <summary>
        /// キャンセルボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 検索ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchInputChecks();
            }
            catch (InputException ex)
            {
                MessageBox.Show(ex.Message);
                if ( ex.ERROR_CODE == COMPANY_NO_SELECTED )
                    return;

                ex.ERROR_TEXTBOX.Clear();
                ex.ERROR_TEXTBOX.Focus();

                return;
            }

            // 検索開始
            DBAdapter dba = SingletonObject.GetDbAdapter();

            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT ");
            sql.AppendLine(" USER_ID, ");
            sql.AppendLine(" USER_NAME, ");
            sql.AppendLine(" COMPANY_ABBREVIATION ");
            sql.AppendLine("FROM ");
            sql.AppendLine(" USER_MASTER ");
            sql.AppendLine("LEFT OUTER JOIN ");
            sql.AppendLine(" COMPANY_MASTER ");
            sql.AppendLine(" ON ");
            sql.AppendLine(" USER_MASTER.COMPANY_ID = COMPANY_MASTER.COMPANY_ID ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine($" USER_NAME LIKE '%{textUser.Text}%'");
            sql.AppendLine($"AND USER_MASTER.COMPANY_ID = '{cmbCompany.SelectedValue}'");

            var table = dba.ExecSQL<UserDataSet.ViewUserMasterDataTable>(sql.ToString());

            dtGridView.SetDataSource(table);

            InitGridView();

            SearchMode(false);
        }

        /// <summary>
        /// クリアボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            SearchBoxClear();
            dtGridView.Clear();
            InitGridView();

            SearchMode(true);
        }

        /// <summary>
        /// 反映ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            // チェック処理
            ApplyBtnCheckes();

            // 呼び出し元に反映させる
            applyFunc(dtGridView.SelectedUserId(), dtGridView.SelectedUserName());

            base.Close();
        }

        #endregion

        #region チェックメソッド

        /// <summary>
        /// 検索ボタンを押下した際のチェック
        /// </summary>
        private void SearchInputChecks()
        {
            if(cmbCompany.SelectedIndex <= 0) // ←なぜ0「以下」
                throw new InputException(GlobalDefine.ERROR_CODE[15].message, GlobalDefine.ERROR_CODE[15].code);

            // シングルクォーテーションチェック
            InputCheck.IsSingleQuotation(this.textUser);

            // ユーザが居るか
            DBAdapter dba = SingletonObject.GetDbAdapter();
            string query = string.Format("SELECT * FROM USER_MASTER WHERE USER_NAME LIKE '%{0}%'", textUser.Text);
            if ( !dba.FindRecord(query) )
            {
                throw new InputException(GlobalDefine.ERROR_CODE[14].message, GlobalDefine.ERROR_CODE[14].code, textUser);
            }
        }

        /// <summary>
        /// 反映ボタン押下のチェック
        /// </summary>
        private void ApplyBtnCheckes()
        {
            if (!dtGridView.IsValidSelectedCells())
                throw new InputException(GlobalDefine.ERROR_CODE[16].message, GlobalDefine.ERROR_CODE[16].code);
        }
        #endregion


        /// <summary>
        /// 検索条件フィールドの有効/無効化
        /// </summary>
        /// <param name="enable"></param>
        private void SearchMode(bool enable)
        {
            textUser.Enabled   = enable;
            cmbCompany.Enabled = enable;
            btnSearch.Enabled  = enable;
            btnApply.Enabled   = !(enable);
        }

        /// <summary>
        /// 検索条件をクリアする
        /// </summary>
        private void SearchBoxClear()
        {
            textUser.Clear();
            cmbCompany.SelectedIndex = COMPANY_EMPTY;
        }
    }
}
