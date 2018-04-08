using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.db;
using Common.define;
using Common.dialog;
using Common.singleton;
using Common.exception;
using Common.ErrorCheck;
using BCCM01.dialog;
using Common.excel;
using System.IO;
using static Common.define.GlobalDefine;

namespace BCHT01.dialog
{
    /// <summary>
    /// 貸出履歴画面
    /// </summary>
    public partial class BCHT0101 : BaseForm
    {

        #region フィールド

        // メンバーリスト保持コンテナ
        private string userId = "";

        // コンボボックスが空白
        private readonly static int IS_CMB_BOX_EMPTY = 0;

        // エラーコード
        private static readonly int DATE_INVALID_CODE = 21;

        // ファイル名(相対パス)
        public static readonly string BOOK_RANKING_NAME = @"..\..\..\ブックランキング帳票.xlsx";
        public static readonly string USER_RANKING_NAME = @"..\..\..\ユーザーランキング帳票.xlsx";
        public static readonly string HISTORY_NAME      = @"..\..\..\貸出履歴帳票.xlsx";
        
        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BCHT0101()
        {
            InitializeComponent();
            InitDialog();

            LendingHistoryGridView();
            dataGridView1.Table.Clear();
            InitGridView();
        }

        /// <summary>
        /// ダイアログ初期化
        /// </summary>
        private void InitDialog()
        {
            DBAdapter dba = SingletonObject.GetDbAdapter();

            this.cmbCategory1.InitControl();
            this.cmbCategory2.InitControl();
            this.cmbCategory3.InitControl();

            rdMonthTop.Checked = true;
            rdBook.Checked = true;

            groupRanking.Enabled = false;

            dateLoanStart.Value = DateTime.Now;
            dateLoanEnd.Value = DateTime.Now;
            
        }

        /// <summary>
        /// DataGridView初期化
        /// </summary>
        private void InitGridView()
        {
            //データソースを設定する
            dataGridView1.InitDataSource();
            // コントロールの初期化
            dataGridView1.InitControl();
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
        /// フォームのクロージング処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BCHT0101_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( base.CloseFunction(GlobalDefine.MESSAGE_ASK_CLOSE) )
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
        /// 返却予定日超過をチェック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkScheduleOver_CheckedChanged(object sender, EventArgs e)
        {
            if ( chkScheduleOver.Checked )
            {
                this.dateLoanStart.Enabled = false;
                this.dateLoanEnd.Enabled = false;
            }
            else
            {
                this.dateLoanStart.Enabled = true;
                this.dateLoanEnd.Enabled = true;
            }
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
            catch(InputException ex)
            {
                MessageBox.Show(ex.Message);
                if ( ex.ERROR_CODE == DATE_INVALID_CODE)
                    return;
                ex.ERROR_TEXTBOX.Clear();
                ex.ERROR_TEXTBOX.Focus();
            }

            // 検索開始
            if(chkRanking.Checked)
            {
                if(rdBook.Checked)
                {
                    // 移送項目3
                    BookRankingGridView();
                    return;
                }

                if(rdUser.Checked)
                {
                    // 移送項目4
                    UserRankingGridView();
                    return;
                }
            }

            // ここにデフォルトの検索出力（移送項目2)
            LendingHistoryGridView();
            return;
        }

        /// <summary>
        /// クリアボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearSearch();
            ClearDataTable();
        }

        /// <summary>
        /// ランキング出力チェックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkRanking_CheckedChanged(object sender, EventArgs e)
        {
            groupRanking.Enabled = (chkRanking.Checked) ? true : false;
            groupSearch.Enabled  = (chkRanking.Checked) ? false : true;
        }

        /// <summary>
        /// 帳票プリント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelPrintChecks();
            }
            catch(InputException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            // 帳票をプリントする
            if ( chkRanking.Checked )
            {
                if ( rdBook.Checked )
                {
                    // 移送項目3
                    using ( ExcelManager xlMgr = new ExcelManager(System.IO.Path.GetFullPath(BOOK_RANKING_NAME)) )
                    {
                        // データ抜き出し
                        DataTable dt = dataGridView1.DataSource as DataTable;
                        int row = 6;
                        int col = 2;
                        int sheetPage = 1;
                        for(int i=0; i<dataGridView1.Table.Rows.Count; i++ )
                        {
                            for(int j=0; j<dataGridView1.Table.Columns.Count; j++ )
                            {
                                xlMgr.WriteCell<string>(dataGridView1.Table.Rows[i][j].ToString(), (row + i), (col + j), sheetPage);
                            }
                        }

                        // ランキング抽出期間の書き込み
                        row = 2;
                        col = 7;
                        string str = RecordTermString();
                        xlMgr.WriteCell<string>(str, row, col, sheetPage);

                    }
                    return;
                }

                if ( rdUser.Checked )
                {
                    // 移送項目4
                    using ( ExcelManager xlMgr = new ExcelManager(System.IO.Path.GetFullPath(USER_RANKING_NAME)) )
                    {
                        // データ抜き出し
                        DataTable dt = dataGridView1.DataSource as DataTable;
                        int row = 6;
                        int col = 2;
                        int sheetPage = 1;
                        for ( int i = 0; i < dataGridView1.Table.Rows.Count; i++ )
                        {
                            for ( int j = 0; j < dataGridView1.Table.Columns.Count; j++ )
                            {
                                xlMgr.WriteCell<string>(dataGridView1.Table.Rows[i][j].ToString(), row + i, col + j, sheetPage);
                            }
                        }

                        // ランキング抽出期間の書き込み
                        row = 2;
                        col = 4;
                        string str = RecordTermString();
                        xlMgr.WriteCell<string>(str, row, col, sheetPage);

                    }
                    return;
                }
            }
            // 移送項目2
            using ( ExcelManager xlMgr = new ExcelManager(System.IO.Path.GetFullPath(HISTORY_NAME)) )
            {
                // データ抜き出し
                DataTable dt = dataGridView1.DataSource as DataTable;
                int row = 10;
                int col = 2;
                int sheetPage = 1;
                int recordNumBegin = 1;
                int recordNumColumn = 1;
                
                for ( int i = 0; i < dataGridView1.Table.Rows.Count; i++ )
                {
                    xlMgr.WriteCell<int>( (i + recordNumBegin), (row + i), recordNumColumn, sheetPage);
                    xlMgr.BorderWrite( (row + i), recordNumColumn, sheetPage);

                    for ( int j = 0; j < dataGridView1.Table.Columns.Count; j++ )
                    {
                        xlMgr.WriteCell<string>(dataGridView1.Table.Rows[i][j].ToString(), (row + i), (col + j), sheetPage);
                        xlMgr.BorderWrite( (row + i), (col + j), sheetPage);
                    }
                }
                row = 2;
                col = 11;
                xlMgr.WriteCell<string>(DateTime.Now.Date.ToString("yyyy-MM-dd"), row, col, sheetPage);
            }
            return;
        }

        #endregion
        
        #region チェックメソッド

        /// <summary>
        /// 検索条件チェック
        /// </summary>
        private void SearchInputChecks()
        {
            // シングルクォーテーションチェック
            InputCheck.IsSingleQuotation(txtId);
            InputCheck.IsSingleQuotation(txtTitle);
            
            // 貸出日より前の日付だった場合
            if ( dateLoanStart.Value.Date > dateLoanEnd.Value.Date )
                throw new InputException(GlobalDefine.ERROR_CODE[21].message, GlobalDefine.ERROR_CODE[21].code);

        }

        /// <summary>
        /// 帳票プリント押下時のチェック
        /// </summary>
        private void ExcelPrintChecks()
        {
            // 1件も無かったら
            if ( dataGridView1.RowCount <= 0 )
                throw new InputException(ERROR_CODE[22].message, ERROR_CODE[22].code);
        }

        #endregion
        
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
        /// 検索条件のクリア    
        /// </summary>
        private void ClearSearch()
        {
            this.txtId.Clear();
            this.txtTitle.Clear();
            this.txtUserName.Clear();
            this.dateLoanStart.Value = DateTime.Now;
            this.dateLoanEnd.Value = DateTime.Now;
            this.chkLending.Checked = false;
            this.chkScheduleOver.Checked = false;
            this.cmbCategory1.SelectedIndex = 0;
            this.cmbCategory2.SelectedIndex = 0;
            this.cmbCategory3.SelectedIndex = 0;
        }

        /// <summary>
        /// dataTableのクリア
        /// </summary>
        private void ClearDataTable()
        {
            dataGridView1.Table.Clear();
        }

        private string RecordTermString()
        {
            string term = "";

            if ( rdMonthTop.Checked )
            {
                term = "期間:" + DateTime.Now.Date.ToString("yyyy年MM月");
                return term;
            }
            if ( rdYearTop.Checked )
            {
                term = "期間:" + DateTime.Now.Date.ToString("yyyy年");
                return term;
            }
            if ( rdTotalTop.Checked )
            {
                term = "全期間";
                return term;
            }

            return term;
        }

        #region 検索画面表示

        /// <summary>
        /// 貸出履歴画面を表示する
        /// </summary>
        private void LendingHistoryGridView()
        {
            string query = string.Format("SELECT " +
                                            "table4.BOOK_ID as '書籍ID', " +
                                            "table4.BOOK_NAME as 'タイトル', " +
                                            "table4.DIVISION_NAME1 as 分類1, " +
                                            "table4.DIVISION_NAME2 as '分類2', " +
                                            "table4.DIVISION_NAME3 as '分類3', " +
                                            "table3.USER_NAME as 'ユーザー名', " +
                                            "table2.LOAN_DATE as '貸出日時', " +
                                            "CASE WHEN table4.LENDING_STATUS=0 THEN table2.RETURN_SCHEDULE ELSE '' End as '返却予定日', " +
                                            "CASE WHEN table4.LENDING_STATUS=0 THEN '' ELSE table2.RETURN_DATE End as '返却日時', " +
                                            "CASE table4.LENDING_STATUS WHEN 0 THEN '貸出中' WHEN 1 THEN '' End as '貸出状態' " +
                                         "FROM " +
                                            "(SELECT " +
                                                "LENDING_DETAIL.* " +
                                            "FROM " +
                                                "(SELECT BOOK_ID, MAX(LOAN_DATE) as LOAN_DATE FROM LENDING_DETAIL GROUP BY BOOK_ID) as table1 " +
                                            "LEFT OUTER JOIN " +
                                                "LENDING_DETAIL " +
                                            "ON " +
                                                "table1.BOOK_ID = LENDING_DETAIL.BOOK_ID " +
                                                "AND table1.LOAN_DATE = LENDING_DETAIL.LOAN_DATE " +
                                            "GROUP BY " +
                                                "LENDING_DETAIL.BOOK_ID) as table2 " +
                                         "LEFT OUTER JOIN " +
                                            "USER_MASTER as table3 " +
                                         "ON " +
                                            "table3.USER_ID = table2.USER_ID " +
                                         "LEFT OUTER JOIN " +
                                            "(SELECT " +
                                                "BOOK_MASTER.*, " +
                                                "dv1.DIVISION_NAME as DIVISION_NAME1, " +
                                                "dv2.DIVISION_NAME as DIVISION_NAME2, " +
                                                "dv3.DIVISION_NAME as DIVISION_NAME3, " +
                                                "st.LENDING_STATUS " +
                                             "FROM " +
                                                "BOOK_MASTER " +
                                             "LEFT OUTER JOIN BOOK_GENRE_MASTER as dv1 ON dv1.DIVISION_ID = DIVISION_ID1 " +
                                             "LEFT OUTER JOIN BOOK_GENRE_MASTER as dv2 ON dv2.DIVISION_ID = DIVISION_ID2 " +
                                             "LEFT OUTER JOIN BOOK_GENRE_MASTER as dv3 ON dv3.DIVISION_ID = DIVISION_ID3 " +
                                             "LEFT OUTER JOIN BOOK_STATUS as st ON st.BOOK_ID = BOOK_MASTER.BOOK_ID) as table4 " +
                                         "ON " +
                                            "table4.BOOK_ID = table2.BOOK_ID " +
                                         "WHERE " +
                                            "table4.BOOK_ID LIKE '%{0}%' " +
                                            "AND table4.BOOK_NAME LIKE '%{1}%' ",
                                          this.txtId.Text, this.txtTitle.Text);

            // 分類1、検索条件を追加
            if ( this.cmbCategory1.SelectedIndex > IS_CMB_BOX_EMPTY )
            {
                query += string.Format("AND table4.DIVISION_ID1 = '{0}' ", cmbCategory1.SelectedValue);
            }

            // 分類2、検索条件を追加
            if ( this.cmbCategory2.SelectedIndex > IS_CMB_BOX_EMPTY )
            {
                query += string.Format("AND table4.DIVISION_ID2 = '{0}' ", cmbCategory2.SelectedValue);
            }

            // 分類3、検索条件を追加
            if ( this.cmbCategory3.SelectedIndex > IS_CMB_BOX_EMPTY )
            {
                query += string.Format("AND table4.DIVISION_ID3 = '{0}' ", cmbCategory3.SelectedValue);
            }

            // 貸出状態のチェックを入れていると、貸出中でないレコードを抽出
            if ( this.chkLending.Checked )
            {
                query += string.Format("AND table4.LENDING_STATUS = 1 ");
            }

            // ユーザ名で検索を追加
            if ( !(string.IsNullOrEmpty(this.txtUserName.Text)) )
            {
                query += string.Format("AND table3.USER_NAME LIKE '%{0}%' ", this.txtUserName.Text);
            }

            // 返却予定超過
            if(chkScheduleOver.Checked)
            {
                query += string.Format("AND table2.RETURN_SCHEDULE < datetime('now') ");
            }

            // 日付条件
            query += string.Format("AND LOAN_DATE >= datetime('{0}') AND LOAN_DATE <= datetime('{1}')",
                                    dateLoanStart.Value.ToString("yyyy-MM-dd"), dateLoanEnd.Value.ToString("yyyy-MM-dd"));

            // GROUP BYを追加
            query += string.Format(" GROUP BY table2.BOOK_ID ");

            DBAdapter dba = SingletonObject.GetDbAdapter();
            dataGridView1.Table = dba.execSQL(query);

            InitGridView();

        }

        /// <summary>
        /// ブック貸出ランキングを表示する
        /// </summary>
        private void BookRankingGridView()
        {
            string startDate = "";
            string endDate = "";

            if ( rdMonthTop.Checked )
            {
                startDate = string.Format("{0}-{1:D2}-01", DateTime.Now.Year, DateTime.Now.Month);
                endDate = string.Format("{0}-{1:D2}-01", DateTime.Now.Year, DateTime.Now.Month + 1);
            }

            if(rdYearTop.Checked)
            {
                startDate = string.Format("{0}-01-01", DateTime.Now.Year);
                endDate = string.Format("{0}-01-01", DateTime.Now.Year + 1);
            }

            if(rdTotalTop.Checked)
            {
                startDate = "1900-01-01";
                endDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            }


            string query = string.Format("SELECT " +
                                            "BOOK_MASTER.BOOK_ID as '書籍ID', " +
                                            "BOOK_MASTER.BOOK_NAME as 'タイトル', " +
                                            "dv1.DIVISION_NAME as '分類1', " +
                                            "dv2.DIVISION_NAME as '分類2', " +
                                            "dv3.DIVISION_NAME as '分類3', " +
                                            "COUNT(LENDING_DETAIL.BOOK_ID) as '貸出数'" +
                                         "FROM " +
                                            "BOOK_MASTER " +
                                         "LEFT OUTER JOIN BOOK_GENRE_MASTER as dv1 ON dv1.DIVISION_ID = DIVISION_ID1 " +
                                         "LEFT OUTER JOIN BOOK_GENRE_MASTER as dv2 ON dv2.DIVISION_ID = DIVISION_ID2 " +
                                         "LEFT OUTER JOIN BOOK_GENRE_MASTER as dv3 ON dv3.DIVISION_ID = DIVISION_ID3 " +
                                         "LEFT OUTER JOIN LENDING_DETAIL ON BOOK_MASTER.BOOK_ID = LENDING_DETAIL.BOOK_ID " +
                                         "WHERE LENDING_DETAIL.LOAN_DATE >= datetime('{0}') AND LENDING_DETAIL.LOAN_DATE < datetime('{1}')" +
                                         "GROUP BY BOOK_MASTER.BOOK_ID " + 
                                         "ORDER BY 貸出数 DESC ",
                                         startDate,endDate);
            
            DBAdapter dba = SingletonObject.GetDbAdapter();
            dataGridView1.Table = dba.execSQL(query);

            InitGridView();
        }

        /// <summary>
        /// 借りているユーザランキングを表示する
        /// </summary>
        private void UserRankingGridView()
        {
            string startDate = "";
            string endDate = "";

            if ( rdMonthTop.Checked )
            {
                startDate = string.Format("{0}-{1:D2}-01", DateTime.Now.Year, DateTime.Now.Month);
                endDate = string.Format("{0}-{1:D2}-01", DateTime.Now.Year, DateTime.Now.Month + 1);
            }

            if ( rdYearTop.Checked )
            {
                startDate = string.Format("{0}-01-01", DateTime.Now.Year);
                endDate = string.Format("{0}-01-01", DateTime.Now.Year + 1);
            }

            if ( rdTotalTop.Checked )
            {
                startDate = "1900-01-01";
                endDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            }

            string query = string.Format("SELECT " +
                                            "LENDING_DETAIL.USER_ID as 'ユーザーID', " +
                                            "USER_MASTER.USER_NAME as '氏名', " +
                                            "COUNT(LENDING_DETAIL.USER_ID) as '利用数' " +
                                         "FROM " +
                                            "LENDING_DETAIL " +
                                         "LEFT OUTER JOIN " +
                                            "USER_MASTER " +
                                         "ON " +
                                            "LENDING_DETAIL.USER_ID = USER_MASTER.USER_ID " +
                                         "WHERE LENDING_DETAIL.LOAN_DATE >= datetime('{0}') AND LENDING_DETAIL.LOAN_DATE < datetime('{1}')" +
                                         "GROUP BY " +
                                            "LENDING_DETAIL.USER_ID " +
                                         "ORDER BY " +
                                            "利用数 DESC ",
                                          startDate, endDate);

            DBAdapter dba = SingletonObject.GetDbAdapter();
            dataGridView1.Table = dba.execSQL(query);

            InitGridView();
        }

        #endregion

    }
}
