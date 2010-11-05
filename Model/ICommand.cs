using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.Model
{
    
    /// <summary>
    /// 実行、元に戻す(undo)、やり直す(redo)の各動作を定義するインターフェース
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// 操作を実行するメソッド
        /// </summary>
        void Invoke();

        /// <summary>
        /// 操作を元に戻すメソッド
        /// </summary>
        void Undo();

        /// <summary>
        /// 操作をやり直すメソッド
        /// </summary>
        void Redo();
    }
}
