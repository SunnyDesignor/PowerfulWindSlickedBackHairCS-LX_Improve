using System;
using System.Threading;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
    public partial class BlueScreen : Form
    {
        public BlueScreen()
        {
            InitializeComponent();

            Cursor.Hide();
            if (Environment.OSVersion.Version.Major >= 10)
            {
                panel1.Visible = false;
            }
            new Thread(() =>
            {
                Thread.Sleep(2500);
                label3.Text = "11% 完成";
                Thread.Sleep(2500);
                label3.Text = "24% 完成";
                Thread.Sleep(2600);
                label3.Text = "35% 完成";
                Thread.Sleep(1500);
                label3.Text = "41% 完成";
                Thread.Sleep(200);
                label3.Text = "58% 完成";
                Thread.Sleep(200);
                label3.Text = "81% 完成";
                Thread.Sleep(200);
                label3.Text = "100% 完成";
                Thread.Sleep(200);
                this.Close();
            })
            { IsBackground = true }.Start();

        }
    }
}
