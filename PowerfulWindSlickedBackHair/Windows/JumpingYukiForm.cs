using System;
using System.Drawing;
using System.Windows.Forms;
using PowerfulWindSlickedBackHair.Tools;

namespace PowerfulWindSlickedBackHair.Windows
{
    public partial class JumpingYukiForm : Form
    {
        private const long MoveDurationFrame = 70L;

        private const int MoveDistance = 1000;

        private const int MoveResetDistance = 950;

        private const float JumpAnimationSeconds = 0.4f;

        private Bitmap upNor;

        private Bitmap downNor;

        private Bitmap upBlw;

        private Bitmap downBlw;

        private Bitmap upBluBlw;

        private Bitmap downBluBlw;

        private Point startLoc;

        private float jumpSpace = 1f;

        private float jumpHeight = 1f;

        private bool canJump = true;

        private YukiState state;

        private int lastP = -1;

        private float speedRate = 1f;

        private bool isDown;

        private bool isPerformingJumpAnimation;

        private bool isMovingToRight;

        private long moveStartFrame;

        private DateTime jumpAnimationStartTime;

        private DateTime nextToggleTime;

        private float maxOpacity = 0.66f;

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
            get
            {
                return speedRate;
            }
            set
            {
                speedRate = value;
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
            nextToggleTime = DateTime.UtcNow;
        }

        public void ShowDialog(Point pos, int endFrame)
        {
            base.Location = pos;
            startLoc = pos;
            jumpSpace = 1f / speedRate;
            jumpHeight = 1f;
            canJump = true;
            isDown = false;
            isPerformingJumpAnimation = false;
            isMovingToRight = false;
            lastP = -1;
            nextToggleTime = DateTime.UtcNow;
            jumpAnimationStartTime = DateTime.UtcNow;
            try
            {
                TrackedDialogHelper.Show(this, 8, delegate(long frame)
                {
                    UpdateF(frame);
                    return frame <= (long)endFrame;
                }, delegate(long frame)
                {
                    UpdateAnimationTick(frame);
                    SwitchBackgroundSecondly();
                    return true;
                }, delegate()
                {
                    MainForm.WindSpeed = 1;
                    canJump = true;
                    isMovingToRight = false;
                    isPerformingJumpAnimation = false;
                    lastP = -1;
                    base.Location = startLoc;
                });
            }
            catch (Exception)
            {
            }
        }

        private void UpdateAnimationTick(long frame)
        {
            DateTime currentTime = DateTime.UtcNow;
            if (currentTime >= nextToggleTime)
            {
                isDown = !isDown;
                nextToggleTime = currentTime.AddMilliseconds(431f * jumpSpace);
                if (canJump && !isMovingToRight)
                {
                    isPerformingJumpAnimation = true;
                    jumpAnimationStartTime = currentTime;
                }
            }
            if (isMovingToRight)
            {
                double progress = (double)(frame - moveStartFrame) / (double)MoveDurationFrame;
                lastP = Math.Max(lastP, (int)((double)startLoc.X + progress * (double)MoveDistance));
                base.Location = new Point(Math.Min(startLoc.X + MoveResetDistance, lastP), startLoc.Y);
                if (progress >= 1.0 || base.Location.X - startLoc.X >= MoveResetDistance)
                {
                    EndMoveToRight();
                }
                return;
            }
            if (!canJump)
            {
                isPerformingJumpAnimation = false;
                base.Location = new Point(base.Location.X, startLoc.Y);
                return;
            }
            if (!isPerformingJumpAnimation)
            {
                base.Location = new Point(base.Location.X, startLoc.Y);
                return;
            }
            float progress2 = (float)(currentTime - jumpAnimationStartTime).TotalSeconds / (JumpAnimationSeconds / SpeedRate);
            if (progress2 >= 1f)
            {
                isPerformingJumpAnimation = false;
                base.Location = new Point(base.Location.X, startLoc.Y);
                return;
            }
            float verticalOffset = jumpHeight * 4f * progress2 * (1f - progress2);
            base.Location = new Point(base.Location.X, (int)(startLoc.Y - verticalOffset * 50f));
        }

        private void BeginMoveToRight(long frame)
        {
            canJump = false;
            isPerformingJumpAnimation = false;
            isMovingToRight = true;
            moveStartFrame = frame;
            lastP = -1;
            MainForm.WindSpeed = 5;
            base.Location = new Point(base.Location.X, startLoc.Y);
        }

        private void EndMoveToRight()
        {
            MainForm.WindSpeed = 1;
            canJump = true;
            isMovingToRight = false;
            isPerformingJumpAnimation = false;
            lastP = -1;
            base.Location = startLoc;
        }

        private void UpdateF(long f)
        {
            switch (f)
            {
                case 153L:
                    base.Opacity = 0.0;
                    break;
                case 172L:
                    jumpSpace = 0.15f / speedRate;
                    base.Opacity = maxOpacity;
                    jumpHeight = 0f;
                    BeginMoveToRight(f);
                    break;
                case 235L:
                    base.Opacity = 0.0;
                    jumpSpace = 1f / speedRate;
                    jumpHeight = 1f;
                    EndMoveToRight();
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
                    jumpSpace = 0.15f / speedRate;
                    base.Opacity = maxOpacity;
                    jumpHeight = 0f;
                    BeginMoveToRight(f);
                    break;
                case 1454L:
                    base.Opacity = 0.0;
                    jumpSpace = 1f / speedRate;
                    jumpHeight = 1f;
                    EndMoveToRight();
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
                    jumpSpace = 0.15f / speedRate;
                    base.Opacity = maxOpacity;
                    jumpHeight = 0f;
                    BeginMoveToRight(f);
                    break;
                case 2062L:
                    base.Opacity = 0.0;
                    jumpSpace = 1f / speedRate;
                    jumpHeight = 1f;
                    EndMoveToRight();
                    break;
                case 2151L:
                    base.Opacity = maxOpacity;
                    break;
                case 2284L:
                    base.Opacity = 0.0;
                    break;
                case 2304L:
                    jumpSpace = 0.15f / speedRate;
                    base.Opacity = maxOpacity;
                    jumpHeight = 0f;
                    BeginMoveToRight(f);
                    break;
                case 2369L:
                    base.Opacity = 0.0;
                    jumpSpace = 1f / speedRate;
                    jumpHeight = 1f;
                    EndMoveToRight();
                    break;
                case 2523L:
                    YukiState = YukiState.YellowBlow;
                    base.Opacity = maxOpacity;
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
                    BackgroundImage = (isDown ? downNor : upNor);
                    break;
                case YukiState.YellowBlow:
                    BackgroundImage = (isDown ? downBlw : upBlw);
                    break;
                case YukiState.BlueBlow:
                    BackgroundImage = (isDown ? downBluBlw : upBluBlw);
                    break;
            }
        }
    }
}
