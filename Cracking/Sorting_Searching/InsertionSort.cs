using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Sorting_Searching
{
    /*
     *This is the idea behind insertion sort. Loop over positions in the array, starting with index 1. 
     * Each new position is like the new card handed to you by the dealer, 
     * and you need to insert it into the correct place in the sorted subarray to the left of that position. 
     */
    class InsertionSort
    {
        public void Test()
        {
            int[] arr = { 5, 2, 1, 4, 3, 6 };
            int[] arr2 = { 5, 2, 1, 4, 3, 6 };
            InsertionSortArr(arr);
            Console.WriteLine(string.Join(",", arr));
            InsertionSortArr_Recursive(arr2, arr.Length);
            Console.WriteLine(string.Join(",", arr2));
        }

        /// <summary>
        /// Time Complexity: O(n*n)
        /// Auxiliary Space: O(1)
        /// Boundary Cases: Insertion sort takes maximum time to sort if elements are sorted in reverse order.
        /// And it takes minimum time (Order of n) when elements are already sorted.
        /// </summary>
        /// <param name="arr"></param>
        private void InsertionSortArr(int[] arr)
        {
            int n = arr.Length;
            for(int i = 0; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;
                /* Move elements of arr[0..i-1], that are
               greater than key, to one position ahead
               of their current position */
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        private void InsertionSortArr_Recursive(int[] arr, int n)
        {
            if (n <= 1) return;
            // Sort first n-1 elements
            InsertionSortArr_Recursive(arr, n - 1);
            // Insert last element at its correct position
            // in sorted array.
            int j = n - 2;
            int key = arr[n - 1];
            /* Move elements of arr[0..i-1], that are
          greater than key, to one position ahead
          of their current position */
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
        }
    }
}
