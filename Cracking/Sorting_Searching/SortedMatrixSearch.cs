using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Sorting_Searching
{
    /// <summary>
    /// 10.9 Sorted Matrix Search: Given an M x N matrix in which each row and each column is sorted in ascending order, write a method to find an element.
    /// 
    /// 
    /// 
    /// This can be solved using O(N^2) by traversing through all rows and columns.
    /// Also can be solved using O(N log N) by doing binary search for columns of each row.
    /// And can be solved using O(M + N) by the implemented the solution below.
    /// Also there is another good solution in the book but it is very complicated.
    /// </summary>
    class SortedMatrixSearch
    {
        public void Test()
        {
            int[][] arr = new int[4][]
                {
                    new int[]{15,20,40,85 },
                    new int[]{20,35,80,95 },
                    new int[]{ 30,55,95,105 },
                    new int[]{ 40,80,100,120 }
                };
            SortedMatrixSearchArr(arr, 55);

        }

        private bool SortedMatrixSearchArr(int[][] arr, int val)
        {
            int rows = arr.Length;
            int cols = arr[0].Length;

            int row = 0, col = cols - 1;
            while(row < rows && col >= 0)
            {
                if (arr[row][col] == val) return true;
                else if (arr[row][col] > val) col--;
                else row++;
            }
            return false;
        }
    }
}
