using ATM_Task.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_Task.App
{
    class Entry
    {
        static void Main(string[] args)
        {
            AppScreen.Welcome();
            long cardNumber = Validator.Convert<long>("Your card number:");
            Console.WriteLine($"Your card number is {cardNumber}");

            Utility.PressEnterToContinue();
        }
    }
}
