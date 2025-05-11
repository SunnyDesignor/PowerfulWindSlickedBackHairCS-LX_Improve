using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using PowerfulWindSlickedBackHair.Tools;
using static System.Windows.Forms.AxHost;

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

        private float speedRate = 1f;

        private bool isDown;

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
        public float SpeedRate
        {
            get { return speedRate; }
            set { speedRate = value; speedRate = value; }
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
                    MainForm.WindSpeed = 5;
                    Thread.Sleep(1);
                }
                MainForm.WindSpeed = 1;
                canJump = true;
                lastP = -1;
                while (base.Location != startLoc)
                {
                    base.Location = startLoc;
                    Thread.Sleep(1);
                }
            };
        }

        public void ShowDialog(Point pos, int endFrame)
        {
            base.Location = pos;
            jumpSpace = 1 / speedRate;
            yukiJumper = Tracker.AddThread("YukiJumper", delegate
            {
                float startY = base.Location.Y;
                bool isPerformingJumpAnimation = false;
                DateTime jumpAnimationStartTime = DateTime.Now;
                DateTime nextToggleTime = DateTime.Now;
                while (Tracker.Running)
                {
                    DateTime currentTime = DateTime.Now;
                    if (currentTime < nextToggleTime)
                    {
                        if (isPerformingJumpAnimation)
                        {
                            if (!canJump)
                            {
                                isPerformingJumpAnimation = false;
                                base.Location = new Point(base.Location.X, (int)startY);
                            }
                            else
                            {
                                TimeSpan elapsedSinceJumpStart = currentTime - jumpAnimationStartTime;
                                float progress = (float)elapsedSinceJumpStart.TotalSeconds / (0.4f / SpeedRate);

                                if (progress >= 1.0f)
                                {
                                    isPerformingJumpAnimation = false;
                                    base.Location = new Point(base.Location.X, (int)startY);
                                }
                                else
                                {
                                    float t = progress;
                                    float verticalOffset = jumpHeight * 4 * t * (1 - t);
                                    Point location = new Point(base.Location.X, (int)(startY - verticalOffset * 50));
                                    base.Location = location;
                                }
                            }
                        }
                        int msToWait = (int)(nextToggleTime - currentTime).TotalMilliseconds;
                        Thread.Sleep(Math.Min(10, Math.Max(1, msToWait)));
                        continue;
                    }
                    isDown = !isDown;
                    nextToggleTime = DateTime.Now.AddMilliseconds(431f * jumpSpace);
                    if (canJump)
                    {
                        if (!isPerformingJumpAnimation)
                        {
                            isPerformingJumpAnimation = true;
                            jumpAnimationStartTime = DateTime.Now;
                        }
                    }
                    else
                    {
                        isPerformingJumpAnimation = false;
                    }
                    if (!isPerformingJumpAnimation)
                    {
                        Thread.Sleep(1);
                    }
                }
            });
            Tracker.AddAndStartThread("yukiJumper", () =>
            {
                int num = endFrame;
                yukiJumper.Start();
                do
                {
                    UpdateF(Tracker.frame);
                    Thread.Sleep(5);
                }
                while (Tracker.frame <= endFrame);
                Hide();
                if (yukiJumper.IsAlive)
                {
                    yukiJumper.Abort();
                }
            });
            try
            {
                ShowDialog();
            }
            catch (Exception)
            {
            }
        }

        float maxOpacity = 0.66f;

        private void UpdateF(long f)
        {
            switch (f)
            {
                case 153L:
                    base.Opacity = 0.0;
                    break;
                case 172L:
                    {
                        jumpSpace = 0.15f / speedRate;
                        base.Opacity = maxOpacity;
                        jumpHeight = 0f;
                        Thread thread4 = new Thread(yukiMoveToRight);
                        thread4.Start();
                        break;
                    }
                case 235L:
                    base.Opacity = 0.0;
                    jumpSpace = 1 / speedRate;
                    jumpHeight = 1f;
                    base.Location = startLoc;
                    break;
                case 315L:
                    YukiState = YukiState.YellowBlow;
                    base.Opacity = maxOpacity;
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
                    base.Opacity = maxOpacity;
                    break;
                case 1371L:
                    base.Opacity = 0.0;
                    break;
                case 1392L:
                    {
                        jumpSpace = 0.15f / speedRate;
                        base.Opacity = maxOpacity;
                        jumpHeight = 0f;
                        Thread thread3 = new Thread(yukiMoveToRight);
                        thread3.Start();
                        break;
                    }
                case 1454L:
                    base.Opacity = 0.0;
                    jumpSpace = 1 / speedRate;
                    base.Location = startLoc;
                    jumpHeight = 1f;
                    break;
                case 1685L:
                    YukiState = YukiState.YellowBlow;
                    base.Opacity = maxOpacity;
                    break;
                case 1811L:
                    base.Opacity = 0.0;
                    break;
                case 1874L:
                    YukiState = YukiState.YellowNormal;
                    base.Opacity = maxOpacity;
                    break;
                case 1979L:
                    base.Opacity = 0.0;
                    break;
                case 1998L:
                    {
                        jumpSpace = 0.15f / speedRate;
                        base.Opacity = maxOpacity;
                        jumpHeight = 0f;
                        Thread thread2 = new Thread(yukiMoveToRight);
                        thread2.Start();
                        break;
                    }
                case 2062L:
                    base.Opacity = 0.0;
                    jumpSpace = 1 / speedRate;
                    base.Location = startLoc;
                    jumpHeight = 1f;
                    break;
                case 2151L:
                    base.Opacity = maxOpacity;
                    break;
                case 2284L:
                    base.Opacity = 0.0;
                    break;
                case 2304L:
                    {
                        jumpSpace = 0.15f / speedRate;
                        base.Opacity = maxOpacity;
                        jumpHeight = 0f;
                        Thread thread = new Thread(yukiMoveToRight);
                        thread.Start();
                        break;
                    }
                case 2369L:
                    base.Opacity = 0.0;
                    base.Location = startLoc;
                    jumpSpace = 1 / speedRate;
                    jumpHeight = 1f;
                    break;
                case 2523L:
                    YukiState = YukiState.YellowBlow;
                    base.Opacity = maxOpacity;
                    break;
                case 2817L:
                    base.Opacity = 0.0;
                    break;
            }
            SwitchBackgroundSecondly();
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
                    BackgroundImage = (isDown ? downNor : upNor);
                    break;
                case YukiState.YellowBlow:
                    BackgroundImage = (isDown ? downBlw : upBlw);
                    break;
                case YukiState.BlueNormal:
                    BackgroundImage = (isDown ? downBluNor : upBluNor);
                    break;
                case YukiState.BlueBlow:
                    BackgroundImage = (isDown ? downBluBlw : upBluBlw);
                    break;
            }
        }
    }
}
