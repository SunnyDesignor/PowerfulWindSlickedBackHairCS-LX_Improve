using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using PowerfulWindSlickedBackHair.Windows;

namespace PowerfulWindSlickedBackHair.Tools
{
	// Token: 0x02000022 RID: 34
	public static class RollingDogShower
	{
		// Token: 0x060000F3 RID: 243 RVA: 0x0000997C File Offset: 0x00007B7C
		public static void Show(int lastPos)
		{
			Thread thread = new Thread(delegate()
			{
				Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
				RollingDogF rollingDogF = new RollingDogF();
				Point pos = new Point(workingArea.Width / 2 - rollingDogF.Width / 2 - 300, workingArea.Height - rollingDogF.Height - 30);
				rollingDogF.ShowDialog(pos, Tracker.frame + 58L, lastPos, lastPos > 1000);
			});
			thread.Start();
		}
	}
}
