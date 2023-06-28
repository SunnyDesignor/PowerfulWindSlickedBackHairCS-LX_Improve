using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using PowerfulWindSlickedBackHair.Windows;

namespace PowerfulWindSlickedBackHair.Tools
{
	// Token: 0x0200001D RID: 29
	public static class ClapYukiShower
	{
		// Token: 0x060000A7 RID: 167 RVA: 0x000085A8 File Offset: 0x000067A8
		public static void Show()
		{
			Rectangle screen = Screen.PrimaryScreen.WorkingArea;
			Thread thread = new Thread(delegate()
			{
				YukiClapF yukiClapF = new YukiClapF();
				yukiClapF.ShowDialog(new Point(screen.Width, screen.Height), (int)(Tracker.frame + 18L), yukiClapF.Size);
			});
			thread.Start();
			Thread thread2 = new Thread(delegate()
			{
				PigeonPeekF pigeonPeekF = new PigeonPeekF();
				pigeonPeekF.ShowDialog(new Point(pigeonPeekF.Width, screen.Height), (int)(Tracker.frame + 18L), pigeonPeekF.Size);
			});
			thread2.Start();
		}
	}
}
