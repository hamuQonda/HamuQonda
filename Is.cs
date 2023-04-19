using System;
using System.IO;
using System.Text.RegularExpressions;

namespace HamuQonda
{
    internal static class Is
    {
        /// <summary>
        /// 引数の文字列が 半角(英数字,_,-.) のみで構成されているかを調べる。
        /// </summary>
        /// <param name="text">チェック対象の文字列。</param>
        /// <returns>文字列がマッチしたら true、そうでなければ falseを返す。</returns>
        public static bool OnlyAlphanumeric2(string text)
        {
            // 文字列の先頭から末尾までが、半角英数字で始まる半角(英数字,_,-)とマッチするかを調べる。
            return (Regex.IsMatch(text, @"^[a-zA-Z0-9.][a-zA-Z0-9_-]*$"));
        }


        /// <summary>
        /// アクセス権のある有効なフォルダか？
        /// 指定pathに書き込み可能か調べる
        /// </summary>
        /// <param name="path"></param>
        /// <returns>true | false</returns>
        public static bool Writable(string path)
        {
            try
            {
                using (var fs = File.Create(path + @"\test.txt"))
                {
                }
                File.Delete(path + @"\test.txt");
                return true;
            }

            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("アクセス許可がありません！！");
                return false;
            }

            catch (Exception ex)
            {
                Console.WriteLine("@@@ " + ex.Message);
                return false;
            }
        }

    }
}
