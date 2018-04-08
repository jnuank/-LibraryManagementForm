using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace Common.db
{
    /// <summary>
    /// データベース接続を行うアダプタークラス
    /// </summary>
    public class DBAdapter
    {
        // DBファイル名定義
        private string db_file = define.GlobalDefine.DB_NAME;
        
        /// <summary>
        /// テーブル一覧取得
        /// </summary>
        /// <returns></returns>
        public List<string> GetTableList()
        {
            // 戻り値格納リスト
            List<string> retList = new List<string>();
 
            // 接続開始
            using ( SQLiteConnection connection = new SQLiteConnection("Data Source=" + db_file) )
            {
                using ( SQLiteCommand command = connection.CreateCommand() )
                {
                    try
                    {
                        connection.Open();

                        // トランザクション開始
                        command.Transaction = connection.BeginTransaction();

                        // "sqlite_master"：sqlite.dbにおけるテーブル・ビューを管理者。
                        // type="table"でテーブル一覧を取得する
                        command.CommandText = "SELECT * FROM sqlite_master WHERE type='table'";

                        using ( SQLiteDataReader reader = command.ExecuteReader() )
                        {
                            while ( reader.Read() )
                            {
                                retList.Add(reader["tbl_name"].ToString());
                            }
                        }

                    }
                    catch ( SQLiteException sqlEx)
                    {
                        System.Diagnostics.Debug.WriteLine(sqlEx.Message);
                        command.Transaction.Rollback();
                    
                    }
                    catch ( Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                        command.Transaction.Rollback();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return retList;
        }

        /// <summary>
        /// 引数で受け取ったクエリをDataTableに入れて返すメソッド
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable execSQL(String query)
        {
            DataTable dt = new DataTable();

            // DBコネクション設定
            using ( SQLiteConnection connecion = new SQLiteConnection("Data Source=" + db_file) )
            {
                // DataTableに設定する為、SQLiteDataAdapterを使用する
                using ( SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connecion) )
                {
                    // Open/Closeはこの関数が自動的にやってくれる為、記述不要
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        /// <summary>
        /// 返り値を持たないクエリ
        /// </summary>
        /// <param name="query"></param>
        public void nonExecSQL(string query)
        {
            using ( SQLiteConnection connection = new SQLiteConnection("Data Source=" + db_file) )
            {
                connection.Open();
                
                // DBに対するコマンドを用意します
                using ( SQLiteCommand command = connection.CreateCommand() )
                {
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        /// <summary>
        /// レコードの検索
        /// </summary>
        /// <param name="query">検索するクエリ文</param>
        /// <returns></returns>
        public bool FindRecord(string query)
        {
            bool isExist = false;
            // DBコネクション設定
            using ( SQLiteConnection connection = new SQLiteConnection("Data Source=" + db_file) )
            {
                connection.Open();
                // DBに対するコマンドを用意します
                using ( SQLiteCommand command = connection.CreateCommand() )
                {
                    command.CommandText = query;

                    using ( SQLiteDataReader reader = command.ExecuteReader() )
                    {
                        isExist = reader.Read();
                    }
                }
                connection.Close();
                return isExist;
            }
        }

        /// <summary>
        /// カラムのデータ取得
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public string[] GetRecord(string query)
        {
            string[] recordData = null;
            // DBコネクション設定
            using ( SQLiteConnection connection = new SQLiteConnection("Data Source=" + db_file) )
            {
                connection.Open();
                // DBに対するコマンドを用意します
                using ( SQLiteCommand command = connection.CreateCommand() )
                {
                    command.CommandText = query;

                    using ( SQLiteDataReader reader = command.ExecuteReader() )
                    {
                        if ( reader.Read() )
                        {
                            recordData = new string[reader.FieldCount];
                            for(int i=0; i < reader.FieldCount; i++ )
                            {
                                recordData[i] = reader.GetValue(i).ToString();
                            }
                        }
                    }
                }
                connection.Close();
                return recordData;
            }
        }
        

        /// <summary>
        /// データベースのIDのMaxを取得する
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public string GetMaxID(string columName, string tableName)
        {
            // DBコネクション設定
            using ( SQLiteConnection connection = new SQLiteConnection("Data Source=" + db_file) )
            {
                connection.Open();
                string maxId = "";

                // DBに対するコマンドを用意します
                using ( SQLiteCommand command = connection.CreateCommand() )
                {
                    // パラメータのセット
                    // 追加をする時に、Max()でidカラムのデータのMax値を取る。

                    // ASでカラム名を指定しておかないと、MAX(カラム名）になってしまう為、取り出しが難しくなる。
                    // command.AddWithValueを使うよりは、string.Formatした方が楽なことに気がついた。
                    string cmd = string.Format("SELECT MAX({0}) AS {0} FROM {1}", columName, tableName);
                    command.CommandText = cmd;

                    using ( SQLiteDataReader reader = command.ExecuteReader() )
                    {
                        while ( reader.Read() )
                        {
                            if ( reader.IsDBNull(0) )
                            {
                                connection.Close();
                                return "0";
                            }
                            maxId = reader.GetString(0);
                        }
                    }
                }
                connection.Close();
                return maxId;
            }
        }

        /// <summary>
        /// 指定したレコードの削除
        /// </summary>
        /// <param name="index"></param>
        public void DeleteData(int index)
        {
            // DBコネクション設定
            using ( SQLiteConnection connection = new SQLiteConnection("Data Source=" + db_file) )
            {
                connection.Open();

                // DBに対するコマンドを用意します
                using ( SQLiteCommand command = connection.CreateCommand() )
                {
                    // パラメータのセット
                    command.Parameters.AddWithValue("@ID", index);
                    command.CommandText = "DELETE FROM member WHERE id=@ID";
                    using ( SQLiteDataReader reader = command.ExecuteReader() )
                    { }
                    // DBからの結果を格納するクラスを用意
                    using ( SQLiteDataReader reader = command.ExecuteReader() )
                    { }
                }
                connection.Close();
            }
        }
    }

}
