using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLib
{
    public static class StringExtensions
    {
        public static string Truncate(this string str, int maxLength)
        {
            return str.Length > maxLength ? str.Substring(0, maxLength) : str;
        }

        // As seen in OpenRasta.
        public static string With(this string str, params object[] args)
        {
            return string.Format(str, args);
        }
    }
}
