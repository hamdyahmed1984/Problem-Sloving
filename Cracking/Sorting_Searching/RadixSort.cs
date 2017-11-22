using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Sorting_Searching
{
    class RadixSort
    {
        public void Test()
        {
            int[] arr = { 170, 45, 75, 90, 802, 24, 2, 66 };

            RadixSortArr(arr);
            Console.WriteLine(string.Join(",", arr));
        }

        private void RadixSortArr(int[] arr)
        {
            int digitWeight = 1;
            int maxValue = GetMax(arr);
            while(maxValue > 0)
            {
                CountingSortArr(arr, digitWeight);
                digitWeight = digitWeight * 10;
                maxValue = maxValue / 10;
            }
        }

        /// <summary>
        /// Runtime: O(n+k) where n is the number of elements in input array and k is the range of input.
        /// Space: O(n+k)
        /// </summary>
        /// <param name="arr"></param>
        private void CountingSortArr(int[] arr, int digitWeight)
        {
            // Create a count array to store count of inidividul
            // elements and initialize count array as 0
            int[] countArr = new int[10];
            // The output array that will have sorted arr
            int[] sortedArr = new int[arr.Length];

            //This step is not nessary as the default value int int is 0
            for (int i = 0; i < countArr.Length; i++)
                countArr[i] = 0;
            // store count of each character
            for (int i = 0; i < arr.Length; i++)
                countArr[(arr[i] / digitWeight) % 10]++;
            // Change count[i] so that count[i] now contains actual
            // position of this element in output array
            for (int i = 1; i < countArr.Length; i++)
                countArr[i] += countArr[i - 1];
            // Build the output array
            for (int i = arr.Length - 1 ; i >= 0; i--)
            {
                sortedArr[countArr[(arr[i] / digitWeight) % 10] - 1] = arr[i];
                countArr[(arr[i] / digitWeight) % 10]--;
            }
            // Copy the output array to arr, so that arr now
            // contains sorted elements
            for (int i = 0; i < sortedArr.Length; i++)
                arr[i] = sortedArr[i];
        }

        private int GetMax(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                max = Math.Max(max, arr[i]);
            }
            return max;
        }
    }
}
