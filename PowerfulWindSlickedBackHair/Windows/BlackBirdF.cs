using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x02000009 RID: 9
	public partial class BlackBirdF : Form
	{
		// Token: 0x06000022 RID: 34 RVA: 0x00004D5C File Offset: 0x00002F5C
		public BlackBirdF()
		{
			this.InitializeComponent();
			this.b1 = new Bitmap("Assets\\BlackBird1.png");
			this.b2 = new Bitmap("Assets\\BlackBird2.png");
			this.pictureBox1.BackgroundImage = this.b1;
			base.StartPosition = FormStartPosition.Manual;
			this.backColorY = Color.FromArgb(16701521);
			this.backColorY = Color.FromArgb(255, (int)this.backColorY.R, (int)this.backColorY.G, (int)this.backColorY.B);
			this.pictureBox1.BackColor = this.backColorY;
			this.backColorB = Color.FromArgb(6471671);
			this.backColorB = Color.FromArgb(255, (int)this.backColorB.R, (int)this.backColorB.G, (int)this.backColorB.B);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00004E68 File Offset: 0x00003068
		public void ShowDialog(Point pos, int endF)
		{
			base.Location = pos;
			TrackedDialogHelper.Show(this, 8, delegate(long frame)
			{
				this.UpdateF(frame);
				this.UpdateHitF(frame);
				return frame <= (long)endF;
			}, delegate(long frame)
			{
				this.UpdateHitVisual();
				return true;
			}, null);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00004EB4 File Offset: 0x000030B4
		private void UpdateF(long f)
		{
			if (f <= 390L)
			{
				if (f != 319L)
				{
					if (f == 390L)
					{
						this.pictureBox1.BackColor = this.backColorB;
						this.Hit(0);
					}
				}
				else
				{
					this.pictureBox1.BackColor = this.backColorY;
					this.Hit(-4);
				}
			}
			else if (f != 467L)
			{
				if (f == 542L)
				{
					this.pictureBox1.BackColor = this.backColorB;
					this.Hit(0);
				}
			}
			else
			{
				this.pictureBox1.BackColor = this.backColorY;
				this.Hit(0);
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00004F70 File Offset: 0x00003170
		private void Hit(int offset)
		{
			this.startHitF = Tracker.frame;
			this.hitOffset = offset;
			this.hitIndex = 0;
			this.isHitSequenceActive = true;
			this.isHitVisible = false;
			this.pictureBox1.BackgroundImage = this.b1;
		}

		private void UpdateHitF(long frame)
		{
			if (!this.isHitSequenceActive || this.hitIndex >= this.hitF.Length)
			{
				return;
			}
			if (frame == this.startHitF + this.hitF[this.hitIndex] + (long)this.hitOffset)
			{
				this.pictureBox1.BackgroundImage = this.b2;
				this.hitResetAt = DateTime.UtcNow.AddMilliseconds(50.0);
				this.isHitVisible = true;
				this.hitIndex++;
			}
		}

		private void UpdateHitVisual()
		{
			if (this.isHitVisible && DateTime.UtcNow >= this.hitResetAt)
			{
				this.pictureBox1.BackgroundImage = this.b1;
				this.isHitVisible = false;
			}
			if (this.isHitSequenceActive && this.hitIndex >= this.hitF.Length && !this.isHitVisible)
			{
				this.isHitSequenceActive = false;
			}
		}

		// Token: 0x0400001E RID: 30
		private Bitmap b1;

		// Token: 0x0400001F RID: 31
		private Bitmap b2;

		// Token: 0x04000020 RID: 32
		private Color backColorY;

		// Token: 0x04000021 RID: 33
		private Color backColorB;

		// Token: 0x04000022 RID: 34
		private long[] hitF = new long[]
		{
			7L,
			11L,
			20L,
			28L,
			34L,
			45L,
			50L,
			59L,
			67L,
			73L
		};

		// Token: 0x04000023 RID: 35
		private long startHitF;

		// Token: 0x04000024 RID: 36
		private int hitIndex;

		private int hitOffset;

		private bool isHitSequenceActive;

		private bool isHitVisible;

		private DateTime hitResetAt;
	}
}
