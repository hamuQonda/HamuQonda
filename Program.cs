using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HamuQonda
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 mainForm = new Form1();
            //スプラッシュウィンドウを表示
            SplashForm.ShowSplash(mainForm);

            //System.Threading.Thread.Sleep(2500);
            Application.Run(mainForm);
        }
    }
}
