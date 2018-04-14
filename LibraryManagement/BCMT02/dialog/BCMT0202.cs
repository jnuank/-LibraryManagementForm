using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCMT02.src;
using Common.dialog;
using Common.db;
using Common.define;
using Common.exception;
using Common.singleton;

namespace BCMT02.dialog
{
    /// <summary>
    /// 追加・編集画面クラス
    /// </summary>
    public partial class BCMT0202 : BaseForm
    {
        #region フィールド

        // 分類目
        string tempCategoryName;

        // 追加or編集or削除
        MODE mode;

        #endregion

        /// <summary>
        /// 新規作成用のコンストラクタ
        /// </summary>
        public BCMT0202()
        {
            InitializeComponent();

            // 新規作成モード
            InitDailog(MODE.ADD);
        }

        /// <summary>
        /// 編集画面用のコンストラクタ
        /// </summary>
        /// <param name="row">1行分のデータ</param>
        public BCMT0202(DataRow row)
        {
            InitializeComponent();

            // 更新モード
            InitDailog(MODE.MOD,row);
        }

        /// <summary>
        /// ダイアログの初期化
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="row">オプション引数。Addモードの時は不要にする</param>
        public void InitDailog(MODE mode, DataRow row = null)
        {
            switch ( mode )
            {
                case MODE.ADD:

                    // 削除ボタンをdisable
                    this.btnDelete.Enabled = false;
                    // 新規追加モード
                    this.mode = mode;
                    break;

                case MODE.MOD:

                    // 削除ボタンを
                    this.btnDelete.Enabled = true;
                    // 編集モード
                    this.mode = mode;
                    // rowのnull対策
                    if (row == null )
                    {
                        return;
                    }
                    // テキストボックスに、編集用データ表示
                    this.textId.Text = row.Field<string>("DIVISION_ID");
                    this.textName.Text = row.Field<string>("DIVISION_NAME");

                    break;
            }
            // 編集前データの保存
            BeforeRecordData();

        }

        /// <summary>
        /// 編集前のデータを保存
        /// </summary>
        private void BeforeRecordData()
        {
            this.tempCategoryName = this.textName.Text;
        }

        /// <summary>
        /// 編集前のデータをリストアする
        /// </summary>
        /// <param name="target"></param>
        private void RestoreRecordData(TextBox target)
        {
            if(target.Name.Equals("textName"))
            {
                target.Text = this.tempCategoryName;
            }
        }
        
        #region イベント

        /// <summary>
        /// 閉じるボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            // クローズ時に、FormClosingイベントが呼ばれる
            this.Close();
        }

        /// <summary>
        /// フォームのクロージング処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BCMT0302_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 削除モードの場合は、確認ダイアログ出さずに閉じる
            if(mode == MODE.DEL)
            {
                // do nothing     
            }else // 新規追加、編集モード
            {
                string msg;
                // 画面時に保持した変数と入力された項目を比較して、MessageBoxに表示するメッセージを変更する
                if ( this.textName.Text.Equals(this.tempCategoryName))
                {
                    msg = GlobalDefine.MESSAGE_ASK_CLOSE;
                }
                else
                {
                    msg = GlobalDefine.MESSAGE_ASK_CLOSE_CHANGE;
                }
                if ( base.IsCancelClosing(msg) )
                { e.Cancel = true; }
            }
        }

        /// <summary>
        /// 確定ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            #region チェック
            try
            {
                ErrorCheck();
            }
            catch(InputException ex)
            {
                //処理実行
                MessageBox.Show(ex.Message);
                ex.ERROR_TEXTBOX.Focus();
                // error_code=3はデータをリストアせずに終了
                if ( ex.ERROR_CODE == GlobalDefine.ERROR_CODE[3].code )
                    return;
                // テキストボックス内の文字列を、更新前に戻す
                RestoreRecordData(ex.ERROR_TEXTBOX);

                return;
            }
            #endregion

            // チェックして問題なければ、DBレコード追加or更新
            switch ( this.mode )
            {
                // 新規作成モード
                case MODE.ADD:
                    if ( base.AskMessageBox(GlobalDefine.MESSAGE_ASK_REGISTRATION) )
                    {
                        DBAdapter dba = SingletonObject.GetDbAdapter();

                        int newId;
                        // 新規ID取得(MAX値+1)
                            newId = int.Parse(dba.GetMaxID("DIVISION_ID", "BOOK_GENRE_MASTER")) + 1;
                        // 0埋めして新規ID作成
                        string newIdText = string.Format("{0:D3}", newId);

                        string query = string.Format("INSERT INTO BOOK_GENRE_MASTER VALUES('{0}','{1}')",
                                                    newIdText,
                                                    this.textName.Text);
                                                    
                        // DBにインサート文を投げる
                        dba.nonExecSQL(query);

                        // 完了メッセージを出力
                        MessageBox.Show(GlobalDefine.MESSAGE_COMPLETE_REGISTRATION);

                        // 画面起動時に保持した変数を、現在の画面の値に更新
                        BeforeRecordData();

                        // IDを画面に表示
                        this.textId.Text = newIdText;

                        // 編集モードに変更
                        this.mode = MODE.MOD;

                        // 編集モードでダイアログ作り直す(DataRowデータは渡さない)
                        InitDailog(this.mode);
                    }
                    break;

                // 編集モード
                case MODE.MOD:
                    if ( base.AskMessageBox(GlobalDefine.MESSAGE_ASK_UPDATE) )
                    {
                        DBAdapter dba = SingletonObject.GetDbAdapter();


                        string query = string.Format("UPDATE BOOK_GENRE_MASTER SET DIVISION_NAME='{1}' WHERE DIVISION_ID='{0}'",
                                                    this.textId.Text,
                                                    this.textName.Text);

                        // DBにインサート文を投げる
                        dba.nonExecSQL(query);

                        // 完了メッセージを出力
                        MessageBox.Show(GlobalDefine.MESSAGE_COMPLETE_UPDATE);

                        // 画面起動時に保持した変数を、現在の画面の値に更新
                        BeforeRecordData();
                    }
                    break;
            }

        }


        /// <summary>
        /// 削除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            #region エラーチェック

            try
            {
                DeleteCheck();
            }
            catch ( InputException ex )
            {
                MessageBox.Show(ex.Message);
                return;
            }

            #endregion

            string msg;
            // 画面時に保持した変数と入力された項目を比較して、MessageBoxに表示するメッセージを変更する
            if ( this.textName.Text.Equals(this.tempCategoryName))
            {
                msg = GlobalDefine.MESSAGE_ASK_DELETE;
            }else
            {
                msg = GlobalDefine.MESSAGE_ASK_DELETE_CHANGE;
            }

            // 確認メッセージ表示
            if ( base.AskMessageBox(msg) )
            {   // 削除実行
                DBAdapter dba = SingletonObject.GetDbAdapter();
                string query = string.Format("DELETE FROM BOOK_GENRE_MASTER WHERE DIVISION_ID = '{0}'", this.textId.Text);
                dba.nonExecSQL(query);

                MessageBox.Show(GlobalDefine.MESSAGE_COMPLETE_DELETE);
                // 削除モードに変更(確認dialog出さずに、フォーム閉じる為)
                mode = MODE.DEL;
                this.Close();
            }
            else
            {   // キャンセル
                return;
            }
        }

        #endregion

        /// <summary>
        /// 入力チェック用メソッド
        /// </summary>
        private void ErrorCheck()
        {
            // シングルクォーテーションが入っていたら(会社名)
            if ( this.textName.Text.IndexOf('\'') >= 0 )
                throw new InputException(GlobalDefine.ERROR_CODE[0].message,GlobalDefine.ERROR_CODE[0].code,this.textName);

            // 空文字チェック(会社名)
            if ( string.IsNullOrEmpty(this.textName.Text) )
                throw new InputException(GlobalDefine.ERROR_CODE[1].message, GlobalDefine.ERROR_CODE[1].code, this.textName);

            // 新規追加モードの場合、会社名が登録されているかどうか
            if ( mode == MODE.ADD )
            {
                DBAdapter dba = SingletonObject.GetDbAdapter();
                string str = string.Format("SELECT * FROM BOOK_GENRE_MASTER WHERE DIVISION_NAME = '{0}'", this.textName.Text);
                if ( dba.FindRecord(str) )
                    throw new InputException(GlobalDefine.ERROR_CODE[3].message, GlobalDefine.ERROR_CODE[3].code, this.textName);
            }
        }

        /// <summary>
        /// 削除チェック用のメソッド
        /// </summary>
        private void DeleteCheck()
        {
            DBAdapter dba = SingletonObject.GetDbAdapter();
            string str = string.Format("SELECT * FROM USER_MASTER WHERE COMPANY_ID = '{0}' AND RETIREMENT_FLAG = 0", this.textId.Text);
            if ( dba.FindRecord(str) )
                throw new InputException(GlobalDefine.ERROR_CODE[4].message, GlobalDefine.ERROR_CODE[4].code, this.textId);
        }

    }
}
