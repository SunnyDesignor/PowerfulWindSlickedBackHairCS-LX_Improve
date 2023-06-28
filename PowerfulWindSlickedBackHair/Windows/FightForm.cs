using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x0200000F RID: 15
	public partial class FightForm : Form
	{
        private Bitmap fight1;

        private Bitmap fight2;

        private Bitmap fight3;

        public new Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
                if (base.IsHandleCreated)
                {
                    BeginInvoke((MethodInvoker)delegate
                    {
                        base.BackgroundImage = value;
                    });
                }
            }
        }

        public FightForm()
        {
            InitializeComponent();
            fight1 = new Bitmap("Assets\\Fight1.png");
            fight2 = new Bitmap("Assets\\Fight2.png");
            fight3 = new Bitmap("Assets\\Fight3.png");
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
            UpdateStyles();
        }

        public void ShowDialog(long endF)
        {
            Thread thread = new Thread((ThreadStart)delegate
            {
                long num = endF;
                while (true)
                {
                    long num2 = Tracker.frame % 6;
                    BackgroundImage = ((num2 < 2) ? fight1 : ((num2 < 4) ? fight2 : fight3));
                    if (Tracker.frame > endF)
                    {
                        break;
                    }
                    Thread.Sleep(3);
                }
                Hide();
            });
            thread.Start();
            ShowDialog();
        }
    }
}
