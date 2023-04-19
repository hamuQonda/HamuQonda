namespace HamuQonda
{
    partial class Dialog2VenvClone
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cancel_Btn = new System.Windows.Forms.Button();
            this.create_Btn = new System.Windows.Forms.Button();
            this.lbl_venvsDir = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_SourceEnv = new System.Windows.Forms.Label();
            this.lbl_DestinationEnv = new System.Windows.Forms.Label();
            this.lbl_newVenvName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cancel_Btn
            // 
            this.cancel_Btn.Location = new System.Drawing.Point(485, 241);
            this.cancel_Btn.Name = "cancel_Btn";
            this.cancel_Btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_Btn.TabIndex = 16;
            this.cancel_Btn.Text = "キャンセル";
            this.cancel_Btn.UseVisualStyleBackColor = true;
            this.cancel_Btn.Click += new System.EventHandler(this.Cancel_Btn_Click);
            // 
            // create_Btn
            // 
            this.create_Btn.Location = new System.Drawing.Point(395, 241);
            this.create_Btn.Name = "create_Btn";
            this.create_Btn.Size = new System.Drawing.Size(75, 23);
            this.create_Btn.TabIndex = 15;
            this.create_Btn.Text = "作成";
            this.create_Btn.UseVisualStyleBackColor = true;
            this.create_Btn.Click += new System.EventHandler(this.Create_Btn_Click);
            // 
            // lbl_venvsDir
            // 
            this.lbl_venvsDir.AutoSize = true;
            this.lbl_venvsDir.Font = new System.Drawing.Font("Ricty Diminished Discord", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_venvsDir.Location = new System.Drawing.Point(36, 169);
            this.lbl_venvsDir.Name = "lbl_venvsDir";
            this.lbl_venvsDir.Size = new System.Drawing.Size(63, 14);
            this.lbl_venvsDir.TabIndex = 12;
            this.lbl_venvsDir.Text = "venvsDir";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ricty Diminished Discord", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(157, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "new仮想環境名を入力";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HamuQonda.Properties.Resources.copy_icon_152214;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(39, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 41);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_SourceEnv
            // 
            this.lbl_SourceEnv.AutoSize = true;
            this.lbl_SourceEnv.Font = new System.Drawing.Font("Ricty Diminished Discord", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_SourceEnv.Location = new System.Drawing.Point(36, 33);
            this.lbl_SourceEnv.Name = "lbl_SourceEnv";
            this.lbl_SourceEnv.Size = new System.Drawing.Size(63, 14);
            this.lbl_SourceEnv.TabIndex = 9;
            this.lbl_SourceEnv.Text = "コピー元";
            // 
            // lbl_DestinationEnv
            // 
            this.lbl_DestinationEnv.AutoSize = true;
            this.lbl_DestinationEnv.Font = new System.Drawing.Font("Ricty Diminished Discord", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_DestinationEnv.Location = new System.Drawing.Point(36, 155);
            this.lbl_DestinationEnv.Name = "lbl_DestinationEnv";
            this.lbl_DestinationEnv.Size = new System.Drawing.Size(63, 14);
            this.lbl_DestinationEnv.TabIndex = 18;
            this.lbl_DestinationEnv.Text = "コピー先";
            // 
            // lbl_newVenvName
            // 
            this.lbl_newVenvName.AutoSize = true;
            this.lbl_newVenvName.BackColor = System.Drawing.Color.Snow;
            this.lbl_newVenvName.Font = new System.Drawing.Font("Ricty Diminished Discord", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_newVenvName.Location = new System.Drawing.Point(120, 169);
            this.lbl_newVenvName.Name = "lbl_newVenvName";
            this.lbl_newVenvName.Size = new System.Drawing.Size(147, 14);
            this.lbl_newVenvName.TabIndex = 19;
            this.lbl_newVenvName.Text = "＜新しい仮想環境名＞";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Ricty Diminished Discord", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBox1.Location = new System.Drawing.Point(151, 98);
            this.textBox1.MaxLength = 32;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(289, 24);
            this.textBox1.TabIndex = 20;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // Dialog2VenvClone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 295);
            this.ControlBox = false;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbl_newVenvName);
            this.Controls.Add(this.lbl_DestinationEnv);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cancel_Btn);
            this.Controls.Add(this.create_Btn);
            this.Controls.Add(this.lbl_venvsDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_SourceEnv);
            this.Name = "Dialog2VenvClone";
            this.Text = "環境コピー ： 選択されている環境のパッケージを 新しい仮想環境にコピーします。";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Dialog2VenvClone_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancel_Btn;
        private System.Windows.Forms.Button create_Btn;
        private System.Windows.Forms.Label lbl_venvsDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_SourceEnv;
        private System.Windows.Forms.Label lbl_DestinationEnv;
        private System.Windows.Forms.Label lbl_newVenvName;
        private System.Windows.Forms.TextBox textBox1;
    }
}