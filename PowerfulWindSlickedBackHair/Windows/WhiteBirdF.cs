using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x0200001A RID: 26
	public partial class WhiteBirdF : Form
	{
		// Token: 0x06000092 RID: 146 RVA: 0x00007E00 File Offset: 0x00006000
		public WhiteBirdF()
		{
			this.InitializeComponent();
			this.hit1 = new Bitmap("Assets\\WhiteBird1.png");
			this.hit2 = new Bitmap("Assets\\WhiteBird2.png");
			base.StartPosition = FormStartPosition.Manual;
			this.backColorY = Color.FromArgb(16701521);
			this.backColorY = Color.FromArgb(255, (int)this.backColorY.R, (int)this.backColorY.G, (int)this.backColorY.B);
			this.BackColor = this.backColorY;
			this.backColorB = Color.FromArgb(6471671);
			this.backColorB = Color.FromArgb(255, (int)this.backColorB.R, (int)this.backColorB.G, (int)this.backColorB.B);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00007EDC File Offset: 0x000060DC
		public void ShowDialog(Point pos, int endF)
		{
			base.Location = pos;
			Thread thread = new Thread(delegate()
			{
				int endF2 = endF;
				for (;;)
				{
					this.UpdateF(Tracker.frame);
					bool flag = Tracker.frame > (long)endF;
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

		// Token: 0x06000094 RID: 148 RVA: 0x00007F28 File Offset: 0x00006128
		private void UpdateF(long frame)
		{
			if (frame <= 390L)
			{
				if (frame != 317L)
				{
					if (frame == 390L)
					{
						this.BackColor = this.backColorB;
						this.Hit();
					}
				}
			}
			else if (frame != 467L)
			{
				if (frame == 542L)
				{
					this.BackColor = this.backColorB;
					this.Hit();
				}
			}
			else
			{
				this.BackColor = this.backColorY;
				this.Hit();
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00007FB4 File Offset: 0x000061B4
		private void Hit()
		{
			Thread thread = new Thread(delegate()
			{
				this.BackgroundImage = this.hit2;
				Thread.Sleep(70);
				this.BackgroundImage = this.hit1;
			});
			thread.Start();
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00007FDB File Offset: 0x000061DB
		private void WhiteBirdF_Load(object sender, EventArgs e)
		{
			this.BackColor = this.backColorY;
			this.Hit();
		}

		// Token: 0x0400007D RID: 125
		private Bitmap hit1;

		// Token: 0x0400007E RID: 126
		private Bitmap hit2;

		// Token: 0x0400007F RID: 127
		private Color backColorY;

		// Token: 0x04000080 RID: 128
		private Color backColorB;
	}
}
