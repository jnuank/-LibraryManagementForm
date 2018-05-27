using System;
using System.Windows.Forms;

namespace Common.control
{
    public abstract partial class BaseDataGridView : UserControl
    {
        public BaseDataGridView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// コントロールの初期化
        /// </summary>
        abstract public void InitControl();

        /// <summary>
        /// 一覧の初期化
        /// </summary>
        abstract public void Clear();

        /// <summary>
        /// リサイズイベントが起きたら、
        /// ユーザコントロールのサイズにDataGridViewのサイズを合わせる
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            dtGridView.Height = this.Height;
            dtGridView.Width  = this.Width;

            base.OnResize(e);
        }
    }
}
