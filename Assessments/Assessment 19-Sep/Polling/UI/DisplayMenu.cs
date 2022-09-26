using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Polling.UI
{
    public class DisplayMenu
    {
        public static void DisplayAppMenu()
        {
            Console.WriteLine("------- Welcome ----------");
            Console.WriteLine(":  Press                                :");
            Console.WriteLine("1. Admin Login                          :");
            Console.WriteLine("2. Voters Login                         :");
            Console.WriteLine("3. New Voter Registration               :");
        }
        public static void DisplayAppMenuSecond()
        {
            Console.WriteLine("------- Welcome ----------");
            Console.WriteLine(":  Press                                    :");
            Console.WriteLine("1. Register Parties                         :");
            Console.WriteLine("2. Delete Voters                            :");
            Console.WriteLine("3. See the Total votes for All Parties  :");
        }

        public static void PrintDotAnimation(int timer = 10)
        {
            Console.Write("Please wait");
            for (int i = 0; i < timer; i++)
            {
                Console.Write("-");
                Thread.Sleep(300);
            }
            Console.Clear();
        }
    }
}
