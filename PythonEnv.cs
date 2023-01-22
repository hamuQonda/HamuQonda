using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamuQonda
{
    internal class PythonEnv
    {
        private string type;                // A=Anaconda, D=Default Python, V=Virtual environment, S=Store
        private string name;                // 環境名
        private string path;                // python.exeの場所(フォルダ full path)
        private string scriptsPath;         // Scriptsフォルダのpath
        private string origPyPathOfVenv;    // 仮想環境の元python path
        private string idlePywPath;         // idlelib\idele.pyw のpath
        private string ver;                 // pythonバージョン
        private string bit;                 // 何bit用Pythonか、32 or 64


        public PythonEnv()
        {

        }
    }
}
