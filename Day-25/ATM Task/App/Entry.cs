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
            ATM_Task atmApp = new ATM_Task();
            atmApp.InitializeData();
            atmApp.Run();
        }
    }
}
