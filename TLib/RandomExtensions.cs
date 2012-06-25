using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLib
{
    public static class RandomExtensions
    {
        public static DateTime NextDateTime(this Random random, DateTime minValue, DateTime maxValue)
        {
            if (maxValue < minValue)
            {
                throw new ArgumentOutOfRangeException("maxValue", "maxValue must be greater than minValue.");
            }
            if (minValue == maxValue)
            {
                return minValue;
            }

            Int64 ticksRange = maxValue.Ticks - minValue.Ticks;

            byte[] buff = new byte[8];
            random.NextBytes(buff);
            Int64 randomTicks = Math.Abs(BitConverter.ToInt64(buff, 0));

            return minValue.AddTicks(randomTicks % ticksRange);
        }

        public static T NextEnum<T>(this Random random)
        {
            var values = Enum.GetValues(typeof(T));
            var index = random.Next(values.Length);
            return values.Cast<T>().ElementAt(index);
        }

        public static T NextEnum<T>(this Random random, T minValue, T maxValue)
        {
            var values = Enum.GetValues(typeof(T));

            var comparer = Comparer<T>.Default;
            var tValuesInRange = values.Cast<T>().Where(tValue =>
                (comparer.Compare(minValue, tValue) <= 0 &&
                comparer.Compare(tValue, maxValue) <= 0));

            var index = random.Next(tValuesInRange.Count());
            return tValuesInRange.Cast<T>().ElementAt(index);
        }

        public static T NextEnum<T>(this Random random, T minValue, T maxValue, T except)
        {
            var values = Enum.GetValues(typeof(T));

            var comparer = Comparer<T>.Default;
            var tValuesInRange = values.Cast<T>().Where(tValue =>
                (comparer.Compare(minValue, tValue) <= 0 &&
                comparer.Compare(tValue, maxValue) <= 0) &&
                comparer.Compare(tValue, except) != 0);

            var index = random.Next(tValuesInRange.Count());
            return tValuesInRange.Cast<T>().ElementAt(index);
        }
    }
}
