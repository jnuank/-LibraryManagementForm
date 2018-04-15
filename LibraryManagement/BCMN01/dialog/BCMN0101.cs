using BCHT01.dialog;
using BCLN01.dialog;
using BCMT01.dialog;
using BCMT02.dialog;
using BCMT03.dialog;
using BCMT04.dialog;
using BCMT05.dialog;
using BCRT01.dialog;
using BCSR01.dialog;
using Common.define;
using Common.dialog;
using System;
using System.Windows.Forms;


namespace BCMN01.dialog
{
    public partial class BCMN0101 : BaseForm
    {
        public BCMN0101()
        {
            InitializeComponent();
        }

        #region イベント

        /// <summary>
        /// 管理者パスワード入力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAdminPass_Click(object sender, EventArgs e)
        {
            // パスワード入力画面で、正しいパスワードが入力されたら呼ばれる
            BCMN0102 inputPassForm = new BCMN0102(() => menuAdminTools.Enabled = true);
            inputPassForm.ShowDialog();
        }

        /// <summary>
        /// ユーザメンテナンス画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuUserMaintenance_Click(object sender, EventArgs e)
        {
            BCMT0401 userMaintenance = new BCMT0401();
            userMaintenance.ShowDialog();
        }

        /// <summary>
        /// 会社メンテナンス画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuCompanyMaintenance_Click(object sender, EventArgs e)
        {
            BCMT0301 companyMaintenance = new BCMT0301();
            companyMaintenance.ShowDialog();
        }

        /// <summary>
        /// フォームを閉じる時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BCMN0101_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( base.IsCancelClosing(GlobalDefine.MESSAGE_ASK_CLOSE) )
            { e.Cancel = true; }
        }

        /// <summary>
        /// 書籍メンテナンス画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuBookMaintenance_Click(object sender, EventArgs e)
        {
            BCMT0101 bookMaintenance = new BCMT0101();
            bookMaintenance.ShowDialog();
        }

        /// <summary>
        /// 分類メンテナンス画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuCategoryMaintenance_Click(object sender, EventArgs e)
        {
            BCMT0201 categoryMaintenance = new BCMT0201();
            categoryMaintenance.ShowDialog();
        }

        /// <summary>
        /// 管理者パスワードメンテナンス画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAdminMaintenance_Click(object sender, EventArgs e)
        {
            BCMT0501 adminMaintenace = new BCMT0501();
            adminMaintenace.ShowDialog();
        }

        /// <summary>
        /// 図書検索画面ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBookSearch_Click(object sender, EventArgs e)
        {
            BCSR0101 bookSearchForm = new BCSR0101();
            bookSearchForm.ShowDialog();
        }

        /// <summary>
        /// 貸出画面ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLend_Click(object sender, EventArgs e)
        {
            BCLN0101 loanForm = new BCLN0101();
            loanForm.ShowDialog();
        }

        /// <summary>
        /// 返却画面ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetBack_Click(object sender, EventArgs e)
        {
            BCRT0101 returnForm = new BCRT0101();
            returnForm.ShowDialog();
        }

        /// <summary>
        /// 貸出履歴画面ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistory_Click(object sender, EventArgs e)
        {
            BCHT0101 historyForm = new BCHT0101();
            historyForm.ShowDialog();
        }
        #endregion

    }
}
