using BCMT01.dataset;
using Common.db;
using Common.define;
using Common.dialog;
using Common.ErrorCheck;
using Common.singleton;
using System;
using System.Data;
using System.Windows.Forms;

namespace BCMT01.dialog
{
    public partial class BCMT0101 : BaseForm
    {
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
            dtGridView.InitControl();
        }

        #region イベント

        /// <summary>
        /// セルダブルクリックのイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtGridView_CellDubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 選択された行を取得
            int nTarget = e.RowIndex;

            // 選択された行を取得
            DataGridViewRow row = dtGridView.SelectedRow();

            // 編集画面にデータを渡し、開く
            BCMT0102 dlg = new BCMT0102(row);
            dlg.ShowDialog();

            // 画面更新
            InitGridView();
        }


        /// <summary>
        /// 検索ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ErrorChecks();

            string query = string.Format(Properties.Resources.SelectBCMT0101, txtId.Text, txtTitle.Text);

            if (cmbCategory1.SelectedValue.ToString() != "")
                query += string.Format(Properties.Resources.SelectBCMT0101_category1, cmbCategory1.SelectedValue.ToString());

            if (cmbCategory2.SelectedValue.ToString() != "")
                query += string.Format(Properties.Resources.SelectBCMT0101_category2, cmbCategory2.SelectedValue.ToString());

            if (cmbCategory3.SelectedValue.ToString() != "")
                query += string.Format(Properties.Resources.SelectBCMT0101_category3, cmbCategory3.SelectedValue.ToString());

            var dba = SingletonObject.GetDbAdapter();

            var table = dba.ExecSQL<BookMaster.ViewTableDataTable>(query);

            dtGridView.SetDataSource(table);

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
            DataGridViewRow row = dtGridView.SelectedRow();

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
    }
}
