using NAudio.Wave;
using PowerfulWindSlickedBackHair.Tools;
using PowerfulWindSlickedBackHair.Windows;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using SoundTouch;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Security.Policy;

namespace PowerfulWindSlickedBackHair
{
    /*
     * 用一堆窗口播放 强风大背头 https://youtu.be/D6DVTLvOupE / https://www.bilibili.com/video/BV1n24y1u7ht
     * 演示：https://www.bilibili.com/video/BV1Kz4y1p7sz
     * 原作者：https://github.com/CS-LX
     * 项目地址(恢复)：https://github.com/SunnyDesignor/PowerfulWindSlickedBackHairCS-LX_Improve
     */

    public partial class MainForm : Form
    {

        private bool isCursorPressOnListView;

        private BackgroundForm backgroundForm;

        private JumpingYukiForm yukiForm;

        private readonly float SpeedRate = 1;
        private readonly float BGMSpeedRate = 1;
        private readonly int BGMOffset = 0;

        private bool isSummonBackgroundForm;
        private bool isSummonJumpingForm;
        private bool isBWYuki = false;
        private bool isFloatWindow = false;
        public static int WindSpeed = 1;

        public static MainForm Instance;

        public MainForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            Instance = this;

            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            base.Location = new Point(workingArea.Width - base.Size.Width, workingArea.Height - base.Size.Height);
            if (File.Exists("Offset.txt"))
            {
                try
                {
                    var array = File.ReadAllLines("Offset.txt");
                    SpeedRate = float.Parse(array[0].Split('：')[1]);
                    BGMSpeedRate = float.Parse(array[1].Split('：')[1]);
                    BGMOffset = int.Parse(array[2].Split('：')[1]);

                    if (SpeedRate > 2)
                        SpeedRate = 2f;
                    else if (SpeedRate < 0.5)
                        SpeedRate = 0.5f;

                    if (BGMSpeedRate > 2)
                        BGMSpeedRate = 2f;
                    else if (BGMSpeedRate < 0.5)
                        BGMSpeedRate = 0.5f;

                    if (BGMOffset > 2000)
                        BGMOffset = 2000;
                    else if (BGMOffset < -2000)
                        BGMOffset = 2000;
                }
                catch (Exception)
                {
                }
            }
            LoadFonts();

            Win32APIHelper.ChangeWallpaper(1);
        }

        public static PrivateFontCollection otherFont = new PrivateFontCollection();
        public void LoadFonts()
        {
            string AppPath = Application.StartupPath;
            try
            {
                otherFont.AddFontFile(AppPath + @"\Assets\font.ttf");
            }
            catch
            {
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Win32APIHelper.MinimizeAllWindows();
            this.Focus();
            Tracker.Running = true;


            Thread frameTracker = Tracker.AddThread("FrameTracker", () =>
            {
                Tracker.AddAndStartThread("ListView", () =>
                {
                    while (Tracker.Running)
                    {
                        if (!isCursorPressOnListView && Tracker.frame % 2 == 0)
                        {
                            threadsList.Items.Clear();
                            try
                            {
                                lock (Tracker.threads)
                                {
                                    Tracker.threads.RemoveAll(t => t.IsAlive == false);
                                }
                                foreach (Thread thread3 in Tracker.threads)
                                {
                                    try
                                    {
                                        ListViewItem listViewItem = threadsList.Items.Add(thread3.Name);
                                        listViewItem.SubItems.Add(thread3.ThreadState.ToString());
                                    }
                                    catch (Exception)
                                    {
                                    }
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                        Thread.Sleep(100);
                    }
                });
                Tracker.AddAndStartThread("Cursor", () =>
                {
                    while (Tracker.Running && Tracker.frame < 2880)
                    {
                        var point = Cursor.Position;
                        Cursor.Position = new Point(point.X + WindSpeed, point.Y);
                        Thread.Sleep(1);
                    }
                });

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                long ticksPerFrame = (long)(466667 / SpeedRate);
                long lastScheduledTick = stopwatch.ElapsedTicks;
                long nextScheduledTick = stopwatch.ElapsedTicks;
                while (Tracker.Running)
                {
                    Tracker.frame++;
                    Update(Tracker.frame, Screen.PrimaryScreen.WorkingArea);
                    if (soundPlayer != null)
                        frameLabel.Text = $"{Tracker.frame} | {soundPlayer.CurrentTime}";
                    else
                        frameLabel.Text = $"{Tracker.frame} | Wait";

                    nextScheduledTick += ticksPerFrame;
                    long currentTimeTicks = stopwatch.ElapsedTicks;
                    long waitTicks = nextScheduledTick - currentTimeTicks;
                    if (waitTicks > 0)
                    {
                        int sleepMilliseconds = (int)(waitTicks / TimeSpan.TicksPerMillisecond);
                        if (sleepMilliseconds > 0)
                        {
                            Thread.Sleep(sleepMilliseconds);
                        }
                        while (stopwatch.ElapsedTicks < nextScheduledTick)
                        {
                            Thread.Yield();
                        }
                    }
                }
            });

            new Thread(() =>
            {
                if (BGMOffset >= 0)
                {
                    PlaySound();
                    Thread.Sleep(Math.Abs(BGMOffset));
                    frameTracker.Start();
                }
                else
                {
                    frameTracker.Start();
                    Thread.Sleep(Math.Abs(BGMOffset));
                    PlaySound();
                }
            }).Start();

        }

        SoundPlayer soundPlayer;

        void PlaySound()
        {
            soundPlayer = new SoundPlayer();
            soundPlayer.Load(@"Assets\Audio.mp3");
            soundPlayer.Play();
            soundPlayer.Rate = BGMSpeedRate;
        }

        bool isClose = false;
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isClose) return;
            Win32APIHelper.CanChangeWallpaper = false;
            Win32APIHelper.ChangeWallpaper(0);
            Tracker.Running = false;
            Tracker.StopAll();
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
            soundPlayer?.Dispose();
            isClose = true;
            Application.Exit();
            new Thread(() =>
            {
                Thread.Sleep(1500);
                Environment.Exit(0);
            })
            { IsBackground = true }.Start();
        }

        bool blueScreenIsShow;
        private void Update(long f, Rectangle screen)
        {
            long num = f;
            //壁纸更新
            if (num == 60)
                this.WindowState = FormWindowState.Minimized;
            else if (num >= 389 && num < 466)
                Win32APIHelper.ChangeWallpaper(2);
            else if (num >= 466 && num < 541)
                Win32APIHelper.ChangeWallpaper(1);
            else if (num >= 541 && num < 618)
                Win32APIHelper.ChangeWallpaper(2);
            else if (num >= 618 && num < 630)
                Win32APIHelper.ChangeWallpaper(1);
            else if (num >= 2870 && num < 2880)
                Win32APIHelper.ChangeWallpaper(0);
            else if (num >= 2880 && num < 2890)
            {
                //蓝屏
                if (blueScreenIsShow)
                    return;
                blueScreenIsShow = true;
                Tracker.AddAndStartThread("Blue", () =>
                {
                    BlueScreen blueScreen = new BlueScreen();
                    blueScreen.ShowDialog();
                });
            }
            else if (num > 3090)
            {
                try
                {
                    var result = MessageBox.Show(Text = "如果觉得好玩，欢迎给项目Star、B站点赞 收藏 关注！\n\n如果你有任何问题或建议，请在评论区留言！", "感谢使用", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.OK)
                    {
                        Process.Start(new ProcessStartInfo("https://space.bilibili.com/286746249") { UseShellExecute = true });
                        Process.Start(new ProcessStartInfo("https://www.bilibili.com/video/BV1Kz4y1p7sz") { UseShellExecute = true });
                    }
                }
                catch (Exception)
                {
                }
                this.Close();
            }

            long num2 = num;
            if (num2 > 3 && num2 < 8)
            {
                if (isSummonBackgroundForm)
                {
                    return;
                }
                Thread thread = Tracker.AddThread("BackgroundShower", delegate
                {
                    if (backgroundForm == null)
                    {
                        isSummonBackgroundForm = true;
                        backgroundForm = new BackgroundForm();
                        backgroundForm.ShowDialog(new Point(screen.Width / 2 - backgroundForm.Width / 2, screen.Height / 2 - backgroundForm.Height / 2), 2864);
                    }
                });
                thread.Start();
                return;
            }

            long num3 = num2;
            if (num3 < 9 || num3 >= 24)
            {
                switch (num2)
                {
                    case 69L:
                        ClapYukiShower.Show();
                        return;
                    case 172L:
                        RollingDogShower.Show(1000);
                        return;
                    case 220L:
                        ClapYukiShower.Show();
                        return;
                    case 234L:
                        {
                            Tracker.AddAndStartThread("StaticYukiForm1", delegate
                            {
                                StaticYukiForm staticYukiForm10 = new StaticYukiForm();
                                staticYukiForm10.ShowDialog(new Point(screen.Width / 2 - staticYukiForm10.Width / 2 - 400, screen.Height / 2 - staticYukiForm10.Height / 2), 269);
                            });
                            return;
                        }
                    case 244L:
                        {
                            Tracker.AddAndStartThread("StaticYukiForm2", delegate
                            {
                                StaticYukiForm staticYukiForm11 = new StaticYukiForm();
                                staticYukiForm11.ShowDialog(new Point(screen.Width / 2 - staticYukiForm11.Width / 2, screen.Height / 2 - staticYukiForm11.Height / 2), 269);
                            });
                            return;
                        }
                    case 254L:
                        {
                            Tracker.AddAndStartThread("StaticYukiForm3", delegate
                            {
                                StaticYukiForm staticYukiForm12 = new StaticYukiForm();
                                staticYukiForm12.ShowDialog(new Point(screen.Width / 2 - staticYukiForm12.Width / 2 + 400, screen.Height / 2 - staticYukiForm12.Height / 2), 269);
                            });
                            return;
                        }
                    case 315L:
                        {
                            Tracker.AddAndStartThread("blackBirdF", delegate
                            {
                                BlackBirdF blackBirdF = new BlackBirdF();
                                Point point2 = new Point(screen.Width / 2 - blackBirdF.Width / 2, screen.Height / 2 - blackBirdF.Height);
                                blackBirdF.ShowDialog(new Point(point2.X - 500, point2.Y + 400), 619);
                            });
                            Tracker.AddAndStartThread("whiteBirdF", delegate
                            {
                                WhiteBirdF whiteBirdF = new WhiteBirdF();
                                Point point = new Point(screen.Width / 2 - whiteBirdF.Width / 2, screen.Height / 2 - whiteBirdF.Height);
                                whiteBirdF.ShowDialog(new Point(point.X + 500, point.Y + 400), 619);
                            });
                            return;
                        }
                    case 619L:
                        {
                            Tracker.AddAndStartThread("WalkingYuki", delegate
                            {
                                WalkingYukiForm walkingYukiForm = new WalkingYukiForm();
                                walkingYukiForm.ShowDialog(new Point(screen.Width - walkingYukiForm.Width, screen.Height / 2 - walkingYukiForm.Height / 2), 1151, 300);
                            });
                            return;
                        }
                    case 811L:
                        RollingDogShower.Show(1450);
                        return;
                    case 990L:
                        RollingDogShower.Show(1450);
                        return;
                    case 1149L:
                        ShowStaticPigeon(new Point(-450, 100), screen, 1184L, isGrey: true);
                        return;
                    case 1158L:
                        ShowStaticPigeon(new Point(-150, 100), screen, 1184L, isGrey: true);
                        return;
                    case 1167L:
                        ShowStaticPigeon(new Point(150, 100), screen, 1184L, isGrey: true);
                        return;
                    case 1176L:
                        ShowStaticPigeon(new Point(450, 100), screen, 1184L, isGrey: false);
                        return;
                    case 1184L:
                        {
                            Tracker.AddAndStartThread("fightForm", delegate
                            {
                                FightForm fightForm = new FightForm();
                                fightForm.ShowDialog(1211L);
                            });
                            return;
                        }
                    case 1212L:
                        {
                            Thread thread12 = Tracker.AddThread("AhhhFShower", delegate
                            {
                                AhhhF ahhhF = new AhhhF();
                                ahhhF.ShowDialog(new Point(screen.Width / 2, screen.Height / 2 - ahhhF.Height / 2), 1226);
                            });
                            thread12.Start();
                            return;
                        }
                    case 1214L:
                        {
                            Thread thread11 = Tracker.AddThread("AhhhError", delegate
                            {
                                int i;
                                for (i = 0; i < 6; i++)
                                {
                                    Tracker.AddAndStartThread("ErrorF", delegate
                                    {
                                        ErrorF errorF = new ErrorF();
                                        errorF.ShowDialog(new Point(screen.Width / 2 - errorF.Width / 2 - i * 40, screen.Height / 2 - errorF.Height / 2 + i * 30), 1230);
                                    });
                                    Thread.Sleep(60);
                                }
                            });
                            thread11.Start();
                            return;
                        }
                    case 1288L:
                        ClapYukiShower.Show();
                        return;
                    case 1391L:
                        RollingDogShower.Show(1000);
                        return;
                    case 1395L:
                        RollingDogShower.Show(1000);
                        return;
                    case 1438L:
                        ClapYukiShower.Show();
                        return;
                    case 1452L:
                        {
                            Tracker.AddAndStartThread("staticYukiForm7", delegate
                            {
                                StaticYukiForm staticYukiForm7 = new StaticYukiForm();
                                staticYukiForm7.ShowDialog(new Point(screen.Width / 2 - staticYukiForm7.Width / 2 - 400, screen.Height / 2 - staticYukiForm7.Height / 2), 1486);
                            });
                            return;
                        }
                    case 1462L:
                        {
                            Tracker.AddAndStartThread("staticYukiForm8", delegate
                            {
                                StaticYukiForm staticYukiForm8 = new StaticYukiForm();
                                staticYukiForm8.ShowDialog(new Point(screen.Width / 2 - staticYukiForm8.Width / 2, screen.Height / 2 - staticYukiForm8.Height / 2), 1486);
                            });
                            return;
                        }
                    case 1472L:
                        {
                            Tracker.AddAndStartThread("staticYukiForm9", delegate
                            {
                                StaticYukiForm staticYukiForm9 = new StaticYukiForm();
                                staticYukiForm9.ShowDialog(new Point(screen.Width / 2 - staticYukiForm9.Width / 2 + 400, screen.Height / 2 - staticYukiForm9.Height / 2), 1486);
                            });
                            return;
                        }
                    case 1512L:
                        ClapYukiShower.Show();
                        return;
                }
                long num4 = num2;
                if (num4 < 1527 || num4 >= 1535)
                {
                    switch (num2)
                    {
                        case 1669L:
                            ClapYukiShower.Show();
                            return;
                        case 1685L:
                            WaveBirdShower.WaveBirdShow(screen, 1806L, new Point(-480, 240), isWhite: false);
                            WaveBirdShower.WaveBirdShow(screen, 1806L, new Point(-320, 240), isWhite: false);
                            WaveBirdShower.WaveBirdShow(screen, 1806L, new Point(-160, 240), isWhite: false);
                            WaveBirdShower.WaveBirdShow(screen, 1806L, new Point(480, 240), isWhite: true);
                            WaveBirdShower.WaveBirdShow(screen, 1806L, new Point(320, 240), isWhite: true);
                            WaveBirdShower.WaveBirdShow(screen, 1806L, new Point(160, 240), isWhite: true);
                            return;
                        case 1808L:
                            {
                                Thread thread14 = Tracker.AddThread("HugeBlowShower", delegate
                                {
                                    HugeBlow hugeBlow = new HugeBlow();
                                    hugeBlow.ShowDialog(1831);
                                });
                                thread14.Start();
                                return;
                            }
                    }
                    long num5 = num2;
                    if (num5 < 1830 || num5 >= 1840)
                    {
                        switch (num2)
                        {
                            case 1880L:
                                BWYukiShower.StopShow();
                                break;
                            case 1896L:
                                ClapYukiShower.Show();
                                break;
                            case 1989L:
                                RollingDogShower.Show(1000);
                                break;
                            case 1993L:
                                RollingDogShower.Show(1000);
                                break;
                            case 1997L:
                                RollingDogShower.Show(1000);
                                break;
                            case 2046L:
                                ClapYukiShower.Show();
                                break;
                            case 2061L:
                                {
                                    Tracker.AddAndStartThread("StaticYukiForm10", delegate
                                    {
                                        StaticYukiForm staticYukiForm = new StaticYukiForm();
                                        staticYukiForm.ShowDialog(new Point(screen.Width / 2 - staticYukiForm.Width / 2 - 400, screen.Height / 2 - staticYukiForm.Height / 2), 2141);
                                    });
                                    break;
                                }
                            case 2071L:
                                {
                                    Tracker.AddAndStartThread("StaticYukiForm11", delegate
                                    {
                                        StaticYukiForm staticYukiForm2 = new StaticYukiForm();
                                        staticYukiForm2.ShowDialog(new Point(screen.Width / 2 - staticYukiForm2.Width / 2, screen.Height / 2 - staticYukiForm2.Height / 2), 2141);
                                    });
                                    break;
                                }
                            case 2081L:
                                {
                                    Tracker.AddAndStartThread("StaticYukiForm12", delegate
                                    {
                                        StaticYukiForm staticYukiForm3 = new StaticYukiForm();
                                        staticYukiForm3.ShowDialog(new Point(screen.Width / 2 - staticYukiForm3.Width / 2 + 400, screen.Height / 2 - staticYukiForm3.Height / 2), 2141);
                                    });
                                    break;
                                }
                            case 2099L:
                                WaveBirdShower.WaveBirdShow(screen, 2122L, new Point(-300, 240), isWhite: true);
                                WaveBirdShower.WaveBirdShow(screen, 2122L, new Point(-100, 240), isWhite: false);
                                WaveBirdShower.WaveBirdShow(screen, 2122L, new Point(100, 240), isWhite: true);
                                WaveBirdShower.WaveBirdShow(screen, 2122L, new Point(300, 240), isWhite: false);
                                break;
                            case 2198L:
                                ClapYukiShower.Show();
                                break;
                            case 2305L:
                                RollingDogShower.Show(1000);
                                break;
                            case 2309L:
                                RollingDogShower.Show(1000);
                                break;
                            case 2313L:
                                RollingDogShower.Show(1000);
                                break;
                            case 2317L:
                                RollingDogShower.Show(1000);
                                break;
                            case 2352L:
                                ClapYukiShower.Show();
                                break;
                            case 2405L:
                                RollingDogShower.Show(1400);
                                break;
                            case 2368L:
                                {
                                    Tracker.AddAndStartThread("StaticYukiForm4", delegate
                                    {
                                        StaticYukiForm staticYukiForm4 = new StaticYukiForm();
                                        staticYukiForm4.ShowDialog(new Point(screen.Width / 2 - staticYukiForm4.Width / 2 - 400, screen.Height / 2 - staticYukiForm4.Height / 2), 2400);
                                    });
                                    break;
                                }
                            case 2378L:
                                {
                                    Tracker.AddAndStartThread("StaticYukiForm5", delegate
                                    {
                                        StaticYukiForm staticYukiForm5 = new StaticYukiForm();
                                        staticYukiForm5.ShowDialog(new Point(screen.Width / 2 - staticYukiForm5.Width / 2, screen.Height / 2 - staticYukiForm5.Height / 2), 2400);
                                    });
                                    break;
                                }
                            case 2388L:
                                {
                                    Tracker.AddAndStartThread("StaticYukiForm6", delegate
                                    {
                                        StaticYukiForm staticYukiForm6 = new StaticYukiForm();
                                        staticYukiForm6.ShowDialog(new Point(screen.Width / 2 - staticYukiForm6.Width / 2 + 400, screen.Height / 2 - staticYukiForm6.Height / 2), 2400);
                                    });
                                    break;
                                }
                            case 2439L:
                                WaveBirdShower.WaveBirdShow(screen, 2485L, new Point(-360, 240), isWhite: false);
                                WaveBirdShower.WaveBirdShow(screen, 2485L, new Point(-240, 240), isWhite: true);
                                WaveBirdShower.WaveBirdShow(screen, 2485L, new Point(-120, 240), isWhite: false);
                                WaveBirdShower.WaveBirdShow(screen, 2485L, new Point(0, 240), isWhite: true);
                                WaveBirdShower.WaveBirdShow(screen, 2485L, new Point(360, 240), isWhite: false);
                                WaveBirdShower.WaveBirdShow(screen, 2485L, new Point(240, 240), isWhite: true);
                                WaveBirdShower.WaveBirdShow(screen, 2485L, new Point(120, 240), isWhite: false);
                                break;
                            case 2508L:
                                {
                                    Tracker.AddAndStartThread("likeForm", delegate
                                    {
                                        LikeForm likeForm = new LikeForm();
                                        likeForm.ShowDialog(2520);
                                    });
                                    break;
                                }
                        }
                    }
                    else if (!isBWYuki)
                    {
                        BWYukiShower.StartShow();
                        isBWYuki = true;
                    }
                }
                else if (!isFloatWindow)
                {
                    Thread thread22 = Tracker.AddThread("FloatWindowShower", delegate
                    {
                        FloatWindowHelperF floatWindowHelperF = new FloatWindowHelperF();
                        floatWindowHelperF.ShowDialog(1684);
                    });
                    thread22.Start();
                    isFloatWindow = true;
                }
            }
            else if (!isSummonJumpingForm)
            {
                Thread thread23 = Tracker.AddThread("JumpingYuki", delegate
                {
                    isSummonJumpingForm = true;
                    yukiForm = new JumpingYukiForm();
                    yukiForm.SpeedRate = SpeedRate;
                    yukiForm.ShowDialog(new Point(screen.Width / 2 - yukiForm.Width / 2, screen.Height / 2 - yukiForm.Height / 2), 2864);
                });
                thread23.Start();
                AnimalsShower.StartShow();
            }
        }

        private void threadsList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isCursorPressOnListView = true;
            }
        }

        private void threadsList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isCursorPressOnListView = false;
            }
        }

        private void ShowStaticPigeon(Point d, Rectangle screen, long endF, bool isGrey)
        {
            Tracker.AddAndStartThread("staticPigeonF", delegate
            {
                StaticPigeonF staticPigeonF = new StaticPigeonF();
                Point point = new Point(screen.Width / 2 - staticPigeonF.Width / 2, screen.Height / 2 - staticPigeonF.Height / 2);
                staticPigeonF.ShowDialog(new Point(point.X + d.X, point.Y + d.Y), endF, isGrey);
            });
        }
    }
}
