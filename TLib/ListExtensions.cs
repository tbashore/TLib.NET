using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLib
{
    public static class ListExtensions
    {
        public static IEnumerable<List<T>> Partition<T>(this IList<T> source, Int32 size)
        {
            for (int i = 0; i < Math.Ceiling(source.Count / (System.Double)size); i++)
            {
                yield return new List<T>(source.Skip(size * i).Take(size));
            }
        }

        public static T PopFirst<T>(this List<T> source)
        {
            if (source.Count == 0) { throw new IndexOutOfRangeException(); }

            var first = source[0];
            source.RemoveAt(0);
            return first;
        }

        public static T PopLast<T>(this List<T> source)
        {
            if (source.Count == 0) { throw new IndexOutOfRangeException(); }

            var last = source.Last();
            source.RemoveAt(source.Count - 1);
            return last;
        }

        public static List<T> Distinct<T>(this List<T> source)
        {
            Dictionary<T, bool> seen = new Dictionary<T, bool>();

            List<T> destination = new List<T>();
            foreach (T item in source)
            {
                if (seen.ContainsKey(item))
                {
                    continue;
                }
                seen.Add(item, true);
                destination.Add(item);
            }
            return destination;
        }

        public static string Join(this List<string> source, string separator)
        {
            return string.Join(separator, source.ToArray());
        }

        public static string ToString<T>(this List<T> source)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[ ");
            sb.Append(source.ConvertAll(item => item.ToString()).Join(", "));
            sb.Append(" ]");
            return sb.ToString();
        }
    }
}
