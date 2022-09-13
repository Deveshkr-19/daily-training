using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMobile
{
    interface ICheckParts
    {
        bool CheckMultParts(string name, List<string> parts);
    }
}
