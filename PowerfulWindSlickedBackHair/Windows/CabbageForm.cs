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
			Thread thread = new Thread(delegate()
			{
				int endFrame2 = endFrame;
				for (;;)
				{
					bool flag = Tracker.frame > (long)endFrame;
					if (flag)
					{
						break;
					}
					bool flag2 = Tracker.frame > this.startF + 5L && !this.isClicked;
					if (flag2)
					{
						this.BackgroundImage = this.cut;
						this.isClicked = true;
					}
					bool flag3 = this.isClicked;
					if (flag3)
					{
						goto Block_4;
					}
				}
				this.Hide();
				return;
				Block_4:
				int i = (int)(this.Opacity * 50.0);
				while (i > 0)
				{
					Thread.Sleep(10);
					bool flag4 = this.Opacity < 0.05000000074505806;
					if (flag4)
					{
						this.Hide();
					}
					this.Opacity -= 0.019999999552965164;
				}
				this.Hide();
			});
			thread.Start();
			base.ShowDialog();
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
