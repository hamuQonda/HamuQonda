using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace HamuQonda
{
    internal static class CmdRun
    {
        // APIを利用する設定
        [DllImport("user32.dll")]
        static extern bool SetWindowText(IntPtr hWnd, string lpString);

        // コマンドプロンプト            C:\WINDOWS\system32\cmd.exe
        private static string cmd = Environment.GetEnvironmentVariable("COMSPEC");


        /// 標準出力と標準エラーを得るメソッドで使うメンバ変数
        public enum Idx { Out, Err, IdxLen }
        public static readonly int OutIdx = 0, ErrIdx = 1, ArryLen = 2;
        private static string[] results = new string[ArryLen];

        /// <summary>
        /// 標準出力と標準エラーを得るメソッド（shellを使わず、DOS窓も開かない）
        /// </summary>
        /// <param name="cmdArg"></param>
        /// <returns></returns>
        internal static string[] Get_Out_Err(string cmdArg)
        {
            using (var p = new Process())
            {
                p.StartInfo.FileName = cmd;
                p.StartInfo.Arguments = cmdArg;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.ErrorDataReceived += P_ErrorDataReceived; // エラー出力が発生時のイベントハンドラ

                try
                {
                    p.Start();
                    results[OutIdx] = p.StandardOutput.ReadToEnd(); // 標準出力を全て読み取り
                    results[ErrIdx] = p.StandardError.ReadToEnd();
                    //p.BeginErrorReadLine();                 // エラー出力を非同期読み取り開始
                    p.WaitForExit();
                }
                catch (Exception ex)
                {
                    results[OutIdx] = "例外が発生しました";
                    results[ErrIdx] = ex.Message;
                }

            }

            return results;
        }
        /// <summary>
        /// エラー出力が発生時のイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">エラー出力データ</param>
        private static void P_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            results[ErrIdx] += e.Data;
        }


        /// <summary>
        /// コマンドプロンプトのコマンドを実行（DOS窓を開く）
        /// </summary>
        /// <param name="cmdArg"></param>
        internal static void CmdWindow(string cmdArg, bool wait)
        {
            using (var p = new Process())
            {
                p.StartInfo.FileName = cmd;
                p.StartInfo.Arguments = cmdArg;
                try
                {
                    p.Start();
                    if (wait) { p.WaitForExit(); }
                }
                catch (Exception ex)
                {
                    results[OutIdx] = "例外が発生しました";
                    results[ErrIdx] = ex.Message;
                }
            }

        }


        /// <summary>
        /// コマンドプロンプトのコマンドを実行（shellを使わず、DOS窓も開かない）
        /// </summary>
        /// <param name="cmdArg"></param>
        /// <param name="wait">プロセスが終了するまで待機するか？</param>
        internal static void CmdNoWindow(string cmdArg, bool wait)
        {
            using (var p = new Process())
            {
                p.StartInfo.FileName = cmd;
                p.StartInfo.Arguments = cmdArg;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                try
                {
                    p.Start();
                    if (wait) { p.WaitForExit(); }
                }
                catch (Exception ex)
                {
                    results[OutIdx] = "例外が発生しました";
                    results[ErrIdx] = ex.Message;
                }
            }

        }


    }
}
