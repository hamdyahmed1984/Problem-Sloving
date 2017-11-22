using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Sorting_Searching
{
    /// <summary>
    /// 10.5 Sparse Search: Given a sorted array of strings that is interspersed with empty strings, write a method to find the location of a given string.
    /// EXAMPLE 
    /// Input: ball, {"at",""}
    /// Output: 4
    /// </summary>
    class SparseSearch
    {
        public void Test()
        {
            string[] arr = { "at", "", "", "", "ball", "", "", "car", "", "", "dad", "", "" };
            int foundIndex = SparseSearchArr(arr, "ball");
            Console.WriteLine(foundIndex);
        }

        private int SparseSearchArr(string[] arr, string str)
        {
            if (arr == null || arr.Length == 0 || string.IsNullOrEmpty(str)) return -1;
            return SparseSearchArr(arr, str, 0, arr.Length - 1);
        }

        private int SparseSearchArr(string[] arr, string str, int start, int end)
        {
            if (start > end) return -1;

            int mid = GetMid(arr, str, start, end);

            if (arr[mid].Equals(str))//Found it
                return mid;
            else if (arr[mid].CompareTo(str) < 0)//Search right
                return SparseSearchArr(arr, str, mid + 1, end);
            else//Search left
                return SparseSearchArr(arr, str, start, mid - 1);
        }

        private int GetMid(string[] arr, string str, int start, int end)
        {
            if (start > end) return -1;
            int mid = (start + end) / 2;
            if (!string.IsNullOrEmpty(arr[mid])) return mid;

            ///* If arr[mid] is empty, find closest non-empty string. */
            int left = mid - 1, right = mid + 1;
            while (true)
            {                
                if (left < start && right > end) return -1;

                if (left >= start && !string.IsNullOrEmpty(arr[left])) return left;
                if (right <= end && !string.IsNullOrEmpty(arr[right])) return right;

                left--;
                right++;
            }
        }
    }
}
