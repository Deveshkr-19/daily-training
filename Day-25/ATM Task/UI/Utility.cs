using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_Task.UI
{
    public static class Utility
    {
        public static string GetSecretInput(string prompt)
        {
            bool isPrompt = true;
            string asterics = "";

            StringBuilder input = new StringBuilder();

            while (true)
            {
                if (isPrompt)
                    Console.WriteLine(prompt);
                ConsoleKeyInfo input Key = Console.ReadKey(true);
            }
        }
        public static void PrintMessage(string msg, bool success = true)
        {
            if(success)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
            PressEnterToContinue();
        }
        public static string GetUserInput(string prompt)
        {
            Console.WriteLine($"Enter {prompt}");
            return Console.ReadLine();
        }
        public static void PressEnterToContinue()
        {
            Console.WriteLine("\n\nPress Enter to continue...\n");
            Console.ReadLine();
        }
    }
}
