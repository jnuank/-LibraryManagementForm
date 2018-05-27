using System;
using System.Data;
using System.Windows.Forms;
using Common.singleton;

namespace Common.control
{
    /// <summary>
    /// DataGridViewコントロールのカスタムコントロール
    /// </summary>
    public class DataGridViewCustom : DataGridView
    {
        #region フィールド

        public DataTable Table { get; set; }

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DataGridViewCustom()
        {
            //this.Table = SingletonObject.GetMemberList();
            this.InitControl();
            this.InitDataSource();
        }

        #region メソッド

        /// <summary>
        /// コントロールの初期化処理
        /// </summary>
        public void InitControl()
        {
            // DataGridViewにデータが表示されていなければ、タブフォーカスさせない。
            // TabStop = false … タブでフォーカスさせない。
            this.TabStop = (this.RowCount > 0) ? true : false;

            // DataGridView内でセル移動無効
            this.StandardTab = true;

            // 編集不可に設定
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.ReadOnly = true;

            // 列サイズを表示領域いっぱいに伸ばす
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 一行選択モード
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
        }

        /// <summary>
        /// データソースの設定
        /// </summary>
        public void InitDataSource()
        {
//            this.DataSource = this.Table;
        }

        #endregion

        #region イベント

        /// <summary>
        /// CellDoubleClickイベント Override
        /// </summary>
        /// <param name="e"></param>
        protected override void OnCellDoubleClick(DataGridViewCellEventArgs e)
        {
            // 選択された行を取得
            int nTarget = e.RowIndex;

            // -1以下は配列インデックス外なのでreturnする
            if ( nTarget < 0 )
                return;

            // 登録されているイベントを実施
            base.OnCellDoubleClick(e);
        }

        /// <summary>
        /// ソート時イベント
        /// </summary>
        /// <param name="e"></param>
        //protected override void OnSorted(EventArgs e)
        //{
        //    //DataView dv = this.Table.DefaultView;
        //    //this.Table = dv.ToTable();

        //    // 登録されているイベントを実施
        //    base.OnSorted(e);
            
        //}

        #endregion
    }
}
