using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLib
{
    public static class DictionaryExtensions
    {
        public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key) where TValue : new()
        {
            if (dictionary.ContainsKey(key) == false)
            {
                dictionary.Add(key, new TValue());
            }
            return dictionary[key];
        }

        public static string ToString<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            var sb = new StringBuilder();
            sb.AppendLine("{");

            foreach (TKey key in dictionary.Keys)
            {
                sb.Append("\t");
                sb.Append(key.ToString());
                sb.Append(": ");
                sb.Append(dictionary[key].ToString());
                sb.AppendLine(",");
            }

            if (dictionary.Keys.Count > 0)
            {
                // Remove the last comma.
                sb.Remove(sb.Length - Environment.NewLine.Length - 1, 1);
            }

            sb.AppendLine("}");
            return sb.ToString();
        }

    }
}
