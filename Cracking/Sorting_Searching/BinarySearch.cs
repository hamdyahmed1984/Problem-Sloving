using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Sorting_Searching
{
    class BinarySearch
    {
        public void Test()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6 };
            int index = BinarySearchArr(arr, 4);
            int index2 = BinarySearchArr_Recursive(arr, 4, 0, arr.Length - 1);
        }

        private int BinarySearchArr(int[] arr, int value)
        {
            int start = 0;
            int end = arr.Length - 1;
            int mid;
            while(start <= end)
            {
                mid = (start + end) / 2;
                if (arr[mid] < value)
                    start = mid + 1; 
                else if (arr[mid] > value)
                    end = mid - 1;
                else
                    return mid;
            }
            return -1;//Not found
        }

        private int BinarySearchArr_Recursive(int[] arr, int value, int start, int end)
        {
            if (start > end) return -1;//Not found

            int mid = (start + end) / 2;
            if (arr[mid] < value)
                return BinarySearchArr_Recursive(arr, value, mid + 1, end);
            else if (arr[mid] > value)
                return BinarySearchArr_Recursive(arr, value, start, mid - 1);
            else
                return mid;
        }
    }
}
