using System;
using System.Windows.Forms;
using System.Threading;

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

            //ミューテックス作成
            Mutex _mutex = new Mutex(false, "MYSOFTWARE_001");

            //ミューテックスの所有権を要求する
            if (_mutex.WaitOne(0, false) == false)
            {
                MessageBox.Show("本ソフトウェアは複数起動できません。");
                return;
            }

        }
    }
}
