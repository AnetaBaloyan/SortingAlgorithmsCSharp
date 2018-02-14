using System;
namespace SortingAlgorithms
{
    public class BubbleSort
    {
        /// <summary>
        /// Sort the specified array.
        /// </summary>
        /// <returns>The sort.</returns>
        /// <param name="a">The array.</param>
        public static void sort(int[] a)
        {
            int length = a.Length;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - i - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        int swap = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = swap;

                    }
                }
            }
        }
    }
}