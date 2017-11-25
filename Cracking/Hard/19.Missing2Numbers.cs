using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Hard
{
    /// <summary>
    /// 17.19 Missing Two: You are given an array with all the numbers from 1 to N appearing exactly once, except for one number that is missing.
    /// How can you find the missing number in O(N) time and O(1) space? 
    /// What if there were two numbers missing?
    /// </summary>
    public class Missing2Numbers
    {
        public int FindMissingNumber_UsingSum(int[] arr)
        {
            int n = arr.Length + 1;//We have 1 missing number so the full length for the array should be length+1
            int fullSum = n * (n + 1) / 2;

            int actualSum = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                actualSum += arr[i];
            }

            int missingNumber = fullSum - actualSum;
            return missingNumber;
        }

        public int FindMissingNumber_UsingProduct(int[] arr)
        {
            int n = arr.Length + 1;//We have 1 missing number so the full length for the array should be length+1

            BigInteger fullProduct = 1;
            for(int i = 1; i <= n; i++)
            {
                fullProduct *= i;
            }

            BigInteger actualProduct = 1;
            for(int i = 0; i < arr.Length; i++)
            {
                actualProduct *= arr[i];
            }

            int missingNumber = (int)(fullProduct / actualProduct);
            return missingNumber;
        }
        public int FindMissingNumber_UsingSquareSum(int[] arr)
        {
            int n = arr.Length + 1;//We have 1 missing number so the full length for the array should be length+1
            int fullSum = 0;
            for (int i = 1; i <= n; i++)
            {
                fullSum += i * i;
            }

            int actualSum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                actualSum += arr[i] * arr[i];
            }

            int missingNumber = (int)Math.Sqrt(fullSum - actualSum);
            return missingNumber;
        }

        public int FindMissingNumber_UsingXOR(int[] arr)
        {
            int n = arr.Length + 1;//We have 1 missing number so the full length for the array should be length+1

            int XOR_Full = 1;
            for(int i = 2; i <= n; i++)
            {
                XOR_Full ^= i;
            }

            int XOR_Actual = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                XOR_Actual ^= arr[i];
            }

            int missingNumber = XOR_Full ^ XOR_Actual;
            return missingNumber;
        }

        public int[] FindMissing2Numbers(int[] arr)
        {
            int n = arr.Length + 2;//We have 1 missing number so the full length for the array should be length+2
            int sum = n * (n + 1) / 2;
            int sumSquares = 0;
            for (int i = 1; i <= n; i++)
            {
                sumSquares += i * i;
            }

            for(int i = 0; i < arr.Length; i++)
            {
                sum -= arr[i];
                sumSquares -= arr[i] * arr[i];
            }

            int[] missing2Numbers = SolveQuadraticEquation(sum, sumSquares);
            return missing2Numbers;
        }

        private int[] SolveQuadraticEquation(int sum, int sumSquares)
        {
            /*
             * a * X^2 + b * X + c
             * X = [-b +- sqrt(b^2 - 4 * a * c)] / 2 * a;
             * In this case, it has to be a+ not a -
            */ 
            int a = 2;
            int b = -2 * sum;
            int c = sum * sum - sumSquares;

            double part1 = -1 * b;
            double part2 = Math.Sqrt(b * b - 4 * a * c);
            double part3 = 2 * a;

            int firstMissingNumber = (int)((part1 + part2) / part3);
            int secondMissingNumber = sum - firstMissingNumber;

            return new int[] { firstMissingNumber, secondMissingNumber };
        }
    }
}
