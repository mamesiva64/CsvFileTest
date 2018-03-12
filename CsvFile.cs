using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualBasic.FileIO;


namespace AlpacaTech
{
    /// <summary>
    /// CSVファイルを２次元配列List<List<string>>に格納するクラス
    /// </summary>
    class CsvFile
    {
        //  格納されるメンバ
        public List<List<string>> lines;

        /// <summary>
        /// コンストラクタ。CSVファイルから読み込み
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <param name="delimiters">区切り文字</param>
        /// <param name="encoding">エンコード指定。Encoding.GetEncoding("shift-jis")等</param>
        public CsvFile(string path, string delimiters = ",", Encoding encoding = null)
        {
            //	指定が無ければUTF-8
            if (encoding == null)
            {
                encoding = Encoding.GetEncoding("utf-8");
            }

            //	パース開始
            var parser = new TextFieldParser(path, encoding);
            using (parser)
            {
                //  区切りの指定
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(delimiters);

                // フィールドが引用符で囲まれているか
                parser.HasFieldsEnclosedInQuotes = true;
                // フィールドの空白トリム設定
                parser.TrimWhiteSpace = false;

                //	リスト生成
                lines = new List<List<string>>();

                // ファイルの終端までループ
                while (!parser.EndOfData)
                {
                    var line = new List<string>();
                    var row = parser.ReadFields();
                    foreach (var field in row)
                    {
                        line.Add(field);
                    }
                    lines.Add(line);
                }
            }
        }
    }
}
