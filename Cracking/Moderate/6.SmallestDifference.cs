using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Moderate
{
    /// <summary>
    /// 16.6 Smallest Difference: Given two arrays of integers, compute the pair of values (one value in each
    /// array) with the smallest(non-negative) difference.Return the difference.
    /// EXAMPLE
    /// Input: {l, 3, 15, 11, 2}, {23, 127, 235, 19, 8}
    /// Output: 3. That is, the pair(11, 8).
    /// </summary>
    class SmallestDifference
    {
        public void Test()
        {
            int[] arr1 = { 1, 3, 15, 11, 2 };
            int[] arr2 = { 23, 127, 235, 19, 8 };

            int minDiff = MinDiff_BF(arr1, arr2);
            minDiff = MinDiff_Optimal(arr1, arr2);
        }
        /// <summary>
        /// O(A * B)
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        int MinDiff_BF(int[] arr1, int[] arr2)
        {
            if (arr1.Length == 0 || arr2.Length == 0)
                return -1;
            int minDiff = int.MaxValue;
            for(int i = 0; i < arr1.Length;i++)
            {
                for(int j =0;j <arr2.Length;j++)
                {
                    if (Math.Abs(arr1[i] - arr2[j]) < minDiff)
                        minDiff = Math.Abs(arr1[i] - arr2[j]);
                }
            }
            return minDiff;
        }

        /// <summary>
        /// O(A log A + B log B)
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        int MinDiff_Optimal(int[] arr1, int[] arr2)
        {
            if (arr1.Length == 0 || arr2.Length == 0)
                return -1;
            Array.Sort(arr1);
            Array.Sort(arr2);
            int minDiff = int.MaxValue;
            int i = 0, j = 0;
            while(i < arr1.Length && j < arr2.Length)
            {
                minDiff = Math.Min(minDiff, Math.Abs(arr1[i] - arr2[j]));
                /* Move smaller value. */
                if (arr1[i] < arr2[j])
                    i++;
                else
                    j++;
            }
            return minDiff;
        }
    }
}
