using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Tools
{
    public class Win32APIHelper
    {

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        const int WM_COMMAND = 0x111;
        const int MIN_ALL = 419;

        /// <summary>
        /// 最小化所有窗口
        /// </summary>
        public static void MinimizeAllWindows()
        {
            IntPtr lHwnd = FindWindow("Shell_TrayWnd", "");
            SendMessage(lHwnd, WM_COMMAND, MIN_ALL, IntPtr.Zero);
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SystemParametersInfo(uint uAction, uint uParam, string lpvParam, uint fuWinIni);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SystemParametersInfo(uint uAction, uint uParam, StringBuilder lpvParam, uint fuWinIni);

        private const uint SPI_GETDESKWALLPAPER = 0x0073;
        private const uint SPI_SETDESKWALLPAPER = 0x0014;
        private const uint SPIF_UPDATEINIFILE = 0x01;
        private const uint SPIF_SENDWININICHANGE = 0x02;

        private static string _originalWallpaperPath = null;
        private static int _lastType = -1;
        public static bool CanChangeWallpaper { get; set; } = true;
        private static readonly object _lock = new object();

        private static void GetOriginalWallpaperFetched()
        {
            if (_originalWallpaperPath == null)
            {
                lock (_lock)
                {
                    if (_originalWallpaperPath == null)
                    {
                        StringBuilder currentWallpaper = new StringBuilder(260);
                        if (SystemParametersInfo(SPI_GETDESKWALLPAPER, (uint)currentWallpaper.Capacity, currentWallpaper, 0))
                        {
                            _originalWallpaperPath = currentWallpaper.ToString();
                            if (string.IsNullOrWhiteSpace(_originalWallpaperPath))
                            {
                                _originalWallpaperPath = string.Empty;
                            }
                        }
                        else
                        {
                            int error = Marshal.GetLastWin32Error();
                            _originalWallpaperPath = string.Empty;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 设置壁纸
        /// </summary>
        /// <param name="type">0恢复原来的桌面壁纸  1纯色黄  2纯色蓝</param>
        public static void ChangeWallpaper(int type)
        {
            GetOriginalWallpaperFetched();

            if ((!CanChangeWallpaper && type != 0) || type == _lastType)
                return;
            lock (_lock)
            {
                _lastType = type;
            }
            if (type == 0 && string.IsNullOrEmpty(_originalWallpaperPath))
            {
                Console.WriteLine("原始壁纸路径未知或为空。");
                return;
            }

            new Thread(() =>
            {
                string wallpaperToSet = null;
                switch (type)
                {
                    case 0:
                        wallpaperToSet = _originalWallpaperPath;
                        break;
                    case 1:
                        wallpaperToSet = Path.Combine(Application.StartupPath, "Assets", "yellow.bmp");
                        break;
                    case 2:
                        wallpaperToSet = Path.Combine(Application.StartupPath, "Assets", "blue.bmp");
                        break;
                    default:
                        return;
                }

                if (string.IsNullOrEmpty(wallpaperToSet))
                {
                    Logger.WriteLine($"类型 {type} 的壁纸路径为 null 或为空。");
                    return;
                }

                Logger.WriteLine($"尝试将壁纸设置为：{wallpaperToSet}");
                if (!SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, wallpaperToSet, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE))
                {
                    int error = Marshal.GetLastWin32Error();
                    Logger.WriteLine($"无法将类型 {type} 的壁纸设置为“{wallpaperToSet}”。错误：{error}");
                }
            }).Start();
        }

        public static void ResetOriginalWallpaperCache()
        {
            lock (_lock)
            {
                _originalWallpaperPath = null;
                _lastType = -1;
            }
        }


    }
}
