using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HamuQonda
{
    public partial class Dialog2VenvClone : Form
    {
        private bool txtChageFirst = true;

        public string VenvName
        {
            get { return textBox1.Text; }
        }

        private Py_Env selPy;
        private readonly string venvsDir;

        internal Dialog2VenvClone(Py_Env _selPyEnv, String _venvsDir)
        {
            InitializeComponent();
            selPy = _selPyEnv;
            venvsDir = _venvsDir;
        }


        private void Dialog2VenvClone_Load(object sender, EventArgs e)
        {
            Text = "コピー - 元環境を新しい仮想環境へ複製する";
            lbl_SourceEnv.Text = "コピー元：" + selPy.ToString();

            lbl_venvsDir.Text = venvsDir + "\\";

            lbl_newVenvName.Text = "";
            lbl_newVenvName.Left = lbl_venvsDir.Left + lbl_venvsDir.Width - 4;

            textBox1.Focus();
            textBox1.Select();
            txtChageFirst = false;

            create_Btn.Enabled = false;
        }


        private void Cancel_Btn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Create_Btn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private string bkupText = string.Empty;
        /// <summary>
        /// 新しい仮想環境フォルダ名に使える文字のチェック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtChageFirst) { return; }

            lbl_newVenvName.Text = textBox1.Text;
            lbl_newVenvName.ForeColor = Color.Black;
            // 半角英数
            if (textBox1.TextLength > 0)
            {
                if (!Is.OnlyAlphanumeric2(textBox1.Text))
                {
                    lbl_newVenvName.Text = bkupText;
                    textBox1.Text = bkupText;
                    textBox1.Select(textBox1.Text.Length, 0);
                }
            }

            bkupText = textBox1.Text;   // 現状のテキストを保持
            var venvFolderPath = Path.Combine(venvsDir, lbl_newVenvName.Text);
            if (Directory.Exists(venvFolderPath))
            {
                lbl_newVenvName.BackColor = Color.Red;
                lbl_newVenvName.ForeColor = Color.DarkGreen;
                create_Btn.Enabled = false;
            }
            else
            {
                lbl_newVenvName.BackColor = Color.Snow;
                lbl_newVenvName.ForeColor = Color.Black;
                create_Btn.Enabled = true;
            }
        }

    }
}