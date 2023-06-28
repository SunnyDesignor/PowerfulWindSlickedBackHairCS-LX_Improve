using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using PowerfulWindSlickedBackHair.Windows;

namespace PowerfulWindSlickedBackHair.Tools
{
	// Token: 0x0200001C RID: 28
	public static class BWYukiShower
	{
		// Token: 0x060000A2 RID: 162 RVA: 0x0000839D File Offset: 0x0000659D
		public static void StartShow()
		{
			BWYukiShower.yukiShower = Tracker.AddThread("BWYukiShower", delegate
			{
				for (;;)
				{
					bool flag = BWYukiShower.lastFrame != Tracker.frame;
					if (flag)
					{
						BWYukiShower.Update(Tracker.frame, Screen.PrimaryScreen.WorkingArea);
						BWYukiShower.lastFrame = Tracker.frame;
					}
					Thread.Sleep(3);
				}
			});
			BWYukiShower.yukiShower.Start();
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000083D9 File Offset: 0x000065D9
		public static void StopShow()
		{
			BWYukiShower.yukiShower.Abort();
			BWYukiShower.lastFrame = -1L;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000083F0 File Offset: 0x000065F0
		private static void Update(long f, Rectangle screen)
		{
			if (f <= 1844L)
			{
				if (f != 1833L)
				{
					if (f != 1840L)
					{
						if (f == 1844L)
						{
							Thread thread = new Thread(delegate()
							{
								float num = 0.33333334f;
								BWYukiForm bwyukiForm = new BWYukiForm();
								Point a = new Point(screen.Width / 2 - bwyukiForm.Width / 2 + 400, screen.Height / 2 - bwyukiForm.Height / 2);
								bwyukiForm.ShowDialog(BWYukiShower.Add(a, new Point((int)(num * (float)BWYukiShower.maxMove), (int)(Math.Sin((double)num * 3.141592653589793 * 2.0) * 40.0))), 1873);
							});
							thread.Start();
						}
					}
					else
					{
						Thread thread2 = new Thread(delegate()
						{
							float num = 0.16666667f;
							BWYukiForm bwyukiForm = new BWYukiForm();
							Point a = new Point(screen.Width / 2 - bwyukiForm.Width / 2 + 400, screen.Height / 2 - bwyukiForm.Height / 2);
							bwyukiForm.ShowDialog(BWYukiShower.Add(a, new Point((int)(num * (float)BWYukiShower.maxMove), (int)(Math.Sin((double)num * 3.141592653589793 * 2.0) * 40.0))), 1873);
						});
						thread2.Start();
					}
				}
				else
				{
					Thread thread3 = new Thread(delegate()
					{
						float num = 0f;
						BWYukiForm bwyukiForm = new BWYukiForm();
						Point a = new Point(screen.Width / 2 - bwyukiForm.Width / 2 + 400, screen.Height / 2 - bwyukiForm.Height / 2);
						bwyukiForm.ShowDialog(BWYukiShower.Add(a, new Point((int)(num * (float)BWYukiShower.maxMove), (int)(Math.Sin((double)num * 3.141592653589793 * 2.0) * 40.0))), 1873);
					});
					thread3.Start();
				}
			}
			else if (f <= 1852L)
			{
				if (f != 1848L)
				{
					if (f == 1852L)
					{
						Thread thread4 = new Thread(delegate()
						{
							float num = 0.6666667f;
							BWYukiForm bwyukiForm = new BWYukiForm();
							Point a = new Point(screen.Width / 2 - bwyukiForm.Width / 2 + 400, screen.Height / 2 - bwyukiForm.Height / 2);
							bwyukiForm.ShowDialog(BWYukiShower.Add(a, new Point((int)(num * (float)BWYukiShower.maxMove), (int)(Math.Sin((double)num * 3.141592653589793 * 2.0) * 40.0))), 1873);
						});
						thread4.Start();
					}
				}
				else
				{
					Thread thread5 = new Thread(delegate()
					{
						float num = 0.5f;
						BWYukiForm bwyukiForm = new BWYukiForm();
						Point a = new Point(screen.Width / 2 - bwyukiForm.Width / 2 + 400, screen.Height / 2 - bwyukiForm.Height / 2);
						bwyukiForm.ShowDialog(BWYukiShower.Add(a, new Point((int)(num * (float)BWYukiShower.maxMove), (int)(Math.Sin((double)num * 3.141592653589793 * 2.0) * 40.0))), 1873);
					});
					thread5.Start();
				}
			}
			else if (f != 1858L)
			{
				if (f == 1862L)
				{
					Thread thread6 = new Thread(delegate()
					{
						float num = 1f;
						BWYukiForm bwyukiForm = new BWYukiForm();
						Point a = new Point(screen.Width / 2 - bwyukiForm.Width / 2 + 400, screen.Height / 2 - bwyukiForm.Height / 2);
						bwyukiForm.ShowDialog(BWYukiShower.Add(a, new Point((int)(num * (float)BWYukiShower.maxMove), (int)(Math.Sin((double)num * 3.141592653589793 * 2.0) * 40.0))), 1873);
					});
					thread6.Start();
				}
			}
			else
			{
				Thread thread7 = new Thread(delegate()
				{
					float num = 0.8333333f;
					BWYukiForm bwyukiForm = new BWYukiForm();
					Point a = new Point(screen.Width / 2 - bwyukiForm.Width / 2 + 400, screen.Height / 2 - bwyukiForm.Height / 2);
					bwyukiForm.ShowDialog(BWYukiShower.Add(a, new Point((int)(num * (float)BWYukiShower.maxMove), (int)(Math.Sin((double)num * 3.141592653589793 * 2.0) * 40.0))), 1873);
				});
				thread7.Start();
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00008560 File Offset: 0x00006760
		private static Point Add(Point a, Point b)
		{
			return new Point(a.X + b.X, a.Y + b.Y);
		}

		// Token: 0x0400008A RID: 138
		private static Thread yukiShower;

		// Token: 0x0400008B RID: 139
		private static long lastFrame = -1L;

		// Token: 0x0400008C RID: 140
		private static int maxMove = 400;
	}
}
