using System;
using System.Collections.Generic;

namespace Census.Api.Extensions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T> DepthFirst<T>(this IEnumerable<T> items, Func<T, IEnumerable<T>> children)
        {
            foreach (var item in items)
            {
                yield return item;
                foreach (var descendant in children(item).DepthFirst(children)) yield return descendant;
            }
        }

        public static IEnumerable<T> Do<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
                yield return item;
            }
        }

        public static void Done<T>(this IEnumerable<T> items)
        {
            using (var enumerator = items.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                }
            }
        }
    }
}