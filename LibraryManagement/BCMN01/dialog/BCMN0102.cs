using Common.db;
using Common.define;
using Common.exception;
using Common.singleton;
using System;
using System.Windows.Forms;
using Common.Properties;
using BCMN01.ViewModel;

namespace BCMN01.dialog
{
    /// <summary>
    /// 管理者パスワード入力画面
    /// </summary>
    public partial class BCMN0102 : Form
    {
        private BCMN0102ViewModel viewModel = new BCMN0102ViewModel();

        // 引数なしのデリゲート変数を用意する（オーナーウィンドウ側の操作用）
        public delegate void DelegateFunc();
        public DelegateFunc menuEnable;

        public BCMN0102(Action action)
        {
            InitializeComponent();
            txtPass.DataBindings.Add("Text", viewModel, "Password");
            btnApply.DataBindings.Add("Enabled", viewModel, "ApplyEnable");
            btnClear.DataBindings.Add("Enabled", viewModel, "ClearEnable");

            btnApply.Click += viewModel.ApplyButton_Click;
            //btnApply.Click += this.btnApply_Click;

            viewModel.MenuEnableAction = action;

            viewModel.PropertyChanged += (sender, e) =>
            {
                if(e.PropertyName == "Message")
                {
                    MessageBox.Show(viewModel.Message);
                }
            };

        }

        #region メソッド

        /// <summary>
        /// チェックボックスに入力されているのが、nullか空文字だったらtrueを返す
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool CheckTextBox(string text)
        {
            return string.IsNullOrEmpty(text);
        }
        

        #endregion

        #region イベント
        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// クリアボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            viewModel.Password = string.Empty;
            
        }
        #endregion
    }
}
