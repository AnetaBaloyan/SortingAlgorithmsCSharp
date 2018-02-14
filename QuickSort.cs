using System;
namespace SortingAlgorithms
{
    /// <summary>
    /// Quick sort.
    /// </summary>
    public class QuickSort
    {
        private static int partition(int[] a, int low, int high)
        {
            int pivot = a[high];
            int i = (low - 1); // index of smaller element
            for (int j = low; j < high; j++)
            {
                // If current element is smaller than or equal to pivot
                if (a[j] <= pivot)
                {
                    i++;

                    // swap a[i] and a[j]
                    int temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                }
            }

            // swap a[i+1] and a[high]
            int swap = a[i + 1];
            a[i + 1] = a[high];
            a[high] = swap;

            return i + 1;
        }

        /// <summary>
        /// Sort the specified array.
        /// </summary>
        /// <returns>The sort.</returns>
        /// <param name="a">The array.</param>
        public static void sort(int[] a)
        {
            QuickSort.sortik(a, 0, a.Length - 1);
        }


        public static void sortik(int[] a, int low, int high)
        {
            if (low < high)
            {
                /* pid is partitioning index, a[pid] is 
                  now at right place */
                int pid = partition(a, low, high);

                // Recursively sort elements before
                // partition and after partition
                sortik(a, low, pid - 1);
                sortik(a, pid + 1, high);
            }
        }
    }
}
