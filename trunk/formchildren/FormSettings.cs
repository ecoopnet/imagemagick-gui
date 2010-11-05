using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1.formchildren
{
    public partial class FormSettings : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        // ImageMagick実行パス
        private string executeDir = "";//@"d:\program files\imagemagick-6.4.9-q16\convert.exe";
        // カレントの作業フォルダ
        private string workingDir = "";

        /// <summary>
        /// コマンド実行パスのget/stt
        /// </summary>
        public string ExecuteDir
        {
            get { return executeDir; }
            private set
            {
                string path = value;
                if (!Directory.Exists(path))
                {
                    ((FormImmex)ParentForm).LogError("フォルダ" + path + "は存在しません！");
                    return;
                }
                if (path.EndsWith("\\"))
                {
                    path = path.Substring(0, path.Length - 1);
                }
                textBoxConvertPath.Text = executeDir = path;
                global::WindowsFormsApplication1.immex.Default.ExecuteDir = ExecuteDir;
                global::WindowsFormsApplication1.immex.Default.Save();
            }
        }

        /// <summary>
        /// 作業ディレクトリのget/set
        /// </summary>
        public string WorkingDir
        {
            get { return workingDir; }
            private set
            {
                string dir = value;
                if (!System.IO.Directory.Exists(dir))
                {
                    if (ParentForm is FormImmex)
                    {
                        ((FormImmex)ParentForm)
                            .LogError("ディレクトリ" + dir + "は存在しません！");
                    }
                    return;
                }
                textBoxWorkDir.Text = workingDir = dir;
                System.IO.Directory.SetCurrentDirectory(workingDir);
                global::WindowsFormsApplication1.immex.Default.LastWorkDir = dir;
                global::WindowsFormsApplication1.immex.Default.Save();
            }
        }

        /// <summary>
        /// 監視対象のファイル。設定しておくと変更があったときに自動的によみこむ。
        /// </summary>
        public string MonitorFilename
        {
            get;
            private set;
        }
        /// <summary>
        /// ファイル監視が有効化どうか
        /// </summary>
        public bool MonitorEnabled
        {
            get;
            private set;
        }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FormSettings()
        {
            InitializeComponent();
            { // 作業ディレクトリ読み込み
                string dir = global::WindowsFormsApplication1.immex.Default.LastWorkDir.Trim();
                if (!dir.Equals("") && Directory.Exists(dir))
                {
                    this.workingDir = dir;
                    textBoxWorkDir.Text = dir;
                    System.IO.Directory.SetCurrentDirectory(workingDir);
                }
                workingDir = textBoxWorkDir.Text = System.IO.Directory.GetCurrentDirectory();
            }
            {
                // デフォルト実行パス設定
                if (executeDir.Equals(""))
                {
                    string path = Application.ExecutablePath;
                    string dir = path.Substring(0, path.LastIndexOf('\\'));
                    executeDir = dir + @"\util\imagick";
                }
                textBoxConvertPath.Text = executeDir;
            }
            // 監視設定読み込み
            MonitorEnabled = global::WindowsFormsApplication1.immex.Default.MonitorEnabled != 0;
            checkBoxMonitorFile.Checked = MonitorEnabled;
            MonitorFilename = global::WindowsFormsApplication1.immex.Default.MonitorFile;
            textBoxMonitorFile.Text = MonitorFilename;

        }

        protected override string GetPersistString()
        {
            return Name;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            // TextBox 全般の操作
            if (this.ActiveControl is TextBox)
            {
                TextBox textBox = (TextBox)this.ActiveControl;

                switch (keyData)
                {
                    // Ctrl+A: 全て選択
                    case Keys.A | Keys.Control:
                        textBox.SelectionStart = 0;
                        textBox.SelectionLength = textBox.Text.Length;
                        return true;
                    //break;
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        // --------------------
        private void buttonChangeWorkingDir_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = workingDir;
            DialogResult result = folderBrowserDialog1.ShowDialog(this);
            if (result != DialogResult.OK)
            {
                return;
            }
            WorkingDir = folderBrowserDialog1.SelectedPath; 
            //            textBoxWorkDir.Text = workingDir = folderBrowserDialog1.SelectedPath;
            //            System.IO.Directory.SetCurrentDirectory(workingDir);
            //            global::WindowsFormsApplication1.immex.Default.LastWorkDir = workingDir;
//            global::WindowsFormsApplication1.immex.Default.Save();

        }

        private void textBoxWorkDir_TextChanged(object sender, EventArgs e)
        {
            workingDir = textBoxWorkDir.Text;
        }

        private void checkBoxMonitorFile_CheckedChanged(object sender, EventArgs e)
        {
            bool bMonitor = checkBoxMonitorFile.Checked;
            textBoxMonitorFile.Enabled = bMonitor;
            if (bMonitor)
            {
                MonitorEnabled = true;
                //timer1.Start();
            }
            else
            {
                //timer1.Stop();
                MonitorEnabled = false;
                MonitorFilename = null;
            }

            global::WindowsFormsApplication1.immex.Default.MonitorEnabled = (ushort)(MonitorEnabled ? 1 : 0);
            global::WindowsFormsApplication1.immex.Default.Save();

            if (OnMonitorSettingsChanged != null)
            {
                OnMonitorSettingsChanged(this, new EventArgs());
            }
        }

        public event EventHandler OnMonitorSettingsChanged;

        private void textBoxMonitorFile_TextChanged(object sender, EventArgs e)
        {
            if (MonitorEnabled)
            {
                MonitorFilename = textBoxMonitorFile.Text;
                global::WindowsFormsApplication1.immex.Default.MonitorFile = MonitorFilename;
                global::WindowsFormsApplication1.immex.Default.Save();
            }

        }

        private void FormSettings_Load(object sender, EventArgs e)
        {

        }

        private void textBoxConvertPath_TextChanged(object sender, EventArgs e)
        {
            ExecuteDir = textBoxConvertPath.Text;

        }

     }
}
