namespace HamuQonda
{
    partial class Form1
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
            this.kakunin = new System.Windows.Forms.TextBox();
            this.lbl_workingFolder = new System.Windows.Forms.Label();
            this.txtDispWorkingFolder = new System.Windows.Forms.TextBox();
            this.btnWdirChange = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // kakunin
            // 
            this.kakunin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.kakunin.Location = new System.Drawing.Point(29, 493);
            this.kakunin.Multiline = true;
            this.kakunin.Name = "kakunin";
            this.kakunin.Size = new System.Drawing.Size(691, 171);
            this.kakunin.TabIndex = 0;
            // 
            // lbl_workingFolder
            // 
            this.lbl_workingFolder.AutoSize = true;
            this.lbl_workingFolder.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_workingFolder.Location = new System.Drawing.Point(190, 73);
            this.lbl_workingFolder.Name = "lbl_workingFolder";
            this.lbl_workingFolder.Size = new System.Drawing.Size(86, 16);
            this.lbl_workingFolder.TabIndex = 1;
            this.lbl_workingFolder.Text = "作業フォルダ";
            // 
            // txtDispWorkingFolder
            // 
            this.txtDispWorkingFolder.BackColor = System.Drawing.Color.White;
            this.txtDispWorkingFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDispWorkingFolder.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDispWorkingFolder.Location = new System.Drawing.Point(183, 33);
            this.txtDispWorkingFolder.Name = "txtDispWorkingFolder";
            this.txtDispWorkingFolder.ReadOnly = true;
            this.txtDispWorkingFolder.Size = new System.Drawing.Size(747, 19);
            this.txtDispWorkingFolder.TabIndex = 2;
            // 
            // btnWdirChange
            // 
            this.btnWdirChange.Location = new System.Drawing.Point(937, 33);
            this.btnWdirChange.Name = "btnWdirChange";
            this.btnWdirChange.Size = new System.Drawing.Size(31, 18);
            this.btnWdirChange.TabIndex = 3;
            this.btnWdirChange.Text = "button1";
            this.btnWdirChange.UseVisualStyleBackColor = true;
            this.btnWdirChange.Click += new System.EventHandler(this.btnWdirChange_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.NavajoWhite;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 105);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(758, 359);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(803, 619);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 676);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnWdirChange);
            this.Controls.Add(this.txtDispWorkingFolder);
            this.Controls.Add(this.lbl_workingFolder);
            this.Controls.Add(this.kakunin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "HamuQonda";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DoubleClick += new System.EventHandler(this.Form1_DoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox kakunin;
        private System.Windows.Forms.Label lbl_workingFolder;
        private System.Windows.Forms.TextBox txtDispWorkingFolder;
        private System.Windows.Forms.Button btnWdirChange;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
    }
}

