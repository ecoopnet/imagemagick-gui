using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Model
{
     /// <summary>
    /// Memento抽象クラス。
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public abstract class Memento<T1, T2>
    {
        /// <summary>
        /// データを取得・設定。
        /// </summary>
        public T1 MementoData { get; protected set; }
        /// <summary>
        /// データ反映対象の取得・設定。
        /// </summary>
        protected T2 Target { get; set; }
        /// <summary>
        /// 思い出を反映させる
        /// </summary>
        /// <param name="_mementData"></param>
        public abstract void SetMemento(T1 _mementData);
    }

    public class MementoComand<T1, T2> : ICommand
    {

        private Memento<T1, T2> _memento;
        private T1 _prev;
        private T1 _next;

        public MementoComand(Memento<T1,T2> prev, Memento<T1,T2> next)
        {
            _memento = prev;
            _prev = prev.MementoData;
            _next = next.MementoData;
        }

        #region ICommand メンバ

        void ICommand.Invoke()
        {
            _prev = _memento.MementoData;
            _memento.SetMemento(_next);
        }

        void ICommand.Undo()
        {
            _memento.SetMemento(_prev);
        }

        void ICommand.Redo()
        {
            _memento.SetMemento(_next);
        }

        #endregion
    }

    public class CommandManager
    {
        private int _maxStack;
        private LinkedList<ICommand> _undoStack;
        private Stack<ICommand> _redoStack;

        public CommandManager(int maxStack)
        {
            _maxStack = maxStack;
            _undoStack = new LinkedList<ICommand>();
            _redoStack = new Stack<ICommand>();
        }
        public void Invoke(ICommand command){
            if(_undoStack.Count >= _maxStack){
                _undoStack.RemoveLast();
            }
            _undoStack.AddFirst(command);
             
            _redoStack.Clear();
            command.Invoke();
            ShowStatus();
        }

        public void Undo()
        {
            if (_undoStack.Count == 0)
            {
                return;
            }
            // Undo から Redo に移す
            ICommand command = _undoStack.First();
            _undoStack.RemoveFirst();
            _redoStack.Push(command);
            // Undo!
            command.Undo();
            ShowStatus();
        }

        public void Redo()
        {
            if (_redoStack.Count == 0)
            {
                return;
            }
            // Redo から Undo に移す
            ICommand command = _redoStack.Pop();
            _undoStack.AddFirst(command);
            // Redo!
            command.Redo();
            ShowStatus();
        }
        private void ShowStatus()
        {
            MessageBox.Show(_undoStack.Count + "/" + _redoStack.Count);
        }
    }


    public class TextBoxMemento : Memento<string, TextBox>
    {
        public TextBoxMemento(TextBox target)
        {
            base.Target = target;
            base.MementoData = target.Text;
        }
        public TextBoxMemento(string mementData, TextBox target)
        {
            base.Target = target;
            base.MementoData = mementData;
        }
        public override void SetMemento(string mementData)
        {
            base.Target.Text = mementData;
            base.MementoData = mementData;
        }
    }

}
