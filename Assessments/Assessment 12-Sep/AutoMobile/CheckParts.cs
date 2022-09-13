using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMobile
{
    public class CheckParts : ICheckParts
    {
        public bool CheckMultParts(string name, List<string> parts)
        {
            foreach(string part in parts)
                if (name == part)
                    return true;
            return false;
        }
    }
}
