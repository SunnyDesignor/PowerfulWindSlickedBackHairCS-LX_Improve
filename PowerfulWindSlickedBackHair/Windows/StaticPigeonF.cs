using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x02000013 RID: 19
	public partial class StaticPigeonF : Form
	{
		// Token: 0x06000065 RID: 101 RVA: 0x00006905 File Offset: 0x00004B05
		public StaticPigeonF()
		{
			this.InitializeComponent();
			base.StartPosition = FormStartPosition.Manual;
			this.grey = new Bitmap("Assets\\GreyPigeon.png");
			this.white = new Bitmap("Assets\\WhitePigeon.png");
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00006948 File Offset: 0x00004B48
		public void ShowDialog(Point pos, long endF, bool isGrey)
		{
			base.Location = pos;
			this.BackgroundImage = (isGrey ? this.grey : this.white);
			Thread thread = new Thread(delegate()
			{
				long endF2 = endF;
				for (;;)
				{
					bool flag = Tracker.frame > endF;
					if (flag)
					{
						break;
					}
					Thread.Sleep(1);
				}
				this.Hide();
			});
			thread.Start();
			base.ShowDialog();
		}

		// Token: 0x04000045 RID: 69
		private Bitmap grey;

		// Token: 0x04000046 RID: 70
		private Bitmap white;
	}
}
