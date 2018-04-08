using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.define
{
    public enum COLUMNS
    {
        ID,
        NAME,
        ABBREVIATION,
    }

    public enum MODE
    {
        ADD,
        MOD,
        DEL,
    }

    public class ErrorCodes
    {
        public int code;
        public string message;
    }

    static public class GlobalDefine
    {
        public static readonly string DB_NAME               = @"..\..\..\Library.db";   // 相対パスで指定
        public static readonly string FORM_NAME             = "図書管理システム";
        public static readonly string COMPANY_ID            = "会社ID";
        public static readonly string COMPANY_NAME          = "会社名";
        public static readonly string COMPANY_ABBREVIATION  = "会社略称";
        public static readonly string USER_ID               = "ユーザID";
        public static readonly string USER_NAME             = "ユーザ名";
        public static readonly string MEMBER_COMPANY        = "所属会社";
        public static readonly string MAIL                  = "メールアドレス";
        public static readonly string RETREMENT             = "退職有無";
        public static readonly string DIVISION_ID           = "ID";
        public static readonly string DIVISION_NAME         = "分類名";
        public static readonly string BOOK_ID               = "ID";
        public static readonly string BOOK_NAME             = "タイトル";
        public static readonly string DIVISION_ID1          = "分類1";
        public static readonly string DIVISION_ID2          = "分類2";
        public static readonly string DIVISION_ID3          = "分類3";
        public static readonly string CATEGORY_DISPLAY      = "DIVISION_NAME";
        public static readonly string CATEGORY_VALUE        = "DIVISION_ID";
        public static readonly string CAUTION               = "警告";
        public static readonly string ARRIVAL_USER          = "入荷者";
        public static readonly string ARRIVAL_DATE          = "入荷日";
        public static readonly string BOOK_MASTER           = "BOOK_MASTER";




        #region メッセージ   

        public static readonly string MESSAGE_ASK_REGISTRATION            = "登録します。よろしいですか？";
        public static readonly string MESSAGE_ASK_UPDATE                  = "更新します。よろしいですか？";
        public static readonly string MESSAGE_COMPLETE_REGISTRATION       = "登録しました";
        public static readonly string MESSAGE_COMPLETE_UPDATE             = "更新しました";
        public static readonly string MESSAGE_NOT_CHANGE_UPDATE           = "更新する項目がありません";
        public static readonly string MESSAGE_ASK_CLOSE                   = "画面を終了してよろしいですか？";
        public static readonly string MESSAGE_ASK_CLOSE_CHANGE            = "変更内容が破棄されますが、画面を終了してよろいですか？";
        public static readonly string MESSAGE_ASK_DELETE                  = "削除します。よろしいですか？";
        public static readonly string MESSAGE_ASK_DELETE_CHANGE           = "削除します。よろしいですか？\r\n※変更された内容は反映されません";
        public static readonly string MESSAGE_COMPLETE_DELETE             = "削除しました";
        public static readonly string MESSAGE_PASSWORD_UPDATE             = "パスワードを変更します。\r\nよろしいですか？";
        public static readonly string MESSAGE_PASSWORD_CHANGE             = "パスワードを変更しました";
        public static readonly string MESSAGE_ASK_LENDING                 = "貸出してよろしいですか？";
        public static readonly string MESSAGE_ASK_RETURN                  = "返却してよろしいですか？";
        public static readonly string MESSAGE_ADMIN_MODE_ENABLE           = "管理者メニューを有効にしました";

        #endregion

        // エラーメッセージList
        public static readonly List<ErrorCodes> ERROR_CODE = new List<ErrorCodes>()
        {
            new ErrorCodes {code = 0, message ="シングルクォーテーションは入力できません"},
            new ErrorCodes {code = 1, message ="会社名を入力して下さい"},
            new ErrorCodes {code = 2, message ="会社略称を入力して下さい"},
            new ErrorCodes {code = 3, message ="既に登録されています"},
            new ErrorCodes {code = 4, message ="所属しているユーザが一人以上いるため削除できません"},
            new ErrorCodes {code = 5, message ="検索条件に一致するユーザが存在しませんでした。"},
            new ErrorCodes {code = 6, message ="編集する分類を選択してください。" },
            new ErrorCodes {code = 7, message ="管理者パスワードは必須入力です。"},
            new ErrorCodes {code = 8, message ="パスワードが間違っています。\n\r※大文字と小文字は区別されます。"},
            new ErrorCodes {code = 9, message ="「新しいパスワード」と「新しいパスワード(確認用)」の値が異なっています"},
            new ErrorCodes {code = 10, message = "検索条件が設定されていません。" },
            new ErrorCodes {code = 11, message = "入力された書籍IDは書籍マスタに存在しませんでした。" },
            new ErrorCodes {code = 12, message = "入力された書籍は現在貸出中です。" },
            new ErrorCodes {code = 13, message = "書籍IDは必須入力です。" },
            new ErrorCodes {code = 14, message = "検索条件に一致するユーザがユーザマスタに存在しませんでした。" },
            new ErrorCodes {code = 15, message = "所属会社は必須項目です。所属会社を選択してください。" },
            new ErrorCodes {code = 16, message = "反映させるユーザを選択してください。" },
            new ErrorCodes {code = 17, message = "ユーザ名は必須入力です。ユーザ検索よりユーザを選択してください。" },
            new ErrorCodes {code = 18, message = "返却予定日は必須入力です。" },
            new ErrorCodes {code = 19, message = "返却予定日には貸出日付よりも前の日付を入力することは出来ません" },
            new ErrorCodes {code = 20, message = "入力された書籍は現在貸出ししていません。" },
            new ErrorCodes {code = 21, message = "貸出日(開始)と貸出日(終了)が不正です。\r\n貸出日(開始)には貸出日(終了)よりも以前の日付を入力してください。" },
            new ErrorCodes {code = 22, message = "出力するデータが存在しません" },
            new ErrorCodes {code = 23, message = "タイトルを入力して下さい" },
            new ErrorCodes {code = 24, message = "ユーザ名を入力して下さい" },
            new ErrorCodes {code = 25, message = "メールアドレスを入力して下さい"},
            new ErrorCodes {code = 26, message = "所属会社を選択してください" },
        };
    }
}
