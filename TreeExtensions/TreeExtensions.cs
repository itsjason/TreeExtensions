namespace TreeExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class TreeExtensions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> items, Func<T, bool> func) where T : class, ITree<T>
        {
            var results = new List<T>();
            foreach (var item in items.Where(i => i != null))
            {
                item.Children = item.Children.Filter(func).ToArray();
                if (item.Children.Any() || func(item))
                    results.Add(item);
            }
            return results;
        }

        public static IEnumerable<T> Filter<T>(this T item, Func<T, bool> func) where T : class, ITree<T>
        {
            return (new[] {item}).Filter(func);
        }

        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> items) where T : ITree<T>
        {
            var result = new List<T>();
            foreach (var item in items)
            {
                result.Add(item);
                result.AddRange(item.Children.Flatten());
            }
            return result;
        }

        public static void Apply<T>(this IEnumerable<T> items, Action<T> action) where T : ITree<T>
        {
            foreach (var item in items)
            {
                action(item);
                item.Children.Apply(action);
            }
        }
    }
}
