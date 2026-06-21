using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
    public partial class BirdWaveF : Form
    {
        //private bool isFlip;

        private Bitmap wave1;

        private Bitmap wave2;

        private Bitmap wave1F;

        private Bitmap wave2F;

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

        public BirdWaveF(bool isWhite)
        {
            InitializeComponent();
            wave1 = ((!isWhite) ? new Bitmap("Assets\\BlackBirdWave1.png") : new Bitmap("Assets\\WhiteBirdWave1.png"));
            wave2 = ((!isWhite) ? new Bitmap("Assets\\BlackBirdWave2.png") : new Bitmap("Assets\\WhiteBirdWave2.png"));
            wave1F = new Bitmap(wave1);
            wave1F.RotateFlip(RotateFlipType.RotateNoneFlipX);
            wave2F = new Bitmap(wave2);
            wave2F.RotateFlip(RotateFlipType.RotateNoneFlipX);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
            UpdateStyles();
        }

        public void ShowDialog(long endF, Point p)
        {
            base.Location = p;
            TrackedDialogHelper.Show(this, 8, delegate(long frame)
            {
                long num2 = frame % 40;
                if (num2 < 10)
                {
                    base.BackgroundImage = wave1;
                }
                else if (num2 < 20)
                {
                    base.BackgroundImage = wave2;
                }
                else if (num2 < 30)
                {
                    base.BackgroundImage = wave1F;
                }
                else
                {
                    base.BackgroundImage = wave2F;
                }
                return frame <= endF;
            });
        }
    }
}
