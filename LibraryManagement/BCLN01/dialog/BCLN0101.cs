using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.singleton;
using Common.db;
using Common.define;
using Common.dialog;
using Common.exception;
using Common.ErrorCheck;
using BCCM01.dialog;

namespace BCLN01.dialog
{
    /// <summary>
    /// 貸出画面
    /// </summary>
    public partial class BCLN0101 : BaseForm
    {

        #region フィールド

        private DataTable dataTable = new DataTable();
        private string userId = "";

        private readonly static int USER_NAME_EMPTY = 17;
        private readonly static int DATE_EMPTY      = 18;
        private readonly static int DATE_ILLEGAL    = 19;

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
        public BCLN0101()
        {
            InitializeComponent();
            InitDiag();

            mode = MODE.FROM_MENU;
        }

        /// <summary>
        /// 図書検索画面からのコンストラクタ
        /// </summary>
        /// <param name="row"></param>
        public BCLN0101(DataRow row)
        {
            InitializeComponent();
            InitDiag();

            txtId.ReadOnly = true;
            txtId.Text = row.Field<string>("ID");
            txtTitle.Text = row.Field<string>("タイトル");
            txtCategory1.Text = row.Field<string>("分類1");
            txtCategory2.Text = row.Field<string>("分類2");
            txtCategory3.Text = row.Field<string>("分類3");

            // 貸出中だったら、貸出ボタンDisableにする
            if ( !row.IsNull("貸出状態") && row.Field<string>("貸出状態").Equals("貸出中") )
                btnLoan.Enabled = false;

            txtId.TabStop = false;
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
            this.dateReturn.Value = DateTime.Now;

            
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

            if ( base.CloseFunction(GlobalDefine.MESSAGE_ASK_CLOSE) )
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

            try
            {
                CheckTxtId();
            }
            catch(InputException ex)
            {
                MessageBox.Show(ex.Message);
                ex.ERROR_TEXTBOX.Clear();
                ex.ERROR_TEXTBOX.Focus();

                return;
            }

            // チェック処理で問題なければ、検索実施

            DBAdapter dba = SingletonObject.GetDbAdapter();

            string query = string.Format("SELECT " +
                                            "BOOK_NAME, " +
                                            "table1.DIVISION_NAME as DIVISION_NAME1, " +
                                            "table2.DIVISION_NAME as DIVISION_NAME2, " +
                                            "table3.DIVISION_NAME as DIVISION_NAME3 " +
                                         "FROM " +
                                            "(SELECT " +
                                                "* " +
                                            "FROM " +
                                                "BOOK_MASTER " +
                                            "WHERE " +
                                                "BOOK_ID = '{0}' " +
                                            ") " +
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
                                            "DIVISION_ID3 = table3.DIVISION_ID "
                                          , txtId.Text);

            string[] bookColumns = dba.GetRecord(query);
            txtTitle.Text = bookColumns[0];
            txtCategory1.Text = bookColumns[1];
            txtCategory2.Text = bookColumns[2];
            txtCategory3.Text = bookColumns[3];

        }

        /// <summary>
        /// 貸出中ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoan_Click(object sender, EventArgs e)
        {
            try
            {
                CheckLoanButton();
            }
            catch(InputException ex)
            {
                MessageBox.Show(ex.Message);
                if ( ex.ERROR_CODE == USER_NAME_EMPTY || ex.ERROR_CODE == DATE_EMPTY || ex.ERROR_CODE == DATE_ILLEGAL)
                    return;
                ex.ERROR_TEXTBOX.Clear(); 
                ex.ERROR_TEXTBOX.Focus();

                return;
            }

            // 確認ダイアログを表示
            if ( !AskMessageBox(GlobalDefine.MESSAGE_ASK_LENDING) )
                return;

            DBAdapter dba = SingletonObject.GetDbAdapter();
            string query = string.Format("SELECT " +
                                            "MAX(SUB_NO) " +
                                         "FROM " +
                                            "LENDING_DETAIL " +
                                         "WHERE " +
                                            "BOOK_ID = '{0}' " +
                                         "AND LOAN_DATE = Datetime('{1}-{2:D2}-{3:D2} 00:00:00')",
                                         txtId.Text, dateLoan.Value.Date.Year, dateLoan.Value.Date.Month, dateLoan.Value.Date.Day);

            string[] maxId = dba.GetRecord(query);

            // 連番取得後、+1する
            int id = 0;
            int.TryParse(maxId[0], out id);
            id++;
            
            // 貸出詳細テーブル更新
            query = string.Format("INSERT INTO LENDING_DETAIL(BOOK_ID, LOAN_DATE, SUB_NO, USER_ID, RETURN_SCHEDULE) " +
                                    "VALUES('{0}',Datetime('{1}-{2:D2}-{3:D2} 00:00:00'), {4}, '{5}', Datetime('{6}-{7:D2}-{8:D2} 00:00:00'));",
                                    txtId.Text,
                                    dateLoan.Value.Date.Year, dateLoan.Value.Date.Month, dateLoan.Value.Date.Day,
                                    id,
                                    userId,
                                    dateReturn.Value.Date.Year, dateReturn.Value.Date.Month, dateReturn.Value.Date.Day);
            dba.nonExecSQL(query);

            // 貸出状態テーブル更新
            query = string.Format("UPDATE BOOK_STATUS SET LENDING_STATUS = 0 WHERE BOOK_ID = '{0}'", txtId.Text);
            dba.nonExecSQL(query);

            MessageBox.Show(GlobalDefine.MESSAGE_COMPLETE_REGISTRATION);

            switch ( mode )
            {
                case MODE.FROM_MENU:
                    InitDiag();
                    txtId.Focus();
                    break;

                case MODE.FROM_SEARCH:
                    mode = MODE.FORCE_CLOSE;
                    this.Close();
                    break;

                default:
                    break;
            }


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

        #endregion


        #region チェックメソッド

        /// <summary>
        /// 書籍IDチェック
        /// </summary>
        private void CheckTxtId()
        {
            DBAdapter dba = SingletonObject.GetDbAdapter();

            // シングルクォーテーションチェック
            InputCheck.IsSingleQuotation(this.txtId);

            // 書籍IDが存在するか
            IsExistBookId();

            // 書籍が貸出中ではないか(貸出詳細テーブルにレコードが無い＝貸し出したことが無い→棚に存在する)
            string query = string.Format("SELECT * FROM BOOK_STATUS WHERE BOOK_ID = '{0}'", txtId.Text);
            if ( dba.FindRecord(query) )
            {
                query = string.Format("SELECT " +
                    "* " +
                  "FROM " +
                    "(SELECT * FROM BOOK_STATUS WHERE BOOK_ID = '{0}') " +
                  "WHERE " +
                    "(LENDING_STATUS=1)",
                    txtId.Text);

                if ( !dba.FindRecord(query) )
                    throw new InputException(GlobalDefine.ERROR_CODE[12].message, GlobalDefine.ERROR_CODE[12].code, txtId);
            }

        }

        /// <summary>
        /// 貸出ボタン押下時のチェック
        /// </summary>
        private void CheckLoanButton()
        {
            // シングルクォーテーションチェック
            InputCheck.IsSingleQuotation(this.txtId);
            
            // 書籍ID未入力チェック
            if(string.IsNullOrEmpty(this.txtId.Text))
                throw new InputException(GlobalDefine.ERROR_CODE[13].message, GlobalDefine.ERROR_CODE[13].code, txtId);

            // 書籍IDが存在するか
            IsExistBookId();

            // ユーザ名未入力チェック
            if(string.IsNullOrEmpty(this.txtUserName.Text))
                throw new InputException(GlobalDefine.ERROR_CODE[17].message, GlobalDefine.ERROR_CODE[17].code);

            // 返却予定日がnullだった場合
            if(dateReturn.Value == null)
                throw new InputException(GlobalDefine.ERROR_CODE[18].message, GlobalDefine.ERROR_CODE[18].code);

            // 貸出日より前の日付だった場合
            if ( dateReturn.Value.Date < dateLoan.Value.Date )
                throw new InputException(GlobalDefine.ERROR_CODE[19].message, GlobalDefine.ERROR_CODE[19].code);
        }

        /// <summary>
        /// 書籍IDの存在チェック
        /// </summary>
        private void IsExistBookId()
        {
            // 書籍IDが存在するか
            DBAdapter dba = SingletonObject.GetDbAdapter();
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

        #endregion


    }
}
