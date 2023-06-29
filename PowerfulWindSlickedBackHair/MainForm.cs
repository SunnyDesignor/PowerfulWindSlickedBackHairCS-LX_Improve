using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using NAudio.Wave;
using PowerfulWindSlickedBackHair;
using PowerfulWindSlickedBackHair.Tools;
using PowerfulWindSlickedBackHair.Windows;
using Sunny.UI;
using Sunny.UI.Win32;


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

        private Mp3FileReader reader;

        private WaveOut wave;

        private BackgroundForm backgroundForm;

        private JumpingYukiForm yukiForm;

        private int offset = 3;
        private int bgOffset = 0;

        private bool isSummonBackgroundForm;

        private bool isSummonJumpingForm;

        private bool isBWYuki = false;

        private bool isFloatWindow = false;

        private long lastFrame = -1L;

        public MainForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            base.Location = new Point(workingArea.Width - base.Size.Width, workingArea.Height - base.Size.Height);
            if (File.Exists("Offset.txt"))
            {
                try
                {
                    var array = File.ReadAllText("Offset.txt").Split(' ');
                    offset = int.Parse(array[0]);
                    bgOffset = int.Parse(array[1]);
                }
                catch (Exception)
                {
                }
            }
            LoadFonts();

            SystemParametersInfo(SPI_GETDESKWALLPAPER, currentWallpaper.Length, currentWallpaper, 0);
            currentWallpaper = currentWallpaper.Substring(0, currentWallpaper.IndexOf('\0'));
            Console.WriteLine("当前桌面壁纸: " + currentWallpaper);

            ChangeWallpaper(1);
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

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        // 定义常量
        private const int SPI_GETDESKWALLPAPER = 0x0073;
        private const int SPI_SETDESKWALLPAPER = 0x0014;
        string currentWallpaper = new string('\0', 260);
        int oldType = 0;
        /// <summary>
        /// 设置壁纸    0恢复原来的桌面壁纸  1纯色黄  2纯色蓝
        /// </summary>
        private void ChangeWallpaper(int type)
        {
            if (type == oldType)
                return;
            oldType = type;
            new Thread(() =>
            {
                switch (type)
                {
                    case 0:
                        SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, currentWallpaper, 3);
                        break;
                    case 1:
                        string whiteWallpaper = Application.StartupPath + "\\Assets\\yellow.png";
                        SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, whiteWallpaper, 3);
                        break;
                    case 2:
                        whiteWallpaper = Application.StartupPath + "\\Assets\\blue.png";
                        SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, whiteWallpaper, 3);
                        break;
                }
            }).Start();
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        const int WM_COMMAND = 0x111; // 命令的消息
        const int MIN_ALL = 419; // 最小化所有窗口的命令


        private void MainForm_Load(object sender, EventArgs e)
        {
            //CmdHelper.ExeCommand("taskkill /im cmd.exe /f");

            //最小化所有窗口
            IntPtr lHwnd = FindWindow("Shell_TrayWnd", "");
            SendMessage(lHwnd, WM_COMMAND, MIN_ALL, IntPtr.Zero);
            this.Focus();

            Thread frameTracker = Tracker.AddThread("FrameTracker", delegate
            {
                int millisecondsTimeout = 60 - offset;
                while (true)
                {
                    Tracker.frame++;
                    Thread.Sleep(millisecondsTimeout);
                }
            });
            Thread thread = Tracker.AddThread("FrameUpdater", delegate
            {
                int num = 60 - offset;
                Stream stream = new FileStream("Assets\\Audio.mp3", FileMode.Open);
                reader = new Mp3FileReader(stream);
                wave = new WaveOut();
                wave.Init((IWaveProvider)(object)reader);
                wave.Play();
                Thread.Sleep(bgOffset);
                frameTracker.Start();
                while (true)
                {
                    if (lastFrame != Tracker.frame)
                    {
                        lastFrame = Tracker.frame;
                        frameLabel.Text = Tracker.frame.ToString();
                        Update(Tracker.frame, Screen.PrimaryScreen.WorkingArea);
                        Thread.Sleep(num / 2);
                    }
                }
            });
            Thread thread2 = Tracker.AddThread("ThreadsShower", delegate
            {
                while (true)
                {
                    if (!isCursorPressOnListView)
                    {
                        threadsList.Items.Clear();
                        try
                        {
                            foreach (Thread thread3 in Tracker.threads)
                            {
                                try
                                {
                                    string name = thread3.Name;
                                    bool isAlive = thread3.IsAlive;
                                    ListViewItem listViewItem = threadsList.Items.Add(name);
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
                        Thread.Sleep(100);
                    }
                }
            });
            thread.Start();
            thread2.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ChangeWallpaper(0);
            Tracker.StopAll();
            wave.Stop();
            wave.Dispose();
            CmdHelper.ExeCommand("taskkill /im PowerfulWindSlickedBackHair.exe /f");
        }

        private void Update(long f, Rectangle screen)
        {
            long num = f;

            //壁纸更新
            if (num == 60)
                this.WindowState = FormWindowState.Minimized;
            else if (num >= 387 && num < 464)
                ChangeWallpaper(2);
            else if (num >= 464 && num < 542)
                ChangeWallpaper(1);
            else if (num >= 542 && num < 616)
                ChangeWallpaper(2);
            else if (num >= 616 && num < 630)
                ChangeWallpaper(1);
            else if (num >= 2870 && num < 2880)
                ChangeWallpaper(0);
            else if (num > 3000)
                this.Close();

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
            if (num3 < 9 || num3 >= 14)
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
                            Thread thread6 = new Thread((ThreadStart)delegate
                            {
                                StaticYukiForm staticYukiForm10 = new StaticYukiForm();
                                staticYukiForm10.ShowDialog(new Point(screen.Width / 2 - staticYukiForm10.Width / 2 - 400, screen.Height / 2 - staticYukiForm10.Height / 2), 269);
                            });
                            thread6.Start();
                            return;
                        }
                    case 244L:
                        {
                            Thread thread5 = new Thread((ThreadStart)delegate
                            {
                                StaticYukiForm staticYukiForm11 = new StaticYukiForm();
                                staticYukiForm11.ShowDialog(new Point(screen.Width / 2 - staticYukiForm11.Width / 2, screen.Height / 2 - staticYukiForm11.Height / 2), 269);
                            });
                            thread5.Start();
                            return;
                        }
                    case 254L:
                        {
                            Thread thread4 = new Thread((ThreadStart)delegate
                            {
                                StaticYukiForm staticYukiForm12 = new StaticYukiForm();
                                staticYukiForm12.ShowDialog(new Point(screen.Width / 2 - staticYukiForm12.Width / 2 + 400, screen.Height / 2 - staticYukiForm12.Height / 2), 269);
                            });
                            thread4.Start();
                            return;
                        }
                    case 315L:
                        {
                            Thread thread2 = Tracker.AddThread("BlackBirdShower", delegate
                            {
                                BlackBirdF blackBirdF = new BlackBirdF();
                                Point point2 = new Point(screen.Width / 2 - blackBirdF.Width / 2, screen.Height / 2 - blackBirdF.Height);
                                blackBirdF.ShowDialog(new Point(point2.X - 500, point2.Y + 400), 619);
                            });
                            thread2.Start();
                            Thread thread3 = Tracker.AddThread("WhiteBirdShower", delegate
                            {
                                WhiteBirdF whiteBirdF = new WhiteBirdF();
                                Point point = new Point(screen.Width / 2 - whiteBirdF.Width / 2, screen.Height / 2 - whiteBirdF.Height);
                                whiteBirdF.ShowDialog(new Point(point.X + 500, point.Y + 400), 619);
                            });
                            thread3.Start();
                            return;
                        }
                    case 619L:
                        {
                            Thread thread7 = Tracker.AddThread("WalkingYuki", delegate
                            {
                                WalkingYukiForm walkingYukiForm = new WalkingYukiForm();
                                walkingYukiForm.ShowDialog(new Point(screen.Width - walkingYukiForm.Width, screen.Height / 2 - walkingYukiForm.Height / 2), 1151, 300);
                            });
                            thread7.Start();
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
                            Thread thread13 = new Thread((ThreadStart)delegate
                            {
                                FightForm fightForm = new FightForm();
                                fightForm.ShowDialog(1211L);
                            });
                            thread13.Start();
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
                                    Thread thread24 = new Thread((ThreadStart)delegate
                                    {
                                        ErrorF errorF = new ErrorF();
                                        errorF.ShowDialog(new Point(screen.Width / 2 - errorF.Width / 2 - i * 40, screen.Height / 2 - errorF.Height / 2 + i * 30), 1226);
                                    });
                                    thread24.Start();
                                    Thread.Sleep(50);
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
                            Thread thread10 = new Thread((ThreadStart)delegate
                            {
                                StaticYukiForm staticYukiForm7 = new StaticYukiForm();
                                staticYukiForm7.ShowDialog(new Point(screen.Width / 2 - staticYukiForm7.Width / 2 - 400, screen.Height / 2 - staticYukiForm7.Height / 2), 1486);
                            });
                            thread10.Start();
                            return;
                        }
                    case 1462L:
                        {
                            Thread thread9 = new Thread((ThreadStart)delegate
                            {
                                StaticYukiForm staticYukiForm8 = new StaticYukiForm();
                                staticYukiForm8.ShowDialog(new Point(screen.Width / 2 - staticYukiForm8.Width / 2, screen.Height / 2 - staticYukiForm8.Height / 2), 1486);
                            });
                            thread9.Start();
                            return;
                        }
                    case 1472L:
                        {
                            Thread thread8 = new Thread((ThreadStart)delegate
                            {
                                StaticYukiForm staticYukiForm9 = new StaticYukiForm();
                                staticYukiForm9.ShowDialog(new Point(screen.Width / 2 - staticYukiForm9.Width / 2 + 400, screen.Height / 2 - staticYukiForm9.Height / 2), 1486);
                            });
                            thread8.Start();
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
                                    Thread thread21 = new Thread((ThreadStart)delegate
                                    {
                                        StaticYukiForm staticYukiForm = new StaticYukiForm();
                                        staticYukiForm.ShowDialog(new Point(screen.Width / 2 - staticYukiForm.Width / 2 - 400, screen.Height / 2 - staticYukiForm.Height / 2), 2141);
                                    });
                                    thread21.Start();
                                    break;
                                }
                            case 2071L:
                                {
                                    Thread thread20 = new Thread((ThreadStart)delegate
                                    {
                                        StaticYukiForm staticYukiForm2 = new StaticYukiForm();
                                        staticYukiForm2.ShowDialog(new Point(screen.Width / 2 - staticYukiForm2.Width / 2, screen.Height / 2 - staticYukiForm2.Height / 2), 2141);
                                    });
                                    thread20.Start();
                                    break;
                                }
                            case 2081L:
                                {
                                    Thread thread19 = new Thread((ThreadStart)delegate
                                    {
                                        StaticYukiForm staticYukiForm3 = new StaticYukiForm();
                                        staticYukiForm3.ShowDialog(new Point(screen.Width / 2 - staticYukiForm3.Width / 2 + 400, screen.Height / 2 - staticYukiForm3.Height / 2), 2141);
                                    });
                                    thread19.Start();
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
                                    Thread thread18 = new Thread((ThreadStart)delegate
                                    {
                                        StaticYukiForm staticYukiForm4 = new StaticYukiForm();
                                        staticYukiForm4.ShowDialog(new Point(screen.Width / 2 - staticYukiForm4.Width / 2 - 400, screen.Height / 2 - staticYukiForm4.Height / 2), 2400);
                                    });
                                    thread18.Start();
                                    break;
                                }
                            case 2378L:
                                {
                                    Thread thread17 = new Thread((ThreadStart)delegate
                                    {
                                        StaticYukiForm staticYukiForm5 = new StaticYukiForm();
                                        staticYukiForm5.ShowDialog(new Point(screen.Width / 2 - staticYukiForm5.Width / 2, screen.Height / 2 - staticYukiForm5.Height / 2), 2400);
                                    });
                                    thread17.Start();
                                    break;
                                }
                            case 2388L:
                                {
                                    Thread thread16 = new Thread((ThreadStart)delegate
                                    {
                                        StaticYukiForm staticYukiForm6 = new StaticYukiForm();
                                        staticYukiForm6.ShowDialog(new Point(screen.Width / 2 - staticYukiForm6.Width / 2 + 400, screen.Height / 2 - staticYukiForm6.Height / 2), 2400);
                                    });
                                    thread16.Start();
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
                                    Thread thread15 = new Thread((ThreadStart)delegate
                                    {
                                        LikeForm likeForm = new LikeForm();
                                        likeForm.ShowDialog(2520);
                                    });
                                    thread15.Start();
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
            Thread thread = new Thread((ThreadStart)delegate
            {
                StaticPigeonF staticPigeonF = new StaticPigeonF();
                Point point = new Point(screen.Width / 2 - staticPigeonF.Width / 2, screen.Height / 2 - staticPigeonF.Height / 2);
                staticPigeonF.ShowDialog(new Point(point.X + d.X, point.Y + d.Y), endF, isGrey);
            });
            thread.Start();
        }
    }
}
