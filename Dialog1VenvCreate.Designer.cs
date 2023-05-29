namespace HamuQonda
{
    internal partial class DialogNewVenvCreate
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
            this.lbl_HomePy = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_venvsDir = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbl_newVenvName = new System.Windows.Forms.Label();
            this.create_Btn = new System.Windows.Forms.Button();
            this.cancel_Btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_HomePy
            // 
            this.lbl_HomePy.AutoSize = true;
            this.lbl_HomePy.Font = new System.Drawing.Font("Ricty Diminished Discord", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_HomePy.Location = new System.Drawing.Point(34, 34);
            this.lbl_HomePy.Name = "lbl_HomePy";
            this.lbl_HomePy.Size = new System.Drawing.Size(77, 14);
            this.lbl_HomePy.TabIndex = 0;
            this.lbl_HomePy.Text = "lbl_HomePy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ricty Diminished Discord", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(107, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "new仮想環境名を入力";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ricty Diminished Discord", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(24, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "場所";
            // 
            // lbl_venvsDir
            // 
            this.lbl_venvsDir.AutoSize = true;
            this.lbl_venvsDir.Font = new System.Drawing.Font("Ricty Diminished Discord", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_venvsDir.Location = new System.Drawing.Point(24, 150);
            this.lbl_venvsDir.Name = "lbl_venvsDir";
            this.lbl_venvsDir.Size = new System.Drawing.Size(63, 14);
            this.lbl_venvsDir.TabIndex = 3;
            this.lbl_venvsDir.Text = "venvsDir";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("Ricty Diminished Discord", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBox1.Location = new System.Drawing.Point(109, 77);
            this.textBox1.MaxLength = 32;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(307, 24);
            this.textBox1.TabIndex = 4;
            this.textBox1.WordWrap = false;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // lbl_newVenvName
            // 
            this.lbl_newVenvName.AutoSize = true;
            this.lbl_newVenvName.BackColor = System.Drawing.Color.Snow;
            this.lbl_newVenvName.Font = new System.Drawing.Font("Ricty Diminished Discord", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_newVenvName.Location = new System.Drawing.Point(93, 150);
            this.lbl_newVenvName.Name = "lbl_newVenvName";
            this.lbl_newVenvName.Size = new System.Drawing.Size(147, 14);
            this.lbl_newVenvName.TabIndex = 6;
            this.lbl_newVenvName.Text = "＜新しい仮想環境名＞";
            // 
            // create_Btn
            // 
            this.create_Btn.Location = new System.Drawing.Point(325, 222);
            this.create_Btn.Name = "create_Btn";
            this.create_Btn.Size = new System.Drawing.Size(75, 23);
            this.create_Btn.TabIndex = 7;
            this.create_Btn.Text = "作成";
            this.create_Btn.UseVisualStyleBackColor = true;
            this.create_Btn.Click += new System.EventHandler(this.Create_Btn_Click);
            // 
            // cancel_Btn
            // 
            this.cancel_Btn.Location = new System.Drawing.Point(415, 222);
            this.cancel_Btn.Name = "cancel_Btn";
            this.cancel_Btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_Btn.TabIndex = 8;
            this.cancel_Btn.Text = "キャンセル";
            this.cancel_Btn.UseVisualStyleBackColor = true;
            this.cancel_Btn.Click += new System.EventHandler(this.Cancel_Btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HamuQonda.Properties.Resources._459_ca_h;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(19, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // DialogNewVenvCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 281);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cancel_Btn);
            this.Controls.Add(this.create_Btn);
            this.Controls.Add(this.lbl_newVenvName);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbl_venvsDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_HomePy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DialogNewVenvCreate";
            this.Text = "仮想環境の作成";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Dialog1VenvCreate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_HomePy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_venvsDir;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbl_newVenvName;
        private System.Windows.Forms.Button create_Btn;
        private System.Windows.Forms.Button cancel_Btn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}