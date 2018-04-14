using Common.define;
using Common.dialog;
using Common.exception;
using Common.singleton;
using System;
using System.Data;
using System.Windows.Forms;

namespace BCMT02.dialog
{
    /// <summary>
    /// 会社マスタメンテナンス画面
    /// </summary>
    public partial class BCMT0201 : BaseForm
    {
        /// <summary>
        /// カラム用
        /// </summary>
        private enum COLUMNS
        {
            ID,
            NAME,
        }

        #region フィールド

        // メンバーリスト保持コンテナ
        private DataTable dataTable = new DataTable();

        #endregion

        /// <summary>
        /// 会社メンテナンス画面のコンスタラクタ
        /// </summary>
        public BCMT0201()
        {
            InitializeComponent();
            InitDialog();
            InitGridView();
        }

        /// <summary>
        /// ダイアログ初期化
        /// </summary>
        private void InitDialog()
        {
            this.Text      = GlobalDefine.FORM_NAME;
            this.dataTable = SingletonObject.GetMemberList();
        }

        /// <summary>
        /// DataGridView初期化
        /// </summary>
        private void InitGridView()
        {
            //データソースを設定する
            dataTable = src.db.Category.GetAllData();
            dataGridView1.DataSource = dataTable;

            dataGridView1.InitControl();

            // 分類IDセル
            dataGridView1.Columns[(int)COLUMNS.ID].HeaderText                 = GlobalDefine.DIVISION_ID;
            dataGridView1.Columns[(int)COLUMNS.ID].AutoSizeMode               = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[(int)COLUMNS.ID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 分類名称
            dataGridView1.Columns[(int)COLUMNS.NAME].HeaderText = GlobalDefine.DIVISION_NAME;
        }


        #region イベント

        // 新規作成ボタン
        private void btnNew_Click(object sender, EventArgs e)
        {
            BCMT0202 newWindow = new BCMT0202();
            newWindow.ShowDialog();

            // 画面更新
            InitGridView();
        }

        // ダブルクリック
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 選択された行を取得
            int nTarget = e.RowIndex;

            // 選択された行を取得
            DataRow row = dataTable.Rows[nTarget];

            if ( row == null )
                throw new InputException(GlobalDefine.ERROR_CODE[6].message, GlobalDefine.ERROR_CODE[6].code);

            // 編集画面にデータを渡し、開く
            BCMT0202 dlg = new BCMT0202(row);
            dlg.ShowDialog();

            // 画面更新
            InitGridView();
        }

        // 閉じるボタン
        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        // フォームのクロージング確認処理
        private void BCMT0301_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = base.IsCancelClosing();
        }
        #endregion
    }
}
