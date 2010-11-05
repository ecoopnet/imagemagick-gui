using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.formchildren;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class FormImmex : Form
    {
        // 子フォーム
        private FormCommand mFormCommand;
        private FormImageView mFormImageView;
        private FormLog mFormLog;
        private FormSettings mFormSettings;

        // DockState 保存先
        private static string dockSaveFile = "dockpanel.xml";
        private static string dockSaveDefaultFile = "dockpanel_default.xml";

        /// <summary>
        /// ファイル監視の最終チェック時刻
        /// </summary>
        public DateTime monitorLastAccessTime;


        public FormImmex()
        {
            InitializeComponent();
            // 他の方式だとセンターに配置すると例外が発生するのでちゃんとスタイル設定。
            // http://community.sharpdevelop.net/forums/p/1278/4037.aspx
            dockPanel1.DocumentStyle = DocumentStyle.DockingWindow;
            // 描画場所
            {
                FormImageView form = new FormImageView();
                form.CloseButtonVisible = false;
                form.CloseButton = false;
                form.HideOnClose = true;
                //form.ShowIcon = false;
                form.ShowHint = DockState.Document;
                mFormImageView = form;
            }
            // 設定
            {
                FormSettings form = new FormSettings();
                form.CloseButtonVisible = false;
                form.CloseButton = false;
                form.HideOnClose = true;
//                form.ShowIcon = false;
                form.ShowHint = DockState.DockBottom;
                mFormSettings = form;
            }
            //実行コマンド
            {
                FormCommand form = new FormCommand();
                form.CloseButtonVisible = false;
                form.CloseButton = false;
                form.HideOnClose = true;
//                form.ShowIcon = false;
                form.ShowHint = DockState.DockBottom;
                mFormCommand = form;
            }
            // ログ
            {
                FormLog form = new FormLog();
                form.CloseButtonVisible = false;
                form.CloseButton = false;
                form.HideOnClose = true;
//                form.ShowIcon = false;
                form.ShowHint = DockState.DockRight;
                mFormLog = form;
            }
            // --------
            // 最後に実行したコマンド読み込み
            if (!global::WindowsFormsApplication1.immex.Default.LastCommand.Trim().Equals(""))
            {
                mFormCommand.textBoxCommand.Text = global::WindowsFormsApplication1.immex.Default.LastCommand.Trim();
            }

            //pictureResult.LoadCompleted += AdjustPicture;
            {
                // ファイル監視スレッドの登録
                mFormSettings.OnMonitorSettingsChanged += new EventHandler(MonitorSettingsChangedEventHandler);
                timer1.Interval = 150;
                timer1.Tick += MonitorImageFile;
                if (mFormSettings.MonitorEnabled) { timer1.Start(); }
            }
        }
        private void FormImmex_Load(object sender, EventArgs e)
        {

            // ドックウィンドウ設定をロード
            if (System.IO.File.Exists(dockSaveFile))
            {
                // 前回の起動状態を復元
                dockPanel1.LoadFromXml(dockSaveFile, new DeserializeDockContent(GetDockContentFromParsistentString));
            }else if (System.IO.File.Exists(dockSaveDefaultFile)){
                // デフォルトの設定から復元
                dockPanel1.LoadFromXml(dockSaveDefaultFile, new DeserializeDockContent(GetDockContentFromParsistentString));
            }else{
                // 初回起動用配置
                mFormImageView.Show(dockPanel1);
                mFormSettings.Show(dockPanel1);
                mFormCommand.Show(dockPanel1);
                mFormLog.Show(dockPanel1);
                // 初期ドックウィンドウ設定をデフォルトファイルに保存
                dockPanel1.SaveAsXml(dockSaveDefaultFile);
            }
            AdjustDock();
        }

        /// <summary>
        /// ドックウィンドウ設定ロード用メソッド
        /// </summary>
        /// <param name="persistentString"></param>
        /// <returns></returns>
        IDockContent GetDockContentFromParsistentString(String persistentString)
        {
            DockContent[] docs = new DockContent[] { mFormImageView, mFormCommand, mFormSettings, mFormLog };
            for (int i = 0; i < docs.Length; i++)
            {
                DockContent form = docs[i];
                if (form.Name.Equals(persistentString))
                {
                    return form;
                }
            }
            throw new ArgumentException("Unknown content: "+persistentString);
        }

        /// <summary>
        /// 全体のキー処理イベント
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                // コマンド実行
                case Keys.F5:
                    ExecuteCommand();
                    return true;
                //break;
            }
            return base.ProcessDialogKey(keyData);
        }
        //-------------------------------------------------------
        // 
        /// <summary>
        /// エラーログとして処理します。
        /// </summary>
        /// <param name="message"></param>
        public void LogError(string message)
        {
            mFormLog.consolePanel1.LogError(message);
        }
        /// <summary>
        /// 情報ログとして処理します。
        /// </summary>
        /// <param name="message"></param>
        public void LogInfo(string message)
        {
            mFormLog.consolePanel1.LogInfo(message);
        }
        /// <summary>
        /// 詳細ログとして処理します。

        /// </summary>
        /// <param name="message"></param>
        public void LogDetail(string message)
        {
            mFormLog.consolePanel1.LogDetail(message);
        }

        /// <summary>
        /// ファイル監視設定の変更時に実行される。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void MonitorSettingsChangedEventHandler(object sender, EventArgs args)
        {
            if (mFormSettings.MonitorEnabled)
            {
                LogInfo("ファイル監視を開始しました。");
                timer1.Start();
            }
            else
            {
                timer1.Stop();
                LogInfo("ファイル監視を終了しました。");
            }
        }

        /// <summary>
        /// ファイル更新の監視タスク。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MonitorImageFile(object sender, EventArgs e)
        {
            string img_file = mFormSettings.MonitorFilename;
            if (!mFormSettings.MonitorEnabled || img_file == null || !System.IO.File.Exists(img_file))
            {
                return;
            }

            DateTime time = System.IO.File.GetLastWriteTime(img_file);
            if (monitorLastAccessTime < time)
            {
                LogInfo("ファイル '"+ img_file+"' から画像を読み込みました。");
                monitorLastAccessTime = time;
                mFormImageView.pictureResult.ImageLocation = img_file;
            }
        }

        public void ExecuteCommand()
        {
            string cmd_in = mFormCommand.textBoxCommand.Text;
            // １行に変換
            string oneline_command = cmd_in.Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " ").Trim();
            string program;
            string oneline_options;
            Match match = Regex.Match(oneline_command, @"^([^   ]+)");
            if (!match.Success)
            {
                LogError("コマンドが間違っています");
                return;
            }

            string progname = match.Value;
            program = mFormSettings.ExecuteDir + "\\" + progname;
            /*
            // PATHEXT=.COM;.EXE;.BAT;.CMD;.VBS;.VBE;.JS;.JSE;.WSF;.WSH
            if(!File.Exists(program) && program){
                ShowErrorMessage("実行プログラム"+program+"は存在しません");
                return;
            }*/
            oneline_command = Regex.Replace(oneline_command, @"^([^   ]+)", "");
            oneline_options = oneline_command.Trim();

            //最後に実行したコマンドとして記録
            global::WindowsFormsApplication1.immex.Default.LastCommand = cmd_in;
            global::WindowsFormsApplication1.immex.Default.Save();

            Process proc = new Process();
            //Encoding encoding = Encoding.GetEncoding("UTF-8");

            proc.StartInfo.FileName = "\"" + program + "\"";
            proc.StartInfo.Arguments = oneline_options;//Encoding.GetEncoding("UTF-8").GetString(Encoding.Default.GetBytes(oneline_options));
            proc.StartInfo.WorkingDirectory = mFormSettings.WorkingDir;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            LogInfo(progname + " " + proc.StartInfo.Arguments);
            try
            {
                proc.Start();

            }
            catch (Win32Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);
                LogError("実行に失敗しました");
                return;
            }
            Thread watcher = new Thread(ReadOutput);
            watcher.Start(proc);
            //CommandImageResponderThread responder = new WindowsFormsApplication1.CommandImageResponderThread();
        }


        /// <summary>
        /// コマンド実行の結果出力を待受けます。
        /// </summary>
        /// <param name="process"></param>
        public void ReadOutput(object process)
        {
            Process proc = (Process)process;
            //proc.StandardInput.Close();
            try
            {
                StreamReader reader = proc.StandardOutput;
                Image res = null;
                try
                {
                    while (!proc.HasExited)
                    {
                        res = Image.FromStream(reader.BaseStream);
                    }
                    //                if(buf != null){}
                    //Succeed(this, new succeedImageEventArgs(res));
                    Invoke(new MethodInvoker(delegate
                    {
                        if (res == null) { return; }
                        mFormImageView.pictureResult.ImageLocation = null;
                        mFormImageView.pictureResult.Image = res;

                    }));
                }
                catch (ArgumentException e)
                {
                    // 標準出力で画像を出力しなかった。(ファイル出力またはエラー)
                    //MessageBox.Show("Step:3 " + reader.BaseStream +"\n"+ e.Message + "\n" + e.StackTrace);
                    /*
                    Invoke(new MethodInvoker(delegate
                    {
                        ShowErrorMessage("実行に失敗しました。");
                    }));
                    */
                }
                while (!proc.StandardError.EndOfStream)
                {
                    Console.WriteLine(proc.StandardError.ReadLine());
                    Invoke(new MethodInvoker(delegate
                    {
                        string msg = proc.StandardError.ReadLine();
                        if (msg == null) { return; }
                        LogError(msg);
                    }));
                }
                /*
                Invoke(new MethodInvoker(delegate
                {
                    ShowErrorMessage("実行完了。");
                }));
                */
            }
            catch (InvalidOperationException e)
            {
                LogError("invalid operation " + e.ToString());
                // no-op
            }
        }

        private void AdjustDock()
        {
            dockPanel1.Height = ClientSize.Height - toolStrip1.Height;
        }

        private void toolStripExecute_Click(object sender, EventArgs e)
        {
            ExecuteCommand();
        }

        private void FormImmex_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void FormImmex_Resize(object sender, EventArgs e)
        {
            AdjustDock();
        }
        /// <summary>
        /// フォーム終了イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormImmex_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ドックウィンドウ設定を保存
            dockPanel1.SaveAsXml(dockSaveFile);
        }

        private void FormImmex_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void dockPanel1_ActiveContentChanged(object sender, EventArgs e)
        {

        }
    }


}
