using BCMT01.logic;
using Common.db;
using Common.define;
using Common.dialog;
using Common.singleton;
using System;
using System.Data;
using System.Windows.Forms;

namespace BCMT01.dialog
{
    public partial class BCMT0101 : BaseForm
    {
        private BookManagementLogic logic = new BookManagementLogic();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BCMT0101()
        {
            InitializeComponent();
            logic.InitDialog(cmbCategory1,cmbCategory2,cmbCategory3);
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

            logic.ErrorChecks(this.txtId, this.txtTitle);

            dataGridView1.Table = dc.SelectManagedBooks(this.txtId.Text, 
                                                        this.txtTitle.Text,
                                                        cmbCategory1.SelectedValue.ToString(),
                                                        cmbCategory2.SelectedValue.ToString(),
                                                        cmbCategory3.SelectedValue.ToString());

            // データグリッドビューの更新
            logic.InitGridView(this.dataGridView1);
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
            logic.ClearResult(this.dataGridView1);
            logic.ClearInputBox(this);
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
            e.Cancel = base.IsCancelClosing(GlobalDefine.MESSAGE_ASK_CLOSE);
        }

        /// <summary>
        /// グリッドビュー、セルダブルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 選択された行を取得
            DataRow row = dataGridView1.Table.Rows[e.RowIndex];

            // 編集画面にデータを渡し、開く
            BCMT0102 dlg = new BCMT0102(row);
            dlg.ShowDialog();

            // 画面更新
            logic.InitGridView(this.dataGridView1);
        }
        #endregion

    }
}
