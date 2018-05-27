using Common.singleton;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Properties;

namespace Common.db
{
    public class DbQuery
    {
        DBAdapter dba = SingletonObject.GetDbAdapter();

        /// <summary>
        /// 管理者パスワードが合っているかどうかDBに問い合わせを行う
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsAdminPassword(string password)
        {
            string query = string.Format(Properties.Resources.SelectPassword, password);
            return dba.FindRecord(query);
        }

        /// <summary>
        /// 書籍管理画面の一覧を検索する
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="selectedValue1"></param>
        /// <param name="selectedValue2"></param>
        /// <param name="selectedValue3"></param>
        /// <returns></returns>
        public DataTable SelectManagedBooks(string id, string title, string selectedValue1 = "", string selectedValue2 = "", string selectedValue3 = "")
        {
            string query = string.Format(Properties.Resources.SelectBCMT0101, id, title);
            if(selectedValue1 != "")
            {
                query += string.Format(Properties.Resources.SelectBCMT0101_category1, selectedValue1);
            }

            if (selectedValue2 != "")
            {
                query += string.Format(Properties.Resources.SelectBCMT0101_category2, selectedValue2);
            }

            if (selectedValue3 != "")
            {
                query += string.Format(Properties.Resources.SelectBCMT0101_category3, selectedValue3);
            }

            return dba.ExecSQL(query);

        }

        /// <summary>
        /// 書籍マスタにデータを登録する
        /// </summary>
        /// <param name="newId"></param>
        /// <param name="title"></param>
        /// <param name="userId"></param>
        /// <param name="dateArrival"></param>
        /// <param name="selectedValue1"></param>
        /// <param name="selectedValue2"></param>
        /// <param name="selectedValue3"></param>
        public void InsertBookMaster(string newId, string title, string userId, DateTime dateArrival, string selectedValue1, string selectedValue2, string selectedValue3)
        {
            string query = string.Format(Properties.Resources.InsertBookMaster,
                                         newId,
                                         title,
                                         userId,
                                         dateArrival.ToString("yyyy-MM-dd"),
                                         selectedValue1,
                                         selectedValue2,
                                         selectedValue3
                                         );

            dba.nonExecSQL(query);
        }

        /// <summary>
        /// 書籍ステータステーブルにデータ登録する
        /// </summary>
        /// <param name="newIdText"></param>
        public void InsertBookStatus(string newIdText)
        {
            string query = string.Format(Properties.Resources.InsertBookStatus,
                                        newIdText);
            dba.nonExecSQL(query);

        }

        /// <summary>
        /// 書籍マスタを更新する（book_idが条件）
        /// </summary>
        /// <param name="title"></param>
        /// <param name="userId"></param>
        /// <param name="dateArrival"></param>
        /// <param name="selectedValue1"></param>
        /// <param name="selectedValue2"></param>
        /// <param name="selectedValue3"></param>
        /// <param name="bookId"></param>
        public void UpdateBookMaster(string title, string userId, DateTime dateArrival, string selectedValue1, string selectedValue2, string selectedValue3, string bookId)
        {
            string query = string.Format(Properties.Resources.UpdateBookMaster,
                                        title,
                                        userId,
                                        dateArrival.ToString("yyyy-MM-dd"),
                                        selectedValue1,
                                        selectedValue2,
                                        selectedValue3,
                                        bookId
                                        );
            dba.nonExecSQL(query);

        }

        /// <summary>
        /// 書籍の削除（書籍ステータスマスタのステータスを削除済みにする）
        /// </summary>
        /// <param name="bookId"></param>
        public void DeleteBook(string bookId)
        {
            string query = string.Format(Properties.Resources.DeleteBook, bookId);

            dba.nonExecSQL(query);
        }

        /// <summary>
        /// 分類IDの取得
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public string[] SelectGenreId(string categoryName)
        {
            string query = string.Format(Resources.SelectGenreId, categoryName);

            return dba.GetRecord(query);
        }

        /// <summary>
        /// ユーザIDの取得
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string[] SelectUserId(string userName)
        {
            string query = string.Format(Resources.SelectUserId, userName);

            return dba.GetRecord(query);
        }
    }
}