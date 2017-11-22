using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Moderate
{
    /// <summary>
    /// 16.17 Contiguous Sequence: You are given an array of integers (both positive and negative). Find the
    /// contiguous sequence with the largest sum.Return the sum.
    /// EXAMPLE
    /// Input: 2, -8, 3, -2, 4, -10
    /// Output: 5 (i.e. , { 3, -2, 4} )
    /// </summary>
    class ContiguousSequenceMaxSum
    {
        public void Test()
        {
            int[] arr = { 2, -8, 3, -2, 4, -10 };            
            int maxContiguousSum = GetMaxContiguousSum(arr);

            arr = new int[3] { -5, -3, -10 };
            maxContiguousSum = GetMaxContiguousSum(arr);

            arr = new int[8] { -2, -3, 4, -1, -2, 1, 5, -2 };
            maxContiguousSum = GetMaxContiguousSum(arr);
        }

        private int GetMaxContiguousSum(int[] arr)
        {
            //If we set maxSum to 0, for array of all negative values the return value will be 0
            // IF we set it to int.MinValue or arr[0], it will handle this case

            int maxSum = int.MinValue;
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                if (maxSum < sum)
                {
                    maxSum = sum;
                }
                if (sum < 0)//If sum turns to be negative, we reset sum 
                {
                    sum = 0;
                }
            }
            return maxSum;
        }
    }
}
