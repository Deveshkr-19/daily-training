using System;
using System.Collections.Generic;
using System.Text;

namespace PartialLib
{
    public partial class Partial
    {
        public void displayBookDetails()
        {
            Console.WriteLine("The author of '" + book_title + "' is - " + book_author);
        }
    }
}
