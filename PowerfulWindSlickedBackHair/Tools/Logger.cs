using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PowerfulWindSlickedBackHair.Tools
{
    public static class Logger
    {
        private static readonly object _lock = new object();

        private static readonly string _logFilePath = "log.txt";

        public static void WriteLine(string msg)
        {
            try
            {
                string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - INFO: {msg}";

                lock (_lock)
                {
                    using (StreamWriter writer = new StreamWriter(_logFilePath, true, Encoding.UTF8))
                    {
                        writer.WriteLine(logMessage);
                        writer.Flush();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public static void WriteLine(Exception ex)
        {
            try
            {
                string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - ERROR: {ex.Message}\r\n{ex}";
                if (ex.InnerException != null)
                {
                    logMessage += $"\r\nInner Exception: {ex.InnerException}";
                }

                lock (_lock)
                {
                    using (StreamWriter writer = new StreamWriter(_logFilePath, true, Encoding.UTF8))
                    {
                        writer.WriteLine(logMessage);
                        writer.WriteLine(new string('-', 80));
                        writer.Flush();
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
