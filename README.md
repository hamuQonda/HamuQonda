# HamuQonda ( Python environment switching launcher with GUI )
 ハムコンダ（GUIでPython環境切り替えランチャー）<br>
It is software that makes it easy to use multiple Python versions and virtual environments on Windows.<br>
  With the working folder as the current directory,<br>
  activate the environment you want to use and open the following tools with one click.<br>
  (Command prompt, Python interpreter, IDLE, JupyterNotebook)<br>

    Windowsでの複数Pythonバージョン・仮想環境 を簡単に使えるようにするソフトです。
    作業フォルダをカレントディレクトリとして、
    使いたい環境を有効化し下記ツールを1クリックで開けます。
    ( コマンドプロンプト、Pythonインタプリタ、IDLE、JupyterNotebook ）

## Features of HamuQondano ( HamuQondanoの特徴 )
### 1. Do not pollute the PATH environment variable on the system side. ( システム環境変数PATHを汚さない )
  The selected Python environment path is automatically added to the PATH environment variable.<br>
  Thus, you can run Python with the python command.<br>
  This PATH is a valid PATH only for the opened tool (eg Command Prompt).<br>
  The PATH environment variable on the system side remains clean.<br>
  If a virtual environment is selected, each tool will open with the virtual environment activated.<br>

    選択されているPython環境のパスが環境変数PATHに自動的に追加されます。
    その為、pythonコマンド で Python を実行できます。
    このPATHは開いたツール（例えばコマンドプロンプト）だけに有効なPATHになります。
    システム側の環境変数PATHはきれいなままです。
    仮想環境が選択されている場合、各ツールは 仮想環境がアクティベートされた状態で開かれます。
### 2. Able to understand the type and version of Python. ( Pythonの種類・バージョンを把握できる )
  You can figure out where Python was installed from on your system.<br>
  Is it from the official Python, Microsoft Store Python, or Anaconda Python?<br>
  Python versions are shown up to major , minor , micro numbers.<br>
  The location of python.exe is also displayed.<br>
  
    システム中のPythonがどこからインストールされたのかを把握できます。
    Python公式からなのか、マイクロソフトストアのPythonなのか、AnacondaのPythonなのか
    Pythonバージョンは、メジャー.マイナー.マイクロ まで表示されます。
    又、python.exeの場所も表示されます。

## Installation and the first thing to do ( インストールと最初にすべき事 )
### 1. To install, simply place HamuQonda.exe in the desired folder.
    HamuQonda.exeを任意のフォルダに置くだけでOKです。

### 2. Set up a working folder and a storage folder for the virtual environment.
    作業フォルダと仮想環境格納フォルダを確認してください。
  The working folder settings are located at the top of the window.<br>
Click on the triangle button to expand the window.<br>
The folder settings for storing virtual environments are at the bottom.<br>

    作業フォルダーの設定は、ウィンドウの上部にあります。
    三角形のボタンをクリックして、ウィンドウを拡大します。
    仮想環境の格納フォルダ設定は一番下にあります。

