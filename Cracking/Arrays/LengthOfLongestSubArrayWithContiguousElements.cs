using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Arrays
{
    class LengthOfLongestSubArrayWithContiguousElements
    {
        public static void Test()
        {
            int[] arr = { 1, 2, 5, 6, 7, 1, 8, 4 };
            findLength(arr);
        }
        /// <summary>
        ///  If all elements are distinct, then a subarray has contiguous elements
        ///  if and only if the difference between maximum and minimum elements in subarray
        ///  is equal to the difference between last and first indexes of subarray. 
        ///  So the idea is to keep track of minimum and maximum element in every subarray.
        ///  and if we found duplicate elements we skip this subarray
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int findLength(int[] arr)
        {
            int n = arr.Length;
            int max_len = 1; // Inialize result

            // One by one fix the starting points
            for (int i = 0; i < n - 1; i++)
            {
                // Create an empty hash set and add i'th element
                // to it.
                HashSet<int> set = new HashSet<int>();
                set.Add(arr[i]);

                // Initialize max and min in current subarray
                int mn = arr[i], mx = arr[i];

                // One by one fix ending points
                for (int j = i + 1; j < n; j++)
                {
                    // If current element is already in hash set, then
                    // this subarray cannot contain contiguous elements
                    if (set.Contains(arr[j]))
                        break;

                    // Else add curremt element to hash set and update
                    // min, max if required.
                    set.Add(arr[j]);
                    mn = Math.Min(mn, arr[j]);
                    mx = Math.Max(mx, arr[j]);

                    // We have already cheched for duplicates, now check
                    // for other property and update max_len if needed
                    if (mx - mn == j - i)
                        max_len = Math.Max(max_len, mx - mn + 1);
                }
            }
            return max_len; // Return result
        }
    }
}
