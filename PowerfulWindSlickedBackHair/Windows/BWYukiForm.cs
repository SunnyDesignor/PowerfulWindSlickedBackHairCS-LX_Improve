using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x0200000B RID: 11
	public partial class BWYukiForm : Form
	{
		// Token: 0x0600002F RID: 47 RVA: 0x000053CD File Offset: 0x000035CD
		public BWYukiForm()
		{
			this.InitializeComponent();
			base.StartPosition = FormStartPosition.Manual;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000053F0 File Offset: 0x000035F0
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
