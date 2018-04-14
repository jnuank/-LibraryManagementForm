using Common.db;
using Common.define;
using Common.dialog;
using Common.ErrorCheck;
using Common.exception;
using Common.singleton;
using System;
using System.Data;
using System.Windows.Forms;

namespace BCRT01.dialog
{
    /// <summary>
    /// 貸出画面
    /// </summary>
    public partial class BCRT0101 : BaseForm
    {

        #region フィールド

        private DataTable dataTable = new DataTable();
        private string userId       = "";
        private int subNo           = 0;        // 内部変数：連番

        private enum MODE
        {
            FROM_MENU,
            FROM_SEARCH,
            FORCE_CLOSE,
        }

        MODE mode;

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BCRT0101()
        {
            InitializeComponent();
            InitDiag();

            mode = MODE.FROM_MENU;
        }

        /// <summary>
        /// 図書検索画面からのコンストラクタ
        /// </summary>
        /// <param name="row"></param>
        public BCRT0101(DataRow row)
        {
            InitializeComponent();
            InitDiag();

            txtId.ReadOnly = true;
            txtId.Text = row.Field<string>("ID");
            txtTitle.Text = row.Field<string>("タイトル");
            txtCategory1.Text = row.Field<string>("分類1");
            txtCategory2.Text = row.Field<string>("分類2");
            txtCategory3.Text = row.Field<string>("分類3");

            mode = MODE.FROM_SEARCH;
        }

        /// <summary>
        /// 画面の初期化
        /// </summary>
        private void InitDiag()
        {
            DBAdapter dba = SingletonObject.GetDbAdapter();
            this.dataTable = SingletonObject.GetMemberList();

            this.txtId.Clear();
            this.txtCategory1.Clear();
            this.txtCategory2.Clear();
            this.txtCategory3.Clear();
            this.txtUserName.Clear();
            this.txtTitle.Clear();
            
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
        private void BCLN0101_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 確認ダイアログ出さずに終了
            if ( mode == MODE.FORCE_CLOSE )
                return;

            if ( base.IsCancelClosing(GlobalDefine.MESSAGE_ASK_CLOSE) )
                e.Cancel = true;
        }

        /// <summary>
        /// 書籍IDのフォーカスが離れた時（Lost Focus)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtId_Leave(object sender, EventArgs e)
        {
            // 空白の場合は、チェックもクエリも投げない。
            if ( string.IsNullOrEmpty(this.txtId.Text) )
                return;

            CheckTxtId();


            // チェック処理で問題なければ、検索実施

            DBAdapter dba = SingletonObject.GetDbAdapter();

            string query = string.Format("SELECT " +
                                            "BOOK_MASTER.BOOK_NAME, " +
                                            "table1.DIVISION_NAME as DIVISION_NAME1, " +
                                            "table2.DIVISION_NAME as DIVISION_NAME2, " +
                                            "table3.DIVISION_NAME as DIVISION_NAME3, " +
                                            "table4.USER_NAME, " +
                                            "table0.LOAN_DATE, " +
                                            "table0.RETURN_SCHEDULE, " +
                                            "SUB_NO " +
                                         "FROM " +
                                            "BOOK_MASTER " +
                                         "LEFT OUTER JOIN " +
                                            "(SELECT " +
                                                "BOOK_ID, " +
                                                "LOAN_DATE, " +
                                                "MAX(SUB_NO) as SUB_NO, " +
                                                "USER_ID, " +
                                                "RETURN_SCHEDULE, " +
                                                "RETURN_DATE " +
                                            "FROM " +
                                                "LENDING_DETAIL " +
                                            "WHERE " +
                                                "BOOK_ID = '{0}' " +
                                                "AND LOAN_DATE = " +
                                                "(SELECT " +
                                                    "MAX(LOAN_DATE) " +
                                                 "FROM " +
                                                    "LENDING_DETAIL " +
                                                 "WHERE " +
                                                    "BOOK_ID = '{0}' " +
                                                 "GROUP BY " +
                                                    "BOOK_ID " +
                                                 ") " +
                                             ") as table0 " +
                                         "LEFT OUTER JOIN " +
                                            "BOOK_GENRE_MASTER as table1 " +
                                         "ON " +
                                            "DIVISION_ID1 = table1.DIVISION_ID " +
                                         "LEFT OUTER JOIN " +
                                            "BOOK_GENRE_MASTER as table2 " +
                                         "ON " +
                                            "DIVISION_ID2 = table2.DIVISION_ID " +
                                         "LEFT OUTER JOIN " +
                                            "BOOK_GENRE_MASTER as table3 " +
                                         "ON " +
                                            "DIVISION_ID3 = table3.DIVISION_ID " +
                                         "LEFT OUTER JOIN " +
                                            "USER_MASTER as table4 " +
                                         "ON " +
                                            "table4.USER_ID = table0.USER_ID " +
                                         "WHERE " +
                                            "BOOK_MASTER.BOOK_ID = '{0}' "
                                            , txtId.Text);

            // フィールドにセット
            string[] bookColumns = dba.GetRecord(query);
            txtTitle.Text = bookColumns[0];
            txtCategory1.Text = bookColumns[1];
            txtCategory2.Text = bookColumns[2];
            txtCategory3.Text = bookColumns[3];
            txtUserName.Text = bookColumns[4];
            dateLoan.Value = DateTime.Parse(bookColumns[5]);
            dateReturnSchedule.Value = DateTime.Parse(bookColumns[6]);
            subNo = int.Parse(bookColumns[7]);
            dateReturn.Value = DateTime.Now;

        }

        /// <summary>
        /// 返却ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            ReturnCheckes();

            // 確認ダイアログを表示
            if ( !AskMessageBox(GlobalDefine.MESSAGE_ASK_RETURN) )
                return;

            // 貸出詳細テーブル更新
            DBAdapter dba = SingletonObject.GetDbAdapter();
            string query = string.Format("UPDATE LENDING_DETAIL SET RETURN_DATE = Datetime('{0}') " +
                                        "WHERE BOOK_ID = '{1}' AND LOAN_DATE = Datetime('{2}') AND SUB_NO = {3} ",
                                        dateReturn.Value.ToString("yyyy-MM-dd"),
                                        txtId.Text,
                                        dateLoan.Value.ToString("yyyy-MM-dd"),
                                        subNo);

            dba.nonExecSQL(query);

            // 貸出状態テーブル更新
            query = string.Format("UPDATE BOOK_STATUS SET LENDING_STATUS = 1 WHERE BOOK_ID = '{0}'", txtId.Text);
            dba.nonExecSQL(query);
            
            MessageBox.Show(GlobalDefine.MESSAGE_COMPLETE_REGISTRATION);

            InitDiag();
            txtId.Focus();


        }

        #endregion


        #region チェックメソッド

        /// <summary>
        /// 書籍ID LostFocusチェック
        /// </summary>
        private void CheckTxtId()
        {

            // シングルクォーテーションチェック
            InputCheck.IsSingleQuotation(this.txtId);

            // 書籍IDが存在するか
            IsExistBookId();

            // 書籍が貸出中か
            DBAdapter dba = SingletonObject.GetDbAdapter();
            string query = string.Format("SELECT * FROM BOOK_STATUS WHERE BOOK_ID = '{0}'", txtId.Text);
            if ( dba.FindRecord(query) )
            {
                query = string.Format("SELECT " +
                    "* " +
                  "FROM " +
                    "(SELECT * FROM BOOK_STATUS WHERE BOOK_ID = '{0}') " +
                  "WHERE " +
                    "(LENDING_STATUS = 0)",
                    txtId.Text);

                if ( !dba.FindRecord(query) )
                    throw new InputException(GlobalDefine.ERROR_CODE[20].message, GlobalDefine.ERROR_CODE[20].code, txtId);
            }

        }

        /// <summary>
        /// 書籍IDの存在チェック
        /// </summary>
        private void IsExistBookId()
        {
            DBAdapter dba = SingletonObject.GetDbAdapter();

            // 書籍IDが存在するか
            string query = string.Format("SELECT * FROM BOOK_MASTER WHERE BOOK_ID = '{0}'", txtId.Text);
            if ( !dba.FindRecord(query) )
            {
                throw new InputException(GlobalDefine.ERROR_CODE[11].message, GlobalDefine.ERROR_CODE[11].code, txtId);
            }
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
        /// 返却ボタン押下時のチェック
        /// </summary>
        private void ReturnCheckes()
        {
            // 未入力チェック
            if ( string.IsNullOrEmpty(txtId.Text) )
                throw new InputException(GlobalDefine.ERROR_CODE[11].message, GlobalDefine.ERROR_CODE[11].code, txtId);

            // 存在チェック
            IsExistBookId();

            // 書籍が貸出中か
            DBAdapter dba = SingletonObject.GetDbAdapter();
            string query = string.Format("SELECT * FROM BOOK_STATUS WHERE BOOK_ID = '{0}'", txtId.Text);
            if ( dba.FindRecord(query) )
            {
                query = string.Format("SELECT " +
                    "* " +
                  "FROM " +
                    "(SELECT * FROM BOOK_STATUS WHERE BOOK_ID = '{0}') " +
                  "WHERE " +
                    "(LENDING_STATUS = 0)",
                    txtId.Text);

                if ( !dba.FindRecord(query) )
                    throw new InputException(GlobalDefine.ERROR_CODE[20].message, GlobalDefine.ERROR_CODE[20].code, txtId);
            }
        }

        #endregion
    }
}
