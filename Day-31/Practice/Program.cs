using System;
using System.Threading;

namespace Practice
{
    //public class MyThread
    //{
    //    public static void Thread1()
    //    {
    //        Console.WriteLine("1");
    //    }
    //    public static void Thread2()
    //    {
    //        Console.WriteLine("2");
    //    }
    //    public static void Thread3()
    //    {
    //        Console.WriteLine("3");
    //    }
    //}

    public class MyThread
    {
        public void thread1()
        {
            //for(int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(i);
            //    Thread.Sleep(200);
            //}

            //for(int i = 0; i < 5; i++)
            //{
            //    Thread t = Thread.CurrentThread;
            //    Console.WriteLine(t.Name + " is running.");
            //    Thread.Sleep(500);
            //}




            Thread t = Thread.CurrentThread;
            Console.WriteLine(t.Name + " is running.");
            Thread.Sleep(500);
        }
    }
    class Program
    {
        //static void method1()
        //{
        //    for (int i = 1; i <= 5; i++)
        //    {
        //        Console.WriteLine($"Method1: {i}");
        //    }
        //}
        //static void method2()
        //{
        //    for (int i = 1; i <= 5; i++)
        //    {
        //        Console.WriteLine($"Method2: {i}");
        //        if (i == 3)
        //        {
        //            Console.WriteLine($"Started performing thread operation");
        //            Thread.Sleep(4000);
        //            Console.WriteLine($"Completed performing thread operation");
        //        }
        //    }
        //}
        //static void method3()
        //{
        //    for (int i = 1; i <= 5; i++)
        //    {
        //        Console.WriteLine($"Method3: {i}");
        //    }
        //}

        static void Main(string[] args)
        {
            //Thread t = Thread.CurrentThread;
            //t.Name = "MyFirstThread";
            //Console.WriteLine(t.Name);


            //MyThread mt = new MyThread();
            //Thread t1 = new Thread(new ThreadStart(MyThread.Thread1));
            //Thread t2 = new Thread(new ThreadStart(MyThread.Thread2));
            //Thread t3 = new Thread(new ThreadStart(MyThread.Thread3));

            //t3.Start();
            //t1.Start();
            //t2.Start();


            //MyThread obj = new MyThread();
            //Thread t1 = new Thread(new ThreadStart(obj.thread1));
            //Thread t2 = new Thread(new ThreadStart(obj.thread1));

            //t1.Start();
            //t2.Start();

            //Console.WriteLine("Start from main");
            //MyThread obj = new MyThread();
            //Thread t1 = new Thread(new ThreadStart(obj.thread1));
            //Thread t2 = new Thread(new ThreadStart(obj.thread1));

            //t1.Start();
            //t2.Start();

            //try
            //{
            //    t1.Abort();
            //    t2.Abort();
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
            //Console.WriteLine("End to main");



            //MyThread obj = new MyThread();
            //Thread t1 = new Thread(new ThreadStart(obj.thread1));
            //Thread t2 = new Thread(new ThreadStart(obj.thread1));

            //t1.Start();
            //t1.Join();
            //t2.Start();



            //MyThread obj = new MyThread();
            //Thread t1 = new Thread(new ThreadStart(obj.thread1));
            //Thread t2 = new Thread(new ThreadStart(obj.thread1));
            //Thread t3 = new Thread(new ThreadStart(obj.thread1));

            //t1.Name = "Player 1";
            //t2.Name = "Player 2";
            //t3.Name = "Player 3";

            //t1.Start();
            //t2.Start();
            //t3.Start();




            //MyThread obj = new MyThread();
            //Thread t1 = new Thread(new ThreadStart(obj.thread1));
            //Thread t2 = new Thread(new ThreadStart(obj.thread1));
            //Thread t3 = new Thread(new ThreadStart(obj.thread1));

            //t1.Name = "Player 1";
            //t2.Name = "Player 2";
            //t3.Name = "Player 3";

            //t3.Priority = ThreadPriority.Highest;
            //t2.Priority = ThreadPriority.Normal;
            //t1.Priority = ThreadPriority.Lowest;

            //t1.Start();
            //t2.Start();
            //t3.Start();




            //method1();
            //method2();
            //method3();



            //Console.WriteLine("Main Thread Started");

            //Thread t1 = new Thread(method1)
            //{
            //    Name = "Thread1"
            //};

            //Thread t2 = new Thread(method2)
            //{
            //    Name = "Thread2"
            //};

            //Thread t3 = new Thread(method3)
            //{
            //    Name = "Thread3"
            //};

            //t1.Start();
            //t2.Start();
            //t3.Start();

            //Console.WriteLine("Main method ended");




            // -------------------------------Reference--------------------------------------

            ////Creating instance of Thread
            //Thread currentThread = Thread.CurrentThread;

            ////Get name of Thread
            //Console.WriteLine($"Thread: {currentThread.Name}");

            //currentThread.Name = "Main";
            //Console.WriteLine($"Thread name: {currentThread.Name}");
            //Console.WriteLine($"Thread Id: {currentThread.ManagedThreadId}");
            //Console.WriteLine($"Thread is Alive? : {currentThread.IsAlive}");
            //Console.WriteLine($"Priority of Thread: {currentThread.Priority}");
            //Console.WriteLine($"Status of Thread: {currentThread.ThreadState}");
            //Console.WriteLine($"IsBackground: {currentThread.IsBackground}");


            //// Create a new Thread
            //Thread Thread1 = new Thread(Print);
            //Thread Thread2 = new Thread(new ThreadStart(Print));
            //Thread Thread3 = new Thread(() => Console.WriteLine("Hello from thread3"));

            //Thread1.Start();  // Thread1 starts
            //Thread2.Start();  // Thread1 starts
            //Thread3.Start();  // Thread1 starts

            //void Print()
            //{
            //    Console.WriteLine("Threads");
            //}



            // Create a new Thread
            Thread MainThread = new Thread(Print);
            // Run thread
            MainThread.Start();

            // Actions that we make in the Main Thread
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Main Thread: {i}");
                //Pause thread
                Thread.Sleep(300);
            }

            // Actions from second thread
            void Print()
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Second Thread: {i}");
                    Thread.Sleep(400);
                }
            }

        }

        private static void method3(object obj)
        {
            Console.WriteLine("Method 3 started using", Thread.CurrentThread.Name);
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine($"Method3: {i}");
            }
            Console.WriteLine("Method 3 ended using", Thread.CurrentThread.Name);
        }

        private static void method2(object obj)
        {
            Console.WriteLine("Method 2 started using", Thread.CurrentThread.Name);
            for (int i = 0; i <= 5; i++)
            {
                if (i == 3)
                {
                    Console.WriteLine("Started performing thread operation");
                    Thread.Sleep(500);
                    Console.WriteLine("Ended performing thread operation");
                }
                Console.WriteLine($"Method1: {i}");
            }
            Console.WriteLine("Method 2 ended using", Thread.CurrentThread.Name);
        }

        private static void method1(object obj)
        {
            Console.WriteLine("Method 1 started using", Thread.CurrentThread.Name);
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine($"Method1: {i}");
            }
            Console.WriteLine("Method 1 ended using", Thread.CurrentThread.Name);
        }
    }
}
