using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.View
{
    public partial class ConsolePanel : UserControl
    {
        public enum LogLevel { ERROR, INFO, DETAIL};
        //private string[] = new string[]{"error", };
        public ConsolePanel()
        {
            InitializeComponent();
            PrintLogLevel = LogLevel.DETAIL;// LogLevel.INFO;
        }

        public LogLevel PrintLogLevel { get; set; } 

        public void Log(LogLevel level, string text){
            if (level <= PrintLogLevel)
            {
                Invoke(new MethodInvoker(delegate
                {
                    this.Focus();
                    textBoxConsole.Focus();
                    string message = "";
                    if (level == LogLevel.ERROR)
                    {
                        message += "" + level + '\t';
                    }
                    /*DateTime.Now + '\t' + */
                    message += text;
                    textBoxConsole.Text += message + System.Environment.NewLine;
                    textBoxConsole.SelectionStart = textBoxConsole.Text.Length;
                    
                    textBoxConsole.ScrollToCaret();
                }));
           }
        }

        public void LogInfo(string text) { Log(LogLevel.INFO, text); }

        public void LogError(string text) { Log(LogLevel.ERROR, text); }
        public void LogDetail(string text) { Log(LogLevel.DETAIL, text); }

        public void Clear()
        {
            textBoxConsole.Text = "";
        }
    }
}
