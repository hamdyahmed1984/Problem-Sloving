using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Moderate
{
    /// <summary>
    /// 16.21 Sum Swap: Given two arrays of integers, find a pair of values (one value from each array) that you can swap to give the two arrays the same sum.
    /// EXAMPLE
    /// lnput:{ 4, 1, 2, 1, 1, 2} and {3, 6, 3, 3}
    /// Output: {1, 3}
    /// 
    /// 
    /// SOLUTION:
    /// When we move a (positive) value a from array A to array B, then the sum of A drops by a and the sum of B increases by a.
    /// We are looking for two values, a and b, such that:
    /// sumA - a + b = sumB - b + a
    /// Doing some quick math:
    /// 2a - 2b = sumA - sumB
    /// a - b = (sumA - sumB) / 2
    /// Therefore, we're looking for two values that have a specific target difference: (sumA - sumB) / 2.
    /// Observe that because that the target must be an integer(after all, you can't swap two integers to get a noninteger
    /// difference), we can conclude that the difference between the sums must be even to have a valid pair.
    /// </summary>
    class SumSwap
    {
        public void Test()
        {
            int[] arr1 = new int[] { 4, 1, 2, 1, 1, 2 };
            int[] arr2 = new int[] { 3, 6, 3, 3 };
            int[] swapValues = FindSwapValues_BF1(arr1, arr2);
            swapValues = FindSwapValues_BF2(arr1, arr2);
            swapValues = FindSwapValues_Optimal1(arr1, arr2);
            swapValues = FindSwapValues_Optimal2(arr1, arr2);
        }

        /// <summary>
        /// O(AB)
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        private int[] FindSwapValues_BF1(int[] arr1, int[] arr2)
        {
            int sum1 = GetSum(arr1);
            int sum2 = GetSum(arr2);

            foreach(int one in arr1)
            {
                foreach(int two in arr2)
                {
                    int newSum1 = sum1 - one + two;
                    int newSum2 = sum2 - two + one;
                    if(newSum1 == newSum2)
                    {
                        return new int[] { one, two };
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// O(AB)
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        private int[] FindSwapValues_BF2(int[] arr1, int[] arr2)
        {
            int? targetDiff = GetTargetDiff(arr1, arr2);

            if (targetDiff == null)
                return null;
            foreach (int one in arr1)
            {
                foreach (int two in arr2)
                {
                    if (one - two == targetDiff)
                        return new int[] { one, two };
                }
            }
            return null;
        }

        /// <summary>
        /// O(A + B)
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        private int[] FindSwapValues_Optimal1(int[] arr1, int[] arr2)
        {
            int? targetDiff = GetTargetDiff(arr1, arr2);
            if (targetDiff == null) return null;
            return FindSwapValues_Optimal1(arr1, arr2, targetDiff);
        }

        private int[] FindSwapValues_Optimal1(int[] arr1, int[] arr2, int? targetDiff)
        {
            HashSet<int> set = new HashSet<int>();
            foreach(int two in arr2)
            {
                set.Add(two);
            }

            foreach(int one in arr1)
            {
                int two = one - targetDiff.Value;
                if (set.Contains(two))
                    return new int[] { one, two };
            }
            return null;
        }
        /// <summary>
        /// O(A log A + B log B)
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        private int[] FindSwapValues_Optimal2(int[] arr1, int[] arr2)
        {
            int? targetDiff = GetTargetDiff(arr1, arr2);
            if (targetDiff == null) return null;
            return FindSwapValues_Optimal2(arr1, arr2, targetDiff);
        }

        private int[] FindSwapValues_Optimal2(int[] arr1, int[] arr2, int? targetDiff)
        {
            Array.Sort(arr1);
            Array.Sort(arr2);
            int a = 0, b = 0;
            while(a < arr2.Length && b < arr2.Length)
            {
                int diff = arr1[a] - arr2[b];
                /* Compare difference to target. If difference is too small, then make it
                 * bigger by moving a to a bigger value. If it is too big, then make it
                 * smaller by moving b to a bigger value. If it's just right, return this pair. */
                if (diff == targetDiff)
                    return new int[] { arr1[a], arr2[b] };
                else if (diff < targetDiff)
                    a++;
                else
                    b++;
            }
            return null;
        }

        private int? GetTargetDiff(int[] arr1, int[] arr2)
        {
            int? targetDiff = null;
            int sum1 = GetSum(arr1);
            int sum2 = GetSum(arr2);

            if ((sum1 - sum2) % 2 == 0)
                targetDiff = (sum1 - sum2) / 2;
            return targetDiff;
        }

        int GetSum(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
                sum += arr[i];
            return sum;
        }
    }
}
