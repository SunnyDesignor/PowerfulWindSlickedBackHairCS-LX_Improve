using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x02000007 RID: 7
	public partial class AhhhF : Form
	{
		// Token: 0x06000019 RID: 25 RVA: 0x00003456 File Offset: 0x00001656
		public AhhhF()
		{
			this.InitializeComponent();
			base.StartPosition = FormStartPosition.Manual;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00003478 File Offset: 0x00001678
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
