﻿using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace Project.Scripts.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ShuffleIE<T>(this IEnumerable<T> source) =>
            source.OrderBy(x => Guid.NewGuid());

        public static List<T> GetRandomElements<T>(this IEnumerable<T> list, int elementsCount) =>
            list.OrderBy(arg => Guid.NewGuid()).Take(elementsCount).ToList();

        public static List<T> GetClone<T>(this List<T> source) =>
            source.GetRange(0, source.Count);

        public static T PickRandom<T>(this IEnumerable<T> collection)
        {
            if (collection == null)
                return default;

            if (collection is IList<T> list)
            {
                return list.Count != 0
                    ? list[Random.Range(0, list.Count)]
                    : default;
            }

            if (collection is HashSet<T> hashset)
            {
                return hashset.Count != 0
                    ? hashset.ElementAt(Random.Range(0, hashset.Count))
                    : default;
            }

            List<T> actual = collection.ToList();

            return actual.Count > 0
                ? actual[Random.Range(0, actual.Count)]
                : default;
        }

        public static float? SumOrNull(this IEnumerable<float> numbers)
        {
            float? sum = null;

            foreach (float f in numbers)
                sum = f + (sum ?? 0);

            return sum;
        }

        public static bool IsEmptyOrNull<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                return true;

            if (enumerable is ICollection<T> collection)
                return collection.Count == 0;

            return !enumerable.Any();
        }

        public static T FindMin<T, TComp>(this IEnumerable<T> enumerable, Func<T, TComp> selector)
            where TComp : IComparable<TComp> =>
            Find(enumerable, selector, true);

        public static T FindMax<T, TComp>(this IEnumerable<T> enumerable, Func<T, TComp> selector)
            where TComp : IComparable<TComp> =>
            Find(enumerable, selector, false);

        private static T Find<T, TComp>(IEnumerable<T> enumerable, Func<T, TComp> selector, bool selectMin)
            where TComp : IComparable<TComp>
        {
            if (enumerable == null)
                return default;

            var first = true;
            T selected = default(T);
            TComp selectedComp = default(TComp);

            foreach (T current in enumerable)
            {
                TComp comp = selector(current);

                if (first)
                {
                    first = false;
                    selected = current;
                    selectedComp = comp;

                    continue;
                }

                int res = selectMin
                    ? comp.CompareTo(selectedComp)
                    : selectedComp.CompareTo(comp);

                if (res < 0)
                {
                    selected = current;
                    selectedComp = comp;
                }
            }

            return selected;
        }
    }
}