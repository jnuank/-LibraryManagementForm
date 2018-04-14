using Common.db;
using Common.define;
using Common.dialog;
using Common.ErrorCheck;
using Common.exception;
using Common.singleton;
using System;
using System.Data;
using System.Windows.Forms;

namespace BCMT01.dialog
{
    public partial class BCMT0101 : BaseForm
    {
        /// <summary>
        /// データグリッドビューに表示するカラム
        /// </summary>
        private enum COLUMNS
        {
            ID,
            NAME,
            DIVISION_ID1,
            DIVISION_ID2,
            DIVISION_ID3,
            ARRIVAL_USER_ID,
            ARRIVAL_DATE,
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BCMT0101()
        {
            InitializeComponent();
            InitDialog();
        }

        /// <summary>
        /// ダイアログ初期化
        /// </summary>
        private void InitDialog()
        {
            DBAdapter dba = SingletonObject.GetDbAdapter();

            cmbCategory1.InitControl();
            cmbCategory2.InitControl();
            cmbCategory3.InitControl();

        }

        /// <summary>
        /// DataGridView初期化
        /// </summary>
        private void InitGridView()
        {
            dataGridView1.InitDataSource();
            dataGridView1.InitControl();

            // 書籍IDセル
            dataGridView1.Columns[(int)COLUMNS.ID].HeaderText   = GlobalDefine.BOOK_ID;
            dataGridView1.Columns[(int)COLUMNS.ID].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            // タイトル
            dataGridView1.Columns[(int)COLUMNS.NAME].HeaderText = GlobalDefine.BOOK_NAME;

        }

        # region イベント

        /// <summary>
        /// 検索ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DbQuery dc = SingletonObject.GetDbQuery();

            // エラーチェック
            //try
            //{
                ErrorChecks();

                dataGridView1.Table = dc.SelectManagedBooks(this.txtId.Text, 
                                                            this.txtTitle.Text,
                                                            cmbCategory1.SelectedValue.ToString(),
                                                            cmbCategory2.SelectedValue.ToString(),
                                                            cmbCategory3.SelectedValue.ToString());

            //}
            //catch ( InputException ex )
            //{
            //    MessageBox.Show(ex.Message);
            //    ex.ERROR_TEXTBOX.Clear();
            //    ex.ERROR_TEXTBOX.Focus();
            //}

            // データグリッドビューの更新
            InitGridView();
        }

        /// <summary>
        /// 新規作成ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            BCMT0102 modFrm = new BCMT0102();
            modFrm.ShowDialog();
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



        /// <summary>
        /// グリッドビュー、セルダブルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 選択された行を取得
            int nTarget = e.RowIndex;

            // 選択された行を取得
            DataRow row = dataGridView1.Table.Rows[nTarget];

            // 編集画面にデータを渡し、開く
            BCMT0102 dlg = new BCMT0102(row);
            dlg.ShowDialog();

            // 画面更新
            InitGridView();
        }
        #endregion

        /// <summary>
        /// 検索結果一覧をクリアする
        /// </summary>
        private void ClearResult()
        {
            dataGridView1.Table.Clear();
            InitGridView();
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

    }
}
