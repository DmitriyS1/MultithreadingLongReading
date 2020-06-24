using System.Collections.Generic;
using System.Threading;

namespace MultithreadingLongReading.Services
{
    public static class ReaderService
    {
        private static string _file;

        public static string ReadFile()
        {
            Thread.Sleep(20000);
            return $"Hello from thread {Thread.CurrentThread.ManagedThreadId}";
        }
        
        public static string ReadFileWithLock()
        {
            var file = new List<byte>();
            // Вернуть в оба потока надо
            var locker = new object();
            lock (locker)
            {
                _file = 
                Thread.Sleep(20000);
                return $"Hello from thread {Thread.CurrentThread.ManagedThreadId}";
            }
        }

        public static string MonitorTest()
        {
            object locker = new object();
            bool acquiredLock = false;
            try
            {
                Monitor.Enter(locker, ref acquiredLock);
                Thread.Sleep(20000);
                return $"Hello from thread {Thread.CurrentThread.ManagedThreadId}";
            }
            finally
            {
                if (acquiredLock)
                {
                    Monitor.Exit(locker);
                }
            }
        }
    }
}
