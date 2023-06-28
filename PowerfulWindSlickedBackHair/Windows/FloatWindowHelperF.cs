using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x02000010 RID: 16
	public partial class FloatWindowHelperF : Form
	{
		// Token: 0x0600004A RID: 74
		[DllImport("user32.dll")]
		private static extern bool GetCursorPos(ref Point lpPoint);

		// Token: 0x0600004B RID: 75 RVA: 0x00005C24 File Offset: 0x00003E24
		public FloatWindowHelperF()
		{
			this.InitializeComponent();
			this.yukiWindow = new FloatYukiWindow();
			this.yukiWindow.TopMost = true;
			this.screen = Screen.PrimaryScreen.WorkingArea;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00005C7C File Offset: 0x00003E7C
		public void ShowDialog(int endFrame)
		{
			this.yukiWindow.Show();
			Thread thread = new Thread(delegate()
			{
				int endFrame2 = endFrame;
				for (;;)
				{
					FloatWindowHelperF.GetCursorPos(ref this.cursorP);
					this.yukiWindow.Location = new Point(this.cursorP.X + 8, Cursor.Position.Y - this.yukiWindow.Height / 2);
					this.yukiWindow.TopMost = true;
					bool flag = this.lastFlame != Tracker.frame;
					if (flag)
					{
						this.lastFlame = Tracker.frame;
						this.UpdateFlame(Tracker.frame);
					}
					bool flag2 = Tracker.frame > (long)endFrame;
					if (flag2)
					{
						break;
					}
					Thread.Sleep(3);
				}
				this.Hide();
				this.yukiWindow.Close();
			});
			thread.Start();
			base.ShowDialog();
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00005CCC File Offset: 0x00003ECC
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			bool flag = e.Button == MouseButtons.None && base.ClientRectangle.Contains(e.Location);
			if (flag)
			{
				this.yukiWindow.Location = new Point(Cursor.Position.X + 16, Cursor.Position.Y - this.yukiWindow.Height / 2);
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00005D44 File Offset: 0x00003F44
		private void UpdateFlame(long f)
		{
			if (f <= 1624L)
			{
				if (f <= 1567L)
				{
					if (f != 1535L)
					{
						if (f == 1567L)
						{
							Thread thread = new Thread(delegate()
							{
								CabbageForm cabbageForm = new CabbageForm();
								cabbageForm.ShowDialog(1685, this.Center(this.screen, new Rectangle(Point.Empty, cabbageForm.Size)));
							});
							thread.Start();
						}
					}
					else
					{
						Thread thread2 = new Thread(delegate()
						{
							CabbageForm cabbageForm = new CabbageForm();
							cabbageForm.ShowDialog(1685, this.Center(this.screen, new Rectangle(Point.Empty, cabbageForm.Size)));
						});
						thread2.Start();
					}
				}
				else if (f != 1604L)
				{
					if (f != 1614L)
					{
						if (f == 1624L)
						{
							Thread thread3 = new Thread(delegate()
							{
								CabbageForm cabbageForm = new CabbageForm();
								Point point = this.Center(this.screen, new Rectangle(Point.Empty, cabbageForm.Size));
								cabbageForm.ShowDialog(1685, new Point(point.X + 60, point.Y));
							});
							thread3.Start();
						}
					}
					else
					{
						Thread thread4 = new Thread(delegate()
						{
							CabbageForm cabbageForm = new CabbageForm();
							Point point = this.Center(this.screen, new Rectangle(Point.Empty, cabbageForm.Size));
							cabbageForm.ShowDialog(1685, new Point(point.X - 60, point.Y));
						});
						thread4.Start();
					}
				}
				else
				{
					Thread thread5 = new Thread(delegate()
					{
						CabbageForm cabbageForm = new CabbageForm();
						Point point = this.Center(this.screen, new Rectangle(Point.Empty, cabbageForm.Size));
						cabbageForm.ShowDialog(1685, new Point(point.X - 180, point.Y));
					});
					thread5.Start();
				}
			}
			else if (f <= 1640L)
			{
				if (f != 1634L)
				{
					if (f == 1640L)
					{
						Thread thread6 = new Thread(delegate()
						{
							CabbageForm cabbageForm = new CabbageForm();
							Point startPos = this.Center(this.screen, new Rectangle(Point.Empty, cabbageForm.Size));
							cabbageForm.ShowDialog(1685, startPos);
						});
						thread6.Start();
					}
				}
				else
				{
					Thread thread7 = new Thread(delegate()
					{
						CabbageForm cabbageForm = new CabbageForm();
						Point point = this.Center(this.screen, new Rectangle(Point.Empty, cabbageForm.Size));
						cabbageForm.ShowDialog(1685, new Point(point.X + 180, point.Y));
					});
					thread7.Start();
				}
			}
			else if (f != 1650L)
			{
				if (f != 1660L)
				{
					if (f == 1670L)
					{
						Thread thread8 = new Thread(delegate()
						{
							CabbageForm cabbageForm = new CabbageForm();
							Point startPos = this.Center(this.screen, new Rectangle(Point.Empty, cabbageForm.Size));
							cabbageForm.ShowDialog(1685, startPos);
						});
						thread8.Start();
					}
				}
				else
				{
					Thread thread9 = new Thread(delegate()
					{
						CabbageForm cabbageForm = new CabbageForm();
						Point point = this.Center(this.screen, new Rectangle(Point.Empty, cabbageForm.Size));
						cabbageForm.ShowDialog(1685, new Point(point.X + 180, point.Y));
					});
					thread9.Start();
				}
			}
			else
			{
				Thread thread10 = new Thread(delegate()
				{
					CabbageForm cabbageForm = new CabbageForm();
					Point point = this.Center(this.screen, new Rectangle(Point.Empty, cabbageForm.Size));
					cabbageForm.ShowDialog(1685, new Point(point.X - 180, point.Y));
				});
				thread10.Start();
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00005F44 File Offset: 0x00004144
		private Point Center(Rectangle big, Rectangle small)
		{
			return new Point(big.Width / 2 - small.Width / 2, big.Height / 2 - small.Height / 2);
		}

		// Token: 0x0400003A RID: 58
		private FloatYukiWindow yukiWindow;

		// Token: 0x0400003B RID: 59
		private Point cursorP = default(Point);

		// Token: 0x0400003C RID: 60
		private long lastFlame;

		// Token: 0x0400003D RID: 61
		private Rectangle screen;
	}
}
