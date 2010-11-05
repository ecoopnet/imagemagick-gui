using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.formchildren
{
    public partial class FormCommand : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public FormCommand()
        {
            InitializeComponent();


            // コマンド入力欄ヒストリの初期化
            //textBoxCommand_history = new Model.CommandManager(100);
            //textBoxCommand_memento = new Model.TextBoxMemento(textBoxCommandOld);

            // リッチテキストボックスにコンテキストメニュー追加
            //MenuItem[] items = new MenuItem[5];
            {
                RichTextBox target = textBoxCommand;

                List<MenuItem> items = new List<MenuItem>();
                {
                    var item = new MenuItem("元に戻す(&X)", delegate(object sender, EventArgs e)
                    {
                        var o = (MenuItem)sender;
                        target.Undo();
                    });
                    item.Enabled = false;
                    items.Add(item);
                    target.TextChanged += new EventHandler(delegate(object sender, EventArgs e)
                    {
                        item.Enabled = target.CanUndo;
                    });
                }
                {
                    var item = new MenuItem("やり直し(&X)", delegate(object sender, EventArgs e)
                    {
                        var o = (MenuItem)sender;
                        target.Redo();
                    });
                    item.Enabled = false;
                    items.Add(item);
                    target.TextChanged += new EventHandler(delegate(object sender, EventArgs e)
                    {
                        item.Enabled = target.CanRedo;
                    });
                }
                items.Add(new MenuItem("-"));
                items.Add(new MenuItem("全て選択(&A)", delegate(object sender, EventArgs e) { target.SelectionStart = 0; target.SelectionLength = target.Text.Length; }));
                items.Add(new MenuItem("切り取り(&X)", delegate(object sender, EventArgs e) { target.Cut(); }));
                items.Add(new MenuItem("コピー(&C)", delegate(object sender, EventArgs e) { target.Copy(); }));
                items.Add(new MenuItem("貼りつけ(&V)", delegate(object sender, EventArgs e) { target.Paste(); }));
                target.ContextMenu = new ContextMenu(items.ToArray());
            }
        }
        protected override string GetPersistString()
        {
            return Name;
        }
    }
}
