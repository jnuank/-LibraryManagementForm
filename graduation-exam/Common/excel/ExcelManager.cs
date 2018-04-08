using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Data;

namespace Common.excel
{
    /// <summary>
    /// エクセル操作をするクラス
    /// </summary>
    public class ExcelManager : IDisposable
    {
        /// <summary>
        /// リリース対象
        /// </summary>
        private enum EnumReleaseMode
        {
            Sheet,
            Sheets,
            Book,
            Books,
            App
        }

        #region フィールド

        // エクセル操作用オブジェクト
        private Application xlApp       = null;
        private Workbooks   xlBooks     = null;
        private Workbook    xlBook      = null;
        private Sheets      xlSheets    = null;
        private Worksheet   xlSheet     = null;

        // リソース解放フラグ
        private bool isDispose = false;



        #endregion


        #region コンストラクタ＆デストラクタ

        /// <summary>
        /// 引数なしコンストラクタはアクセス出来ないようにする。
        /// </summary>
        private ExcelManager()
        {
            // do nothing...
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="fileName"></param>
        public ExcelManager(string fileName)
        {
            xlApp = new Application();
            OpenExcelFile(fileName);
        }

        /// <summary>
        /// リソースの解放
        /// </summary>
        public void Dispose()
        {
            ReleaseExcelComObject(EnumReleaseMode.App);

            isDispose = true;

            // 連続で書き込みメソッドが呼ばれたときには、明示的に指定しておかないとExcel.exeが残ってしまう
            GC.Collect();
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~ExcelManager()
        {
            // 呼び出し側がDispose()を呼ばないときには、ここでDispose()を呼ぶ
            if ( !isDispose )
                Dispose();
        }

        #endregion

        #region メソッド

        /// <summary>
        /// Excelリソース解放
        /// </summary>
        /// <param name="releaseMode">リリース対象</param>
        private void ReleaseExcelComObject(EnumReleaseMode releaseMode)
        {
            // enumでリソースをどこまで解放するか指定
            try
            {
                // XlSheet解放
                if ( xlSheet != null )
                {
                    Marshal.ReleaseComObject(xlSheet);
                    xlSheet = null;
                }
                if ( releaseMode == EnumReleaseMode.Sheet )
                    return;

                // xlSheets解放
                if ( xlSheets != null )
                {
                    Marshal.ReleaseComObject(xlSheets);
                    xlSheets = null;
                }
                if ( releaseMode == EnumReleaseMode.Sheets )
                    return;

                // xlBook解放
                if ( xlBook != null )
                {
                    try
                    {
                        xlBook.Close();
                    }
                    finally
                    {
                        Marshal.ReleaseComObject(xlBook);
                        xlBook = null;
                    }
                }
                if ( releaseMode == EnumReleaseMode.Book )
                    return;

                // xlBooks解放
                if ( xlBooks != null )
                {
                    Marshal.ReleaseComObject(xlBooks);
                    xlBooks = null;
                }
                if ( releaseMode == EnumReleaseMode.Books )
                    return;

                // xlApp解放
                if ( xlApp != null )
                {
                    try
                    {
                        // アラートが表示されるように戻して終了
                        xlApp.DisplayAlerts = true;
                        xlApp.Quit();
                    }
                    finally
                    {
                        Marshal.ReleaseComObject(xlApp);
                        xlApp = null;
                    }
                }
            }
            catch ( Exception ex )
            {
                throw;
            }

        }

        /// <summary>
        /// 個別にセル書き込み
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="writeData">書き込むデータ</param>
        /// <param name="row">書き込む行</param>
        /// <param name="column">書き込む列</param>
        /// <param name="sheet">書き込むシート</param>
        public void WriteCell<T>(T writeData, int row, int column, int sheet)
        {

            // シート選択
            xlSheets = xlBook.Worksheets;
            xlSheet = xlSheets[sheet] as Worksheet;
            xlSheet.Select();

            // リソース準備
            Range temp = xlSheet.Cells;
            Range cell = temp[row, column];

            // データ書き込み
            cell.Value = writeData;

            // 確認ダイアログを表示しない
            xlApp.DisplayAlerts = false;
            xlApp.SaveWorkspace();
            xlApp.DisplayAlerts = true;

            // リソース破棄
            Marshal.ReleaseComObject(cell);
            Marshal.ReleaseComObject(temp);
        }

        /// <summary>
        /// 個別にセル書き込み（A1指定ver）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="writeData"></param>
        /// <param name="cellTarget"></param>
        /// <param name="sheet"></param>
        public void WriteCell<T>(T writeData, string cellTarget, int sheet)
        {

            // シート選択
            xlSheets = xlBook.Worksheets;
            xlSheet = xlSheets[sheet] as Worksheet;
            xlSheet.Select();

            // リソース準備
            Range temp = xlSheet.Cells;
            Range cell = temp.get_Range(cellTarget);

            // データ書き込み
            cell.Value = writeData;

            // 確認ダイアログを表示しない
            xlApp.DisplayAlerts = false;
            xlApp.SaveWorkspace();
            xlApp.DisplayAlerts = true;

            // リソース破棄
            Marshal.ReleaseComObject(cell);
            Marshal.ReleaseComObject(temp);
        }

        /// <summary>
        /// 指定したファイルのエクセルを開く
        /// </summary>
        /// <param name="fileName"></param>
        private void OpenExcelFile(string fileName)
        {
            if ( xlBook == null )
            {
                this.xlBooks = xlApp.Workbooks;
                this.xlBook = xlBooks.Open(fileName);
            }
        }

        /// <summary>
        /// 罫線を引く
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void BorderWrite(int row, int column, int sheet)
        {

            // シート選択
            xlSheets = xlBook.Worksheets;
            xlSheet = xlSheets[sheet] as Worksheet;
            xlSheet.Select();

            // リソース準備
            Range temp = xlSheet.Cells;
            Range cell = temp[row, column];
            Border border;

            // 対象セルの周りに罫線を引く
            border = cell.Borders.get_Item(XlBordersIndex.xlEdgeBottom);
            border.LineStyle = XlLineStyle.xlContinuous;

            border = cell.Borders.get_Item(XlBordersIndex.xlEdgeTop);
            border.LineStyle = XlLineStyle.xlContinuous;

            border = cell.Borders.get_Item(XlBordersIndex.xlEdgeRight);
            border.LineStyle = XlLineStyle.xlContinuous;

            border = cell.Borders.get_Item(XlBordersIndex.xlEdgeLeft);
            border.LineStyle = XlLineStyle.xlContinuous;

            // 確認ダイアログを表示しない
            xlApp.DisplayAlerts = false;
            xlApp.SaveWorkspace();
            xlApp.DisplayAlerts = true;

            // リソース破棄
            Marshal.ReleaseComObject(cell);
            Marshal.ReleaseComObject(temp);
            Marshal.ReleaseComObject(border);

        }

        #endregion
    }
}
