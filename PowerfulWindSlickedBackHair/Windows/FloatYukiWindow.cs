using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x02000011 RID: 17
	public partial class FloatYukiWindow : Form
	{
        private Bitmap yuki;

        public FloatYukiWindow()
        {
            InitializeComponent();
            yuki = new Bitmap("Assets//CuttingYuki.png");
            base.Size = yuki.Size;
        }

        private unsafe void FloatYukiWindow_Load(object sender, EventArgs e)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            ConcurrentBag<Point> points = new ConcurrentBag<Point>();
            Rectangle rect = new Rectangle(0, 0, yuki.Width, yuki.Height);
            BitmapData data = yuki.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte* ptr = (byte*)(void*)data.Scan0;
            int stride = data.Stride;
            Parallel.For(0, data.Height, delegate (int y)
            {
                for (int i = 0; i < data.Width; i++)
                {
                    byte b = ptr[y * stride + i * 4 + 3];
                    if (b > 0)
                    {
                        points.Add(new Point(i, y));
                    }
                }
            });
            yuki.UnlockBits(data);
            if (points.Count > 0)
            {
                graphicsPath.AddPolygon(points.ToArray());
            }
            BackColor = Color.White;
            base.TransparencyKey = Color.White;
        }

        private void FloatYukiWindow_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(0, 0, base.ClientRectangle.Width, base.ClientRectangle.Height);
            using (new SolidBrush(Color.LightBlue))
            {
                e.Graphics.DrawImage(yuki, 0, 0);
            }
        }
    }
}
