using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace DinosaursWithLasers.Utilities
{
    public static class ExtensionMethods
    {
        public static int ToInt(this int? src)
        {
            int r;
            int.TryParse(src.ToString(), out r);
            return r;
        }
    }
}
