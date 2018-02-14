using System;
namespace SortingAlgorithms
{
    /// <summary>
    /// Insert sort.
    /// </summary>
    public class InsertSort
    {
        /// <summary>
        /// Sort the specified array.
        /// </summary>
        /// <returns>The sort.</returns>
        /// <param name="a">The array.</param>
        public static void sort(int[] a)
        {
            int length = a.Length;
            for (int i = 1; i < length; ++i)
            {
                int key = a[i];
                int j = i - 1;

                /* Move elements of arr[0..i-1], that are
                   greater than key, to one position ahead
                   of their current position */
                while (j >= 0 && a[j] > key)
                {
                    a[j + 1] = a[j];
                    j = j - 1;
                }
                a[j + 1] = key;
            }
        }
    }
}
