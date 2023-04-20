namespace HamuQonda
{
    partial class FormHQ
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHQ));
            this.kakunin = new System.Windows.Forms.TextBox();
            this.lbl_workingFolder = new System.Windows.Forms.Label();
            this.txtBoxWorkDir = new System.Windows.Forms.TextBox();
            this.btnWdirChange = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tStripMenu_Cmd = new System.Windows.Forms.ToolStripMenuItem();
            this.tStripMenu_PyIp = new System.Windows.Forms.ToolStripMenuItem();
            this.tStripMenu_Idle = new System.Windows.Forms.ToolStripMenuItem();
            this.tStripMenu_JpNb = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tStripMenu_NewVenv = new System.Windows.Forms.ToolStripMenuItem();
            this.tStripMenu_CopyEnv = new System.Windows.Forms.ToolStripMenuItem();
            this.tStripMenu_DelVenv = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tStripMenu_ReqTxtOut = new System.Windows.Forms.ToolStripMenuItem();
            this.tStripMenu_ReqTxt_In = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnVenvsDirChange = new System.Windows.Forms.Button();
            this.btnSelPyOnOff = new System.Windows.Forms.Button();
            this.txtBoxVenvsDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReqTxtIn = new System.Windows.Forms.Button();
            this.btnReqTxtOut = new System.Windows.Forms.Button();
            this.btnVenvNew = new System.Windows.Forms.Button();
            this.btnVenvDel = new System.Windows.Forms.Button();
            this.btnVenvClone = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_VirtualEnv = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.gboxInfo = new System.Windows.Forms.GroupBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tStripBtn_Cmd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tStripBtn_PyIp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tStripBtn_Idle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tStripBtn_JpNb = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gboxInfo.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kakunin
            // 
            this.kakunin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.kakunin.Font = new System.Drawing.Font("Ricty Diminished Discord", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.kakunin.Location = new System.Drawing.Point(555, 300);
            this.kakunin.Multiline = true;
            this.kakunin.Name = "kakunin";
            this.kakunin.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kakunin.Size = new System.Drawing.Size(1087, 180);
            this.kakunin.TabIndex = 0;
            this.kakunin.WordWrap = false;
            // 
            // lbl_workingFolder
            // 
            this.lbl_workingFolder.AutoSize = true;
            this.lbl_workingFolder.Font = new System.Drawing.Font("Ricty Diminished", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_workingFolder.Location = new System.Drawing.Point(9, 12);
            this.lbl_workingFolder.Name = "lbl_workingFolder";
            this.lbl_workingFolder.Size = new System.Drawing.Size(91, 13);
            this.lbl_workingFolder.TabIndex = 1;
            this.lbl_workingFolder.Text = "作業フォルダー";
            this.lbl_workingFolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lbl_workingFolder, "カレントディレクトリ(現在のフォルダ)");
            // 
            // txtBoxWorkDir
            // 
            this.txtBoxWorkDir.BackColor = System.Drawing.Color.White;
            this.txtBoxWorkDir.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxWorkDir.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtBoxWorkDir.Font = new System.Drawing.Font("Ricty Diminished Discord", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtBoxWorkDir.Location = new System.Drawing.Point(93, 12);
            this.txtBoxWorkDir.Name = "txtBoxWorkDir";
            this.txtBoxWorkDir.ReadOnly = true;
            this.txtBoxWorkDir.Size = new System.Drawing.Size(445, 14);
            this.txtBoxWorkDir.TabIndex = 0;
            this.txtBoxWorkDir.TabStop = false;
            // 
            // btnWdirChange
            // 
            this.btnWdirChange.BackColor = System.Drawing.Color.Gainsboro;
            this.btnWdirChange.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnWdirChange.FlatAppearance.BorderSize = 0;
            this.btnWdirChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWdirChange.Location = new System.Drawing.Point(539, 9);
            this.btnWdirChange.Name = "btnWdirChange";
            this.btnWdirChange.Size = new System.Drawing.Size(27, 20);
            this.btnWdirChange.TabIndex = 3;
            this.btnWdirChange.Text = "…";
            this.btnWdirChange.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.btnWdirChange, "作業フォルダの変更");
            this.btnWdirChange.UseVisualStyleBackColor = false;
            this.btnWdirChange.Click += new System.EventHandler(this.BtnWdirChange_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStripMenu_Cmd,
            this.tStripMenu_PyIp,
            this.tStripMenu_Idle,
            this.tStripMenu_JpNb,
            this.toolStripSeparator1,
            this.tStripMenu_NewVenv,
            this.tStripMenu_CopyEnv,
            this.tStripMenu_DelVenv,
            this.toolStripSeparator2,
            this.tStripMenu_ReqTxtOut,
            this.tStripMenu_ReqTxt_In});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(188, 214);
            // 
            // tStripMenu_Cmd
            // 
            this.tStripMenu_Cmd.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tStripMenu_Cmd.Image = global::HamuQonda.Properties.Resources.env_prpt;
            this.tStripMenu_Cmd.Name = "tStripMenu_Cmd";
            this.tStripMenu_Cmd.Size = new System.Drawing.Size(187, 22);
            this.tStripMenu_Cmd.Text = "コマンドプロンプト";
            this.tStripMenu_Cmd.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // tStripMenu_PyIp
            // 
            this.tStripMenu_PyIp.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tStripMenu_PyIp.Image = global::HamuQonda.Properties.Resources.pinterp;
            this.tStripMenu_PyIp.Name = "tStripMenu_PyIp";
            this.tStripMenu_PyIp.Size = new System.Drawing.Size(187, 22);
            this.tStripMenu_PyIp.Text = "Pythonインタプリタ";
            this.tStripMenu_PyIp.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // tStripMenu_Idle
            // 
            this.tStripMenu_Idle.Image = global::HamuQonda.Properties.Resources.py_IDLE;
            this.tStripMenu_Idle.Name = "tStripMenu_Idle";
            this.tStripMenu_Idle.Size = new System.Drawing.Size(187, 22);
            this.tStripMenu_Idle.Text = "IDLE";
            this.tStripMenu_Idle.Click += new System.EventHandler(this.ToolStripMenuItem3_Click);
            // 
            // tStripMenu_JpNb
            // 
            this.tStripMenu_JpNb.Image = global::HamuQonda.Properties.Resources.jupyterN;
            this.tStripMenu_JpNb.Name = "tStripMenu_JpNb";
            this.tStripMenu_JpNb.Size = new System.Drawing.Size(187, 22);
            this.tStripMenu_JpNb.Text = "Jupyter Notebook";
            this.tStripMenu_JpNb.Click += new System.EventHandler(this.ToolStripMenuItem4_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // tStripMenu_NewVenv
            // 
            this.tStripMenu_NewVenv.Image = ((System.Drawing.Image)(resources.GetObject("tStripMenu_NewVenv.Image")));
            this.tStripMenu_NewVenv.Name = "tStripMenu_NewVenv";
            this.tStripMenu_NewVenv.Size = new System.Drawing.Size(187, 22);
            this.tStripMenu_NewVenv.Text = "新しい仮想環境を作成";
            this.tStripMenu_NewVenv.Click += new System.EventHandler(this.ToolStripMenuItem5_Click);
            // 
            // tStripMenu_CopyEnv
            // 
            this.tStripMenu_CopyEnv.Image = global::HamuQonda.Properties.Resources.copy_icon_152214;
            this.tStripMenu_CopyEnv.Name = "tStripMenu_CopyEnv";
            this.tStripMenu_CopyEnv.Size = new System.Drawing.Size(187, 22);
            this.tStripMenu_CopyEnv.Text = "新しい仮想環境へコピー";
            this.tStripMenu_CopyEnv.Click += new System.EventHandler(this.TStripMenu_CopyEnv_Click);
            // 
            // tStripMenu_DelVenv
            // 
            this.tStripMenu_DelVenv.Image = global::HamuQonda.Properties.Resources._602_ex_h;
            this.tStripMenu_DelVenv.Name = "tStripMenu_DelVenv";
            this.tStripMenu_DelVenv.Size = new System.Drawing.Size(187, 22);
            this.tStripMenu_DelVenv.Text = "仮想環境の削除";
            this.tStripMenu_DelVenv.Click += new System.EventHandler(this.TStripMenu_DelVenv_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(184, 6);
            // 
            // tStripMenu_ReqTxtOut
            // 
            this.tStripMenu_ReqTxtOut.Image = global::HamuQonda.Properties.Resources.req_Out;
            this.tStripMenu_ReqTxtOut.Name = "tStripMenu_ReqTxtOut";
            this.tStripMenu_ReqTxtOut.Size = new System.Drawing.Size(187, 22);
            this.tStripMenu_ReqTxtOut.Text = "requirements.txt 出力";
            this.tStripMenu_ReqTxtOut.Click += new System.EventHandler(this.TStripMenu_ReqTxtOut_Click);
            // 
            // tStripMenu_ReqTxt_In
            // 
            this.tStripMenu_ReqTxt_In.Image = global::HamuQonda.Properties.Resources.req_Input;
            this.tStripMenu_ReqTxt_In.Name = "tStripMenu_ReqTxt_In";
            this.tStripMenu_ReqTxt_In.Size = new System.Drawing.Size(187, 22);
            this.tStripMenu_ReqTxt_In.Text = "requirements.txt 読込";
            this.tStripMenu_ReqTxt_In.Click += new System.EventHandler(this.TStripMenu_ReqTxt_In_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // btnVenvsDirChange
            // 
            this.btnVenvsDirChange.BackColor = System.Drawing.Color.Gainsboro;
            this.btnVenvsDirChange.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnVenvsDirChange.FlatAppearance.BorderSize = 0;
            this.btnVenvsDirChange.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnVenvsDirChange.Location = new System.Drawing.Point(537, 535);
            this.btnVenvsDirChange.Name = "btnVenvsDirChange";
            this.btnVenvsDirChange.Size = new System.Drawing.Size(28, 20);
            this.btnVenvsDirChange.TabIndex = 17;
            this.btnVenvsDirChange.Text = "…";
            this.btnVenvsDirChange.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.btnVenvsDirChange, "仮想環境格納フォルダの変更");
            this.btnVenvsDirChange.UseVisualStyleBackColor = false;
            this.btnVenvsDirChange.Click += new System.EventHandler(this.BtnVenvSearchDirChange_Click);
            // 
            // btnSelPyOnOff
            // 
            this.btnSelPyOnOff.BackColor = System.Drawing.SystemColors.Control;
            this.btnSelPyOnOff.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnSelPyOnOff.FlatAppearance.BorderSize = 0;
            this.btnSelPyOnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelPyOnOff.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSelPyOnOff.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSelPyOnOff.Location = new System.Drawing.Point(257, 117);
            this.btnSelPyOnOff.Name = "btnSelPyOnOff";
            this.btnSelPyOnOff.Size = new System.Drawing.Size(73, 40);
            this.btnSelPyOnOff.TabIndex = 19;
            this.btnSelPyOnOff.Text = "△";
            this.toolTip1.SetToolTip(this.btnSelPyOnOff, "環境の選択(開く／閉じる)");
            this.btnSelPyOnOff.UseVisualStyleBackColor = false;
            this.btnSelPyOnOff.Click += new System.EventHandler(this.Button3_Click);
            // 
            // txtBoxVenvsDir
            // 
            this.txtBoxVenvsDir.BackColor = System.Drawing.Color.White;
            this.txtBoxVenvsDir.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtBoxVenvsDir.Font = new System.Drawing.Font("Ricty Diminished Discord", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtBoxVenvsDir.Location = new System.Drawing.Point(153, 537);
            this.txtBoxVenvsDir.Name = "txtBoxVenvsDir";
            this.txtBoxVenvsDir.ReadOnly = true;
            this.txtBoxVenvsDir.Size = new System.Drawing.Size(384, 21);
            this.txtBoxVenvsDir.TabIndex = 27;
            this.txtBoxVenvsDir.TabStop = false;
            this.toolTip1.SetToolTip(this.txtBoxVenvsDir, "このフォルダ下の仮想環境が\r\n上のリストに表示されます。");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ricty Diminished Discord", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(15, 538);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "仮想環境の格納フォルダ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.label1, "このフォルダ下の仮想環境が\r\n上のリストに表示されます。\r\n");
            // 
            // btnReqTxtIn
            // 
            this.btnReqTxtIn.BackgroundImage = global::HamuQonda.Properties.Resources.req_Input;
            this.btnReqTxtIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReqTxtIn.Location = new System.Drawing.Point(183, 5);
            this.btnReqTxtIn.Name = "btnReqTxtIn";
            this.btnReqTxtIn.Size = new System.Drawing.Size(33, 33);
            this.btnReqTxtIn.TabIndex = 30;
            this.toolTip1.SetToolTip(this.btnReqTxtIn, "パッケージリスト 読込 \r\n requirements.txt の内容で\r\n選択環境にパッケージをインストール\r\n");
            this.btnReqTxtIn.UseVisualStyleBackColor = true;
            this.btnReqTxtIn.Click += new System.EventHandler(this.BtnReqTxtIn_Click);
            // 
            // btnReqTxtOut
            // 
            this.btnReqTxtOut.BackgroundImage = global::HamuQonda.Properties.Resources.req_Out;
            this.btnReqTxtOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReqTxtOut.Location = new System.Drawing.Point(144, 5);
            this.btnReqTxtOut.Name = "btnReqTxtOut";
            this.btnReqTxtOut.Size = new System.Drawing.Size(33, 33);
            this.btnReqTxtOut.TabIndex = 29;
            this.toolTip1.SetToolTip(this.btnReqTxtOut, "パッケージリスト 出力 \r\n requirements.txt を\r\n作業フォルダに作成");
            this.btnReqTxtOut.UseVisualStyleBackColor = true;
            this.btnReqTxtOut.Click += new System.EventHandler(this.BtnReqTxtOut_Click);
            // 
            // btnVenvNew
            // 
            this.btnVenvNew.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVenvNew.BackgroundImage")));
            this.btnVenvNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVenvNew.Location = new System.Drawing.Point(4, 5);
            this.btnVenvNew.Name = "btnVenvNew";
            this.btnVenvNew.Size = new System.Drawing.Size(33, 33);
            this.btnVenvNew.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnVenvNew, "仮想環境の作成");
            this.btnVenvNew.UseVisualStyleBackColor = true;
            this.btnVenvNew.Click += new System.EventHandler(this.BtnVenvNew_Click);
            // 
            // btnVenvDel
            // 
            this.btnVenvDel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVenvDel.BackgroundImage")));
            this.btnVenvDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVenvDel.Location = new System.Drawing.Point(96, 5);
            this.btnVenvDel.Name = "btnVenvDel";
            this.btnVenvDel.Size = new System.Drawing.Size(33, 33);
            this.btnVenvDel.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btnVenvDel, "仮想環境の削除");
            this.btnVenvDel.UseVisualStyleBackColor = true;
            this.btnVenvDel.Click += new System.EventHandler(this.BtnVenvDel_Click);
            // 
            // btnVenvClone
            // 
            this.btnVenvClone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVenvClone.BackgroundImage")));
            this.btnVenvClone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVenvClone.Location = new System.Drawing.Point(43, 5);
            this.btnVenvClone.Name = "btnVenvClone";
            this.btnVenvClone.Size = new System.Drawing.Size(33, 33);
            this.btnVenvClone.TabIndex = 12;
            this.toolTip1.SetToolTip(this.btnVenvClone, "環境の複製");
            this.btnVenvClone.UseVisualStyleBackColor = true;
            this.btnVenvClone.Click += new System.EventHandler(this.BtnVenvClone_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Font = new System.Drawing.Font("Ricty Diminished Discord", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 17);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.toolTip1.SetToolTip(this.splitContainer1.Panel1, "システム環境");
            this.splitContainer1.Panel1MinSize = 256;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.lbl_VirtualEnv);
            this.splitContainer1.Panel2MinSize = 256;
            this.splitContainer1.Size = new System.Drawing.Size(547, 334);
            this.splitContainer1.SplitterDistance = 270;
            this.splitContainer1.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Ricty Diminished Discord", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(270, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "システム環境";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox1.Image = global::HamuQonda.Properties.Resources.h47_128;
            this.pictureBox1.Location = new System.Drawing.Point(0, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_VirtualEnv
            // 
            this.lbl_VirtualEnv.BackColor = System.Drawing.Color.Gainsboro;
            this.lbl_VirtualEnv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_VirtualEnv.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_VirtualEnv.Font = new System.Drawing.Font("Ricty Diminished Discord", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_VirtualEnv.Location = new System.Drawing.Point(0, 0);
            this.lbl_VirtualEnv.Name = "lbl_VirtualEnv";
            this.lbl_VirtualEnv.Size = new System.Drawing.Size(273, 16);
            this.lbl_VirtualEnv.TabIndex = 20;
            this.lbl_VirtualEnv.Text = "仮想環境";
            this.lbl_VirtualEnv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtInfo
            // 
            this.txtInfo.BackColor = System.Drawing.Color.Snow;
            this.txtInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtInfo.Font = new System.Drawing.Font("Ricty Diminished Discord", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtInfo.Location = new System.Drawing.Point(12, 35);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(556, 77);
            this.txtInfo.TabIndex = 0;
            this.txtInfo.TabStop = false;
            // 
            // gboxInfo
            // 
            this.gboxInfo.Controls.Add(this.splitContainer1);
            this.gboxInfo.Font = new System.Drawing.Font("Ricty Diminished Discord", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gboxInfo.Location = new System.Drawing.Point(12, 175);
            this.gboxInfo.Name = "gboxInfo";
            this.gboxInfo.Size = new System.Drawing.Size(553, 354);
            this.gboxInfo.TabIndex = 8;
            this.gboxInfo.TabStop = false;
            this.gboxInfo.Text = "Python環境の選択";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 43);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(5);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator7,
            this.tStripBtn_Cmd,
            this.toolStripSeparator4,
            this.tStripBtn_PyIp,
            this.toolStripSeparator5,
            this.tStripBtn_Idle,
            this.toolStripSeparator6,
            this.tStripBtn_JpNb,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(11, 115);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(243, 43);
            this.toolStrip1.TabIndex = 26;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 43);
            // 
            // tStripBtn_Cmd
            // 
            this.tStripBtn_Cmd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tStripBtn_Cmd.Image = global::HamuQonda.Properties.Resources.env_prpt;
            this.tStripBtn_Cmd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tStripBtn_Cmd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tStripBtn_Cmd.Name = "tStripBtn_Cmd";
            this.tStripBtn_Cmd.Size = new System.Drawing.Size(40, 40);
            this.tStripBtn_Cmd.Text = "コマンドプロンプト";
            this.tStripBtn_Cmd.ToolTipText = "コマンド\r\nプロンプト";
            this.tStripBtn_Cmd.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 43);
            // 
            // tStripBtn_PyIp
            // 
            this.tStripBtn_PyIp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tStripBtn_PyIp.Image = global::HamuQonda.Properties.Resources.pinterp;
            this.tStripBtn_PyIp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tStripBtn_PyIp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tStripBtn_PyIp.Name = "tStripBtn_PyIp";
            this.tStripBtn_PyIp.Size = new System.Drawing.Size(40, 40);
            this.tStripBtn_PyIp.Text = "インタプリタ";
            this.tStripBtn_PyIp.ToolTipText = "python\r\nインタプリタ";
            this.tStripBtn_PyIp.Click += new System.EventHandler(this.ToolStripButton2_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 43);
            // 
            // tStripBtn_Idle
            // 
            this.tStripBtn_Idle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tStripBtn_Idle.Image = global::HamuQonda.Properties.Resources.py_IDLE;
            this.tStripBtn_Idle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tStripBtn_Idle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tStripBtn_Idle.Name = "tStripBtn_Idle";
            this.tStripBtn_Idle.Size = new System.Drawing.Size(40, 40);
            this.tStripBtn_Idle.Text = "IDLE";
            this.tStripBtn_Idle.Click += new System.EventHandler(this.TStripBtn_Idle_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 43);
            // 
            // tStripBtn_JpNb
            // 
            this.tStripBtn_JpNb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tStripBtn_JpNb.Image = global::HamuQonda.Properties.Resources.jupyterN;
            this.tStripBtn_JpNb.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tStripBtn_JpNb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tStripBtn_JpNb.Name = "tStripBtn_JpNb";
            this.tStripBtn_JpNb.Size = new System.Drawing.Size(40, 40);
            this.tStripBtn_JpNb.Text = "Jupyter notebook";
            this.tStripBtn_JpNb.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.tStripBtn_JpNb.ToolTipText = "Jupyter\r\nnotebook";
            this.tStripBtn_JpNb.Click += new System.EventHandler(this.TStripBtn_JpNb_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnVenvNew);
            this.panel1.Controls.Add(this.btnVenvClone);
            this.panel1.Controls.Add(this.btnReqTxtIn);
            this.panel1.Controls.Add(this.btnVenvDel);
            this.panel1.Controls.Add(this.btnReqTxtOut);
            this.panel1.Location = new System.Drawing.Point(354, 144);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 38);
            this.panel1.TabIndex = 31;
            // 
            // FormHQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(580, 557);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtBoxVenvsDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVenvsDirChange);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.gboxInfo);
            this.Controls.Add(this.btnWdirChange);
            this.Controls.Add(this.txtBoxWorkDir);
            this.Controls.Add(this.lbl_workingFolder);
            this.Controls.Add(this.kakunin);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnSelPyOnOff);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(600, 210);
            this.Name = "FormHQ";
            this.Text = "HamuQonda";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.FormHQ_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gboxInfo.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox kakunin;
        private System.Windows.Forms.Label lbl_workingFolder;
        private System.Windows.Forms.TextBox txtBoxWorkDir;
        private System.Windows.Forms.Button btnWdirChange;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.GroupBox gboxInfo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tStripMenu_Cmd;
        private System.Windows.Forms.ToolStripMenuItem tStripMenu_PyIp;
        private System.Windows.Forms.ToolStripMenuItem tStripMenu_Idle;
        private System.Windows.Forms.ToolStripMenuItem tStripMenu_JpNb;
        private System.Windows.Forms.Button btnVenvNew;
        private System.Windows.Forms.Button btnVenvDel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnVenvsDirChange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_VirtualEnv;
        private System.Windows.Forms.Button btnSelPyOnOff;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tStripMenu_NewVenv;
        private System.Windows.Forms.ToolStripMenuItem tStripMenu_DelVenv;
        private System.Windows.Forms.ToolStripMenuItem tStripMenu_CopyEnv;
        private System.Windows.Forms.ToolStripButton tStripBtn_Cmd;
        private System.Windows.Forms.ToolStripButton tStripBtn_PyIp;
        private System.Windows.Forms.ToolStripButton tStripBtn_Idle;
        private System.Windows.Forms.ToolStripButton tStripBtn_JpNb;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.TextBox txtBoxVenvsDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReqTxtOut;
        private System.Windows.Forms.Button btnReqTxtIn;
        private System.Windows.Forms.Button btnVenvClone;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tStripMenu_ReqTxtOut;
        private System.Windows.Forms.ToolStripMenuItem tStripMenu_ReqTxt_In;
    }
}

