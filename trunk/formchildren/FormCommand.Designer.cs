namespace WindowsFormsApplication1.formchildren
{
    partial class FormCommand
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCommand));
            this.textBoxCommand = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCommand.Location = new System.Drawing.Point(0, 0);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(292, 269);
            this.textBoxCommand.TabIndex = 3;
            this.textBoxCommand.Text = "convert logo: -resize 250x250  jpg:-";
            // 
            // FormCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 269);
            this.Controls.Add(this.textBoxCommand);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCommand";
            this.Text = "実行コマンド";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox textBoxCommand;

    }
}