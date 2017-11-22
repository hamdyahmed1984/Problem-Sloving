using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.DynamicProgramming
{
    class PrintAllPathsInMatrix
    {
        public static void Test()
        {
            int[][] matrix = new int[3][]
            {
                new int[]{1,2,3 },
                new int[]{4,5,6 },
                new int[]{7,8,9 }
            };
            PrintPossiblePaths(matrix);
        }
        
        private static void PrintPossiblePaths(int[][] matrix)
        {
            PrintPossiblePaths(matrix, 0, 0, matrix.Length, matrix[0].Length, "");
        }

        private static void PrintPossiblePaths(int[][] matrix, int row, int col, int rowsCount, int colsCount, string path)
        {
            // Reached the bottom of the matrix so we are left with
            // only option to move right
            if ( row == rowsCount - 1)
            {
                for(int i = col; i < colsCount; i++)
                {
                    path = path + " - " + matrix[row][i];
                }
                Console.WriteLine(path);
                return;
            }
            // Reached the right corner of the matrix we are left with
            // only the downward movement.
            if (col  == colsCount - 1)
            {
                for(int i = row; i < rowsCount; i++)
                {
                    path = path + " - " + matrix[i][col];
                }
                Console.WriteLine(path);
                return;
            }
            // Add the current cell to the path being generated
            path = path + " - " + matrix[row][col];
            // Print all the paths that are possible after moving right
            PrintPossiblePaths(matrix, row, col + 1, rowsCount, colsCount, path);
            // Print all the paths that are possible after moving down
            PrintPossiblePaths(matrix, row + 1, col, rowsCount, colsCount, path);
            // Print all the paths that are possible after moving diagonal
            //PrintPossiblePaths(matrix, row + 1, col + 1, rowsCount, colsCount, path);
        }
    }
}
