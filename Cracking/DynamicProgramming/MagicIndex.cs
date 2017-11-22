using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.DynamicProgramming
{
    /*
     8.3 Magic Index: A magic index in an array A[ 1 .•. n-1] is defined to be an index such that A[ i]
        i. Given a sorted array of distinct integers, write a method to find a magic index, if one exists, in
        array A.
        FOLLOW UP
        What if the values are not distinct?
         */
    class MagicIndex
    {
        public static void Test()
        {
            int[] arr = new int[] {-40,-20,-1,1,2,3,4,7,9,12,13 };
            //int[] arr = new int[] {-10,-5,2,2,2,3,4,7,9,12,13 };
            int magicIndex = GetMagicIndex(arr);
            Console.WriteLine("Magic Index: " + magicIndex);
            magicIndex = GetMagicIndex_Fast_NoDups(arr);
            Console.WriteLine("Magic Index: " + magicIndex);
            magicIndex = GetMagicIndex_Fast_Dups(arr);
            Console.WriteLine("Magic Index: " + magicIndex);
        }

        /// <summary>
        /// Naiive solution takes O(n)
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static int GetMagicIndex(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == i) return i;
            return -1;
        }

        private static int GetMagicIndex_Fast_NoDups(int[] arr)
        {
            return GetMagicIndex_Fast_NoDups(arr, 0, arr.Length - 1);
        }

        private static int GetMagicIndex_Fast_NoDups(int[] arr, int start, int end)
        {
            if (start > end)
                return -1;
            int midIndex = (start + end) / 2;
            if (midIndex == arr[midIndex])
                return midIndex;
            if (midIndex > arr[midIndex])//Because there are no duplicate values in the array, we guarantee that if the midIndex > value at midIndex so the magic index,if exists, is on the right side.
                return GetMagicIndex_Fast_NoDups(arr, midIndex + 1, end);
            else//Because there are no duplicates values in the arraym we guarantee that if the midIndex is less that the value at midIndex so the magic index,if exists, is on the left side.
                return GetMagicIndex_Fast_NoDups(arr, start, midIndex - 1);
        }

        private static int GetMagicIndex_Fast_Dups(int[] arr)
        {
            return GetMagicIndex_Fast_Dups(arr, 0, arr.Length - 1);
        }

        private static int GetMagicIndex_Fast_Dups(int[] arr, int start, int end)
        {
            if (start > end) return -1;

            int midIndex = (start + end) / 2;
            int midValue = arr[midIndex];
            //If found magic index return it
            if (midIndex == midValue) return midIndex;
            /*
             * If not found it may be on left or on right as there are duplicates we cannot guarantee so we should search on both sides.
             */

            //For left side we search from start to the first(first here when you are coming from midIndex and going to start) element that could be a magic index
            int leftEndIndex = Math.Min(midIndex - 1, midValue);
            int leftIndex = GetMagicIndex_Fast_Dups(arr, start, leftEndIndex);
            if (leftIndex >= 0)//We check for leftIndex >=0 here to gaurantee that we search right side if left side doesn't have a magic index
                return leftIndex;
            //For right side we search from the first element that could be a magic index to the end of the sub array
            int rightStartIndex = Math.Max(midIndex + 1, midValue);
            int rightIndex = GetMagicIndex_Fast_Dups(arr, rightStartIndex, end);
            return rightIndex;
        }
    }
}
