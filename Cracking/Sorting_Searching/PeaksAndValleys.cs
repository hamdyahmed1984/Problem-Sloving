using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Sorting_Searching
{
    /// <summary>
    /// 10.11 Peaks and Valleys: In an array of integers, a "peak" is an element which is greater than or equal to the adjacent integers 
    /// and a "valley" is an element which is less than or equal to the adjacent integers.
    /// For example, in the array { 5, 8, 6, 2, 3, 4, 6}, {8, 6} are peaks and {5, 2} are valleys.
    /// Given an array of integers, sort the array into an alternating sequence of peaks and valleys.
    /// EXAMPLE
    /// Input: { 5, 3, 1, 2, 3}
    /// Output: {5, 1, 3, 2, 3}
    /// </summary>
    class PeaksAndValleys
    {
        public void Test()
        {
            int[] arr = { 1, 0, 4, 7, 8, 9 };
            int[] arr1 = { 1, 0, 4, 7, 8, 9 };

            SortValleyPeak1(arr);
            SortValleyPeak2(arr1);
        }

        /// <summary>
        /// O(nlogn)
        /// </summary>
        /// <param name="arr"></param>
        private void SortValleyPeak1(int[] arr)
        {
            Array.Sort(arr);
            for (int i = 1; i < arr.Length; i = i + 2)
            {
                Swap(arr, i, i - 1);
            }
        }

        private void Swap(int[] arr, int left, int right)
        {
            int tmp = arr[left];
            arr[left] = arr[right];
            arr[right] = tmp;
        }

        /// <summary>
        /// O(n)
        /// </summary>
        /// <param name="arr"></param>
        private void SortValleyPeak2(int[] arr)
        {
            for (int i = 1; i < arr.Length; i = i + 2)
            {
                int biggestIndex = GetMaxIndex(arr, i - 1, i, i + 1);
                if (biggestIndex != i)
                    Swap(arr, i, biggestIndex);
            }
        }

        private int GetMaxIndex(int[] arr, int a, int b, int c)
        {
            int n = arr.Length;
            int aVal = a >= 0 && a < n ? arr[a] : int.MinValue;
            int bVal = b >= 0 && a < n ? arr[b] : int.MinValue;
            int cVal = c >= 0 && c < n ? arr[c] : int.MinValue;

            int maxVal = Math.Max(aVal, Math.Max(bVal, cVal));

            if (maxVal == aVal) return a;
            else if (maxVal == bVal) return b;
            else return c;
        }
    }
}
