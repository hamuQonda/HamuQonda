using System;
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

            FormHQ mainForm = new FormHQ();
            //スプラッシュウィンドウを表示
            SplashForm.ShowSplash(mainForm);

            //System.Threading.Thread.Sleep(2500);
            Application.Run(mainForm);
        }
    }
}
