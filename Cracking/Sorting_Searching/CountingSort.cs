using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Sorting_Searching
{
    class CountingSort
    {
        public void Test()
        {
            int[] arr = { 5, 1, 2, 1, 3, 4, 2 };

            int[] arr2 = new int[arr.Length];
            arr.CopyTo(arr2, 0);

            CountingSortArr(arr);
            Console.WriteLine(string.Join(",", arr));

            CountingSortArr2(arr2);
            Console.WriteLine(string.Join(",", arr2));
        }

        private void CountingSortArr(int[] arr)
        {

            int maxValue = GetMax(arr);
            int[] countArr = new int[maxValue + 1];
            int[] sortedArr = new int[arr.Length];

            //This step is not nessary as the default value int int is 0
            for (int i = 0; i < countArr.Length; i++)
                countArr[i] = 0;

            for (int i = 0; i < arr.Length; i++)
                countArr[arr[i]]++;

            int sortedIndex = 0;
            for(int i = 0; i < countArr.Length; i++)
            {
                int currentCount = countArr[i];
                while(currentCount > 0)
                {
                    sortedArr[sortedIndex] = i;
                    sortedIndex++;
                    currentCount--;
                }
            }

            for (int i = 0; i < sortedArr.Length; i++)
                arr[i] = sortedArr[i];
        }

        /// <summary>
        /// Runtime: O(n+k) where n is the number of elements in input array and k is the range of input.
        /// Space: O(n+k)
        /// </summary>
        /// <param name="arr"></param>
        private void CountingSortArr2(int[] arr)
        {

            int maxValue = GetMax(arr);
            // Create a count array to store count of inidividul
            // elements and initialize count array as 0
            int[] countArr = new int[maxValue + 1];
            // The output array that will have sorted arr
            int[] sortedArr = new int[arr.Length];

            //This step is not nessary as the default value int int is 0
            for (int i = 0; i < countArr.Length; i++)
                countArr[i] = 0;
            // store count of each character
            for (int i = 0; i < arr.Length; i++)
                countArr[arr[i]]++;
            // Change count[i] so that count[i] now contains actual
            // position of this element in output array
            for (int i = 1; i < countArr.Length; i++)
                countArr[i] += countArr[i - 1];
            // Build the output array
            for (int i = 0; i < arr.Length; i++)
            {
                sortedArr[countArr[arr[i]] - 1] = arr[i];
                countArr[arr[i]]--;
            }
            // Copy the output array to arr, so that arr now
            // contains sorted elements
            for (int i = 0; i < sortedArr.Length; i++)
                arr[i] = sortedArr[i];
        }

        private int GetMax(int[] arr)
        {
            int max = arr[0];
            for(int i = 1; i < arr.Length; i++)
            {
                max = Math.Max(max, arr[i]);
            }
            return max;
        }
    }
}
