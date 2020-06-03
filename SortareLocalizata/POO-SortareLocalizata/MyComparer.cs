using System;
using System.Collections.Generic;
using System.Globalization;
namespace POO_SortareLocalizata
{
    internal class MyComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, new CultureInfo("ro-RO"), CompareOptions.None);
        }
    }
}