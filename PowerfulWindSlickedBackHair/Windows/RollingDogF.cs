using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
	public partial class RollingDogF : Form
	{
        private Bitmap dogWalk1;

        private Bitmap dogWalk2;

        private Bitmap dogRolling;

        private long switchF;

        private long startFrame;

        private long endFrame;

        private int lastPosition;

        private long sustainLength;

        private Point startLocation;

        private bool isShowMsg;

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

        public RollingDogF()
        {
            InitializeComponent();
            dogRolling = new Bitmap("Assets\\RollingDog.png");
            dogWalk1 = new Bitmap("Assets\\DogWalk1.png");
            dogWalk2 = new Bitmap("Assets\\DogWalk2.png");
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
            UpdateStyles();
            base.TopMost = true;
            base.StartPosition = FormStartPosition.Manual;
        }

        public void ShowDialog(Point pos, long endF, int lastPos, bool isShowMsg)
        {
            startFrame = Tracker.frame;
            endFrame = endF;
            lastPosition = lastPos;
            sustainLength = endFrame - startFrame;
            startLocation = pos;
            base.Location = pos;
            this.isShowMsg = isShowMsg;
            switchF = endF - 30;
            Thread thread = new Thread((ThreadStart)delegate
            {
                long num = endF;
                Thread thread2 = new Thread((ThreadStart)delegate
                {
                    while (true)
                    {
                        if (Tracker.frame < switchF)
                        {
                            long num3 = Tracker.frame % 6;
                            BackgroundImage = ((num3 < 3) ? dogWalk1 : dogWalk2);
                        }
                        else
                        {
                            if (this.isShowMsg)
                            {
                                NotifyIcon notifyIcon = new NotifyIcon();
                                notifyIcon.Visible = true;
                                notifyIcon.BalloonTipText = "风力实在是太强了！\r\n我整条狗都快被吹飞了！";
                                notifyIcon.Icon = new Icon("Assets\\Cross.ico");
                                notifyIcon.ShowBalloonTip(1000, "风力实在是太强了！", "我整条狗都快被吹飞了！", ToolTipIcon.Warning);
                                this.isShowMsg = false;
                            }
                            Bitmap bitmap = new Bitmap(dogRolling);
                            bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            dogRolling = bitmap;
                            BackgroundImage = bitmap;
                            Thread.Sleep(100);
                        }
                        Thread.Sleep(8);
                    }
                });
                thread2.Start();
                while (true)
                {
                    double num2 = (double)(Tracker.frame - startFrame) / (double)sustainLength;
                    base.Location = new Point((int)((double)startLocation.X + num2 * (double)lastPosition), startLocation.Y);
                    if (Tracker.frame > endF)
                    {
                        break;
                    }
                    Thread.Sleep(1);
                }
                Hide();
                thread2.Abort();
            });
            thread.Start();
            ShowDialog();
        }
    }
}
