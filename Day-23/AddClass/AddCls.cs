using System;
using System.Collections.Generic;
using System.Text;

namespace AddClass
{
    public class AddCls
    {
        public int x, y, total, diff;
        public AddCls(int a, int b)
        {
            x = a;
            y = b;
        }
        public static AddCls operator -(AddCls obj)
        {
            obj.diff = obj.x - obj.y;
            return obj;
        }
    }
}
