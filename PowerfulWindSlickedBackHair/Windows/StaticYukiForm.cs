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
            Thread thread = new Thread((ThreadStart)delegate
            {
                Thread thread2 = new Thread((ThreadStart)delegate
                {
                    while (true)
                    {
                        BackgroundImage = (((int)(Tracker.frame / 8) % 2 == 1) ? upNor : downNor);
                        Thread.Sleep(10);
                    }
                });
                thread2.Start();
                int num = endFrame;
                while (Tracker.frame <= endFrame)
                {
                }
                Hide();
                thread2.Abort();
            });
            thread.Start();
            ShowDialog();
        }
    }
}
