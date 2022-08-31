using System;
using System.Collections.Generic;
using System.Text;

namespace PartialLib
{
    public partial class Partial
    {
        private string book_title;
        private string book_author;

        public Partial(string a, string b)
        {
            this.book_title = a;
            this.book_author = b;
        }
    }
}
