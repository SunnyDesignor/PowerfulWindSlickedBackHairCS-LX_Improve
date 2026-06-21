using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
    // Token: 0x0200000C RID: 12
    public partial class CabbageForm : Form
    {
        // Token: 0x06000033 RID: 51 RVA: 0x00005518 File Offset: 0x00003718
        public CabbageForm()
        {
            this.InitializeComponent();
            this.cut = new Bitmap("Assets//CabbageCut.png");
            base.StartPosition = FormStartPosition.Manual;
        }

        // Token: 0x06000034 RID: 52 RVA: 0x00005548 File Offset: 0x00003748
        public void ShowDialog(int endFrame, Point startPos)
        {
            base.Location = startPos;
            this.startF = Tracker.frame;
            this.isClicked = false;
            this.Opacity = 1.0;
            DateTime nextFadeAt = DateTime.UtcNow;
            TrackedDialogHelper.Show(this, 8, delegate(long frame)
            {
                if (frame > (long)endFrame)
                {
                    return false;
                }
                if (frame > this.startF + 5L && !this.isClicked)
                {
                    this.BackgroundImage = this.cut;
                    this.isClicked = true;
                    nextFadeAt = DateTime.UtcNow;
                }
                if (this.isClicked && DateTime.UtcNow >= nextFadeAt)
                {
                    if (this.Opacity < 0.05000000074505806)
                    {
                        return false;
                    }
                    this.Opacity -= 0.019999999552965164;
                    nextFadeAt = DateTime.UtcNow.AddMilliseconds(10.0);
                }
                return true;
            });
        }

        // Token: 0x06000035 RID: 53 RVA: 0x0000559D File Offset: 0x0000379D
        private void CabbageForm_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = this.cut;
            this.isClicked = true;
        }

        // Token: 0x0400002E RID: 46
        private Bitmap cut;

        // Token: 0x0400002F RID: 47
        private bool isClicked;

        // Token: 0x04000030 RID: 48
        private long startF;
    }
}
