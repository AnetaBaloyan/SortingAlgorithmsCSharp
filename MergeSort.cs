using System;
namespace SortingAlgorithms
{
    /// <summary>
    /// Merge sort.
    /// </summary>
    public class MergeSort
    {
        /// <summary>
        /// Merge the specified arrays.
        /// </summary>
        /// <returns>The merge.</returns>
        /// <param name="a">The array.</param>
        /// <param name="l">Left.</param>
        /// <param name="m">Middle.</param>
        /// <param name="r">Right.</param>
        private static void merge(int[] a, int l, int m, int r)
        {
            // Find sizes of two subarrays to be merged
            int n1 = m - l + 1;
            int n2 = r - m;

            /* Create temp arrays */
            int[] L = new int[n1];
            int[] R = new int[n2];

            /*Copy data to temp arrays*/
            for (int f = 0; f < n1; f++)
                L[f] = a[l + f];
            for (int g = 0; g < n2; g++)
                R[g] = a[m + 1 + g];


            /* Merge the temp arrays */

            // Initial indexes of first and second subarrays
            int i = 0, j = 0;

            // Initial index of merged subarry array
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    a[k] = L[i];
                    i++;
                }
                else
                {
                    a[k] = R[j];
                    j++;
                }
                k++;
            }

            /* Copy remaining elements of L[] if any */
            while (i < n1)
            {
                a[k] = L[i];
                i++;
                k++;
            }

            /* Copy remaining elements of R[] if any */
            while (j < n2)
            {
                a[k] = R[j];
                j++;
                k++;
            }
        }

        /// <summary>
        /// Sort the specified array.
        /// </summary>
        /// <returns>The sort.</returns>
        /// <param name="a">The array.</param>
        public static void sort(int[] a)
        {
            MergeSort.sortik(a, 0, a.Length - 1);;
        }

        public static void sortik(int[] a, int l, int r)
        {
            if (l < r)
            {
                // Find the middle point
                int m = (l + r) / 2;

                // Sort first and second halves
                sortik(a, l, m);
                sortik(a, m + 1, r);

                // Merge the sorted halves
                merge(a, l, m, r);
            }
        }
    }
}
