using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.DynamicProgramming
{
    class LongestIncreasingSubsequence
    {
        public void Test()
        {
            int[] arr = { 10, 22, 9, 33, 21, 50, 41, 60 };
            int lengthOfLIS = LIS(arr);
            Console.WriteLine("Length of LIS: " + lengthOfLIS);

            lengthOfLIS = longestIncreasingSubSequence(arr);
            Console.WriteLine("Length of LIS: " + lengthOfLIS);
        }

        private int LIS(int[] arr)
        {
            int[] LIS = new int[arr.Length];

            for (int i = 0; i < LIS.Length; i++)
                LIS[i] = 1;

            for(int i = 1; i < arr.Length; i++)
            {
                for(int j =0; j < i; j++)
                {
                    if(arr[j] < arr[i])
                    {
                        LIS[i] = Math.Max(LIS[i], LIS[j] + 1);
                    }
                }
            }

            int lengthOfLIS = LIS[0];
            for(int i = 0; i < LIS.Length; i++)
            {
                if (LIS[i] > lengthOfLIS)
                    lengthOfLIS = LIS[i];
            }
            return lengthOfLIS;
        }

        /**
         * Returns index in T for ceiling of s
         */
        private int ceilIndex(int[] input, int[] T, int end, int s)
        {
            int start = 0;
            int middle;
            int len = end;
            while (start <= end)
            {
                middle = (start + end) / 2;
                if (middle < len && input[T[middle]] < s && s <= input[T[middle + 1]])
                {
                    return middle + 1;
                }
                else if (input[T[middle]] < s)
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }
            }
            return -1;
        }

        public int longestIncreasingSubSequence(int[] input)
        {
            int[] T = new int[input.Length];
            int[] R = new int[input.Length];
            for (int i = 0; i < R.Length; i++)
            {
                R[i] = -1;
            }
            T[0] = 0;
            int len = 0;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[T[0]] > input[i])
                { //if input[i] is less than 0th value of T then replace it there.
                    T[0] = i;
                }
                else if (input[T[len]] < input[i])
                { //if input[i] is greater than last value of T then append it in T
                    len++;
                    T[len] = i;
                    R[T[len]] = T[len - 1];
                }
                else
                { //do a binary search to find ceiling of input[i] and put it there.
                    int ceilingIndex = ceilIndex(input, T, len, input[i]);
                    T[ceilingIndex] = i;
                    R[T[ceilingIndex]] = T[ceilingIndex - 1];
                }
            }

            //this prints increasing subsequence in reverse order.
            Console.WriteLine("Longest increasing subsequence ");
            int index = T[len];
            while (index != -1)
            {
                Console.Write(input[index] + " ");
                index = R[index];
            }

            Console.WriteLine();
            return len + 1;
        }

        // Binary search (note boundaries in the caller)
        // A[] is ceilIndex in the caller
        static int CeilIndex(int[] A, int l, int r, int key)
        {
            while (r - l > 1)
            {
                int m = l + (r - l) / 2;
                if (A[m] >= key)
                    r = m;
                else
                    l = m;
            }

            return r;
        }

        static int LongestIncreasingSubsequenceLength(int[] A, int size)
        {
            // Add boundary case, when array size is one

            int[] tailTable = new int[size];
            int len; // always points empty slot

            tailTable[0] = A[0];
            len = 1;
            for (int i = 1; i < size; i++)
            {
                if (A[i] < tailTable[0])
                    // new smallest value
                    tailTable[0] = A[i];

                else if (A[i] > tailTable[len - 1])
                    // A[i] wants to extend largest subsequence
                    tailTable[len++] = A[i];

                else
                    // A[i] wants to be current end candidate of an existing
                    // subsequence. It will replace ceil value in tailTable
                    tailTable[CeilIndex(tailTable, -1, len - 1, A[i])] = A[i];
            }

            return len;
        }
    }
}
