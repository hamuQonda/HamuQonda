using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HamuQonda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 仮想環境検索フォルダ：このフォルダ下から仮想環境を検索
        private string venvsDir;
        
        // 作業フォルダ
        private string workingDir;
        
        // python環境の配列
        private PythonEnv[] pyList;

        // HamQonda.exeのフォルダを得る
        private readonly string hqExePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        // ユーザープロファイル
        private readonly string userProfile = Environment.GetEnvironmentVariable("USERPROFILE");

        // ローカルアプリケーションデータ
        private readonly string localAppData = Environment.GetEnvironmentVariable("LOCALAPPDATA");

        // Windowsインストールフォルダ
        private readonly string winDir = Environment.GetEnvironmentVariable("WINDIR");

        // マイドキュメント
        private readonly string mydocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


        private void Form1_Load(object sender, EventArgs e)
        {
            // py.exe の存在確認
            var pyexeExistsAlluser = File.Exists(winDir + @"\py.exe");
            var pyexeExistsLocaluser = File.Exists(localAppData + @"\Programs\Python\Launcher\py.exe");

            // py.exe が無いなら終了
            if (!pyexeExistsAlluser && !pyexeExistsLocaluser)
            {
                MessageBox.Show("Pythonランチャーがインストールされていません。\n ・・・終了します。");
                Close();
            }

            InitializeFolder();
            pyList = InitializePyList();

        }

        private PythonEnv[] InitializePyList()
        {
            var count = 0;
            var _py0pList = GetPy0p().Split('\n');
            var pyenvs = new PythonEnv[5];
            foreach(string _py in _py0pList)
            {
                kakunin.Text += Environment.NewLine + _py;
            }

            return pyenvs;
        }

        private string GetPy0p()
        {
            string results = "";
            try
            {
                using(var p = new Process())
                {
                    p.StartInfo.FileName = Environment.GetEnvironmentVariable("COMSPEC");
                    p.StartInfo.UseShellExecute= false;
                    p.StartInfo.RedirectStandardOutput= true;
                    p.StartInfo.CreateNoWindow= true;
                    p.StartInfo.Arguments = @"/c py -0p";
                    p.Start();
                    results = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Console.WriteLine(results);
            return results;
        }

        /// <summary>
        /// 仮想環境フォルダ、作業フォルダ を設定
        /// </summary>
        private void InitializeFolder()
        {
            // 作業フォルダ設定
            workingDir = Properties.Settings.Default.WorkingFolder;
            if (workingDir == "")
            {
                workingDir = mydocuments;
                Properties.Settings.Default.WorkingFolder = workingDir;
            }
            txtDispWorkingFolder.Text = workingDir;

            // 仮想環境を格納しているフォルダ設定
            venvsDir = Properties.Settings.Default.VenvsFolder;
            if (venvsDir == "")
            {
                venvsDir = mydocuments;
                Properties.Settings.Default.VenvsFolder = venvsDir;

            }

        }


        private void btnWdirChange_Click(object sender, EventArgs e)
        {
            using( var fbDialog = new FolderBrowserDialog())
            {

                // ダイアログの説明文を指定する
                fbDialog.Description = "作業フォルダを選択して、ＯＫボタンをクリック";

                // デフォルトのフォルダを指定する
                fbDialog.SelectedPath = workingDir;
                SendKeys.Send("{TAB}{TAB}{RIGHT}");

                // 「新しいフォルダーの作成する」ボタンを表示する
                fbDialog.ShowNewFolderButton = true;

                // ダイアログからフォルダを選択する
                for (; ; )
                {
                    if (fbDialog.ShowDialog() == DialogResult.OK)
                    {
                        var selectDir = fbDialog.SelectedPath;
                        if (IsValidDir(selectDir))
                        {
                            txtDispWorkingFolder.Text = fbDialog.SelectedPath;
                            Properties.Settings.Default.WorkingFolder = txtDispWorkingFolder.Text;
                            Properties.Settings.Default.Save();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("有効なフォルダではありません。\n他のフォルダを選択してください。");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("キャンセルされました");
                        break;
                    }

                }
            }

        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {

            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _ = IsValidDir(workingDir);
        }

        /// <summary>
        /// 指定pathに書き込み可能か？
        /// </summary>
        /// <param name="_path"></param>
        /// <returns>true | false</returns>
        private bool IsValidDir(string _path)
        {
            try
            {
                using (var fs = File.Create(_path + @"\test.txt"))
                {
                }
                File.Delete(_path + @"\test.txt");
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
