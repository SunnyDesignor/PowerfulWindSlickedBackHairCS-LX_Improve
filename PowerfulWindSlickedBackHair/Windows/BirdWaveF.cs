using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
    public partial class BirdWaveF : Form
    {
        private bool isFlip;

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
                    BeginInvoke((MethodInvoker)delegate
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
            Thread thread = new Thread((ThreadStart)delegate
            {
                long num = endF;
                while (true)
                {
                    long num2 = Tracker.frame % 40;
                    long num3 = num2;
                    long num4 = num3;
                    if (num4 < 10)
                    {
                        BackgroundImage = wave1;
                    }
                    else
                    {
                        long num5 = num4;
                        if (num5 >= 10 && num5 < 20)
                        {
                            BackgroundImage = wave2;
                        }
                        else
                        {
                            long num6 = num4;
                            if (num6 >= 20 && num6 < 30)
                            {
                                BackgroundImage = wave1F;
                            }
                            else
                            {
                                long num7 = num4;
                                if (num7 >= 30 && num7 < 40)
                                {
                                    BackgroundImage = wave2F;
                                }
                            }
                        }
                    }
                    if (Tracker.frame > endF)
                    {
                        break;
                    }
                    Thread.Sleep(3);
                }
                Hide();
            });
            thread.Start();
            ShowDialog();
        }
    }
}
