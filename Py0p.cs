using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HamuQonda
{
    internal class Py0p
    {
        internal struct PyInfo
        {
            internal string Ver { get; set; }
            internal string ExePath { get; set; }
            internal string Type { get; set; }
            internal bool Valid { get; set; }

            public PyInfo(string ver, string exePath, string type, bool valid)
            {
                Ver= ver;
                ExePath= exePath;
                Type= type;
                Valid= valid;
            }
        }

        private List<PyInfo> _pyInfos;
        public List<PyInfo> PyInfos
        {
            get { return _pyInfos; }
        }
        public int Length { get; }


        public Py0p()
        {
            string cmdArg = "/c py -0p";
            string[] Py0p = CmdRun.Get_Out_Err(cmdArg);
            string strOut = Py0p[CmdRun.OutIdx];
            string strErr = Py0p[CmdRun.ErrIdx];

            // pythonが無い
            if (strOut == "") { return; }

            //
            _pyInfos = new List<PyInfo>();
            var pys = strOut.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < pys.Length; i++)
            {
                var py = pys[i].Trim();

                // バージョン／供給元
                var ver = py.Split()[0];
                ver = ver.Contains("-V:3") ? ver : ver.Replace("-3.", "-V:3.");
                ver = ver.Contains("-V:2") ? ver : ver.Replace("-2.", "-V:2.");

                // pythonの.exeのフルパス
                var exePath = py.Substring(ver.Length).Trim(new char[]{ ' ','*'});

                // C:\Users\nakse\AppData\Local\Microsoft\WindowsApps\PythonSoftwareFoundation.Python.3.8_qbz5n2kfra8p0\python3.8.exe
                // C:\Users\nakse\AppData\Local\Microsoft\WindowsApps\PythonSoftwareFoundation.Python.3.9_qbz5n2kfra8p0\python.exe
                // C:\Users\nakse\AppData\Local\Packages             \PythonSoftwareFoundation.Python.3.9_qbz5n2kfra8p0\LocalCache\local-packages\Python39\Scripts

                // C:\Program Files\WindowsApps\PythonSoftwareFoundation.Python.3.8_3.8.2800.0_x64__qbz5n2kfra8p0\python3.8.exe

                // MSストアのpython？
                string MsWinAppPySoftFndtion = @"\Microsoft\WindowsApps\PythonSoftwareFoundation.";
                string MsPySearchDir = FormHQ.localAppData + @"\Microsoft\WindowsApps";
                string type;
                if (exePath.Contains(MsWinAppPySoftFndtion) || !exePath.Contains(@":\"))
                {
                    type = "S";
                    var verVal = ver.Split(new char[] { ' ', '-', 'V', ':' }, StringSplitOptions.RemoveEmptyEntries)[0];
                    var searchPattern = "PythonSoftwareFoundation.Python." + verVal + "*";
                    var msPyDirs = Directory.GetDirectories(MsPySearchDir, searchPattern);
                    exePath = (msPyDirs.Length > 0) ? msPyDirs[0] + @"\python.exe" : exePath;
                }
                else if (ver.Contains("/Anaconda"))         type = "A";
                else if (exePath.EndsWith("python.exe"))    type = "O";
                else                                        type = "?";

                var valid = PythonExists(exePath);
                Console.WriteLine($"{valid} : {exePath}");

                _pyInfos.Add(new PyInfo(ver, exePath, type, valid));

            }
            Length = _pyInfos.Count;

            foreach (var py in _pyInfos) { Console.WriteLine(py.Valid + " " + py.Ver + " " + py.ExePath); }
        }

        internal bool PythonExists(string exePath)
        {
            var cmdArg = "/c \"" + exePath + "\" -V";
            var result = CmdRun.Get_Out_Err(cmdArg);
            if (result[CmdRun.OutIdx]=="" && result[CmdRun.ErrIdx].StartsWith("Python 2.7")) { return true; }
            return result[CmdRun.OutIdx] != "";
        }

    }
}
