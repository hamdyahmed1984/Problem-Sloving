using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Arrays
{
    class SubArraysWithSum
    {
        public static void Test()
        {
            //int[] arr = { 10, 5, 1, 2, -1  -1, 7, 1, 2 };
            //int pathsWithSum = PathsWithGivenSum(arr, 8);

            int[] arr = { 1, 2, 3, -4, 6, 8 };
            int pathsWithSum = PathsWithGivenSum(arr, 5);
        }

        private static int PathsWithGivenSum(int[] arr, int givenSum)
        {
            int runningSum = 0;
            int pathsWithSum = 0;
            Dictionary<int, int> runningSumMap = new Dictionary<int, int>();
            for(int i = 0; i < arr.Length; i++)
            {
                runningSum += arr[i];
                if (runningSumMap.ContainsKey(runningSum))
                    runningSumMap[runningSum]++;
                else
                    runningSumMap.Add(runningSum, 1);

                if (runningSumMap.ContainsKey(runningSum - givenSum))
                    pathsWithSum++;
            }
            return pathsWithSum;
        }
    }
}
