using Common.control;
using Common.define;
using Common.ErrorCheck;
using System.Windows.Forms;

namespace BCMT01.logic
{
    public class BookManagementLogic
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
        /// DataGridView初期化
        /// </summary>
        /// <param name="dataGridView"></param>
        public void InitGridView(DataGridViewCustom dataGridView)
        {
            // データソースの設定をする
            dataGridView.InitDataSource();
            // コントロールの初期化
            dataGridView.InitControl();

            // 書籍IDセル
            dataGridView.Columns[(int)COLUMNS.ID].HeaderText   = GlobalDefine.BOOK_ID;
            dataGridView.Columns[(int)COLUMNS.ID].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            // タイトル
            dataGridView.Columns[(int)COLUMNS.NAME].HeaderText = GlobalDefine.BOOK_NAME;
        }

        /// <summary>
        /// 検索結果一覧をクリアする
        /// </summary>
        /// <param name="dataGridView"></param>
        public void ClearResult(DataGridViewCustom dataGridView)
        {
            dataGridView.Table.Clear();
            this.InitGridView(dataGridView);
        }

        /// <summary>
        /// 検索条件をクリアする
        /// </summary>
        /// <param name="control"></param>
        public void ClearInputBox(Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                if (control.HasChildren)
                    ClearInputBox(control);

                if(control is TextBox)
                {
                    var textBox = control as TextBox;
                    textBox.Clear();
                }
                else if (control is CategoryDropDownList)
                {
                    var cmbBox = control as CategoryDropDownList;
                    cmbBox.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// エラーチェック
        /// </summary>
        /// <param name="txtId"></param>
        /// <param name="txtTitle"></param>
        public void ErrorChecks(TextBox txtId, TextBox txtTitle)
        {
            InputCheck.IsSingleQuotation(txtId);
            InputCheck.IsSingleQuotation(txtTitle);
        }

        /// <summary>
        /// コンボボックスの初期化
        /// </summary>
        /// <param name="cmbCategorys"></param>
        public void InitDialog(params CategoryDropDownList[] cmbCategorys)
        {
            foreach (var item in cmbCategorys)
            {
                item.InitControl();
            }
        }
    }
}
