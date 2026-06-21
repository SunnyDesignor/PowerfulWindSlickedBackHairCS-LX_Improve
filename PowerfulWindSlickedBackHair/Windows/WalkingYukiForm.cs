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

        private DateTime nextWalkFrameAt;

        public new Image BackgroundImage
        {
            get
            {
                if (this.IsDisposed) return null;
                if (InvokeRequired)
                {
                    return (Image)Invoke(new Func<Image>(() => base.BackgroundImage));
                }
                return base.BackgroundImage;
            }
            set
            {
                if (IsDisposed)
                    return;
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        if (IsDisposed || !IsHandleCreated)
                            return;
                        Image oldImage = base.BackgroundImage;
                        base.BackgroundImage = value;
                    });
                }
                else
                {
                    if (IsDisposed || !IsHandleCreated)
                        return;
                    Image oldImage = base.BackgroundImage;
                    base.BackgroundImage = value;
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
            sustainLength = Math.Max(1L, endFrame - startFrame);
            base.Location = pos;
            startLocation = base.Location;
            walkState = 0;
            nextWalkFrameAt = DateTime.UtcNow;
            try
            {
                TrackedDialogHelper.Show(this, 8, delegate(long frame)
                {
                    if (DateTime.UtcNow >= nextWalkFrameAt)
                    {
                        walkState++;
                        nextWalkFrameAt = DateTime.UtcNow.AddMilliseconds(430.0);
                    }
                    switch (walkState % 4)
                    {
                        case 0:
                            base.BackgroundImage = walk1;
                            break;
                        case 1:
                            base.BackgroundImage = walk2;
                            break;
                        case 2:
                            base.BackgroundImage = walk3;
                            break;
                        default:
                            base.BackgroundImage = walk4;
                            break;
                    }
                    double num2 = (double)(frame - startFrame) / (double)sustainLength;
                    base.Location = new Point((int)((double)startLocation.X - num2 * (double)lastPosition), startLocation.Y);
                    return frame <= (long)endF;
                });
            }
            catch (Exception)
            {
            }
        }
    }
}
