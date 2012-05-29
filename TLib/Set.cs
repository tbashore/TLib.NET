using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLib
{
    /// <summary>
    /// A generic set class.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be stored in the set.</typeparam>
    public class Set<T> : IEnumerable<T>
    {
        private Dictionary<T, bool> m_dict;

        public Set()
        {
            m_dict = new Dictionary<T, bool>();
        }

        public bool Add(T item)
        {
            if (m_dict.ContainsKey(item)) { return false; }
            m_dict.Add(item, true);
            return true;
        }

        public bool Contains(T item)
        {
            return m_dict.ContainsKey(item);
        }

        public int Count
        {
            get { return m_dict.Count; }
        }

        public List<T> ToList()
        {
            List<T> list = new List<T>();
            foreach (T key in m_dict.Keys)
            {
                list.Add(key);
            }
            return list;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("{");

            foreach (T key in m_dict.Keys)
            {
                sb.Append("\t");
                sb.Append(key.ToString());
                sb.AppendLine(",");
            }
            
            if (m_dict.Keys.Count > 0)
            {
                // Remove the last comma.
                sb.Remove(sb.Length - Environment.NewLine.Length - 1, 1);
            }

            sb.AppendLine("}");
            return sb.ToString();
        }

        public Set<T> Union(Set<T> s2)
        {
            Set<T> s3 = new Set<T>();
            foreach (T key in this.m_dict.Keys)
            {
                s3.Add(key);
            }
            foreach (T key in s2.m_dict.Keys)
            {
                s3.Add(key);
            }
            return s3;
        }

        public Set<T> Intersection(Set<T> s2)
        {
            Set<T> s3 = new Set<T>();
            foreach (T key in s2.m_dict.Keys)
            {
                if (this.m_dict.ContainsKey(key))
                {
                    s3.Add(key);
                }
            }
            return s3;
        }

        public Set<T> Difference(Set<T> s2)
        {
            Set<T> s3 = new Set<T>();
            foreach (T key in this.m_dict.Keys)
            {
                if (!s2.m_dict.ContainsKey(key))
                {
                    s3.Add(key);
                }
            }
            foreach (T key in s2.m_dict.Keys)
            {
                if (!this.m_dict.ContainsKey(key))
                {
                    s3.Add(key);
                }
            }
            return s3;
        }

        public Set<T> Complement(Set<T> s2)
        {
            Set<T> s3 = new Set<T>();
            foreach (T key in this.m_dict.Keys)
            {
                if (!s2.m_dict.ContainsKey(key))
                {
                    s3.Add(key);
                }
            }
            return s3;
        }

        public Set<TResult> CartesianProduct<TResult>(Set<T> s2, Func<T, T, TResult> assoc)
        {
            Set<TResult> s3 = new Set<TResult>();
            foreach (T key1 in this.m_dict.Keys)
            {
                foreach (T key2 in s2.m_dict.Keys)
                {
                    s3.Add(assoc.Invoke(key1, key2));
                }
            }
            return s3;
        }

        #region IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            return m_dict.Keys.GetEnumerator();
        }
        #endregion

        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return m_dict.Keys.GetEnumerator();
        }
        #endregion
    }
}
