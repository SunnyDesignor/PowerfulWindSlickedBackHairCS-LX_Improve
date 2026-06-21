using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x02000016 RID: 22
	public partial class PigeonPeekF : Form
	{
        private long startFrame;

        private long endFrame;

        private Size lastPosition;

        private long sustainLength;

        private Point startLocation;

        private Bitmap peek1;

        private Bitmap peek2;

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
                    Invoke((MethodInvoker)delegate
                    {
                        base.BackgroundImage = value;
                    });
                }
            }
        }

        public PigeonPeekF()
        {
            InitializeComponent();
            base.StartPosition = FormStartPosition.Manual;
            peek1 = new Bitmap("Assets\\PigeonPeek.png");
            peek2 = new Bitmap("Assets\\PigeonPeek2.png");
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
            UpdateStyles();
        }

        public void ShowDialog(Point pos, int endF, Size lastPos)
        {
            startFrame = Tracker.frame;
            endFrame = endF;
            lastPosition = lastPos;
            sustainLength = Math.Max(1L, endFrame - startFrame);
            base.Location = pos;
            startLocation = base.Location;
            TrackedDialogHelper.Show(this, 8, delegate(long frame)
            {
                base.BackgroundImage = ((frame % 4 < 2) ? peek1 : peek2);
                double num2 = (double)(frame - startFrame) / (double)sustainLength;
                base.Location = new Point(startLocation.X - lastPos.Width, (int)((double)startLocation.Y - F(num2) * (double)lastPos.Height));
                return num2 <= 0.949999988079071;
            });
        }

        private double F(double x)
        {
            double num = -Math.E * x * Math.Log(x);
            double value = 0.0 - Math.Pow(num, 0.4);
            return Math.Abs(value);
        }
    }
}
