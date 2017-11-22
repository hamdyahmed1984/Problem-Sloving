using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Sorting_Searching
{
    /*
     * Bubble Sort | Runtime: O( n^2 ) average and worst case. Memory: O(1) .
     * In bubble sort, we start at the beginning of the array and swap the first two elements if the first is greater than the second.
     * Then, we go to the next pair, and so on, continuously making sweeps of the array until it is sorted.
     * In doing so, the smaller items slowly"bubble" up to the beginning of the list.
     */
    class BubbleSort
    {
        public void Test()
        {
            int[] arr = { 5, 2, 1, 4, 3, 6 };
            int[] arr2 = { 5, 2, 1, 4, 3, 6 };
            BubbleSortArr(arr);
            Console.WriteLine(string.Join(",", arr));
            BubbleSortArr_Optimal(arr2);
            Console.WriteLine(string.Join(",", arr2));
        }

        private void BubbleSortArr(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(arr, j, j + 1);
                    }
                }
            }
        }

        private void BubbleSortArr_Optimal(int[] arr)
        {
            int n = arr.Length;
            bool swapped = false;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(arr, j, j + 1);
                        swapped = true;
                    }
                }
                if (!swapped)//If no swaps inner loop, so the array in this stage is sorted and no need to iterate moew.
                    break;
            }
        }

        private void Swap(int[] arr, int i, int j)
        {
            int tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
    }
}
