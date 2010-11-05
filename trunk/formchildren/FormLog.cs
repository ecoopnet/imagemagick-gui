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
    public partial class FormLog : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public FormLog()
        {
            InitializeComponent();
        }
        protected override string GetPersistString()
        {
            return Name;
        }
    }
}
