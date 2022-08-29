using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1.SampleClasses
{
    public partial class Sample
    {
        private string Movie_title;
        private int release_yr;

        public Sample(string x, int y)
        {
            this.Movie_title = x;
            this.release_yr = y;
        }
    }
}
