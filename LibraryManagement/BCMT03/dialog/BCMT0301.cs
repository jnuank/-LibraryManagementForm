using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCMT03.src;
using Common.dialog;
using Common.define;
using Common.singleton;

namespace BCMT03.dialog
{
    /// <summary>
    /// 会社マスタメンテナンス画面
    /// </summary>
    public partial class BCMT0301 : BaseForm
    {
        #region フィールド

        // メンバーリスト保持コンテナ
        private DataTable dataTable = new DataTable();

        #endregion

        /// <summary>
        /// 会社メンテナンス画面のコンスタラクタ
        /// </summary>
        public BCMT0301()
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
            this.Text = GlobalDefine.FORM_NAME;

            this.dataTable = SingletonObject.GetMemberList();
        }

        /// <summary>
        /// DataGridView初期化
        /// </summary>
        private void InitGridView()
        {

            //データソースを設定する
            dataTable = src.db.Company.GetAllData();
            dataGridView1.DataSource = dataTable;

            dataGridView1.InitControl();

            // 会社IDセル
            dataGridView1.Columns[(int)COLUMNS.ID].HeaderText = GlobalDefine.COMPANY_ID;
            dataGridView1.Columns[(int)COLUMNS.ID].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[(int)COLUMNS.ID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            // 会社名
            dataGridView1.Columns[(int)COLUMNS.NAME].HeaderText = GlobalDefine.COMPANY_NAME;

            // 会社略称
            dataGridView1.Columns[(int)COLUMNS.ABBREVIATION].HeaderText = GlobalDefine.COMPANY_ABBREVIATION;
        }

        // 新規作成ボタン
        private void btnNew_Click(object sender, EventArgs e)
        {
            BCMT0302 newWindow = new BCMT0302();
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

            // 編集画面にデータを渡し、開く
            BCMT0302 dlg = new BCMT0302(row);
            dlg.ShowDialog();

            // 画面更新
            InitGridView();
        }

        // 閉じるボタン
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // フォームのクロージング確認処理
        private void BCMT0301_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( base.CloseFunction(GlobalDefine.MESSAGE_ASK_CLOSE) )
                e.Cancel = true;
        }
    }
}
