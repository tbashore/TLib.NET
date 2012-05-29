using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLib
{
    public static class DateTimeExtensions
    {
        public static bool Between(this DateTime date, DateTime start, DateTime end)
        {
            return
                (date >= start && date <= end) ||
                (date >= end && date <= start);
        }
    }
}
