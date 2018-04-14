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
    public partial class BCMT0401 : BaseForm
    {
        #region フィールド

        // ユーザ名
        string userName;

        #endregion
        public enum COLUMNS
        {
            ID,
            NAME,
            COMPANY_ID,
            MAIL,
            RETREMENT,
        }

        DataTable dataTable = SingletonObject.GetMemberList();

        public BCMT0401()
        {
            InitializeComponent();
            InitDialog();
            InitGridView();

            // 保存
            BeforeRecordData();
        }

        /// <summary>
        /// 画面の初期化
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

            // 退職者を含めない
            rdobtnExcludedRetired.Checked = true;
        }

        /// <summary>
        /// DataGridView初期化
        /// </summary>
        private void InitGridView()
        {
            // データソースの設定をする
            dataGridView1.DataSource = dataTable;

            dataGridView1.InitControl();

            if ( dataGridView1.Rows.Count > 0 )
            {
                // ユーザIDセル
                dataGridView1.Columns[(int)COLUMNS.ID].HeaderText = GlobalDefine.USER_ID;
                dataGridView1.Columns[(int)COLUMNS.ID].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView1.Columns[(int)COLUMNS.ID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // ユーザ名
                dataGridView1.Columns[(int)COLUMNS.NAME].HeaderText = GlobalDefine.USER_NAME;

                // 会社名
                dataGridView1.Columns[(int)COLUMNS.COMPANY_ID].HeaderText = GlobalDefine.MEMBER_COMPANY;

                // メールアドレス
                dataGridView1.Columns[(int)COLUMNS.MAIL].HeaderText = GlobalDefine.MAIL;

                // 退職有無
                dataGridView1.Columns[(int)COLUMNS.RETREMENT].HeaderText = GlobalDefine.RETREMENT;
            }
        }

        #region イベント

        /// <summary>
        /// 閉じるボタンを押したらクローズ
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
        private void BCMT0401_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( base.IsCancelClosing(GlobalDefine.MESSAGE_ASK_CLOSE) )
            { e.Cancel = true; }
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
                // 入力エラーチェック
                ErrorCheck();

                // ユーザ名でユーザマスタを検索かける
                DBAdapter dba = SingletonObject.GetDbAdapter();

                // ★memo
                // 退職者を含めない（flagがfalseになっているモノだけ）
                // 退職者を含める（flag自体は検索条件に含めない)
                // この場合、クエリ文自体をif文で切り替えないとかな？
                string query = string.Format("SELECT "+
                                            "USER_MASTER.USER_ID,USER_MASTER.USER_NAME,"+
                                            "COMPANY_MASTER.COMPANY_NAME,"+
                                            "USER_MASTER.USER_MAILADDRESS,"+
                                            "CASE RETIREMENT_FLAG "+
                                            "WHEN 0 THEN '' "+
                                            "WHEN 1 THEN '退職'"+
                                            "END as RETIREMENT_FLAG "+
                                            "FROM USER_MASTER, COMPANY_MASTER "+
                                            "WHERE USER_MASTER.COMPANY_ID=COMPANY_MASTER.COMPANY_ID "+
                                            "AND USER_NAME LIKE '%{0}%' ",
                                            this.textUser.Text);


                // 検索条件によってクエリ文を追加する
                if( rdobtnExcludedRetired.Checked )
                {
                    query = query + " AND USER_MASTER.RETIREMENT_FLAG=0 ";
                }

                // 検索条件によってクエリ文を追加する
                if(this.cmbCompany.SelectedIndex != -1)
                {
                    string str = string.Format("AND USER_MASTER.COMPANY_ID='{0}'", this.cmbCompany.SelectedValue);
                    query = query + str;
                }
                
                // 一旦初期化
                //dataTable.Clear();

                dataTable = dba.execSQL(query);

                // クエリ投げた後の結果でエラーチェック
                SQLErrorCheck();

                // データグリッドビューの更新
                InitGridView();
                
            }
            catch ( InputException ex )
            {
                MessageBox.Show(ex.Message);
                if ( ex.ERROR_CODE == GlobalDefine.ERROR_CODE[0].code )
                    RestoreRecordData(this.textUser);
                return;
            }
        }

        /// <summary>
        /// クリアボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            
            ClearSearchBox();
        }

        /// <summary>
        /// 新規作成ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            BCMT0402 modifyForm = new BCMT0402();
            modifyForm.ShowDialog();

            InitGridView();
        }

        #endregion

        #region メソッド

        /// <summary>
        /// 入力チェック用メソッド
        /// </summary>
        private void ErrorCheck()
        {
            InputCheck.IsSingleQuotation(this.textUser);
        }

        /// <summary>
        /// SQLエラーチェック用メソッド
        /// </summary>
        private void SQLErrorCheck()
        {
            // データが0件だった場合
            if ( dataTable.Rows.Count < 1 )
                throw new InputException(GlobalDefine.ERROR_CODE[5].message, GlobalDefine.ERROR_CODE[5].code);
        }

        /// <summary>
        /// クリア用メソッド
        /// </summary>
        private void ClearSearchBox()
        {
            this.textUser.Text = "";
            this.rdobtnExcludedRetired.Checked = true;
            //this.dataTable.Clear();
                        
            this.cmbCompany.SelectedIndex = -1;
            InitGridView();
        }

        /// <summary>
        /// 編集前のデータを保存
        /// </summary>
        private void BeforeRecordData()
        {
            this.userName = this.textUser.Text;
        }

        /// <summary>
        /// 編集前のデータをリストアする
        /// </summary>
        /// <param name="target"></param>
        private void RestoreRecordData(TextBox target)
        {
            if ( target.Name.Equals("textUser") )
            {
                target.Text = this.userName;
            }
        }


        #endregion

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 選択された行を取得
            int nTarget = e.RowIndex;

            // 選択された行を取得
            DataRow row = dataTable.Rows[nTarget];

            // 編集画面にデータを渡し、開く
            BCMT0402 modifyForm = new BCMT0402(row);
            modifyForm.ShowDialog();

            // 画面更新
            InitGridView();
        }
    }
}
