using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using PowerfulWindSlickedBackHair.Tools;

namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x02000015 RID: 21
	public partial class JumpingYukiForm : Form
	{
        private Bitmap upNor;

        private Bitmap downNor;

        private Bitmap upBlw;

        private Bitmap downBlw;

        private Bitmap upBluNor;

        private Bitmap downBluNor;

        private Bitmap upBluBlw;

        private Bitmap downBluBlw;

        private Point startLoc;

        private float jumpSpace = 1f;

        private float jumpHeight = 1f;

        private bool canJump = true;

        private YukiState state;

        private Thread yukiJumper;

        private ThreadStart yukiMoveToRight;

        private int lastP = -1;

        private YukiState YukiState
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }

        public JumpingYukiForm()
        {
            InitializeComponent();
            upNor = new Bitmap("Assets\\JumpUp.png");
            downNor = new Bitmap("Assets\\JumpDown.png");
            upBlw = new Bitmap("Assets\\JumpUpBlow.png");
            downBlw = new Bitmap("Assets\\JumpDownBlow.png");
            upBluBlw = new Bitmap("Assets\\JumpUpBlowBlue.png");
            downBluBlw = new Bitmap("Assets\\JumpDownBlowBlue.png");
            base.StartPosition = FormStartPosition.Manual;
            YukiState = YukiState.YellowNormal;
            yukiMoveToRight = delegate
            {
                canJump = false;
                long num = 70L;
                long frame = Tracker.frame;
                long num2 = Tracker.frame + num;
                while (base.Location.X - startLoc.X < 950)
                {
                    double num3 = (double)(Tracker.frame - frame) / (double)num;
                    lastP = Math.Max(lastP, (int)((double)startLoc.X + num3 * 1000.0));
                    base.Location = new Point(lastP, startLoc.Y);
                    Thread.Sleep(1);
                }
                canJump = true;
                lastP = -1;
                while (base.Location != startLoc)
                {
                    base.Location = startLoc;
                }
            };
        }

        public void ShowDialog(Point pos, int endFrame)
        {
            base.Location = pos;
            yukiJumper = Tracker.AddThread("YukiJumper", delegate
            {
                for (int i = 0; i < 1024; i++)
                {
                    Thread thread2 = new Thread((ThreadStart)delegate
                    {
                        SwitchBackgroundSecondly();
                    });
                    Thread thread3 = new Thread((ThreadStart)delegate
                    {
                        float num2 = base.Location.Y;
                        float num3 = 0f;
                        while (num3 < 0.4f)
                        {
                            if (canJump)
                            {
                                num3 += 0.02f + 0.08f * (1f - jumpSpace);
                                Point location = new Point(base.Location.X, (int)((double)num2 + (double)(jumpHeight * 200f * num3) * Math.Log((double)num3 * 2.5)));
                                base.Location = location;
                                Thread.Sleep(1);
                            }
                        }
                    });
                    thread2.Start();
                    if (canJump)
                    {
                        thread3.Start();
                    }
                    Thread.Sleep((int)(431f * jumpSpace));
                }
            });
            Thread thread = new Thread((ThreadStart)delegate
            {
                int num = endFrame;
                yukiJumper.Start();
                do
                {
                    UpdateF(Tracker.frame);
                }
                while (Tracker.frame <= endFrame);
                Hide();
                yukiJumper.Abort();
            });
            thread.Start();
            ShowDialog();
        }

        private void UpdateF(long f)
        {
            switch (f)
            {
                case 153L:
                    base.Opacity = 0.0;
                    break;
                case 172L:
                    {
                        jumpSpace = 0.4f;
                        base.Opacity = 1.0;
                        jumpHeight = 0f;
                        Thread thread4 = new Thread(yukiMoveToRight);
                        thread4.Start();
                        break;
                    }
                case 235L:
                    base.Opacity = 0.0;
                    jumpSpace = 1f;
                    jumpHeight = 1f;
                    base.Location = startLoc;
                    break;
                case 315L:
                    YukiState = YukiState.YellowBlow;
                    base.Opacity = 1.0;
                    break;
                case 390L:
                    YukiState = YukiState.BlueBlow;
                    break;
                case 467L:
                    YukiState = YukiState.YellowBlow;
                    break;
                case 542L:
                    YukiState = YukiState.BlueBlow;
                    break;
                case 619L:
                    base.Opacity = 0.0;
                    YukiState = YukiState.YellowNormal;
                    break;
                case 1228L:
                    YukiState = YukiState.YellowNormal;
                    base.Opacity = 1.0;
                    break;
                case 1371L:
                    base.Opacity = 0.0;
                    break;
                case 1392L:
                    {
                        jumpSpace = 0.4f;
                        base.Opacity = 1.0;
                        jumpHeight = 0f;
                        Thread thread3 = new Thread(yukiMoveToRight);
                        thread3.Start();
                        break;
                    }
                case 1454L:
                    base.Opacity = 0.0;
                    jumpSpace = 1f;
                    base.Location = startLoc;
                    jumpHeight = 1f;
                    break;
                case 1685L:
                    YukiState = YukiState.YellowBlow;
                    base.Opacity = 1.0;
                    break;
                case 1811L:
                    base.Opacity = 0.0;
                    break;
                case 1874L:
                    YukiState = YukiState.YellowNormal;
                    base.Opacity = 1.0;
                    break;
                case 1979L:
                    base.Opacity = 0.0;
                    break;
                case 1998L:
                    {
                        jumpSpace = 0.4f;
                        base.Opacity = 1.0;
                        jumpHeight = 0f;
                        Thread thread2 = new Thread(yukiMoveToRight);
                        thread2.Start();
                        break;
                    }
                case 2062L:
                    base.Opacity = 0.0;
                    jumpSpace = 1f;
                    base.Location = startLoc;
                    jumpHeight = 1f;
                    break;
                case 2151L:
                    base.Opacity = 1.0;
                    break;
                case 2284L:
                    base.Opacity = 0.0;
                    break;
                case 2304L:
                    {
                        jumpSpace = 0.4f;
                        base.Opacity = 1.0;
                        jumpHeight = 0f;
                        Thread thread = new Thread(yukiMoveToRight);
                        thread.Start();
                        break;
                    }
                case 2369L:
                    base.Opacity = 0.0;
                    base.Location = startLoc;
                    jumpSpace = 1f;
                    jumpHeight = 1f;
                    break;
                case 2523L:
                    YukiState = YukiState.YellowBlow;
                    base.Opacity = 1.0;
                    break;
                case 2817L:
                    base.Opacity = 0.0;
                    break;
            }
        }

        private void JumpingYukiForm_Load(object sender, EventArgs e)
        {
            base.TopMost = true;
            base.TopLevel = true;
            startLoc = base.Location;
        }

        private void SwitchBackgroundSecondly()
        {
            switch (YukiState)
            {
                case YukiState.YellowNormal:
                    BackgroundImage = ((BackgroundImage == upNor) ? downNor : upNor);
                    break;
                case YukiState.YellowBlow:
                    BackgroundImage = ((BackgroundImage == upBlw) ? downBlw : upBlw);
                    break;
                case YukiState.BlueNormal:
                    BackgroundImage = ((BackgroundImage == upBluNor) ? downBluNor : upBluNor);
                    break;
                case YukiState.BlueBlow:
                    BackgroundImage = ((BackgroundImage == upBluBlw) ? downBluBlw : upBluBlw);
                    break;
            }
        }
    }
}
