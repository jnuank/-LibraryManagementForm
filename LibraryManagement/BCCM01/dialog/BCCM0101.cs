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
using Common.singleton;
using Common.dialog;
using Common.ErrorCheck;
using Common.exception;


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

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BCCM0101()
        {
            InitializeComponent();
            InitDialog();
            InitGridView();
        }

        /// <summary>
        /// デリゲート有り
        /// </summary>
        /// <param name="func"></param>
        public BCCM0101(DelegateFunc func)
        {
            InitializeComponent();
            InitDialog();
            InitGridView();

            this.applyFunc = func;
        }

        /// <summary>
        /// 画面の初期化
        /// </summary>
        private void InitDialog()
        {
            string query = "SELECT * FROM COMPANY_MASTER";

            DBAdapter dba = SingletonObject.GetDbAdapter();
            cmbCompany.DataSource = dba.execSQL(query);

            #region ここ直したい
            // 実際に表示するのは会社略称
            cmbCompany.DisplayMember = "COMPANY_ABBREVIATION";
            // 内部的に渡すのは、会社ID
            cmbCompany.ValueMember = "COMPANY_ID";
            #endregion

            // ロード時は無効
            btnApply.Enabled = false;

        }

        /// <summary>
        /// DataGridView初期化
        /// </summary>
        private void InitGridView()
        {
            // データソースの設定をする
            dataGridView1.InitDataSource();
            // コントロールの初期化
            dataGridView1.InitControl();
        }

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

            string query = string.Format("SELECT " +
                                            "USER_ID as 'ユーザID', " +
                                            "USER_NAME as 'ユーザ名', " +
                                            "COMPANY_ABBREVIATION as '所属会社' " +
                                         "FROM " +
                                            "USER_MASTER " +
                                         "LEFT OUTER JOIN " +
                                            "COMPANY_MASTER " +
                                         "ON " +
                                            "USER_MASTER.COMPANY_ID = COMPANY_MASTER.COMPANY_ID " +
                                         "WHERE " +
                                            "USER_NAME LIKE '%{0}%'" +
                                            "AND USER_MASTER.COMPANY_ID = '{1}'",
                                            textUser.Text,cmbCompany.SelectedValue);

            dataGridView1.Table = dba.execSQL(query);

            InitGridView();

            SearchBoxEnable(false);

        }

        /// <summary>
        /// クリアボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            SearchBoxClear();
            dataGridView1.Table.Clear();

            InitGridView();

            SearchBoxEnable(true);
        }

        /// <summary>
        /// 反映ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                ApplyBtnCheckes();
            }
            catch(InputException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            // 反映開始
            applyFunc(dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString());

            this.Close();
        }

        #endregion

        #region チェックメソッド

        /// <summary>
        /// 検索ボタンを押下した際のチェック
        /// </summary>
        private void SearchInputChecks()
        {
            
            if(cmbCompany.SelectedIndex <= COMPANY_EMPTY)
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
            if ( dataGridView1.SelectedCells == null )
                throw new InputException(GlobalDefine.ERROR_CODE[16].message, GlobalDefine.ERROR_CODE[16].code);
        }
        #endregion


        /// <summary>
        /// 検索条件フィールドの有効/無効化
        /// </summary>
        /// <param name="flag"></param>
        private void SearchBoxEnable(bool flag)
        {
            textUser.Enabled = flag;
            cmbCompany.Enabled = flag;
            btnSearch.Enabled = flag;
            btnApply.Enabled = !(flag);
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
