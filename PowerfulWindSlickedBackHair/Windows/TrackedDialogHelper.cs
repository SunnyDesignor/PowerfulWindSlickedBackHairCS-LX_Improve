using System;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
    internal static class TrackedDialogHelper
    {
        public static void Show(Form owner, int intervalMs, Func<long, bool> onTick)
        {
            Show(owner, intervalMs, null, onTick, null);
        }

        public static void Show(Form owner, int intervalMs, Func<long, bool> onFrameStep, Func<long, bool> onTick, Action onCompleted)
        {
            using (DialogLoop dialogLoop = new DialogLoop(owner, intervalMs, onFrameStep, onTick, onCompleted))
            {
                dialogLoop.ShowDialog();
            }
        }

        private sealed class DialogLoop : IDisposable
        {
            private readonly Form owner;

            private readonly Timer timer;

            private readonly Func<long, bool> onFrameStep;

            private readonly Func<long, bool> onTick;

            private readonly Action onCompleted;

            private bool isRunning;

            private long lastProcessedFrame;

            public DialogLoop(Form owner, int intervalMs, Func<long, bool> onFrameStep, Func<long, bool> onTick, Action onCompleted)
            {
                this.owner = owner;
                this.onFrameStep = onFrameStep;
                this.onTick = onTick;
                this.onCompleted = onCompleted;
                timer = new Timer();
                timer.Interval = intervalMs;
                timer.Tick += Timer_Tick;
            }

            public void ShowDialog()
            {
                isRunning = true;
                lastProcessedFrame = Tracker.frame - 1;
                timer.Start();
                try
                {
                    owner.ShowDialog();
                }
                finally
                {
                    Stop();
                    if (onCompleted != null)
                    {
                        onCompleted();
                    }
                }
            }

            public void Dispose()
            {
                timer.Dispose();
            }

            private void Timer_Tick(object sender, EventArgs e)
            {
                if (!isRunning)
                {
                    return;
                }
                if (owner.IsDisposed)
                {
                    Stop();
                    return;
                }
                if (!Tracker.Running)
                {
                    Finish();
                    return;
                }
                long currentFrame = Tracker.frame;
                if (currentFrame < lastProcessedFrame)
                {
                    lastProcessedFrame = currentFrame - 1;
                }
                if (onFrameStep != null)
                {
                    for (long frame = lastProcessedFrame + 1; frame <= currentFrame; frame++)
                    {
                        if (!onFrameStep(frame))
                        {
                            Finish();
                            return;
                        }
                    }
                }
                lastProcessedFrame = currentFrame;
                if (onTick != null && !onTick(currentFrame))
                {
                    Finish();
                }
            }

            private void Finish()
            {
                if (!isRunning)
                {
                    return;
                }
                Stop();
                if (!owner.IsDisposed)
                {
                    owner.Hide();
                }
            }

            private void Stop()
            {
                if (!isRunning)
                {
                    return;
                }
                isRunning = false;
                timer.Stop();
            }
        }
    }
}
