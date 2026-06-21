using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using PowerfulWindSlickedBackHair.Properties;

namespace PowerfulWindSlickedBackHair.Windows
{
	public partial class StaticYukiForm : Form
	{
        private Bitmap upNor;

        private Bitmap downNor;

        public StaticYukiForm()
        {
            InitializeComponent();
            base.StartPosition = FormStartPosition.Manual;
            upNor = new Bitmap("Assets\\JumpUp.png");
            downNor = new Bitmap("Assets\\JumpDown.png");
        }

        public void ShowDialog(Point pos, int endFrame)
        {
            base.Location = pos;
            TrackedDialogHelper.Show(this, 8, delegate(long frame)
            {
                base.BackgroundImage = (((int)(frame / 8) % 2 == 1) ? upNor : downNor);
                return frame <= (long)endFrame;
            });
        }
    }
}
