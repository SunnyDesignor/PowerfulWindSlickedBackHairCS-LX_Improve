using System;
using System.Collections.Generic;
using System.Threading;

namespace PowerfulWindSlickedBackHair
{
    // Token: 0x02000004 RID: 4
    public static class Tracker
    {
        // Token: 0x0600000B RID: 11 RVA: 0x00003258 File Offset: 0x00001458
        public static Thread AddThread(string name, ThreadStart start)
        {
            Thread thread = new Thread(start);
            thread.Name = name;
            thread.IsBackground = true;
            lock (threads)
            {
                threads.Add(thread);
            }
            return thread;
        }
        public static Thread AddAndStartThread(string name, ThreadStart start)
        {
            Thread thread = AddThread(name, start);
            thread.Start();
            return thread;
        }

        // Token: 0x0600000C RID: 12 RVA: 0x00003288 File Offset: 0x00001488
        public static void StopAll()
        {
            List<Thread> threadsCopy;
            lock (threads)
            {
                threadsCopy = new List<Thread>(threads);
            }
            foreach (Thread thread in threadsCopy)
            {
                if (thread != null && thread.IsAlive)
                {
                    thread.Abort();
                }
            }
        }

        // Token: 0x04000014 RID: 20
        public static List<Thread> threads = new List<Thread>();

        // Token: 0x04000015 RID: 21
        public static long frame;

        public static bool Running;
    }
}
