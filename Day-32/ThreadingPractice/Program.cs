using System;
using System.Threading;

namespace ThreadingPractice
{
    class Program
    {
        // ------------------------------- {3} Lock
        static readonly object pblock = new object();
        static void PrintInfo()
        {
            lock (pblock)
            {
                for (int i = 1; i <= 4; i++)
                {
                    Console.WriteLine("i value: {0}", i);
                    Thread.Sleep(1000);
                }
            }
        }
        static void Main(string[] args)
        {

            //// ------------------------------- {1} Sleep thread
            //for (int i = 1; i <= 5; i++)
            //{
            //    Console.WriteLine("Thread paused for {0} second", 1);
            //    // Pause thread for 1 second
            //    Thread.Sleep(1000);
            //    Console.WriteLine("i value: {0}", i);
            //}




            //// ------------------------------- {2} Sleep thread with Timespan property
            //TimeSpan ts = new TimeSpan(0, 0, 1);
            //for (int i = 1; i <= 5; i++)
            //{
            //    Console.WriteLine("Thread paused for {0} second", 1);
            //    // Pause thread for 1 second
            //    Thread.Sleep(ts);
            //    Console.WriteLine("i value: {0}", i);
            //}
            //Console.WriteLine("Main Thread Exists");



            // ------------------------------- {3} Lock
            Thread t1 = new Thread(new ThreadStart(PrintInfo));
            Thread t2 = new Thread(new ThreadStart(PrintInfo));
            t1.Start();
            t2.Start();

        }
    }
}
