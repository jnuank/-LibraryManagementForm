using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCSR01.dataset;

namespace BCSR01.dialog
{
    public partial class BookLendingGridView : UserControl
    {
        // セルダブルクリックイベント
        public delegate void CellDubleClickHandler(object sender, DataGridViewCellEventArgs e);

        /// <summary>
        /// データグリッドビュー内のセルがクリックされた時に発生するイベント
        /// </summary>
        public event CellDubleClickHandler CellDubleClick;

        /// <summary>
        /// データグリッドビューにバインドさせるデータソース
        /// </summary>
        BindingSource binding = new BindingSource();

        /// <summary>
        /// データグリッドビューにバインドさせるデータテーブル
        /// </summary>
        BookLending.ViewDataTable source = new BookLending.ViewDataTable();

        private string[] columnName =
        {
            "書籍ID",
            "書籍名",
            "カテゴリ1",
            "カテゴリ2",
            "カテゴリ3",
            "貸出状態",
            "返却日",
        };

        public BookLendingGridView()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 検索結果をデータグリッドビューに表示する
        /// </summary>
        /// <param name="dataSource"></param>
        public void ShowSearchResult(BookLending.ViewDataTable dataSource)
        {
            this.source = dataSource;

            binding.DataSource = this.source;
            binding.DataMember = string.Empty;

            dtGridView.DataSource = binding;
            binding.ResetBindings(false);
        }

        private void InitHeaderText()
        {
            for(int index=0; index < columnName.Length; index++)
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
            source.Clear();
            binding.ResetBindings(false);

        }

        /// <summary>
        /// 選択した行を返す
        /// </summary>
        /// <returns></returns>
        public DataGridViewRow SelectedRow()
        {
            return dtGridView.CurrentRow;
        }

        /// <summary>
        /// リサイズイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BookLendingGridView_Resize(object sender, EventArgs e)
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
