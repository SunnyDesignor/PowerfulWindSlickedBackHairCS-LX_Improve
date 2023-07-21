using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
    // Token: 0x02000008 RID: 8
    public partial class BackgroundForm : Form
    {
        // Token: 0x0600001D RID: 29 RVA: 0x0000359C File Offset: 0x0000179C
        public BackgroundForm()
        {
            this.InitializeComponent();
            this.backColorY = Color.FromArgb(16701521);
            this.backColorY = Color.FromArgb(255, (int)this.backColorY.R, (int)this.backColorY.G, (int)this.backColorY.B);
            this.BackColor = this.backColorY;
            this.backColorB = Color.FromArgb(6471671);
            this.backColorB = Color.FromArgb(255, (int)this.backColorB.R, (int)this.backColorB.G, (int)this.backColorB.B);
            base.StartPosition = FormStartPosition.Manual;
            this.text.Font = new Font(MainForm.otherFont.Families[0], 100f, FontStyle.Bold, GraphicsUnit.Point, 134);
        }

        // Token: 0x0600001E RID: 30 RVA: 0x00003658 File Offset: 0x00001858
        public void ShowDialog(Point pos, int endFrame)
        {
            base.Location = pos;
            Thread thread = new Thread(delegate ()
            {
                int endFrame2 = endFrame;
                bool flag;
                do
                {
                    this.UpdateText(Tracker.frame);
                    flag = (Tracker.frame > (long)endFrame);
                }
                while (!flag);
                this.Hide();
            });
            thread.Start();
            base.ShowDialog();
        }

        // Token: 0x0600001F RID: 31 RVA: 0x000036A4 File Offset: 0x000018A4
        private void UpdateText(long f)
        {
            long num = 0L;
            long num2 = f - num;
            long num3 = num2;
            if (num3 <= 1386L)
            {
                if (num3 <= 772L)
                {
                    if (num3 <= 257L)
                    {
                        if (num3 <= 152L)
                        {
                            if (num3 <= 68L)
                            {
                                if (num3 != 10L)
                                {
                                    if (num3 != 48L)
                                    {
                                        if (num3 == 68L)
                                        {
                                            this.text.Text = "";
                                        }
                                    }
                                    else
                                    {
                                        this.text.Text = "終わったわ\r\n";
                                    }
                                }
                                else
                                {
                                    this.text.Text = "外出た瞬間\r\n";
                                }
                            }
                            else if (num3 <= 125L)
                            {
                                if (num3 != 86L)
                                {
                                    if (num3 == 125L)
                                    {
                                        this.text.Text = "進めない\r\n";
                                    }
                                }
                                else
                                {
                                    this.text.Text = "天気は良いのに\r\n";
                                }
                            }
                            else if (num3 != 146L)
                            {
                                if (num3 == 152L)
                                {
                                    this.text.Text = "風";
                                }
                            }
                            else
                            {
                                this.text.Text = "";
                                this.text.Font = new Font(MainForm.otherFont.Families[0], 186f, FontStyle.Bold, GraphicsUnit.Point, 134);
                            }
                        }
                        else if (num3 <= 201L)
                        {
                            if (num3 != 167L)
                            {
                                if (num3 != 172L)
                                {
                                    if (num3 == 201L)
                                    {
                                        this.text.Text = "お亡くなり\r\n";
                                    }
                                }
                                else
                                {
                                    this.text.Text = "強すぎて\r\n";
                                }
                            }
                            else
                            {
                                this.text.Text = "";
                                this.text.Font = new Font(MainForm.otherFont.Families[0], 100f, FontStyle.Bold, GraphicsUnit.Point, 134);
                            }
                        }
                        else if (num3 <= 238L)
                        {
                            if (num3 != 221L)
                            {
                                if (num3 == 238L)
                                {
                                    this.text.Text = "定期      \r\n";
                                }
                            }
                            else
                            {
                                this.text.Text = "";
                            }
                        }
                        else if (num3 != 247L)
                        {
                            if (num3 == 257L)
                            {
                                this.text.Text = "定期定期\r\n的に";
                            }
                        }
                        else
                        {
                            this.text.Text = "定期定期\r\n";
                        }
                    }
                    else if (num3 <= 618L)
                    {
                        if (num3 <= 390L)
                        {
                            if (num3 != 272L)
                            {
                                if (num3 != 309L)
                                {
                                    if (num3 == 390L)
                                    {
                                        this.BackColor = this.backColorB;
                                    }
                                }
                                else
                                {
                                    this.text.Text = "";
                                }
                            }
                            else
                            {
                                this.text.Text = "オールバック\r\n";
                            }
                        }
                        else if (num3 <= 467L)
                        {
                            if (num3 != 460L)
                            {
                                if (num3 == 467L)
                                {
                                    this.BackColor = this.backColorY;
                                    this.text.Text = "強風オールバック\r\n";
                                }
                            }
                            else
                            {
                                this.text.Font = new Font(MainForm.otherFont.Families[0], 72f, FontStyle.Bold, GraphicsUnit.Point, 134);
                            }
                        }
                        else if (num3 != 542L)
                        {
                            if (num3 == 618L)
                            {
                                this.text.Text = "";
                                this.text.Font = new Font(MainForm.otherFont.Families[0], 100f, FontStyle.Bold, GraphicsUnit.Point, 134);
                            }
                        }
                        else
                        {
                            this.BackColor = this.backColorB;
                        }
                    }
                    else if (num3 <= 714L)
                    {
                        if (num3 <= 652L)
                        {
                            if (num3 != 619L)
                            {
                                if (num3 == 652L)
                                {
                                    this.text.Text = "潜りたいな\r\n";
                                }
                            }
                            else
                            {
                                this.text.Text = "地下に\r\n";
                                this.BackColor = this.backColorY;
                            }
                        }
                        else if (num3 != 701L)
                        {
                            if (num3 == 714L)
                            {
                                this.text.Text = "って\r\n";
                            }
                        }
                        else
                        {
                            this.text.Text = "";
                        }
                    }
                    else if (num3 <= 729L)
                    {
                        if (num3 != 726L)
                        {
                            if (num3 == 729L)
                            {
                                this.text.Text = "思いました\r\n";
                            }
                        }
                        else
                        {
                            this.text.Text = "";
                        }
                    }
                    else if (num3 != 762L)
                    {
                        if (num3 == 772L)
                        {
                            this.text.Text = "風さえ\r\n";
                        }
                    }
                    else
                    {
                        this.text.Text = "";
                    }
                }
                else if (num3 <= 1142L)
                {
                    if (num3 <= 997L)
                    {
                        if (num3 <= 876L)
                        {
                            if (num3 != 810L)
                            {
                                if (num3 != 843L)
                                {
                                    if (num3 == 876L)
                                    {
                                        this.text.Text = "あったかいのに\r\n";
                                    }
                                }
                                else
                                {
                                    this.text.Text = "";
                                    this.text.Font = new Font(MainForm.otherFont.Families[0], 86f, FontStyle.Bold, GraphicsUnit.Point, 134);
                                }
                            }
                            else
                            {
                                this.text.Text = "なくなれば\r\n";
                            }
                        }
                        else if (num3 <= 924L)
                        {
                            if (num3 != 909L)
                            {
                                if (num3 == 924L)
                                {
                                    this.text.Text = "ずっと\r\n";
                                }
                            }
                            else
                            {
                                this.text.Text = "";
                                this.text.Font = new Font(MainForm.otherFont.Families[0], 100f, FontStyle.Bold, GraphicsUnit.Point, 134);
                            }
                        }
                        else if (num3 != 958L)
                        {
                            if (num3 == 997L)
                            {
                                this.text.Text = "";
                            }
                        }
                        else
                        {
                            this.text.Text = "座りたいな\r\n";
                        }
                    }
                    else if (num3 <= 1034L)
                    {
                        if (num3 != 1018L)
                        {
                            if (num3 != 1029L)
                            {
                                if (num3 == 1034L)
                                {
                                    this.text.Text = "思いました\r\n";
                                }
                            }
                            else
                            {
                                this.text.Text = "";
                            }
                        }
                        else
                        {
                            this.text.Text = "って\r\n";
                        }
                    }
                    else if (num3 <= 1109L)
                    {
                        if (num3 != 1076L)
                        {
                            if (num3 == 1109L)
                            {
                                this.text.Text = "と\r\n";
                            }
                        }
                        else
                        {
                            this.text.Text = "いやいや\r\n";
                        }
                    }
                    else if (num3 != 1114L)
                    {
                        if (num3 == 1142L)
                        {
                            this.text.Text = "";
                        }
                    }
                    else
                    {
                        this.text.Text = "外でたら\r\n";
                    }
                }
                else if (num3 <= 1212L)
                {
                    if (num3 <= 1170L)
                    {
                        if (num3 != 1152L)
                        {
                            if (num3 != 1161L)
                            {
                                if (num3 == 1170L)
                                {
                                    this.text.Text = "      ハト   \r\n";
                                }
                            }
                            else
                            {
                                this.text.Text = "   ハト      \r\n";
                            }
                        }
                        else
                        {
                            this.text.Text = "ハト         \r\n";
                        }
                    }
                    else if (num3 <= 1185L)
                    {
                        if (num3 != 1179L)
                        {
                            if (num3 == 1185L)
                            {
                                this.text.Text = "";
                            }
                        }
                        else
                        {
                            this.text.Text = "         ハト\r\n";
                        }
                    }
                    else if (num3 != 1191L)
                    {
                        if (num3 == 1212L)
                        {
                            this.text.Text = "";
                        }
                    }
                    else
                    {
                        this.text.Text = "大乱闘\r\n";
                    }
                }
                else if (num3 <= 1304L)
                {
                    if (num3 <= 1266L)
                    {
                        if (num3 != 1228L)
                        {
                            if (num3 == 1266L)
                            {
                                this.text.Text = "終わったわ\r\n";
                            }
                        }
                        else
                        {
                            this.text.Text = "外出た瞬間\r\n";
                        }
                    }
                    else if (num3 != 1288L)
                    {
                        if (num3 == 1304L)
                        {
                            this.text.Text = "天気は良いのに\r\n";
                        }
                    }
                    else
                    {
                        this.text.Text = "";
                    }
                }
                else if (num3 <= 1364L)
                {
                    if (num3 != 1343L)
                    {
                        if (num3 == 1364L)
                        {
                            this.text.Text = "";
                            this.text.Font = new Font(MainForm.otherFont.Families[0], 186f, FontStyle.Bold, GraphicsUnit.Point, 134);
                        }
                    }
                    else
                    {
                        this.text.Text = "進めない\r\n";
                    }
                }
                else if (num3 != 1371L)
                {
                    if (num3 == 1386L)
                    {
                        this.text.Text = "";
                        this.text.Font = new Font(MainForm.otherFont.Families[0], 100f, FontStyle.Bold, GraphicsUnit.Point, 134);
                    }
                }
                else
                {
                    this.text.Text = "風";
                }
            }
            else if (num3 <= 2099L)
            {
                if (num3 <= 1851L)
                {
                    if (num3 <= 1491L)
                    {
                        if (num3 <= 1441L)
                        {
                            if (num3 != 1391L)
                            {
                                if (num3 != 1420L)
                                {
                                    if (num3 == 1441L)
                                    {
                                        this.text.Text = "";
                                    }
                                }
                                else
                                {
                                    this.text.Text = "お亡くなり\r\n";
                                }
                            }
                            else
                            {
                                this.text.Text = "強すぎて\r\n";
                            }
                        }
                        else if (num3 <= 1466L)
                        {
                            if (num3 != 1456L)
                            {
                                if (num3 == 1466L)
                                {
                                    this.text.Text = "定期定期\r\n";
                                }
                            }
                            else
                            {
                                this.text.Text = "定期      \r\n";
                            }
                        }
                        else if (num3 != 1476L)
                        {
                            if (num3 == 1491L)
                            {
                                this.text.Text = "オールバック\r\n";
                            }
                        }
                        else
                        {
                            this.text.Text = "定期定期\r\n的に";
                        }
                    }
                    else if (num3 <= 1810L)
                    {
                        if (num3 != 1527L)
                        {
                            if (num3 != 1685L)
                            {
                                if (num3 == 1810L)
                                {
                                    this.text.Text = "";
                                    this.text.Font = new Font(MainForm.otherFont.Families[0], 100f, FontStyle.Bold, GraphicsUnit.Point, 134);
                                }
                            }
                            else
                            {
                                this.text.Text = "強風オールバック\r\n";
                            }
                        }
                        else
                        {
                            this.text.Text = "";
                            this.text.Font = new Font(MainForm.otherFont.Families[0], 72f, FontStyle.Bold, GraphicsUnit.Point, 134);
                        }
                    }
                    else if (num3 <= 1843L)
                    {
                        if (num3 != 1836L)
                        {
                            if (num3 == 1843L)
                            {
                                this.text.Text = "外出\r\n";
                            }
                        }
                        else
                        {
                            this.text.Text = "外\r\n";
                        }
                    }
                    else if (num3 != 1847L)
                    {
                        if (num3 == 1851L)
                        {
                            this.text.Text = "外出た瞬\r\n";
                        }
                    }
                    else
                    {
                        this.text.Text = "外出た\r\n";
                    }
                }
                else if (num3 <= 1979L)
                {
                    if (num3 <= 1895L)
                    {
                        if (num3 != 1865L)
                        {
                            if (num3 != 1874L)
                            {
                                if (num3 == 1895L)
                                {
                                    this.text.Text = "";
                                }
                            }
                            else
                            {
                                this.text.Text = "終わったわ\r\n";
                            }
                        }
                        else
                        {
                            this.text.Text = "外出た瞬間\r\n";
                        }
                    }
                    else if (num3 <= 1951L)
                    {
                        if (num3 != 1912L)
                        {
                            if (num3 == 1951L)
                            {
                                this.text.Text = "進めない\r\n";
                            }
                        }
                        else
                        {
                            this.text.Text = "天気は良いのに\r\n";
                        }
                    }
                    else if (num3 != 1973L)
                    {
                        if (num3 == 1979L)
                        {
                            this.text.Text = "風";
                        }
                    }
                    else
                    {
                        this.text.Text = "";
                        this.text.Font = new Font(MainForm.otherFont.Families[0], 186f, FontStyle.Bold, GraphicsUnit.Point, 134);
                    }
                }
                else if (num3 <= 2048L)
                {
                    if (num3 <= 1998L)
                    {
                        if (num3 != 1994L)
                        {
                            if (num3 == 1998L)
                            {
                                this.text.Text = "強すぎて\r\n";
                            }
                        }
                        else
                        {
                            this.text.Text = "";
                            this.text.Font = new Font(MainForm.otherFont.Families[0], 100f, FontStyle.Bold, GraphicsUnit.Point, 134);
                        }
                    }
                    else if (num3 != 2028L)
                    {
                        if (num3 == 2048L)
                        {
                            this.text.Text = "";
                        }
                    }
                    else
                    {
                        this.text.Text = "お亡くなり\r\n";
                    }
                }
                else if (num3 <= 2074L)
                {
                    if (num3 != 2065L)
                    {
                        if (num3 == 2074L)
                        {
                            this.text.Text = "定期定期\r\n";
                        }
                    }
                    else
                    {
                        this.text.Text = "定期      \r\n";
                    }
                }
                else if (num3 != 2084L)
                {
                    if (num3 == 2099L)
                    {
                        this.text.Text = "オールバック\r\n";
                    }
                }
                else
                {
                    this.text.Text = "定期定期\r\n的に";
                }
            }
            else if (num3 <= 2333L)
            {
                if (num3 <= 2180L)
                {
                    if (num3 <= 2141L)
                    {
                        if (num3 != 2131L)
                        {
                            if (num3 != 2135L)
                            {
                                if (num3 == 2141L)
                                {
                                    this.text.Text = "と\r\n";
                                }
                            }
                            else
                            {
                                this.text.Text = "";
                            }
                        }
                        else
                        {
                            this.text.Text = "そっ\r\n";
                        }
                    }
                    else if (num3 <= 2151L)
                    {
                        if (num3 != 2148L)
                        {
                            if (num3 == 2151L)
                            {
                                this.text.Text = "出た瞬間\r\n";
                            }
                        }
                        else
                        {
                            this.text.Text = "";
                        }
                    }
                    else if (num3 != 2172L)
                    {
                        if (num3 == 2180L)
                        {
                            this.text.Text = "終わったわ\r\n";
                        }
                    }
                    else
                    {
                        this.text.Text = "";
                    }
                }
                else if (num3 <= 2277L)
                {
                    if (num3 <= 2218L)
                    {
                        if (num3 != 2200L)
                        {
                            if (num3 == 2218L)
                            {
                                this.text.Text = "天気は良いのに\r\n";
                            }
                        }
                        else
                        {
                            this.text.Text = "";
                        }
                    }
                    else if (num3 != 2255L)
                    {
                        if (num3 == 2277L)
                        {
                            this.text.Text = "";
                            this.text.Font = new Font(MainForm.otherFont.Families[0], 186f, FontStyle.Bold, GraphicsUnit.Point, 134);
                        }
                    }
                    else
                    {
                        this.text.Text = "進めない\r\n";
                    }
                }
                else if (num3 <= 2300L)
                {
                    if (num3 != 2285L)
                    {
                        if (num3 == 2300L)
                        {
                            this.text.Text = "";
                            this.text.Font = new Font(MainForm.otherFont.Families[0], 100f, FontStyle.Bold, GraphicsUnit.Point, 134);
                        }
                    }
                    else
                    {
                        this.text.Text = "風";
                    }
                }
                else if (num3 != 2304L)
                {
                    if (num3 == 2333L)
                    {
                        this.text.Text = "お亡くなり\r\n";
                    }
                }
                else
                {
                    this.text.Text = "強すぎて\r\n";
                }
            }
            else if (num3 <= 2445L)
            {
                if (num3 <= 2381L)
                {
                    if (num3 != 2356L)
                    {
                        if (num3 != 2371L)
                        {
                            if (num3 == 2381L)
                            {
                                this.text.Text = "定期定期\r\n";
                            }
                        }
                        else
                        {
                            this.text.Text = "定期      \r\n";
                        }
                    }
                    else
                    {
                        this.text.Text = "";
                    }
                }
                else if (num3 <= 2405L)
                {
                    if (num3 != 2391L)
                    {
                        if (num3 == 2405L)
                        {
                            this.text.Text = "オールバック\r\n";
                        }
                    }
                    else
                    {
                        this.text.Text = "定期定期\r\n的に";
                    }
                }
                else if (num3 != 2438L)
                {
                    if (num3 == 2445L)
                    {
                        this.text.Text = "髪の毛\r\n";
                    }
                }
                else
                {
                    this.text.Text = "";
                }
            }
            else if (num3 <= 2523L)
            {
                if (num3 <= 2476L)
                {
                    if (num3 != 2461L)
                    {
                        if (num3 == 2476L)
                        {
                            this.text.Text = "オールバック\r\n";
                        }
                    }
                    else
                    {
                        this.text.Text = "強風\r\n";
                    }
                }
                else if (num3 != 2502L)
                {
                    if (num3 == 2523L)
                    {
                        if (!changedLeft)
                            this.Left -= 360;
                        changedLeft = true;
                        this.text.Font = new Font(MainForm.otherFont.Families[0], 25f, FontStyle.Bold, GraphicsUnit.Point, 134);
                        this.text.TextAlign = ContentAlignment.MiddleLeft;
                        this.text.Text = "強風オールバック\r\n但是Windows";
                    }
                }
                else
                {
                    this.text.Text = "";
                }
            }
            else if (num3 <= 2677L)
            {
                if (num3 != 2602L)
                {
                    if (num3 == 2677L)
                    {
                        this.text.Text = "改: LX\r\n显示: winform\r\n\n反编译/补充功能：\nGithub.com/SunnyDesignor";
                    }
                }
                else
                {
                    this.text.Text = "原: https://youtu.be/D6DVTLvOupE\r\n";
                }
            }
            else if (num3 != 2753L)
            {
                if (num3 == 2818L)
                {
                    if (!changedLeft2)
                        this.Left += 360;
                    changedLeft2 = true;
                    this.text.Font = new Font(MainForm.otherFont.Families[0], 100f, FontStyle.Bold, GraphicsUnit.Point, 134);
                    this.text.TextAlign = ContentAlignment.MiddleCenter;
                    this.text.Text = "谢谢观看\r\n记得三连~";
                }
            }
            else
            {
                this.text.Text = "使用插件:\r\nNAudio、SoundTouch";
            }
        }

        bool changedLeft, changedLeft2;

        // Token: 0x0400001A RID: 26
        private Color backColorY;

        // Token: 0x0400001B RID: 27
        private Color backColorB;
    }
}
