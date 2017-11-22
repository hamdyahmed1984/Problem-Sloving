using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Sorting_Searching
{
    class MergeSort
    {
        public void Test()
        {
            int[] arr = { 12, 11, 13, 5, 6, 7 };
            Console.WriteLine(string.Join(",", arr));
            MergeSortArr(arr, 0, arr.Length - 1);
            Console.WriteLine(string.Join(",", arr));
        }

        /// <summary>
        /// Merge Sort | Runtime: O(n log (n)) average and worst case. Memory: Depends.
        /// space complexity of merge sort is O(n) due to the auxiliary space used to merge parts of the array.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        private void MergeSortArr(int[] arr, int l, int r)
        {
            if(l < r)
            {
                int m = (l + r) / 2;
                MergeSortArr(arr, l, m);
                MergeSortArr(arr, m + 1, r);
                Merge(arr, l, m, r);
            }
        }

        /// <summary>
        ///Merges two subarrays of arr[].
        ///First subarray is arr[l..m]
        ///Second subarray is arr[m+1..r]
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="l"></param>
        /// <param name="m"></param>
        /// <param name="r"></param>
        private void Merge(int[] arr, int l, int m, int r)
        {
            // Find sizes of two subarrays to be merged
            int n1 = m - l + 1;
            int n2 = r - m;
            /* Create temp arrays */
            int[] L = new int[n1];
            int[] R = new int[n2];
            /*Copy data to temp arrays*/
            for (int index = 0; index < n1; index++)
            {
                L[index] = arr[l + index];
            }
            for (int index = 0; index < n2; index++)
            {
                R[index] = arr[m + 1 + index];
            }
            /* Merge the temp arrays */

            // Initial indexes of first and second subarrays
            int i = 0, j = 0;
            // Initial index of merged subarry array
            int current = l;
            while(i < n1 && j < n2)
            {
                if(L[i] <= R[j])
                {
                    arr[current] = L[i];
                    i++;
                }
                else
                {
                    arr[current] = R[j];
                    j++;
                }
                current++;
            }
            /* Copy remaining elements of L[] if any */
            while (i < n1)
            {
                arr[current] = L[i];
                current++;
                i++;
            }
            /* Copy remaining elements of R[] if any */
            while (j < n2)
            {
                arr[current] = R[j];
                current++;
                j++;
            }
        }
    }
}
