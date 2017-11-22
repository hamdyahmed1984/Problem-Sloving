using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Arrays
{
    class MaxDiff
    {
        public static void MaxDiffTest()
        {
            int[] arr = { 10, 7, 6, 8, 9, 4, 3 };
            int maxDiff = GetMaxDiffSuchThatGreaterComeBeforeSmaller(arr);
            Console.WriteLine(maxDiff);
        }
        public static int GetMaxDiffSuchThatGreaterComeBeforeSmaller(int[] arr)
        {
            if (arr.Length == 0)
                return 0;
            if (arr.Length == 1)
                return arr[0];
            int min = arr[0];//int.MaxValue;
            int maxDiff = arr[1] - arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                int diff = arr[i] - min;
                maxDiff = Math.Max(maxDiff, diff);
                min = Math.Min(min, arr[i]);
            }
            return maxDiff;
        }        
    }
}
