using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using PowerfulWindSlickedBackHair.Tools;

namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x02000014 RID: 20
	public partial class HugeBlow : Form
	{
		// Token: 0x06000069 RID: 105 RVA: 0x00006AA4 File Offset: 0x00004CA4
		public HugeBlow()
		{
			this.InitializeComponent();
			this.blow2 = new Bitmap("Assets//HugeBlow2.png");
			base.StartPosition = FormStartPosition.CenterScreen;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00006AD4 File Offset: 0x00004CD4
		public void ShowDialog(int endFrame)
		{
			base.TopMost = true;
			bool isBlowSwitched = false;
			TrackedDialogHelper.Show(this, 8, delegate(long frame)
			{
				if (!isBlowSwitched && frame >= 1820L)
				{
					this.BackgroundImage = this.blow2;
					isBlowSwitched = true;
				}
				int num = (int)((PerlinNoise.Noise((float)frame / 2f, (float)frame / 2f + 200f, 0f) - 0.5f) * 80f);
				int num2 = (int)((PerlinNoise.Noise((float)frame / 2f + 400f, (float)frame / 2f + 510f, 0f) - 0.5f) * 80f);
				this.Location = new Point(num + this.startLoc.X, num2 + this.startLoc.Y);
				return frame <= (long)endFrame;
			});
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00006B1E File Offset: 0x00004D1E
		private void HugeBlow_Load(object sender, EventArgs e)
		{
			this.startLoc = base.Location;
		}

		// Token: 0x04000048 RID: 72
		private Bitmap blow2;

		// Token: 0x04000049 RID: 73
		private Point startLoc;
	}
}
