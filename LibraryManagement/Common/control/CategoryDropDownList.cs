using System.Windows.Forms;
using Common.singleton;
using Common.db;
using Common.define;
using System.Data;

namespace Common.control
{
    /// <summary>
    /// カテゴリードロップダウンリスト
    /// </summary>
    public class CategoryDropDownList : ComboBox
    {
        public CategoryDropDownList()
        {
           // コンストラクタでクエリ流そうとすると、デザイナー上で貼り付けるとエラー起きる
           //InitControl();
        }

        /// <summary>
        /// コントロール初期化
        /// </summary>
        public void InitControl()
        {
            // ドロップダウンリストに設定
            this.DropDownStyle = ComboBoxStyle.DropDownList;

            DBAdapter dba = SingletonObject.GetDbAdapter();

            string query = "SELECT * FROM BOOK_GENRE_MASTER";

            DataTable dt1 = dba.ExecSQL(query);
            DataRow dr = dt1.NewRow();
            dr["DIVISION_ID"] = "";
            dr["DIVISION_NAME"] = "";
            dt1.Rows.InsertAt(dr, 0);

            this.DataSource = dt1;

            this.DisplayMember = GlobalDefine.CATEGORY_DISPLAY;
            this.ValueMember   = GlobalDefine.CATEGORY_VALUE;
            
        }
    }
}
