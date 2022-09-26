

using Polling.Models;
using Polling.PollingApp;
using System;

namespace Polling
{
    class Program
    {
        static void Main(string[] args)
        {
            string repeat = "Y";
            while (repeat.ToUpper() == "Y")
            {
                VotingApp.StartApp();

                Console.WriteLine("Do you want to start again? (Y/N)");
                repeat = Console.ReadLine();
            }
        }
    }
}
