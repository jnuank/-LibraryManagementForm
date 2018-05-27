using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCCM01.dataset;

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
            COMPANY_ID,
            USER_MAILADDRESS,
            RETIREMENT_FLAG,
            MODIFY_FLAG,
        }

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
//            dataGridView.DataSource = dataSource;
        }

        /// <summary>
        /// コントロールの初期化
        /// </summary>
        public void InitControl()
        {
            dataGridView.InitControl();
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

        /// <summary>
        /// ユーザコントロールのサイズにDataGridViewを合わせる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserDataGridView_Resize(object sender, EventArgs e)
        {
            dataGridView.Height = this.Height-10;
            dataGridView.Width  = this.Width-10;
        }

        // ソートイベントが発生した時に、呼ぶ
        private void dataGridView_Sorted(object sender, EventArgs e)
        {
            MessageBox.Show("test");
        }
    }
}
    