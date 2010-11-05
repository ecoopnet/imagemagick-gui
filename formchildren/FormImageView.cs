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
    public partial class FormImageView : WeifenLuo.WinFormsUI.Docking.DockContent

    {
        public FormImageView()
        {
            InitializeComponent();
            pictureResult.SizeChanged += AdjustPicture;
        }
        protected override string GetPersistString()
        {
            return Name;
        }

        public void AdjustPicture(object sender, EventArgs e)
        {

            pictureResult.Location = new Point((ClientSize.Width - pictureResult.Width) / 2, (ClientSize.Height - pictureResult.Height) / 2);
            //Console.WriteLine("Adjusted:" + pictureResult.Location);
        }
    }
}
