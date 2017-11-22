using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Sorting_Searching
{
    /// <summary>
    /// 10.4 Sorted Search, No Size: You are given an array-like data structure Listy which lacks a size
    /// method.It does, however, have an elementAt(i) method that returns the element at index i in
    /// O(1) time.If i is beyond the bounds of the data structure, it returns -1. (For this reason, the data
    /// structure only supports positive integers.) Given a Listy which contains sorted, positive integers,
    /// find the index at which an element x occurs. If x occurs multiple times, you may return any index.
    /// </summary>
    class SortedSearch_NoSize
    {
        public void Test()
        {
            Listy list = new Listy();
            list.AddRange(new int[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 15, 15 });

            int foundIndex = SortedSearch_NoSizeArr(list, 5);
            Console.WriteLine(foundIndex);
        }

        private int SortedSearch_NoSizeArr(Listy list, int searchValue)
        {
            int size = 1;
            /*
             * Optimization: this condition (list.GetElementAtIndex(size) < searchValue) means:
             * If the element is bigger than the searchValue, we'll jump over to the binary search part early.
             * 
             * So the 2 conditions below means that we increase the size until we reach the value -1 (element at index greater than the size of the collection),
             * or up to a point where the value at index size is greater than the value we search fro becuase in this case if the value we sr=earch for exists in
             * the array it will be in any index in indeces less than size.
             */
            while (list.GetElementAtIndex(size) != -1 && list.GetElementAtIndex(size) < searchValue)
            {
                size *= 2;
            }
            int foundIndex = BinarySearch_Custom(list, size/2, size, searchValue);//Really I don't know why we start binary search from size/2 and not from 0. But it works :)
            return foundIndex;
        }

        private int BinarySearch_Custom(Listy list, int low, int high, int searchValue)
        {
            while(low <= high)
            {
                int mid = (low + high) / 2;
                int midValue = list.GetElementAtIndex(mid);
                /*
                 * midValue == -1: means that this is outside the bounds of the array and we should search in the left side
                 */
                if (midValue > searchValue || midValue == -1)
                    high = mid - 1;
                else if (midValue < searchValue)
                    low = mid + 1;
                else return mid;
            }
            return -1;
        }

        class Listy: List<int>
        {
            public int GetElementAtIndex(int index)
            {
                if (index >= this.Count) return -1;
                return this[index];
            }
        }
    }
}
