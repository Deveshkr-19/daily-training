using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_Task.UI
{
    public static class AppScreen
    {
        internal static void Welcome()
        {
            //clears the console screen
            Console.Clear();
            // Sets the title of the console window
            Console.Title = "My ATM App";
            // Sets the text color or foreground color to white
            Console.ForegroundColor = ConsoleColor.White;


            // Set the welcome message
            Console.WriteLine("\n\n-------------------------------Welcome to My ATM App-------------------------------\n");
            // Prompt the user to insert ATM card
            Console.WriteLine("Please insert your ATM card");
            Console.WriteLine("Note: Actual ATM machine will accept and validate a physical ATM card, read the number and validate it.");
            Utility.PressEnterToContinue();
        }

    }
}
