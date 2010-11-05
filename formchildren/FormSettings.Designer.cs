namespace WindowsFormsApplication1.formchildren
{
    partial class FormSettings
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.buttonChangeWorkingDir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxWorkDir = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxConvertPath = new System.Windows.Forms.TextBox();
            this.textBoxMonitorFile = new System.Windows.Forms.TextBox();
            this.checkBoxMonitorFile = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // buttonChangeWorkingDir
            // 
            this.buttonChangeWorkingDir.Location = new System.Drawing.Point(337, 24);
            this.buttonChangeWorkingDir.Name = "buttonChangeWorkingDir";
            this.buttonChangeWorkingDir.Size = new System.Drawing.Size(21, 23);
            this.buttonChangeWorkingDir.TabIndex = 17;
            this.buttonChangeWorkingDir.Text = "...";
            this.buttonChangeWorkingDir.UseVisualStyleBackColor = true;
            this.buttonChangeWorkingDir.Click += new System.EventHandler(this.buttonChangeWorkingDir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "作業ディレクトリ";
            // 
            // textBoxWorkDir
            // 
            this.textBoxWorkDir.Location = new System.Drawing.Point(3, 24);
            this.textBoxWorkDir.Name = "textBoxWorkDir";
            this.textBoxWorkDir.Size = new System.Drawing.Size(328, 19);
            this.textBoxWorkDir.TabIndex = 15;
            this.textBoxWorkDir.TextChanged += new System.EventHandler(this.textBoxWorkDir_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "ImageMagickフォルダ";
            this.label3.Visible = false;
            // 
            // textBoxConvertPath
            // 
            this.textBoxConvertPath.Location = new System.Drawing.Point(3, 92);
            this.textBoxConvertPath.Name = "textBoxConvertPath";
            this.textBoxConvertPath.Size = new System.Drawing.Size(355, 19);
            this.textBoxConvertPath.TabIndex = 20;
            this.textBoxConvertPath.Visible = false;
            this.textBoxConvertPath.TextChanged += new System.EventHandler(this.textBoxConvertPath_TextChanged);
            // 
            // textBoxMonitorFile
            // 
            this.textBoxMonitorFile.Enabled = false;
            this.textBoxMonitorFile.Location = new System.Drawing.Point(153, 49);
            this.textBoxMonitorFile.Name = "textBoxMonitorFile";
            this.textBoxMonitorFile.Size = new System.Drawing.Size(160, 19);
            this.textBoxMonitorFile.TabIndex = 19;
            this.textBoxMonitorFile.TextChanged += new System.EventHandler(this.textBoxMonitorFile_TextChanged);
            // 
            // checkBoxMonitorFile
            // 
            this.checkBoxMonitorFile.AutoSize = true;
            this.checkBoxMonitorFile.Location = new System.Drawing.Point(3, 51);
            this.checkBoxMonitorFile.Name = "checkBoxMonitorFile";
            this.checkBoxMonitorFile.Size = new System.Drawing.Size(153, 16);
            this.checkBoxMonitorFile.TabIndex = 18;
            this.checkBoxMonitorFile.Text = "指定したファイルを監視する";
            this.checkBoxMonitorFile.UseVisualStyleBackColor = true;
            this.checkBoxMonitorFile.CheckedChanged += new System.EventHandler(this.checkBoxMonitorFile_CheckedChanged);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 122);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxConvertPath);
            this.Controls.Add(this.textBoxMonitorFile);
            this.Controls.Add(this.checkBoxMonitorFile);
            this.Controls.Add(this.buttonChangeWorkingDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxWorkDir);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSettings";
            this.Text = "設定";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonChangeWorkingDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textBoxWorkDir;
        private System.Windows.Forms.TextBox textBoxConvertPath;
        private System.Windows.Forms.TextBox textBoxMonitorFile;
        private System.Windows.Forms.CheckBox checkBoxMonitorFile;

    }
}