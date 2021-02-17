using System;
using System.Collections.Generic;

namespace Algorithms
{
    public static class SortingAlgorithms
    {
        private static void SubSort<T>(IList<T> collection, int lo, int hi, Func<T, T, int> compare)
        {
            if (lo >= hi)
            {
                return;
            }

            int pivot = (lo + hi) / 2;
            Tuple<int, int> range = Partition(collection, lo, hi, collection[pivot], compare);

            SubSort(collection, lo, range.Item1 - 1, compare);
            SubSort(collection, range.Item2 + 1, hi, compare);
        }

        private static Tuple<int, int> Partition<T>(IList<T> collection, int lo, int hi, T pivotValue, Func<T, T, int> compare)
        {
            int lt = lo;
            int gt = hi;
            int i = lo;

            while (i <= gt)
            {
                int result = compare(collection[i], pivotValue);
                if (result < 0)
                {
                    Swap(collection, i, lt);
                    i++;
                    lt++;
                    continue;
                }
                if (result > 0)
                {
                    Swap(collection, i, gt);
                    gt--;
                }
                if (result == 0)
                {
                    i++;
                }
            }
            return new Tuple<int, int>(lt, gt);
        }

        private static void Swap<T>(IList<T> collection, int i, int j)
        {
            var temp = collection[i];
            collection[i] = collection[j];
            collection[j] = temp;
        }

        public static void QuickSort<T>(this IList<T> collection, Func<T, T, int> compare)
        {
            SubSort(collection, 0, collection.Count - 1, compare);
        }

        public static void QuickSort<T>(this IList<T> collection) where T : IComparable<T>
        {
            SubSort(collection, 0, collection.Count - 1, (T a, T b) => a.CompareTo(b));
        }
    }
}
