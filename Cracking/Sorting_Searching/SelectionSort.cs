using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Sorting_Searching
{
    /*
     * Selection Sort | Runtime: O( n^2 ) average and worst case. Memory: O(1).
     * Selection sort is the child's algorithm: simple, but inefficient.
     * Find the smallest element using a linear scan and move it to the front (swapping it with the front element).
     * Then, find the second smallest and move it, again doing a linear scan. Continue doing this until all the elements are in place.
     */
    class SelectionSort
    {
        public void Test()
        {
            int[] arr = { 5, 2, 1, 4, 3, 6 };
            SelectionSortArr(arr);
            Console.WriteLine(string.Join(",", arr));
        }

        private void SelectionSortArr(int[] arr)
        {
            int n = arr.Length;
            for(int i = 0; i < n - 1; i++)
            {
                int minIndex = GetIndexForMinValue(arr, i);
                Swap(arr, i, minIndex);
            }
        }

        private int GetIndexForMinValue(int[] arr, int start)
        {
            int minIndex = start;
            for(int i = start + 1; i < arr.Length; i++)
            {
                if(arr[i] < arr[minIndex])
                {
                    minIndex = i;
                }
            }
            return minIndex;
        }
        private void Swap(int[] arr, int i, int j)
        {
            int tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
    }
}
