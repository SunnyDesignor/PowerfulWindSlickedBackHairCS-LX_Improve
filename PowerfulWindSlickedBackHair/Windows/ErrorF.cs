using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x0200000E RID: 14
	public partial class ErrorF : Form
	{
		// Token: 0x0600003F RID: 63 RVA: 0x000058D2 File Offset: 0x00003AD2
		public ErrorF()
		{
			this.InitializeComponent();
			base.StartPosition = FormStartPosition.Manual;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000058F4 File Offset: 0x00003AF4
		public void ShowDialog(Point pos, int endFrame)
		{
			base.Location = pos;
			Thread thread = new Thread(delegate()
			{
				int endFrame2 = endFrame;
				bool flag;
				do
				{
					flag = (Tracker.frame > (long)endFrame);
				}
				while (!flag);
				this.Hide();
			});
			thread.Start();
			base.ShowDialog();
		}
	}
}
