using System;
using System.Threading;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
    public partial class BlueScreen : Form
    {
        private readonly System.Windows.Forms.Timer progressTimer;

        private readonly int[] progressDurations = new int[] { 2500, 2500, 2600, 1500, 200, 200, 200, 200 };

        private readonly string[] progressTexts = new string[] { "11% 完成", "24% 完成", "35% 完成", "41% 完成", "58% 完成", "81% 完成", "100% 完成" };

        private int progressIndex;

        public BlueScreen()
        {
            InitializeComponent();
            Cursor.Hide();
            if (Environment.OSVersion.Version.Major >= 10)
            {
                panel1.Visible = false;
            }
            progressTimer = new System.Windows.Forms.Timer();
            progressTimer.Interval = progressDurations[0];
            progressTimer.Tick += ProgressTimer_Tick;
            Disposed += BlueScreen_Disposed;
            progressTimer.Start();
        }

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            if (progressIndex >= progressTexts.Length)
            {
                progressTimer.Stop();
                Close();
                return;
            }
            label3.Text = progressTexts[progressIndex];
            progressIndex++;
            progressTimer.Interval = progressDurations[progressIndex];
        }

        private void BlueScreen_Disposed(object sender, EventArgs e)
        {
            progressTimer.Dispose();
        }
    }
}
