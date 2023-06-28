using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x02000019 RID: 25
	public partial class WalkingYukiForm : Form
	{
        private readonly Bitmap walk1;

        private readonly Bitmap walk2;

        private readonly Bitmap walk3;

        private readonly Bitmap walk4;

        private long startFrame;

        private long endFrame;

        private int lastPosition;

        private long sustainLength;

        private Point startLocation;

        private int walkState;

        public new Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
                if (base.IsHandleCreated)
                {
                    BeginInvoke((MethodInvoker)delegate
                    {
                        base.BackgroundImage = value;
                    });
                }
            }
        }

        public WalkingYukiForm()
        {
            InitializeComponent();
            walk1 = new Bitmap("Assets\\Walk1.png");
            walk2 = new Bitmap("Assets\\Walk2.png");
            walk3 = new Bitmap("Assets\\Walk3.png");
            walk4 = new Bitmap("Assets\\Walk4.png");
            base.StartPosition = FormStartPosition.Manual;
            base.TopMost = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
            UpdateStyles();
        }

        public void ShowDialog(Point pos, int endF, int lastPos)
        {
            startFrame = Tracker.frame;
            endFrame = endF;
            lastPosition = lastPos;
            sustainLength = endFrame - startFrame;
            base.Location = pos;
            startLocation = base.Location;
            Thread thread = new Thread((ThreadStart)delegate
            {
                int num = endF;
                Thread thread2 = new Thread((ThreadStart)delegate
                {
                    while (true)
                    {
                        walkState++;
                        switch (walkState % 4)
                        {
                            case 0:
                                BackgroundImage = walk1;
                                break;
                            case 1:
                                BackgroundImage = walk2;
                                break;
                            case 2:
                                BackgroundImage = walk3;
                                break;
                            case 3:
                                BackgroundImage = walk4;
                                break;
                        }
                        Thread.Sleep(430);
                    }
                });
                thread2.Start();
                do
                {
                    double num2 = (double)(Tracker.frame - startFrame) / (double)sustainLength;
                    base.Location = new Point((int)((double)startLocation.X - num2 * (double)lastPosition), startLocation.Y);
                }
                while (Tracker.frame <= endF);
                thread2.Abort();
                Hide();
            });
            thread.Start();
            ShowDialog();
        }
    }
}
