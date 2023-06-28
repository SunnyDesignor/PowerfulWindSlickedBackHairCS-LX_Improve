using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using PowerfulWindSlickedBackHair.Windows;

namespace PowerfulWindSlickedBackHair.Tools
{
	// Token: 0x02000021 RID: 33
	public static class AnimalsShower
	{
		// Token: 0x060000EE RID: 238 RVA: 0x00009540 File Offset: 0x00007740
		public static void StartShow()
		{
			bool flag = AnimalsShower.isStarted;
			if (!flag)
			{
				AnimalsShower.dogShower = Tracker.AddThread("DogShower", delegate
				{
					for (;;)
					{
						bool flag2 = AnimalsShower.lastFrame != Tracker.frame;
						if (flag2)
						{
							AnimalsShower.Update(Tracker.frame, Screen.PrimaryScreen.WorkingArea);
							AnimalsShower.lastFrame = Tracker.frame;
						}
						Thread.Sleep(1);
					}
				});
				AnimalsShower.dogShower.Start();
				AnimalsShower.isStarted = true;
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00009598 File Offset: 0x00007798
		public static void StopShow()
		{
			AnimalsShower.dogShower.Abort();
			AnimalsShower.lastFrame = -1L;
			AnimalsShower.isStarted = false;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000095B4 File Offset: 0x000077B4
		private static void Update(long f, Rectangle screen)
		{
			if (f <= 1228L)
			{
				if (f != 14L)
				{
					if (f != 272L)
					{
						if (f == 1228L)
						{
							Thread thread = new Thread(delegate()
							{
								DogWalkF dogWalkF = new DogWalkF();
								Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
								dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(-450, 200)), 1388);
							});
							thread.Start();
							Thread thread2 = new Thread(delegate()
							{
								DogWalkF dogWalkF = new DogWalkF();
								Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
								dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(-225, 200)), 1371);
							});
							thread2.Start();
							Thread thread3 = new Thread(delegate()
							{
								DogWalkF dogWalkF = new DogWalkF();
								Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
								dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(225, 200)), 1371);
							});
							thread3.Start();
							Thread thread4 = new Thread(delegate()
							{
								DogWalkF dogWalkF = new DogWalkF();
								Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
								dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(450, 200)), 1388);
							});
							thread4.Start();
						}
					}
					else
					{
						Thread thread5 = new Thread(delegate()
						{
							DogWalkF dogWalkF = new DogWalkF();
							Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
							dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(-450, 200)), 309);
						});
						thread5.Start();
						Thread thread6 = new Thread(delegate()
						{
							DogWalkF dogWalkF = new DogWalkF();
							Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
							dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(-225, 200)), 309);
						});
						thread6.Start();
						Thread thread7 = new Thread(delegate()
						{
							DogWalkF dogWalkF = new DogWalkF();
							Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
							dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(0, 200)), 309);
						});
						thread7.Start();
						Thread thread8 = new Thread(delegate()
						{
							DogWalkF dogWalkF = new DogWalkF();
							Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
							dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(225, 200)), 309);
						});
						thread8.Start();
						Thread thread9 = new Thread(delegate()
						{
							DogWalkF dogWalkF = new DogWalkF();
							Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
							dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(450, 200)), 309);
						});
						thread9.Start();
					}
				}
				else
				{
					Thread thread10 = new Thread(delegate()
					{
						DogWalkF dogWalkF = new DogWalkF();
						Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
						dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(-450, 200)), 152);
					});
					thread10.Start();
					Thread thread11 = new Thread(delegate()
					{
						DogWalkF dogWalkF = new DogWalkF();
						Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
						dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(450, 200)), 152);
					});
					thread11.Start();
				}
			}
			else if (f <= 1874L)
			{
				if (f != 1491L)
				{
					if (f == 1874L)
					{
						Thread thread12 = new Thread(delegate()
						{
							DogWalkF dogWalkF = new DogWalkF();
							Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
							dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(-225, 200)), 1979);
						});
						thread12.Start();
						Thread thread13 = new Thread(delegate()
						{
							DogWalkF dogWalkF = new DogWalkF();
							Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
							dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(225, 200)), 1979);
						});
						thread13.Start();
					}
				}
				else
				{
					Thread thread14 = new Thread(delegate()
					{
						DogWalkF dogWalkF = new DogWalkF();
						Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
						dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(-450, 200)), 1527);
					});
					thread14.Start();
					Thread thread15 = new Thread(delegate()
					{
						DogWalkF dogWalkF = new DogWalkF();
						Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
						dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(-225, 200)), 1527);
					});
					thread15.Start();
					Thread thread16 = new Thread(delegate()
					{
						DogWalkF dogWalkF = new DogWalkF();
						Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
						dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(225, 200)), 1527);
					});
					thread16.Start();
					Thread thread17 = new Thread(delegate()
					{
						DogWalkF dogWalkF = new DogWalkF();
						Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
						dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(450, 200)), 1527);
					});
					thread17.Start();
				}
			}
			else if (f != 2151L)
			{
				if (f == 2217L)
				{
					Thread thread18 = new Thread(delegate()
					{
						DogWalkF dogWalkF = new DogWalkF();
						Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
						dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(-562, 200)), 2284);
					});
					thread18.Start();
					Thread thread19 = new Thread(delegate()
					{
						DogWalkF dogWalkF = new DogWalkF();
						Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
						dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(558, 200)), 2284);
					});
					thread19.Start();
				}
			}
			else
			{
				Thread thread20 = new Thread(delegate()
				{
					DogWalkF dogWalkF = new DogWalkF();
					Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
					dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(-450, 200)), 2284);
				});
				thread20.Start();
				Thread.Sleep(1);
				Thread thread21 = new Thread(delegate()
				{
					DogWalkF dogWalkF = new DogWalkF();
					Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
					dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(-338, 200)), 2284);
				});
				thread21.Start();
				Thread.Sleep(1);
				Thread thread22 = new Thread(delegate()
				{
					DogWalkF dogWalkF = new DogWalkF();
					Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
					dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(-226, 200)), 2284);
				});
				thread22.Start();
				Thread.Sleep(1);
				Thread thread23 = new Thread(delegate()
				{
					DogWalkF dogWalkF = new DogWalkF();
					Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
					dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(222, 200)), 2284);
				});
				thread23.Start();
				Thread.Sleep(1);
				Thread thread24 = new Thread(delegate()
				{
					DogWalkF dogWalkF = new DogWalkF();
					Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
					dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(334, 200)), 2284);
				});
				thread24.Start();
				Thread.Sleep(1);
				Thread thread25 = new Thread(delegate()
				{
					DogWalkF dogWalkF = new DogWalkF();
					Point a = new Point(screen.Width / 2 - dogWalkF.Width / 2, screen.Height / 2 - dogWalkF.Height / 2);
					dogWalkF.ShowDialog(AnimalsShower.Add(a, new Point(446, 200)), 2284);
				});
				thread25.Start();
				Thread.Sleep(1);
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000993C File Offset: 0x00007B3C
		private static Point Add(Point a, Point b)
		{
			return new Point(a.X + b.X, a.Y + b.Y);
		}

		// Token: 0x04000094 RID: 148
		private static Thread dogShower;

		// Token: 0x04000095 RID: 149
		private static long lastFrame = -1L;

		// Token: 0x04000096 RID: 150
		private static bool isStarted;
	}
}
