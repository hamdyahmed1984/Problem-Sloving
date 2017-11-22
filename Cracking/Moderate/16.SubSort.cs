using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Moderate
{
    /// <summary>
    /// 16.16 Sub Sort: Given an array of integers, write a method to find indices m and n such that if you sorted
    /// elements m through n, the entire array would be sorted.Minimize n - m(that is, find the smallest such sequence).
    /// EXAMPLE
    /// Input: 1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19
    /// Output: (3, 9)
    /// </summary>
    class SubSort
    {
        public void Test()
        {
            int[] arr = { 1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19 };
            int start_Unsorted, end_Unsorted;
            FindUnsortedSequence(arr, out start_Unsorted, out end_Unsorted);
        }

        private void FindUnsortedSequence(int[] arr, out int start_Unsorted, out int end_Unsorted)
        {
            //Get the index of the increasing subsequence
            int endOfSortedLeft = EndOfSortedLeft(arr);
            if (endOfSortedLeft == arr.Length - 1)//Array is already sorted, because you went through all the array and found each element greater then its prev one
            {
                //C# requires to set out params before leaving the method
                start_Unsorted = end_Unsorted = -1;
                return;
            }
            //Get the index where the right side is unsorted
            int startOfSortedRight = StartOfSortedRight(arr);           
            /*
             * We want to get the min of the middle & right side and also the max of left & middle side.
             * Because the left side is sorted so its last index is the max of the left side.
             * And because the right side is sorted so its first index is the min of the right side.
             * So, we loop from the end of sorted left to the start of the sorted right(hence we include the middle part in between)
             */
            int minIndexOfMiddleAndRight = startOfSortedRight;
            int maxIndexOfLeftAndMiddle = endOfSortedLeft;
            for(int i = endOfSortedLeft + 1; i < startOfSortedRight; i++)
            {
                if (arr[i] < arr[minIndexOfMiddleAndRight])
                    minIndexOfMiddleAndRight = i;
                if (arr[i] > arr[maxIndexOfLeftAndMiddle])
                    maxIndexOfLeftAndMiddle = i;
            }
            //We shrink left and right sides based on the min and max values
            endOfSortedLeft = ShrinkLeft(arr, endOfSortedLeft, minIndexOfMiddleAndRight);
            startOfSortedRight = ShrinkRight(arr, startOfSortedRight, maxIndexOfLeftAndMiddle);

            start_Unsorted = endOfSortedLeft;
            end_Unsorted = startOfSortedRight;
        }

        private int EndOfSortedLeft(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[i - 1])
                    return i - 1;
            }
            return arr.Length - 1;
        }
        private int StartOfSortedRight(int[] arr)
        {
            for(int i = arr.Length - 1; i > 0; i--)
            {
                if (arr[i] < arr[i - 1])
                    return i;
            }
            return 0;
        }

        private int ShrinkLeft(int[] arr, int endIndexOfSortedLeft, int minOfMiddleAndLeftIndex)
        {
            //Continue shrinking of the left side until we found an element less that the min of middle & right sides
            for(int i = endIndexOfSortedLeft; i >= 0; i--)
            {
                if (arr[i] <= arr[minOfMiddleAndLeftIndex])
                    return i + 1;
            }
            return 0;
        }

        private int ShrinkRight(int[] arr, int startIndexOfSortedRight, int maxOfLeftAndMiddleIndex)
        {
            //Continue shrinking of the right side until we found an element greater than the left and middle sides
            for(int i = startIndexOfSortedRight; i < arr.Length; i++)
            {
                if (arr[i] >= arr[maxOfLeftAndMiddleIndex])
                    return i - 1;
            }
            return arr.Length - 1;
        }
    }
}
