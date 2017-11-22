using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Arrays
{
    class PrintMatrixInSpiralForm
    {
        public void Test()
        {
            int[][] matrix = new int[4][]
            {
                new int[]{ 1, 2, 3, 4},
                new int[]{ 12, 13, 14, 5},
                new int[]{ 11, 16, 15, 6},
                new int[]{ 10, 9, 8, 7}
            };

            PrintSpiral(matrix);
        }

        private void PrintSpiral(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0) return;

            int rows = matrix.Length;
            int cols = matrix[0].Length;

            int top = 0;
            int bottom = rows - 1;
            int left = 0;
            int right = cols - 1;
            /*dis variable represents the spiral moving direction
             * dir = 0 : left to right
             * dir = 1 : top to bottom
             * dir = 2 : right to left
             * dir = 3 : bottom to top
             */
            int dir = 0;
            while (top <= bottom && left <= right)
            {
                if (dir == 0)//left to right
                {
                    for (int col = left; col <= right; col++)
                        Print(matrix[top][col]);
                    top++;
                }
                else if(dir == 1)//top to bottom
                {
                    for (int row = top; row <= bottom; row++)
                        Print(matrix[row][right]);
                    right--;
                }
                else if (dir == 2) //right to left
                {
                    for (int col = right; col >= left; col--)
                        Print(matrix[bottom][col]);
                    bottom--;
                }
                else if (dir == 3)//bottom to top
                {
                    for (int row = bottom; row >= top; row--)
                        Print(matrix[row][left]);
                    left++;
                }
                dir = (dir + 1) % 4;//Change direction for every iteration of the while loop.
            }
        }

        private void Print(int v)
        {
            Console.Write(v + " ");
        }
    }
}
