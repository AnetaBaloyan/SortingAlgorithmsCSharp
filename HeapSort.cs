using System;
namespace SortingAlgorithms
{
    /// <summary>
    /// Heap sort.
    /// </summary>
    public class HeapSort
    {
        /// <summary>
        /// Sort the specified array.
        /// </summary>
        /// <returns>The sort.</returns>
        /// <param name="a">The array.</param>
        public static void sort(int[] a)
        {
            int n = a.Length;

            // Build Max Heap
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(a, n, i);
            
            for (int i = n - 1; i >= 0; i--)
            {
                // Move current root to end
                int temp = a[0];
                a[0] = a[i];
                a[i] = temp;

                heapify(a, i, 0);
            }
        }

        /// <summary>
        /// Heapify the specified array.
        /// </summary>
        /// <returns>The heapification.</returns>
        /// <param name="a">The array.</param>
        /// <param name="n">The length.</param>
        /// <param name="i">The index.</param>
        private static void heapify(int[] a, int n, int i)
        {
            int max = i;  // Initialize largest as root
            int l = 2 * i + 1;  // left = 2*i + 1
            int r = 2 * i + 2;  // right = 2*i + 2

            // If left child is larger than root
            if (l < n && a[l] > a[max])
                max = l;

            // If right child is larger than largest so far
            if (r < n && a[r] > a[max])
                max = r;

            // If largest is not root
            if (max != i)
            {
                int swap = a[i];
                a[i] = a[max];
                a[max] = swap;

                // Recursively heapify the affected sub-tree
                heapify(a, n, max);
            }
        }
    }
}
