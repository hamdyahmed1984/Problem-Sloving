using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Hard
{/// <summary>
/// 17.4 Missing Number: An array A contains all the integers from O to n, except for one number which
/// is missing.In this problem, we cannot access an entire integer in A with a single operation.The
/// elements of A are represented in binary, and the only operation we can use to access them is "fetch
/// the jth bit of A[i];' which takes constant time. Write code to find the missing integer. 
/// Can you do it in O(n) time?
/// 
/// SOLUTION IDEA:
/// if n % 2 == 1 then count(0s) = count(ls)
/// if n % 2 == 0 then count(0s) = 1 + count(ls)
/// 
/// So,if c ount(0s) <= c ount(ls),thenvis even.lf c ount(0s) > c ount(ls),thenvis odd.
/// </summary>
    public class MissingNumber
    {
        /// <summary>
        /// This is for 0 to n and we cann't access the entire int but individual bits
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int FindMissingNumber(List<BitArray> arr)
        {
            return FindMissingNumber(arr, 0);
        }

        public int FindMissingNumber(List<BitArray> arr, int column)
        {
            if (column >= 32) return 0;//We're done!

            List<BitArray> zeroBits = new List<BitArray>();
            List<BitArray> oneBits = new List<BitArray>();

            foreach(BitArray x in arr)
            {
                if (x.Get(column) == false)
                    zeroBits.Add(x);
                else
                    oneBits.Add(x);
            }
            if(zeroBits.Count <= oneBits.Count)
            {
                int v = FindMissingNumber(zeroBits, column + 1);
                return (v << 1) | 0;
            }
            else
            {
                int v = FindMissingNumber(oneBits, column + 1);
                return (v << 1) | 1;
            }            
        }
        /// <summary>
        /// Finding missing number in range from 1 to n, be careful NOT from 0 to n
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int FindMissingNumber_XOR(int[] arr)
        {
            int n = arr.Length + 1;//because there is a missing number.
            int XOR_All = 1;
            for (int i = 2; i <= n; i++)
                XOR_All = XOR_All ^ i;

            int XOR_Arr = arr[0];
            for (int i = 1; i < arr.Length; i++)
                XOR_Arr = XOR_Arr ^ arr[i];

            return XOR_All ^ XOR_Arr;
        }

        /// <summary>
        /// Finding missing number in range from 1 to n, be careful NOT from 0 to n
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int FindMissingNumber_UsingSum(int[] arr)
        {
            int n = arr.Length + 1;//because there is a missing number.
            int sum = n * (n + 1) / 2;
            int currentSum = 0;
            for (int i = 0; i < arr.Length; i++)
                currentSum += arr[i];

            return sum - currentSum;
        }
    }
}
