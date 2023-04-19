using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Security.Permissions;

namespace HamuQonda
{
    public partial class FormHQ : Form
    {
        public FormHQ()
        {
            InitializeComponent();
            kakunin.Visible = false;
        }

        // 仮想環境検索フォルダ：このフォルダ下から仮想環境を検索
        internal string venvsDir;

        // 作業フォルダ
        internal string workingDir;

        // 選択されてるpython環境のNo.
        internal int selPyNo = 0;

        // 選択されているPython環境
        internal Py_Env selPyEnv;

        // 選択されてる仮想環境のNo.
        private int selVenvNo = 0;

        // python環境のリスト
        // 仮List化 @@@@@@@@@@@@@@@@@@@@
        internal List<Py_Env> pyEnvList;
        internal List<Py_Env> pyVenvList;

        // HamQonda.exeのフォルダを得る
        private readonly string hqExePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        // ユーザープロファイル           C:\Users\【ユーザ名】
        private readonly string userProfile = Environment.GetEnvironmentVariable("USERPROFILE");

        // アプリケーションデータローカル  C:\Users\【ユーザ名】\AppData\Local
        internal static readonly string localAppData = Environment.GetEnvironmentVariable("LOCALAPPDATA");

        // Windowsインストールフォルダ    C:\WINDOWS
        private readonly string winDir = Environment.GetEnvironmentVariable("WINDIR");

        // マイドキュメント
        private readonly string mydocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // コマンドプロンプト            C:\WINDOWS\system32\cmd.exe
        private readonly string cmd = Environment.GetEnvironmentVariable("COMSPEC");

        // 環境変数 PATH
        private readonly string orgEnvVarPath = Environment.GetEnvironmentVariable("PATH");

        public const bool waitForExitTrue = true;
        public const bool waitForExitFalse = false;


        private void Form1_Load(object sender, EventArgs e)
        {
            // py.exe の存在確認
            var pyexeExistsAlluser = File.Exists(winDir + @"\py.exe");
            var pyexeExistsLocaluser = File.Exists(localAppData + @"\Programs\Python\Launcher\py.exe");

            // py.exe が無いなら終了
            if (!pyexeExistsAlluser && !pyexeExistsLocaluser)
            {
                return;
                //MessageBox.Show("Pythonランチャーを確認できません。\n ・・・終了します。");
                //Close();
            }

            Height = 160;
            btnSelPyOnOff.Text = "▽";
            panel1.Visible = false;

            SettingsLoad();
            InitializeSysPyList();
            CreateSysPyBtnOnPanel1();
            InitializeVenvPyList();     // 仮想環境リストを更新
            CreateVenvPyBtnOnPanel2();  // 仮想環境ボタンを生成
            SelPyBtnActivation();
            Directory.SetCurrentDirectory(workingDir);

        }

        private void SelPyBtnActivation()
        {
            var parentPanel = (selPyNo > pyEnvList.Count) ? splitContainer1.Panel2 : splitContainer1.Panel1;
            foreach (object b in parentPanel.Controls)
            {
                if (b is Button && ((Button)b).Tag != null)
                {
                    var btn = (Button)b;
                    Py_Env pyEnv = (Py_Env)btn.Tag;

                    if (pyEnv.TagNo == selPyNo)
                    {
                        SelectedPyEnvBtn(btn);
                    }
                }
            }

        }


        /// <summary>
        /// 仮想環境フォルダ、作業フォルダ を設定
        /// </summary>
        private void SettingsLoad()
        {
            // 作業フォルダ設定
            workingDir = Properties.Settings.Default.WorkingFolder;
            if (workingDir == "")
            {
                workingDir = mydocuments;
                Properties.Settings.Default.WorkingFolder = workingDir;
            }
            txtBoxWorkDir.Text = workingDir;

            // 仮想環境を格納しているフォルダ設定
            venvsDir = Properties.Settings.Default.VenvsFolder;
            if (venvsDir == "")
            {
                venvsDir = mydocuments;
                Properties.Settings.Default.VenvsFolder = venvsDir;
            }
            txtBoxVenvsDir.Text= venvsDir;
            toolTip1.SetToolTip(lbl_VirtualEnv, "仮想環境\n格納場所\n" + venvsDir);
            toolTip1.SetToolTip(splitContainer1.Panel2, "仮想環境\n格納場所\n" + venvsDir);

            // システム環境の初期選択
            selPyNo = Properties.Settings.Default.SelectedPyEnvNo;

            // 仮想環境の初期選択
            selVenvNo = Properties.Settings.Default.SelectedPyVenvNo;

        }


        // システム環境リスト作成
        private void InitializeSysPyList()
        {
            pyEnvList = new List<Py_Env> { };
            Py0p py0P = new Py0p();             // py -0p コマンド出力のオブジェクトを得る
            foreach (Py0p.PyInfo pyInfo in py0P.PyInfos )
            {
                if(pyInfo.Valid)
                {
                    var py = pyInfo.Ver + " " + pyInfo.ExePath;
                    var pyEnv = new Py_Env(py);
                    pyEnvList.Add(pyEnv);
                }
            }

        }

        // 仮想環境リスト作成
        private void InitializeVenvPyList()
        {
            pyVenvList = new List<Py_Env> { };
            var venvArry = GetVenvs();
            foreach (string vpy in venvArry)
            {
                var pyVenv = new Py_Env(vpy);
                pyVenvList.Add(pyVenv);
            }
        }

        private string[] GetVenvs()
        {
            kakunin.Clear();
            var venvCount = 0;
            var venvPaths = Directory.GetDirectories(venvsDir);
            foreach(string venvPath in venvPaths)
            {
                if (ValidBase(venvPath))
                {
                    var venvPyPath = venvPath + @"\Scripts\python.exe";
                    if (File.Exists(venvPyPath))
                    {
                        var result = CmdRun.Get_Out_Err("/c " + venvPyPath + " -V");
                        var version = (result[0].Trim() + result[1].Trim()).Replace("Python ", "-Ve:");
                        kakunin.Text += (version + " " + venvPyPath + Environment.NewLine);
                        venvCount++;
                    }
                }
            }
            var _venvList = new string[venvCount];
            for (int i = 0; i < venvCount; i++)
            {
                _venvList[i] = kakunin.Lines[i];
            }
            return _venvList;
        }

        /// <summary>
        /// 仮想環境パス\pyvenv.cfg 内の home = ベースとなるpythonパス が有効か？
        /// </summary>
        /// <param name="venvPath"></param>
        /// <returns>true | false</returns>
        private bool ValidBase(string venvPath)
        {
            // 仮想環境フォルダに "pyvenv.cfg" が無いなら false
            var pyvenvCfgPath = venvPath + @"\pyvenv.cfg";
            if (File.Exists(pyvenvCfgPath))
            {
                var homePyPath = File.ReadLines(pyvenvCfgPath).ToArray()[0].Replace("home = ", "");
                var cmdArg = "/c \"" + homePyPath + "\\python.exe\" -V";

                var result = CmdRun.Get_Out_Err(cmdArg);
                if (result[CmdRun.OutIdx] == "" && result[CmdRun.ErrIdx].StartsWith("Python 2.7")) { return true; }
                return result[CmdRun.OutIdx] != "";

                //return CmdRun.Get_Out_Err(cmdArg)[CmdRun.OutIdx] != "";
            }
            else { return false; }

        }


        /// <summary>
        /// システム環境pythonボタン生成
        /// </summary>
        private void CreateSysPyBtnOnPanel1()
        {
            var countpy = 0;
            foreach (Py_Env pyEnv in pyEnvList)
            {
                if (pyEnv is null) continue;
                if (pyEnv.Ver == "???") continue;
                // 複数インストールされているPython毎に選択用のボタンを生成する
                Button btnPyEnv = new Button()
                {
                    TabStop = false,
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(204, 64),
                    Location = new Point(30, 16 + countpy * 68),
                    Text = "Python " + pyEnv.Ver + " - " + pyEnv.Bit.Trim() + "\n<" + pyEnv.Provided + ">",
                    BackColor = (pyEnv.Type == "O") ? Color.LightYellow : 
                                (pyEnv.Type == "S") ? Color.FromArgb(220, 240, 255) :
                                (pyEnv.Type == "A") ? Color.FromArgb(230, 255, 230) :
                                Color.Azure,
                    Tag = pyEnv,    // Tagにpython環境オブジェクトを持たせる
                    ContextMenuStrip = contextMenuStrip1,
                };
                btnPyEnv.MouseDown += new MouseEventHandler(btnPyEnv_MouseDown);
                btnPyEnv.FlatAppearance.BorderSize = 0;
                btnPyEnv.FlatAppearance.BorderColor = Color.Orange;
                btnPyEnv.FlatAppearance.MouseOverBackColor = Color.Lavender;

                splitContainer1.Panel1.Controls.Add(btnPyEnv);
                toolTip1.SetToolTip(btnPyEnv, "右クリック → ツールメニュー");

                if (previousEnv is null )
                {
                    previousEnv = pyEnv;
                    if (pyEnv.TagNo == selPyNo) previousEnv = null;
                }

                countpy++;
            }

            //foreach (object b in TabP_Env.Controls)
            foreach (object b in splitContainer1.Panel1.Controls)
            {
                if (b is Button && ((Button)b).Tag != null)
                {
                    var btn = (Button)b;
                    Py_Env pyEnv = (Py_Env)btn.Tag;

                    if (pyEnv.TagNo == selPyNo)
                    {
                        this.ActiveControl = btn;
                        SelectedPyEnvBtn(btn);
                    }
                    Console.WriteLine(pyEnv.TagNo);
                }
            }
        }


        /// <summary>
        /// 仮想環境pythonボタン生成
        /// </summary>
        private void CreateVenvPyBtnOnPanel2()
        {
            var countpy = 0;
            //foreach (Py_Env pyEnv in pyVenvArry)
            foreach (Py_Env pyEnv in pyVenvList)    // 仮List化 @@@@@@@@@@@@@@@@@@@@
            {
                // 仮想環境のPython毎に選択用のボタンを生成する
                Button btnPyEnv = new Button()
                {
                    TabStop = false,
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(204, 64),
                    Location = new Point(30, 16 + countpy * 68),
                    Text = pyEnv.Provided + "\n" + "Python " + pyEnv.Ver + " - " + pyEnv.Bit.Trim(),
                    BackColor = Color.SeaShell,
                    Tag = pyEnv,    // Tagにpython環境オブジェクトを持たせる
                    ContextMenuStrip = contextMenuStrip1,
                };
                btnPyEnv.MouseDown += new MouseEventHandler(btnPyEnv_MouseDown);
                btnPyEnv.FlatAppearance.BorderSize = 0;
                btnPyEnv.FlatAppearance.BorderColor = Color.Orange;
                btnPyEnv.FlatAppearance.MouseOverBackColor = Color.Lavender;

                splitContainer1.Panel2.Controls.Add(btnPyEnv);
                toolTip1.SetToolTip(btnPyEnv, "右クリック → ツールメニュー");
                countpy++;
            }

        }

        private Button previousBtn;
        private void btnPyEnv_MouseDown(object sender, MouseEventArgs e)
        {
            var btn = (Button)sender;
            SelectedPyEnvBtn(btn);
            previousBtn = btn;
            // Console.WriteLine("TagNo = " + ((Py_Env)btn.Tag).TagNo);
        }

        private Py_Env previousEnv;

        /// <summary>
        /// 選択されたPython環境の表示処理
        /// </summary>
        /// <param name="btn"></param>
        private void SelectedPyEnvBtn(Button btn)
        {
            txtInfo.Clear();
            txtInfo.AppendText("＊＊＊＊更新中＊＊＊＊");
            txtInfo.Enabled = false;

            var parentPanel = btn.Parent;
            pictureBox1.Parent = parentPanel;   // ハムのアイコンを選択されたボタンのあるパネルに移動

            this.ActiveControl = btn;
            pictureBox1.Top = btn.Top + btn.Height / 4;

            var locationoff = new Point(btn.Top + 70, btn.Left);
            if (parentPanel == splitContainer1.Panel1)
                splitContainer1.Panel1.AutoScrollOffset = locationoff;
            else
                splitContainer1.Panel2.AutoScrollOffset = locationoff;

            foreach (object b in parentPanel.Controls)
            {
                if (b is Button && ((Button)b).Tag != null)
                {
                    var _btn = (Button)b;
                    Py_Env _pyEnv = (Py_Env)_btn.Tag;

                    if (_pyEnv == previousEnv)
                    {
                        _btn.FlatAppearance.BorderSize = 0;
                    }
                    Console.WriteLine(_pyEnv.TagNo);
                }
            }

            if(!(previousBtn is null)) previousBtn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.BorderSize = 2;
            previousBtn = btn;

            var pyEnv = (Py_Env)btn.Tag;
            selPyEnv = pyEnv;
            selPyNo = pyEnv.TagNo;
            previousEnv = selPyEnv;

            Properties.Settings.Default.SelectedPyEnvNo = selPyNo;
            Properties.Settings.Default.Save();
            AddPythonPathToEnvVarPATH();

            txtInfo.ResetText();
            var addtxt = "[ 現在の環境 ]：";
            if (pyEnv.Type == "V") // Venv
            {
                addtxt = "選択環境 ((( 仮想環境 )))";
                tStripMenu_NewVenv.Visible = false; btnVenvNew.  Visible = false;
                tStripMenu_CopyEnv.Visible = true; btnVenvClone.Visible = true;
                tStripMenu_DelVenv.Visible = true; btnVenvDel.Visible = true;
                tStripMenu_JpNb.Visible = !pyEnv.Ver.StartsWith("2.");
                tStripBtn_JpNb.Enabled = !pyEnv.Ver.StartsWith("2.");
            }
            if (pyEnv.Type == "O") // org
            {
                addtxt = "選択環境 << システム環境 >>";
                tStripMenu_NewVenv.Visible = true;  btnVenvNew.  Visible = true;
                tStripMenu_CopyEnv.Visible = true; btnVenvClone.Visible = true; ;
                tStripMenu_DelVenv.Visible = false; btnVenvDel.Visible = false; ;
                tStripMenu_JpNb.Visible = !pyEnv.Ver.StartsWith("2.");
                tStripBtn_JpNb.Enabled = !pyEnv.Ver.StartsWith("2.");
            }
            if (pyEnv.Type == "S") // store
            {
                addtxt = "選択環境 << システム環境 >> store";
                tStripMenu_NewVenv.Visible = true;  btnVenvNew.  Visible = true;
                tStripMenu_CopyEnv.Visible = true; btnVenvClone.Visible = true;
                tStripMenu_DelVenv.Visible = false; btnVenvDel.Visible = false;
                tStripMenu_JpNb.Visible = true;
                tStripBtn_JpNb.Enabled = true;
            }
            if (pyEnv.Type == "A") // Anaconda
            {
                addtxt = "選択環境 [[ Anaconda base ]]";
                tStripMenu_NewVenv.Visible = false; btnVenvNew.  Visible = false;
                tStripMenu_CopyEnv.Visible = false; btnVenvClone.Visible = false;
                tStripMenu_DelVenv.Visible = false; btnVenvDel.Visible = false;
                tStripMenu_JpNb.Visible = true;
                tStripBtn_JpNb.Enabled = true;
            }
            txtInfo.AppendText(addtxt + Environment.NewLine);
            txtInfo.AppendText(pyEnv + Environment.NewLine);
            txtInfo.AppendText(pyEnv.ExePath + Environment.NewLine);

            txtInfo.SelectionStart = 0;
            txtInfo.ScrollToCaret();
            txtInfo.Enabled = true;

        }


        /// <summary>
        /// コマンド python -VV でpythonの詳細情報を得る
        /// </summary>
        /// <param name="py1"></param>
        /// <param name="pyPath"></param>
        /// <returns></returns>
        private string GetPyVV(string py1, string pyPath)
        {

            // Python 3 以降のバージョン
            var cmdArg = @"/c " + pyPath + " -VV";

            if (py1.Contains("-V:2"))
            {
                // Python 2 は python -VV で詳細表示が無い為、下記処理で詳細を得る
                cmdArg = "/c " + pyPath + " -c " + "\"import sys;print(sys.version)\"";
            }

            var result = CmdRun.Get_Out_Err(cmdArg)[0];

            if (result.StartsWith("例外")) return "";
            if (result.StartsWith("Python ")) return result;
            if (result != null) return "Python " + result;

            return "";

        }


        /// <summary>
        /// 作業フォルダの変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWdirChange_Click(object sender, EventArgs e)
        {
            using (var fbDialog = new FolderBrowserDialog())
            {

                // ダイアログの説明文を指定する
                fbDialog.Description = "作業フォルダを選択して、ＯＫボタンをクリック";

                // デフォルトのフォルダを指定する
                fbDialog.SelectedPath = workingDir;
                SendKeys.Send("{TAB}{TAB}{RIGHT}");

                // 「新しいフォルダーの作成する」ボタンを表示する
                fbDialog.ShowNewFolderButton = true;

                for (; ; )
                {
                    // ダイアログからフォルダを選択する
                    if (fbDialog.ShowDialog() == DialogResult.OK)
                    {
                        var selectDir = fbDialog.SelectedPath;
                        if (Is.Writable(selectDir))
                        {
                            workingDir = selectDir;
                            txtBoxWorkDir.Text = workingDir;
                            Properties.Settings.Default.WorkingFolder = workingDir;
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

        /// <summary>
        /// 仮想環境格納フォルダの変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVenvSearchDirChange_Click(object sender, EventArgs e)
        {
            using (var fbDialog = new FolderBrowserDialog())
            {

                // ダイアログの説明文を指定する
                fbDialog.Description = "< 仮想環境-格納場所 >\n\n        フォルダを選択して、ＯＫをクリック";
          //        + "※選択フォルダ下にある仮想環境が表示されるようになります。";

                // デフォルトのフォルダを指定する
                fbDialog.SelectedPath = venvsDir;
                SendKeys.Send("{TAB}{TAB}{RIGHT}");

                // 「新しいフォルダーの作成」ボタンの有無
                fbDialog.ShowNewFolderButton = true;

                for (; ; )
                {
                    // ダイアログからフォルダを選択する
                    if (fbDialog.ShowDialog() == DialogResult.OK)
                    {
                        var selectDir = fbDialog.SelectedPath;
                        if (Is.Writable(selectDir))
                        {
                            venvsDir = selectDir;
                            toolTip1.SetToolTip(lbl_VirtualEnv, "仮想環境\n格納場所\n" + venvsDir);
                            toolTip1.SetToolTip(splitContainer1.Panel2, "仮想環境\n格納場所\n" + venvsDir);
                            Properties.Settings.Default.VenvsFolder = venvsDir;
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


        /// <summary>
        /// コマンドプロンプトを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (selPyEnv is null) return;

            string titleTxt = selPyEnv.Provided + " Python " + selPyEnv.Ver + " - " + selPyEnv.Bit;
            string cmdArg;
            switch (selPyEnv.Type)
            {
                case "S":
                case "O":
                    cmdArg = "/k title " + titleTxt;
                    Process.Start(cmd, cmdArg);
                    break;

                case "A":
                    if (File.Exists(selPyEnv.cmdActivate))
                    {
                        Environment.SetEnvironmentVariable("PATH", orgEnvVarPath);
                        cmdArg = "/k title " + titleTxt + " & " + selPyEnv.cmdActivate + " " + selPyEnv.ExeDir;
                        CmdRun.CmdWindow(cmdArg, waitForExitFalse);
                    }
                    break;

                case "V":
                    if (File.Exists(selPyEnv.HomePyPath + @"\python.exe"))
                    {
                        Environment.SetEnvironmentVariable("PATH", orgEnvVarPath);
                        cmdArg = "/k title " + titleTxt + " & " + selPyEnv.cmdActivate;
                        CmdRun.CmdWindow(cmdArg, waitForExitFalse);
                    }
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Pythonインタプリタを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (selPyEnv is null) return;

            string titleTxt = selPyEnv.Provided + " Python " + selPyEnv.Ver + " - " + selPyEnv.Bit;
            string cmdArg;
            switch (selPyEnv.Type)
            {
                case "S":
                case "O":
                    cmdArg = "/k title " + titleTxt + " & " + selPyEnv.ExePath;
                    Process.Start(cmd, cmdArg);
                    break;

                case "A":
                    if (File.Exists(selPyEnv.cmdActivate))
                    {
                        Environment.SetEnvironmentVariable("PATH", orgEnvVarPath);
                        cmdArg = "/k title " + titleTxt + " & " + selPyEnv.cmdActivate + " " + selPyEnv.ExeDir + " & " + selPyEnv.ExePath;
                        CmdRun.CmdWindow(cmdArg, waitForExitFalse);
                    }
                    break;

                case "V":
                    if (File.Exists(selPyEnv.HomePyPath + @"\python.exe"))
                    {
                        Environment.SetEnvironmentVariable("PATH", orgEnvVarPath);
                        cmdArg = "/k title " + titleTxt + " & " + selPyEnv.cmdActivate + " & python";
                        CmdRun.CmdWindow(cmdArg, waitForExitFalse);
                    }
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// IDLEを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (selPyEnv is null) return;

            string titleTxt = selPyEnv.Provided + " Python " + selPyEnv.Ver + " - " + selPyEnv.Bit + " IDLE";
            string cmdArg;
            switch (selPyEnv.Type)
            {
                case "S":
                    if (File.Exists(selPyEnv.ExeDir + @"\idle.exe"))
                    {
                        cmdArg = "/c " + selPyEnv.ExeDir + @"\idle.exe" + " -t \"" + titleTxt + "\"";
                        CmdRun.CmdNoWindow(cmdArg, waitForExitFalse);
                    }
                    break;

                case "A":
                    if (File.Exists(selPyEnv.ExeDir + @"\Lib\idlelib\idle.pyw") &&
                       File.Exists(selPyEnv.ExeDir + @"\pythonw.exe"))
                    {
                        Environment.SetEnvironmentVariable("PATH", orgEnvVarPath);
                        cmdArg = "/c " + selPyEnv.cmdActivate + " " + selPyEnv.ExeDir + " & " +
                                 "IDLE" + " -t \"" + titleTxt + "\"";
                        CmdRun.CmdNoWindow(cmdArg, waitForExitFalse);
                    }
                    break;

                case "O":
                    if (File.Exists(selPyEnv.ExeDir + @"\Lib\idlelib\idle.pyw") &&
                        File.Exists(selPyEnv.ExeDir + @"\pythonw.exe"))
                    {
                        cmdArg = "/c " + "pythonw.exe " + selPyEnv.ExeDir + @"\Lib\idlelib\idle.pyw" + 
                                 " -t \"" + titleTxt + "\"";
                        CmdRun.CmdNoWindow(cmdArg, waitForExitFalse);
                    }
                    break;

                case "V":
                    // base Python Microsoft Store
                    if (File.Exists(selPyEnv.HomePyPath + @"\idle.exe"))
                    {
                        Environment.SetEnvironmentVariable("PATH", orgEnvVarPath);
                        cmdArg = "/c " + selPyEnv.cmdActivate + " & " +
                                "python -m idlelib -t \"" + titleTxt + "\"";
                        CmdRun.CmdNoWindow(cmdArg, waitForExitFalse);
                    }
                    // base Python.org
                    else if (File.Exists(selPyEnv.HomePyPath + @"\python.exe") &&
                             File.Exists(selPyEnv.ExeDir + @"\pythonw.exe"))
                    {
                        Environment.SetEnvironmentVariable("PATH", orgEnvVarPath);
                        cmdArg = "/c " + selPyEnv.cmdActivate + " & " +
                            selPyEnv.ExeDir + @"\pythonw.exe " + 
                            "\"" + selPyEnv.HomePyPath + @"\Lib\idlelib\idle.pyw" + "\"" +
                            " -t \"" + titleTxt + "\"";
                        CmdRun.CmdNoWindow(cmdArg, waitForExitFalse);
                    }
                    break;

                default:
                    break;
            }

        }

        /// <summary>
        /// Jupyter Notebook を開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (selPyEnv is null) return;

            if (!selPyEnv.HasJupyter())
            {
                if (selPyEnv.Type == "O" || selPyEnv.Type == "S" || selPyEnv.Type == "V")
                {
                    var result = MessageBox.Show($"{selPyEnv.Provided} Python {selPyEnv.Ver} {selPyEnv.Bit}\n" +
                        "この環境に Jupyter Notebook がありません。\n\n Jupyter Notebook をインストールしますか？", "",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                    if (result == DialogResult.Yes)
                    {
                        lbl_VirtualEnv.Text = "Jupyter Notebook インストール中！！";
                        InstallJupyter();
                    }
                    else { return; }
                }
            }

            txtInfo.AppendText("Jupyter Notebook 準備中！！" + Environment.NewLine);

            string titleTxt = "Python " + selPyEnv.Ver + " - " + selPyEnv.Bit + " - " + selPyEnv.Provided;
            string cmdArg;
            switch (selPyEnv.Type)
            {
                case "S":
                    cmdArg = "/c " + "python -m notebook";
                    CmdRun.CmdNoWindow(cmdArg, waitForExitFalse);
                    break;

                case "O":
                    cmdArg = "/c " + "jupyter notebook";
                    CmdRun.CmdNoWindow(cmdArg, waitForExitFalse);
                    break;

                case "A":
                    // D:\Acd3\python.exe D:\Acd3\cwp.py D:\Acd3 D:\Acd3\python.exe D:\Acd3\Scripts\jupyter-notebook-script.py "%USERPROFILE%/"
                    var cwp_py = " " + selPyEnv.ExeDir + "\\cwp.py ";
                    var JpNb_script_py = selPyEnv.ScriptsPath + "\\jupyter-notebook-script.py " + @"""" + workingDir + @"/""";
                    cmdArg = "/c " + selPyEnv.ExePath + cwp_py + selPyEnv.ExeDir + " " + selPyEnv.ExePath + " " + JpNb_script_py;
                    CmdRun.CmdNoWindow(cmdArg, waitForExitFalse);

                    break;

                case "V":
                    if (File.Exists(selPyEnv.ScriptsPath + @"\activate.bat"))
                    {
                        Environment.SetEnvironmentVariable("PATH", orgEnvVarPath);
                        cmdArg = "/c " + selPyEnv.cmdActivate + " " + selPyEnv.ExeDir + " & jupyter notebook";
                        CmdRun.CmdNoWindow(cmdArg, waitForExitFalse);
                    }
                    break;

                default:
                    break;
            }
            txtInfo.Text = txtInfo.Text.Replace("Jupyter Notebook 準備中！！",
                                                "ブラウザに Jupyter Notebook を開いています。");
            lbl_VirtualEnv.Text = "仮想環境";
        }

        /// <summary>
        /// Jupyter Notebook をインストール
        /// </summary>
        private void InstallJupyter()
        {
            switch (selPyEnv.Type)
            {
                case "O":
                case "S":
                    var cmdArg1 = "/c python -m pip install --upgrade pip";
                    CmdRun.CmdWindow(cmdArg1, waitForExitTrue);

                    var cmdArg = "/c python -m pip install jupyter";
                    CmdRun.CmdWindow(cmdArg, waitForExitTrue);
                    break;

                case "A":
                    break; 
                case "V":
                    cmdArg = "/c " + selPyEnv.cmdActivate + " & python -m pip install jupyter";
                    CmdRun.CmdWindow(cmdArg, waitForExitFalse);
                    break;
            }
        }

        /// <summary>
        /// 選択されているpythonのパスを環境変数PATHに追加
        /// </summary>
        private void AddPythonPathToEnvVarPATH()
        {
            if (selPyEnv is null || selPyEnv.Type == "V") return;

            var pathSeparator = Path.PathSeparator.ToString();
            var pyPathAddedForward = selPyEnv.ExeDir + pathSeparator + selPyEnv.ScriptsPath + pathSeparator + orgEnvVarPath;
            Environment.SetEnvironmentVariable("PATH", pyPathAddedForward);
        }

        /// <summary>
        /// 環境選択オン・オフ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            switch (btnSelPyOnOff.Text)
            {
                case "▽":
                    Height = this.MaximumSize.Height;
                    btnSelPyOnOff.Text = "△";
                    panel1.Visible = true;
                    break;

                case "△":
                    Height = this.MinimumSize.Height;
                    btnSelPyOnOff.Text = "▽";
                    panel1.Visible = false;
                    break;

                default:
                    break;
            }
            // 画面のサイズを取得する
            Rectangle rect = Screen.GetWorkingArea(this);

            // Formの幅と高さを取得する
            int formWidth = this.Width;
            int formHeight = this.Height;

            // Formが画面の範囲内に収まるように調整する
            if (this.Right > rect.Right)
            {
                // Formが右端からはみ出ている場合、左側のモニターに移動させる
                foreach (Screen screen in Screen.AllScreens)
                {
                    if (screen.WorkingArea.Right <= this.Right)
                    {
                        this.Left = screen.WorkingArea.Right - formWidth;
                        break;
                    }
                }
            }
            else if (this.Left < rect.Left)
            {
                // Formが左端からはみ出ている場合、右側のモニターに移動させる
                foreach (Screen screen in Screen.AllScreens)
                {
                    if (screen.WorkingArea.Left >= this.Left)
                    {
                        this.Left = screen.WorkingArea.Left;
                        break;
                    }
                }
            }

            if (this.Bottom > rect.Bottom)
            {
                // Formが下端からはみ出ている場合、上側のモニターに移動させる
                foreach (Screen screen in Screen.AllScreens)
                {
                    if (screen.WorkingArea.Bottom <= this.Bottom)
                    {
                        this.Top = screen.WorkingArea.Bottom - formHeight;
                        break;
                    }
                }
            }
            else if (this.Top < rect.Top)
            {
                // Formが上端からはみ出ている場合、下側のモニターに移動させる
                foreach (Screen screen in Screen.AllScreens)
                {
                    if (screen.WorkingArea.Top >= this.Top)
                    {
                        this.Top = screen.WorkingArea.Top;
                        break;
                    }
                }
            }

        }

        // virtualenv のインストール
        private void Install_virtualenv()
        {
            var cmdActivate = (selPyEnv.Type == "V") ? selPyEnv.cmdActivate : "";

            var cmdArg1 = "/c " + cmdActivate + " & " + "python -m pip install --upgrade pip";
            CmdRun.CmdNoWindow(cmdArg1, waitForExitTrue);

            var cmdArg2 = "/c " + cmdActivate + " & " + "python -m pip install virtualenv";
            CmdRun.CmdNoWindow(cmdArg2, waitForExitTrue);
        }

        /// <summary>
        /// 仮想環境を作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVenvNew_Click(object sender, EventArgs e)
        {
            // anaconda、仮想環境、が選択されているときは、ダイアログを開かない
            if (selPyEnv is null || selPyEnv.Type == "A" || selPyEnv.Type == "V") return;

            // システムのPython2に virtualenv が無ければインストールする
            var isPy27 = selPyEnv.Ver.StartsWith("2.");
            var existsVirtualEnv = File.Exists(selPyEnv.ScriptsPath + @"\virtualenv.exe");
            if (isPy27 && !existsVirtualEnv) Install_virtualenv();

            // 新しい仮想環境名ダイアログ
            var newVenv = new DialogNewVenvCreate(selPyEnv, venvsDir);
            var result = newVenv.ShowDialog();

            if (result != DialogResult.OK) { return; }
            else
            {
                lbl_VirtualEnv.Text = "新しい仮想環境を作成中！！";
                var venvCmd = (isPy27) ? "virtualenv " : "venv ";
                var cmdArg = "/c python -m " + venvCmd + venvsDir + "\\" + newVenv.VenvName;
                CmdRun.CmdWindow(cmdArg, waitForExitTrue);
            }

            DeleteVenvPyBtnOnPanel2();// 仮想環境ボタンを削除
            InitializeVenvPyList();     // 仮想環境リストを更新
            CreateVenvPyBtnOnPanel2();  // 仮想環境ボタンを生成

            foreach ( var venv in pyVenvList)
            {
                if (venv is null || venv.Type != "V" || venv.Ver == "???") continue;
                selPyNo = venv.Provided.Contains(newVenv.VenvName) ? venv.TagNo : selPyNo;
            }
            SelPyBtnActivation();

            lbl_VirtualEnv.Text = "仮想環境";
        }


        /// <summary>
        /// 環境の複製(コピー)･･･新しい仮想環境に元環境のパッケージをインストールする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVenvClone_Click(object sender, EventArgs e)
        {
            // anaconda、が選択されているときは、ダイアログを開かない
            if (selPyEnv is null || selPyEnv.Type == "A") return;

            // requirements.txt を作成
            var cmdArg = "/c " + selPyEnv.cmdActivate + " python -m pip freeze --all > requirements.txt";
            CmdRun.CmdNoWindow(cmdArg, waitForExitTrue);

            // 環境がPython2で、virtualenv が無ければインストールする
            var isPy27 = selPyEnv.Ver.StartsWith("2.");
            var existsVirtualEnv = File.Exists(selPyEnv.ScriptsPath + @"\virtualenv.exe");
            if (isPy27 && !existsVirtualEnv) Install_virtualenv();

            // 新しいコピー環境名ダイアログ
            var envClone = new Dialog2VenvClone(selPyEnv, venvsDir);
            var result = envClone.ShowDialog();

            // ダイアログでキャンセルされたらメソッドを抜ける
            if (result != DialogResult.OK) { return; }

            lbl_VirtualEnv.Text = "   コピー先の仮想環境を作成中！";
            var venvCmd = (isPy27) ? "virtualenv " : "venv ";
            cmdArg = "/c python -m " + venvCmd + venvsDir + "\\" + envClone.VenvName;
            CmdRun.CmdWindow(cmdArg, waitForExitTrue);

            DeleteVenvPyBtnOnPanel2();// 仮想環境ボタンを削除
            InitializeVenvPyList();     // 仮想環境リストを更新
            CreateVenvPyBtnOnPanel2();  // 仮想環境ボタンを生成

            // コピー先の仮想環境を有効にする
            foreach (var venv in pyVenvList)
            {
                if (venv.Type != "V") continue;
                var venvName = venv.Provided.Trim('(', ')');
                if (venvName == envClone.VenvName)
                {
                    selPyNo = venv.TagNo;
                    break;
                }
            }
            SelPyBtnActivation();

            // コピー先の pip をアップグレード
            cmdArg = "/c " + selPyEnv.cmdActivate + " & python -m pip install --upgrade pip";
            CmdRun.CmdWindow(cmdArg, waitForExitTrue);

            // パッケージをインストール、
            // python -m pip install -r requirements.txt
            var titleTxt = "パッケージをインストール";
            cmdArg = "/c title " + titleTxt + " & " + selPyEnv.cmdActivate + " & python -m pip install -r requirements.txt";
            CmdRun.CmdWindow(cmdArg, waitForExitTrue);

            lbl_VirtualEnv.Text = "仮想環境";
        }

        /// <summary>
        /// パネル２の仮想環境ボタンを全て削除
        /// </summary>
        private void DeleteVenvPyBtnOnPanel2()
        {
            for (int i = splitContainer1.Panel2.Controls.Count - 1; i >= 0; i--)
            {
                var ctrl = splitContainer1.Panel2.Controls[i];
                if (ctrl is Button && ctrl.Text != "…")
                {
                    var btn = (Button)ctrl;
                    var penv = (Py_Env)btn.Tag;
                    Console.WriteLine("delete TagNo. = " + penv.TagNo);
                    Py_Env.IdxDecrement();
                    btn.Dispose();
                }
            }
        }

        /// <summary>
        /// 選択されている仮想環境を削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVenvDel_Click(object sender, EventArgs e)
        {
            if (selPyEnv.Type != "V") return;

            var result = MessageBox.Show(selPyEnv.Provided + "  この仮想環境を\n\n" + "            削除しますか？\n\n\nはい(Y) をクリックするとゴミ箱に移動します。",
                "仮想環境の削除",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                lbl_VirtualEnv.Text = "仮想環境リストを更新中！！";
                var venvPath = selPyEnv.ExeDir.Substring(0, selPyEnv.ExeDir.LastIndexOf(@"\Scripts"));
                if (DeleteVenvDir(venvPath))
                {   // 削除成功
                    DeleteVenvPyBtnOnPanel2();  // 仮想環境ボタンを削除
                    InitializeVenvPyList();     // 仮想環境リストを更新
                    CreateVenvPyBtnOnPanel2();  // 仮想環境ボタンを生成
                    selPyNo = (selPyNo > (pyEnvList.Count + pyVenvList.Count)) ? selPyNo - 1 : selPyNo;
                    SelPyBtnActivation();
                }

                lbl_VirtualEnv.Text = "仮想環境";
            }
        }

        /// <summary>
        /// 仮想環境をゴミ箱に移す
        /// </summary>
        /// <param name="venvDir"></param>
        /// <returns></returns>
        private bool DeleteVenvDir(string venvDir)
        {
            try
            {
                // 第一引数で指定したディレクトリをゴミ箱に移す
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(venvDir,
                    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                    Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin,
                    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            btnVenvNew_Click(sender, e);
        }

        private void tStripMenu_DelVenv_Click(object sender, EventArgs e)
        {
            btnVenvDel_Click(sender, e);
        }

        private void tStripMenu_CopyEnv_Click(object sender, EventArgs e)
        {
            btnVenvClone_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1_Click(sender, e);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            toolStripMenuItem2_Click(sender, e);
        }

        private void tStripBtn_Idle_Click(object sender, EventArgs e)
        {
            toolStripMenuItem3_Click(sender, e);
        }

        private void tStripBtn_JpNb_Click(object sender, EventArgs e)
        {
            toolStripMenuItem4_Click(sender, e);
        }

        private void btnReqTxtOut_Click(object sender, EventArgs e)
        {
            var msgText = "選択環境のパッケージリストを\n" +
                          "作業フォルダに作成します。\n" +
                          "\n内部実行コマンド\n pip freeze > requirements.txt";
            var msgCaption = "パッケージリスト出力";
            var result = MessageBox.Show(msgText, msgCaption,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.OK) return;

            string cmdArg;
            if (selPyEnv.Type == "V")
            {
                Environment.SetEnvironmentVariable("PATH", orgEnvVarPath);
                cmdArg = "/c " + selPyEnv.cmdActivate + " & python -m pip freeze > requirements.txt";
                CmdRun.CmdWindow(cmdArg, waitForExitTrue);
            }
            else
            {
                cmdArg = "/c python -m pip freeze > requirements.txt";
                CmdRun.CmdWindow(cmdArg, waitForExitTrue);
            }
            MessageBox.Show("パッケージリスト\nrequirements.txt\nを作成しました。");
        }

        private void btnReqTxtIn_Click(object sender, EventArgs e)
        {
            var msgText = "パッケージリストを読込\n" +
                          "選択環境にインストールします。\n" +
                          "\n内部実行コマンド\n pip install -r requirements.txt";
            var msgCaption = "パッケージリスト読込";
            var result = MessageBox.Show(msgText, msgCaption,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.OK) return;

            string cmdArg;
            if (selPyEnv.Type == "V")
            {
                Environment.SetEnvironmentVariable("PATH", orgEnvVarPath);
                cmdArg = "/c " + selPyEnv.ScriptsPath + @"\activate.bat & python -m pip install -r requirements.txt";
                CmdRun.CmdWindow(cmdArg, waitForExitTrue);
            }
            else
            {
                cmdArg = "/c python -m pip install -r requirements.txt";
                CmdRun.CmdWindow(cmdArg, waitForExitTrue);
            }
            MessageBox.Show("requirements.txt を読込、\nパッケージをインストールしました。");
        }

        private void tStripMenu_ReqTxtOut_Click(object sender, EventArgs e)
        {
            btnReqTxtIn_Click(sender, e);
        }

        private void tStripMenu_ReqTxt_In_Click(object sender, EventArgs e)
        {
            btnReqTxtIn_Click(sender, e);
        }
    }
}
