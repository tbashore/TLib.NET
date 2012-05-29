using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLib
{
    public static class IEnumerableExtensions
    {
        // From http://www.ookii.org/showpost.aspx?post=8.
        // Only useful if IEnumerable<T>.Aggregate is not available.
        public delegate TAggregate ReduceDelegate<TAggregate, TInput>(TAggregate aggregate, TInput input);
        public static TAggregate Reduce<TAggregate, TInput>(this IEnumerable<TInput> list, TAggregate initial, ReduceDelegate<TAggregate, TInput> function)
        {
            TAggregate aggregate = initial;
            foreach (TInput item in list)
            {
                aggregate = function(aggregate, item);
            }
            return aggregate;
        }

        public delegate TOutput MapDelegate<TOutput, TInput>(TInput input);
        public static IEnumerable<TOutput> Map<TOutput, TInput>(this IEnumerable<TInput> list, MapDelegate<TOutput, TInput> function)
        {
            foreach (TInput item in list)
            {
                yield return function(item);
            }
        }
    }
}
