using System;
using System.Drawing;
using System.Threading;
using PowerfulWindSlickedBackHair.Windows;

namespace PowerfulWindSlickedBackHair.Tools
{
	// Token: 0x02000023 RID: 35
	public static class WaveBirdShower
	{
		// Token: 0x060000F4 RID: 244 RVA: 0x000099B0 File Offset: 0x00007BB0
		public static void WaveBirdShow(Rectangle s, long f, Point dp, bool isWhite)
		{
			Thread thread = new Thread(delegate()
			{
				BirdWaveF birdWaveF = new BirdWaveF(isWhite);
				Point point = new Point(s.Width / 2 - birdWaveF.Width / 2, s.Height / 2 - birdWaveF.Height / 2);
				birdWaveF.ShowDialog(f, new Point(point.X + dp.X, point.Y + dp.Y));
			});
			thread.Start();
		}
	}
}
