using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using PowerfulWindSlickedBackHair.Properties;

namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x02000012 RID: 18
	public partial class LikeForm : Form
	{
		// Token: 0x06000061 RID: 97 RVA: 0x000065BB File Offset: 0x000047BB
		public LikeForm()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000065D4 File Offset: 0x000047D4
		public void ShowDialog(int endFrame)
		{
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
			base.TopMost = true;
			base.ShowDialog();
		}
	}
}
