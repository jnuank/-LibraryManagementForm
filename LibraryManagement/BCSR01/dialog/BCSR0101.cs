using BCLN01.dialog;
using BCSR01.dataset;
using Common.db;
using Common.define;
using Common.dialog;
using Common.ErrorCheck;
using Common.exception;
using Common.singleton;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BCSR01.dialog
{
    public partial class BCSR0101 : BaseForm
    {
        #region フィールド

        // メンバーリスト保持コンテナ
        private DataTable dataTable = new DataTable();

        // コンボボックスが空白
        private readonly static int IS_CMB_BOX_EMPTY = 0;
        private readonly static int ERROR_SINGLEQUOTATION = 0;

        #endregion

        #region コンストラクタ
        public BCSR0101()
        {
            InitializeComponent();

            InitDialog();

            ExecuteSearch();
            InitGridView();
        }

        #endregion

        /// <summary>
        /// ダイアログ初期化
        /// </summary>
        private void InitDialog()
        {
            DBAdapter dba = SingletonObject.GetDbAdapter();

            this.Text = GlobalDefine.FORM_NAME;

            this.dataTable = SingletonObject.GetMemberList();

            cmbCategory1.InitControl();
            cmbCategory2.InitControl();
            cmbCategory3.InitControl();
        }

        /// <summary>
        /// DataGridView初期化
        /// </summary>
        private void InitGridView()
        {
            dtGridView.InitControl();
        }

        # region イベント

        /// <summary>
        /// 検索ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // エラーチェック
            try
            {
                ErrorChecks();
                ExecuteSearch();
            }
            catch ( InputException ex )
            {
                MessageBox.Show(ex.Message);
                if ( ex.ERROR_CODE == ERROR_SINGLEQUOTATION )
                {
                    ex.ERROR_TEXTBOX.Clear();
                    ex.ERROR_TEXTBOX.Focus();
                }
                return;
            }

            // データグリッドビューの更新
            InitGridView();

            // 検索条件フィールドを無効化にする
            SearchBoxEnable(false);
        }

        /// <summary>
        /// クリアボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearResult();
            ClearInputBox();
            SearchBoxEnable(true);
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
        /// フォームのクロージング処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BCMT0101_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( base.IsCancelClosing(GlobalDefine.MESSAGE_ASK_CLOSE) )
                e.Cancel = true;
        }

        private void dtGridView_CellDubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 選択された行を取得
            int nTarget = e.RowIndex;

            BCLN0101 loanForm = new BCLN0101(dtGridView.SelectedRow());
            loanForm.ShowDialog();

            ExecuteSearch();
            InitGridView();
        }

        #endregion

        /// <summary>
        /// 検索結果一覧をクリアする
        /// </summary>
        private void ClearResult()
        {
            dtGridView.Clear();
        }

        /// <summary>
        /// 検索条件をクリアする
        /// </summary>
        private void ClearInputBox()
        {
            txtId.Clear();
            txtTitle.Clear();
            cmbCategory1.SelectedIndex = 0;
            cmbCategory2.SelectedIndex = 0;
            cmbCategory3.SelectedIndex = 0;
        }

        /// <summary>
        /// エラーチェック
        /// </summary>
        private void ErrorChecks()
        {
            InputCheck.IsSingleQuotation(this.txtId);
            InputCheck.IsSingleQuotation(this.txtTitle);
        }

        /// <summary>
        /// ベースとなるクエリ発行関数
        /// </summary>
        /// <returns></returns>
        private string BaseQuery()
        {
            string query = string.Format(
                "SELECT " +
                    "BOOK_ID, " +
                    "BOOK_NAME, " +
                    "DIVISION_NAME1, " +
                    "DIVISION_NAME2, " +
                    "DIVISION_NAME3, " +
                    "CASE LENDING_STATUS WHEN 0 THEN '貸出中' WHEN 1 THEN '' End as 'LENDING_STATUS', " +
                    "CASE WHEN LENDING_STATUS=0 THEN RETURN_SCHEDULE ELSE '' End as 'RETURN_SCHEDULE'" +
                "FROM " +
                    "(SELECT " +
                        "*, " +
                        "BOOK_GENRE_MASTER.DIVISION_NAME as 'DIVISION_NAME3' " +
                    "FROM " +
                        "(SELECT " +
                            "*, " +
                            "BOOK_GENRE_MASTER.DIVISION_NAME as 'DIVISION_NAME2' " +
                         "FROM " +
                            "(SELECT " +
                                "*, " +
                                "BOOK_GENRE_MASTER.DIVISION_NAME as 'DIVISION_NAME1' " +
                            "FROM " +
                                "(SELECT " +
                                    "* " +
                                    "FROM " +
                                        "(SELECT " +
                                            "BOOK_MASTER.BOOK_ID, " +
                                            "BOOK_NAME, " +
                                            "DIVISION_ID1, " +
                                            "DIVISION_ID2, " +
                                            "DIVISION_ID3, " +
                                            "MAX(RETURN_SCHEDULE) as RETURN_SCHEDULE " +
                                        "FROM " +
                                            "BOOK_MASTER " +
                                        "LEFT OUTER JOIN " +
                                            "LENDING_DETAIL " +
                                        "ON " +
                                            "BOOK_MASTER.BOOK_ID = LENDING_DETAIL.BOOK_ID " +
                                        "GROUP BY " +
                                            "BOOK_MASTER.BOOK_ID " +
                                        ") as SubTable1 " +
                                    "LEFT OUTER JOIN " +
                                        "BOOK_STATUS " +
                                    "ON " +
                                        "SubTable1.BOOK_ID = BOOK_STATUS.BOOK_ID " +
                                    "WHERE BOOK_STATUS.EXISTENTIAL_STATUS=1 " +
                                    ") as SubTable2 " +
                                "LEFT OUTER JOIN " +
                                    "BOOK_GENRE_MASTER " +
                                "ON " +
                                    "DIVISION_ID1 = BOOK_GENRE_MASTER.DIVISION_ID " +
                                ") as SubTable3 " +
                            "LEFT OUTER JOIN " +
                                "BOOK_GENRE_MASTER " +
                            "ON " +
                                "DIVISION_ID2 = BOOK_GENRE_MASTER.DIVISION_ID " +
                            ") as SubTable4 " +
                        "LEFT OUTER JOIN " +
                            "BOOK_GENRE_MASTER " +
                        "ON " +
                            "DIVISION_ID3 = BOOK_GENRE_MASTER.DIVISION_ID " +
                        ")");

            return query;
        }

        /// <summary>
        /// 検索条件フィールドの有効化
        /// </summary>
        /// <param name="enable"></param>
        private void SearchBoxEnable(bool enable)
        {
            this.txtId.Enabled        = enable;
            this.txtTitle.Enabled     = enable;
            this.cmbCategory1.Enabled = enable;
            this.cmbCategory2.Enabled = enable;
            this.cmbCategory3.Enabled = enable;
            this.chkLending.Enabled   = enable;
            this.btnSearch.Enabled    = enable;
        }

        /// <summary>
        /// 図書検索クエリを流す
        /// </summary>
        private void ExecuteSearch()
        {
            DBAdapter dba = SingletonObject.GetDbAdapter();

            string query = "";
            query = BaseQuery();

            query += string.Format("WHERE BOOK_ID LIKE '%{0}%' AND BOOK_NAME LIKE '%{1}%' ", this.txtId.Text, this.txtTitle.Text);

            // 分類1、検索条件を追加
            if ( this.cmbCategory1.SelectedIndex > IS_CMB_BOX_EMPTY )
                query += string.Format("AND DIVISION_ID1 = '{0}' ", cmbCategory1.SelectedValue);

            // 分類2、検索条件を追加
            if ( this.cmbCategory2.SelectedIndex > IS_CMB_BOX_EMPTY )
                query += string.Format("AND DIVISION_ID2 = '{0}' ", cmbCategory2.SelectedValue);

            // 分類3、検索条件を追加
            if ( this.cmbCategory3.SelectedIndex > IS_CMB_BOX_EMPTY )
                query += string.Format("AND DIVISION_ID3 = '{0}' ", cmbCategory3.SelectedValue);

            // 貸出状態のチェックを入れていると、貸出中でないレコードを抽出
            if ( this.chkLending.Checked )
                query += string.Format("AND LENDING_STATUS = 1");

            var viewTable = dba.ExecSQL<BookLending.ViewDataTable>(query);
            dtGridView.ShowSearchResult(viewTable);
        }

    }
}
