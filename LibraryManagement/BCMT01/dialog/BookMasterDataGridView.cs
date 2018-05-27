using System.Windows.Forms;
using Common.control;
using BCMT01.dataset;
using System.Data;

namespace BCMT01.dialog
{
    public partial class BookMasterDataGridView : UserControl
    {
        // 独自イベント
        public delegate void CellDubleClickHandler(object sender, DataGridViewCellEventArgs e);
        public event CellDubleClickHandler CellDubleClick;



        /// <summary>
        /// データグリッドビューにバインドさせるデータソース
        /// </summary>
        BindingSource binding = new BindingSource();

        /// <summary>
        /// データグリッドビューにバインドさせるデータテーブル
        /// </summary>
        BookMaster.ViewTableDataTable source = new BookMaster.ViewTableDataTable();

        public BookMasterDataGridView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// データグリッドビューに表示するカラム
        /// </summary>
        public enum COLUMNS
        {
            BOOK_ID,
            BOOK_NAME,
            DIVISION_NAME1,
            DIVISION_NAME2,
            DIVISION_NAME3,
            ARRIVAL_USER_NAME,
            ARRIVAL_DATE,
        }

        private string[] columnName =
        {
            "書籍ID",
            "書籍名",
            "カテゴリ1",
            "カテゴリ2",
            "カテゴリ3",
            "入荷ユーザ",
            "入荷日",
        };

        /// <summary>
        /// データソースを設定する
        /// </summary>
        /// <param name="dataSource"></param>
        public void SetDataSource(BookMaster.ViewTableDataTable dataSource)
        {
            this.source = dataSource;

            binding.DataSource = this.source;
            binding.DataMember = string.Empty;

            dtGridView.DataSource = binding;

            binding.ResetBindings(false);
        }

        private void InitHeaderText()
        {
            for(int index = 0; index < columnName.Length; index++)
            {
                dtGridView.Columns[index].HeaderText = columnName[index];
            }
        }

        public void InitControl()
        {
            dtGridView.InitControl();

            InitHeaderText();
        }

        public void Clear()
        {
            binding.Clear();
        }

        /// <summary>
        /// 選択した行を返す
        /// </summary>
        /// <returns></returns>
        public DataGridViewRow SelectedRow()
        {
            return dtGridView.CurrentRow;
        }


        private void BookMasterDataGridView_Resize(object sender, System.EventArgs e)
        {
            dtGridView.Height = this.Height;
            dtGridView.Width  = this.Width;
        }


        /// <summary>
        /// データグリッドビューのセルをダブルクリックした時に実行される
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // UserControlで定義したCellDoubleClickを呼び出す
            this.CellDubleClick(sender, e);
        }
    }
}
