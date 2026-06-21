using System;
using System.Drawing;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
    public partial class RollingDogF : Form
    {
        private const int RollingFrameIntervalMs = 100;

        private readonly Bitmap dogWalk1;

        private readonly Bitmap dogWalk2;

        private readonly Bitmap[] dogRollingFrames;

        private readonly Icon warningIcon;

        private readonly System.Windows.Forms.Timer animationTimer;

        private long switchF;

        private long startFrame;

        private long endFrame;

        private int lastPosition;

        private long sustainLength;

        private Point startLocation;

        private bool isShowMsg;

        private bool isRollingStarted;

        private bool isAnimationFinished;

        private int currentRollingFrameIndex;

        private long lastRollingFrameTick;

        private NotifyIcon notifyIcon;

        public RollingDogF()
        {
            InitializeComponent();
            dogRollingFrames = CreateRollingFrames("Assets\\RollingDog.png");
            dogWalk1 = new Bitmap("Assets\\DogWalk1.png");
            dogWalk2 = new Bitmap("Assets\\DogWalk2.png");
            warningIcon = new Icon("Assets\\Cross.ico");
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 8;
            animationTimer.Tick += AnimationTimer_Tick;
            Disposed += RollingDogF_Disposed;
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
            sustainLength = Math.Max(1L, endFrame - startFrame);
            startLocation = pos;
            base.Location = pos;
            switchF = endF - 30;
            this.isShowMsg = isShowMsg;
            isRollingStarted = false;
            isAnimationFinished = false;
            currentRollingFrameIndex = 0;
            base.BackgroundImage = dogWalk1;
            MainForm.WindSpeed = 5;
            animationTimer.Start();
            try
            {
                base.ShowDialog();
            }
            finally
            {
                animationTimer.Stop();
                MainForm.WindSpeed = 1;
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (isAnimationFinished)
            {
                return;
            }
            if (!Tracker.Running)
            {
                FinishAnimation();
                return;
            }
            long frame = Tracker.frame;
            UpdateLocation(frame);
            if (frame < switchF)
            {
                base.BackgroundImage = ((frame % 6 < 3) ? dogWalk1 : dogWalk2);
            }
            else
            {
                if (!isRollingStarted)
                {
                    isRollingStarted = true;
                    currentRollingFrameIndex = 1;
                    lastRollingFrameTick = DateTime.UtcNow.Ticks;
                }
                if (this.isShowMsg)
                {
                    ShowWarning();
                    this.isShowMsg = false;
                }
                UpdateRollingFrame();
            }
            if (frame > endFrame)
            {
                FinishAnimation();
            }
        }

        private void UpdateLocation(long frame)
        {
            double progress = Math.Min(1.0, (double)(frame - startFrame) / (double)sustainLength);
            base.Location = new Point((int)((double)startLocation.X + progress * (double)lastPosition), startLocation.Y);
        }

        private void UpdateRollingFrame()
        {
            long currentTick = DateTime.UtcNow.Ticks;
            long frameIntervalTick = TimeSpan.TicksPerMillisecond * RollingFrameIntervalMs;
            long elapsedTick = currentTick - lastRollingFrameTick;
            if (elapsedTick >= frameIntervalTick)
            {
                long step = Math.Max(1L, elapsedTick / frameIntervalTick);
                currentRollingFrameIndex = (currentRollingFrameIndex + (int)(step % dogRollingFrames.Length)) % dogRollingFrames.Length;
                lastRollingFrameTick += step * frameIntervalTick;
            }
            base.BackgroundImage = dogRollingFrames[currentRollingFrameIndex];
        }

        private void ShowWarning()
        {
            CleanupNotifyIcon();
            notifyIcon = new NotifyIcon();
            notifyIcon.Visible = true;
            notifyIcon.Icon = warningIcon;
            notifyIcon.BalloonTipTitle = "风力实在是太强了！";
            notifyIcon.BalloonTipText = "风力实在是太强了！\r\n我整条狗都快被吹飞了！";
            notifyIcon.ShowBalloonTip(1000, "风力实在是太强了！", "我整条狗都快被吹飞了！", ToolTipIcon.Warning);
        }

        private void FinishAnimation()
        {
            if (isAnimationFinished)
            {
                return;
            }
            isAnimationFinished = true;
            animationTimer.Stop();
            base.Location = new Point(startLocation.X + lastPosition, startLocation.Y);
            Hide();
        }

        private void CleanupNotifyIcon()
        {
            if (notifyIcon == null)
            {
                return;
            }
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            notifyIcon = null;
        }

        private void RollingDogF_Disposed(object sender, EventArgs e)
        {
            animationTimer.Dispose();
            CleanupNotifyIcon();
            warningIcon.Dispose();
            dogWalk1.Dispose();
            dogWalk2.Dispose();
            foreach (Bitmap dogRollingFrame in dogRollingFrames)
            {
                dogRollingFrame.Dispose();
            }
        }

        private static Bitmap[] CreateRollingFrames(string imagePath)
        {
            Bitmap[] frames = new Bitmap[4];
            frames[0] = new Bitmap(imagePath);
            for (int i = 1; i < frames.Length; i++)
            {
                frames[i] = new Bitmap(frames[i - 1]);
                frames[i].RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            return frames;
        }
    }
}
