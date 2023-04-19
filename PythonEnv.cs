using System;
using System.IO;
using System.Linq;

namespace HamuQonda
{
    /// <summary>
    /// python環境情報のクラス
    /// </summary>
    internal class Py_Env
    {
        public string ExePath { get; }      // python.exeの full ExePath
        public string ExeDir { get; }       // python.exeのあるディレクトリ
        public string ProgramFilesDir { get; }
        public string Ver { get; }          // pythonバージョン
        public string Type { get; }         // A=Anaconda, O=Python.org, S=Microsoft Store, V=Virtual environment
        public string Provided { get; }     // pythonの提供元、又は仮想環境名
        public string Bit { get; }          // 何bit用Pythonか、32 or 64
        public string ScriptsPath { get; }  // Scriptsフォルダ
        public string cmdActivate { get; }  // 仮想環境を有効にするコマンド
        public string HomePyPath { get; }   // 仮想環境のベースとなるpython
        public int TagNo { get; }      // 環境番号、1･･からの連番


        // ローカルアプリケーションデータ  C:\Users\【ユーザ名】\AppData\Local
        private readonly string localAppData = Environment.GetEnvironmentVariable("LOCALAPPDATA");


        private static int idx;
        static Py_Env() { idx = 0; } //静的コンストラクタ

        internal static void IdxDecrement()
        {
            --idx;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="py">py -0p 出力の１行</param>
        public Py_Env(string py)
        {
            // pyの値の例 -V:3.7  D:\Python\Python37\python.exe

            // python.exeのパス
            ExePath = py.Substring(py.IndexOf(@":\") - 1);
            //// 空白を含むパスに対応するために、ドライブ文字から最後までを " で括る
            //if (ExePath.Contains(" ")) { ExePath = "\"" + ExePath + "\""; }

            // C:\Program Files\WindowsApps\PythonSoftwareFoundation.Python.3.8_3.8.2800.0_x64__qbz5n2kfra8p0\python3.8.exe
            // C:\Users\nakse\AppData\Local\Microsoft\WindowsApps\PythonSoftwareFoundation.Python.3.8_qbz5n2kfra8p0\python3.8.exe

            // Microsoft Store版なら ProgramFilesDir を設定
            if (ExePath.Contains(@"\Program Files\WindowsApps\PythonSoftwareFoundation."))
            {
                // var afterID = ExePath.Substring(ExePath.LastIndexOf("_"));
                var afterID = Path.GetDirectoryName(ExePath.Substring(ExePath.LastIndexOf("_"))) + "\\python.exe";
                var ver = py.Split(new char[] {' ','-',':','V','e'},StringSplitOptions.RemoveEmptyEntries)[0];
                //var Ver = ver.Substring(ver.IndexOf("-V:") + 3);
                ProgramFilesDir = ExePath;
                ExePath = localAppData + @"\Microsoft\WindowsApps\PythonSoftwareFoundation.Python." + ver + afterID;
            }

            ExeDir = Path.GetDirectoryName(ExePath);    // python.exeのあるディレクトリ

            // python の詳細情報を取得(python -VV の出力)
            var pythonInfo = GetPyVV(py, ExePath);
            // ex. pythonInfo = "Python 3.7.9 (tags/v3.7.9:13c94747c7, Aug 17 2020, 18:58:18) [MSC v.1900 64 bit (AMD64)]"

            // pythonのバージョン
            Ver = (pythonInfo == "") ? "???" : pythonInfo.Split()[1];

            // pythonの種類
            if (Venv(py))      { var pySplit = py.Split('\\');
                                      Type = "V"; Provided = "(" + pySplit[pySplit.Length - 3] + ")"; }
            else if (Anaconda(py))       { Type = "A"; Provided = "Anaconda"; }
            else if (MsStore(py))   { Type = "S"; Provided = "Microsoft Store"; }
            else if (PyOrg(py))     { Type = "O"; Provided = "python.org"; }
            else                    { Type = "?"; Provided = "???"; }

            // 何bit用のpython？ 32 or 64
            Bit = (pythonInfo == "") ? "???" : pythonInfo.Substring(pythonInfo.IndexOf(" bit ") - 2, 7);

            // Scriptsフォルダ
            ScriptsPath = (Type == "V" && pythonInfo != "") ? ExeDir : GetScriptsPath(ExeDir);

            // cmdActivate 仮想環境を有効にするコマンド
            cmdActivate = (Type == "V" || Type == "A") ? ScriptsPath + "\\activate.bat" : "";

            // 仮想環境のベースとなるpython
            HomePyPath = GetHomePyPath(ExeDir);

            // TagNo 、1･･からの連番
            TagNo = ++idx;
            Console.WriteLine(idx);
        }


        private string GetHomePyPath(string exeDir)
        {
            if (File.Exists(exeDir.Replace("Scripts", "pyvenv.cfg")) == false) return "";
            //  ↓ pyvenv.cfg 内の1行目例
            // home = D:\Python\Python37
            var homePyPath = File.ReadLines(exeDir.Replace("Scripts", "pyvenv.cfg")).ToArray()[0].Replace("home = ", "");
            return homePyPath;
        }


        /// <summary>
        /// python の詳細情報を得る
        /// </summary>
        /// <param name="py"></param>
        /// <param name="exePath"></param>
        /// <returns></returns>
        private string GetPyVV(string py, string exePath)
        {
            // python詳細情報を得るためのコマンド
            var cmdArg = @"/c " + exePath + " -VV";

            if (py.Contains("-V:2") || py.Contains("-Ve:2"))
            {
                // Python 2 は python -VV で詳細表示が無い為、下記コマンドで詳細を得る
                cmdArg = "/c " + exePath + " -c " + "\"import sys;print(sys.version)\"";
            }

            var result = CmdRun.Get_Out_Err(cmdArg)[CmdRun.OutIdx]; // python -VV の結果

            if (result.StartsWith("例外"))    return "";
            if (result.StartsWith("Python ")) return result;
            if (result.StartsWith("2."))      return "Python " + result;

            return "";
        }


        /// <summary>
        /// Anaconda 版の Pythonか？
        /// </summary>
        /// <param name="py"></param>
        /// <returns></returns>
        private bool Anaconda(string py)
        {
            return py.Contains("/Anaconda");
        }


        /// <summary>
        /// Microsoft Store 版の Pythonか？
        /// </summary>
        /// <param name="py">py -0p </param>
        /// <returns></returns>
        private bool MsStore(string py)
        {
            var result = py.Contains(@"\WindowsApps\PythonSoftwareFoundation.Python.") ||
                        !py.Contains(@":\");
            return result;
        }


        /// <summary>
        /// python.org 版の Pythonか？
        /// </summary>
        /// <param name="py"></param>
        /// <returns></returns>
        private bool PyOrg(string py)
        {
            if (MsStore(py) || Anaconda(py)) { return false; }
            return double.TryParse(py.Substring(py.IndexOf(":") + 1, 3), out _);
        }


        /// <summary>
        /// 仮想環境のpythonか？
        /// </summary>
        /// <param name="py"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool Venv(string py)
        {
            return py.StartsWith("-Ve:");
        }


// C:\Users\nakse\AppData\Local\Microsoft\WindowsApps\PythonSoftwareFoundation.Python.3.9_qbz5n2kfra8p0\python.exe
// C:\Users\nakse\AppData\Local\Packages             \PythonSoftwareFoundation.Python.3.9_qbz5n2kfra8p0\LocalCache\local-packages\Python39\Scripts

        /// <summary>
        /// "Scripts"フォルダpathを返す
        /// </summary>
        /// <param name="pythonExeDir"></param>
        /// <returns></returns>
        private string GetScriptsPath(string pythonExeDir)
        {
            if(!Directory.Exists(ExeDir)) { return ""; }

            var pathBeforScripts = pythonExeDir;
            if (Type == "S")
            {
                var verNumsArry = Ver.Split('.');
                var pythonXX = "Python" + verNumsArry[0] + verNumsArry[1];
                pathBeforScripts = pythonExeDir.Replace("Microsoft\\WindowsApps", "Packages") + "\\LocalCache\\local-packages\\" + pythonXX;
            }
            
            var scriptsDirs = Directory.GetDirectories(pathBeforScripts, "Scripts");
            if (scriptsDirs.Length == 1)
                return scriptsDirs[0];
            else return "";
        }

        /// <summary>
        /// Jupyter Notebook がインストールされているか
        /// </summary>
        /// <returns></returns>
        public bool HasJupyter()
        {
          /*Type == "O"*/var cmdArg = " /c jupyter notebook --version";
            if (Type == "S") cmdArg = " /c python -m notebook --version";
            if (Type == "A") cmdArg = " /c " + ScriptsPath + @"\activate.bat & jupyter notebook --version";
            if (Type == "V") cmdArg = " /c " + ScriptsPath + @"\activate.bat & jupyter notebook --version";

            var jpnbVer = CmdRun.Get_Out_Err(cmdArg)[CmdRun.OutIdx];
            // jupyter notebook のバージョンが返ってきたら true 無かったら false
            return jpnbVer != "";
        }

        public override string ToString()
        {
            if (Type == "V")
                return Provided + " Python " + Ver + " - " + Bit.Trim();
            else
                return "Python " + Ver + " - " + Bit.Trim() + " <" + Provided + ">";
        }

    }
}