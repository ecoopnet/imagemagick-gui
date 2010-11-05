namespace WindowsFormsApplication1.formchildren
{
    partial class FormLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLog));
            this.consolePanel1 = new WindowsFormsApplication1.View.ConsolePanel();
            this.SuspendLayout();
            // 
            // consolePanel1
            // 
            this.consolePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consolePanel1.Location = new System.Drawing.Point(0, 0);
            this.consolePanel1.Name = "consolePanel1";
            this.consolePanel1.PrintLogLevel = WindowsFormsApplication1.View.ConsolePanel.LogLevel.INFO;
            this.consolePanel1.Size = new System.Drawing.Size(292, 269);
            this.consolePanel1.TabIndex = 16;
            // 
            // FormLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 269);
            this.Controls.Add(this.consolePanel1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLog";
            this.Text = "ログ";
            this.ResumeLayout(false);

        }

        #endregion

        public WindowsFormsApplication1.View.ConsolePanel consolePanel1;

    }
}