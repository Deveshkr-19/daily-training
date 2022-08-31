using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1
{
    class AccessSpecifiers
    {
        public int pubA { get; set; }
        public int pubB { get; set; }
        private int privA { get; set; }
        protected int protA { get; set; }

        public int getPrivA
        {
            get
            {
                return privA;
            }
            set
            {
                privA = value;
            }
        }

        public int getProtA
        {
            get
            {
                return protA;
            }
            set
            {
                protA = value;
            }
        }
    }
}
