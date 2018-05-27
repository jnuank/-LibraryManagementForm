using BCCM01.dataset;
using System;
using System.Windows.Forms;
using Common.control;

namespace BCCM01.dialog
{
    public partial class UserDataGridView : UserControl
    {
        /// <summary>
        /// データグリッドビューにバインドさせるデータソース
        /// </summary>
        BindingSource binding = new BindingSource();

        /// <summary>
        /// データグリッドビューにバインドさせるデータテーブル
        /// </summary>
        UserDataSet.ViewUserMasterDataTable dataSource = new UserDataSet.ViewUserMasterDataTable();

        public UserDataGridView()
        {
            InitializeComponent();
            ResetBindingSource();
        }

        enum Column
        {
            USER_ID,
            USER_NAME,
            COMPANY_ABBREVIATION,
        }

        private string[] columnName =
        {
            "ユーザID",
            "ユーザ名",
            "会社略称",
        };
        /// <summary>
        /// データソースの設定
        /// </summary>
        /// <param name="dataSource"></param>
        public void SetDataSource(UserDataSet.ViewUserMasterDataTable dataSource)
        {
            this.dataSource = dataSource;

            binding.DataSource = this.dataSource;
            binding.DataMember = string.Empty;

            dataGridView.DataSource = binding;
            binding.ResetBindings(false);
        }

        /// <summary>
        /// コントロールの初期化
        /// </summary>
        public void InitControl()
        {
            dataGridView.InitControl();

            InitHeaderText();
        }

        /// <summary>
        /// カラム名を変更する
        /// </summary>
        public void InitHeaderText()
        {
            for(int index = 0; index < columnName.Length; index++)
            {
                dataGridView.Columns[index].HeaderText = columnName[index];
            }
        }

        /// <summary>
        /// データソースをクリアする
        /// </summary>
        public void Clear()
        {
            dataSource.Clear();
        }

        /// <summary>
        /// 選択中のセルが表の中にあるのか
        /// </summary>
        /// <returns></returns>
        public bool IsValidSelectedCells()
        {
            return dataGridView.SelectedCells != null;
        }

        public string SelectedUserId()
        {
            return dataGridView.CurrentRow.Cells[(int)Column.USER_ID].Value.ToString();
        }

        public string SelectedUserName()
        {
            return dataGridView.CurrentRow.Cells[(int)Column.USER_NAME].Value.ToString();
        }

        /// <summary>
        /// バインドしたデータをリセットする
        /// </summary>
        private void ResetBindingSource()
        {
            dataGridView.DataSource = binding;
            binding.ResetBindings(false);
        }

        // ソートイベントが発生した時に、呼ぶ
        private void dataGridView_Sorted(object sender, EventArgs e)
        {
            MessageBox.Show("test");
        }

        private void UserDataGridView_Resize(object sender, EventArgs e)
        {
            dataGridView.Height = this.Height;
            dataGridView.Width  = this.Width;
        }
    }
}
    