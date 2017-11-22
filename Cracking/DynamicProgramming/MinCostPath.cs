using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.DynamicProgramming
{
    class MinCostPath
    {
        public static void Test()
        {
            int[][] matrix = new int[3][]
            {
                new int[]{1,5,2},
                new int[]{6,3,4},
                new int[]{7,9,8}
            };
            MinCostPath_2(matrix, matrix.Length, matrix[0].Length);
        }

        private static void MinCostPath_1(int[][] matrix)
        {
            List<int> shortestPath = new List<int>();
            shortestPath.Add(int.MaxValue);
            MinCostPath_1(matrix, 0, 0, matrix.Length, matrix[0].Length, new List<int>(), ref shortestPath);
            Console.WriteLine("Shortest Path: " + string.Join(" - ", shortestPath) + ", With length: " + shortestPath.Sum());
        }

        private static void MinCostPath_1(int[][] matrix, int row, int col, int rowsCount, int colsCount, List<int> path, ref List<int> shortestPath)
        {
            if (row == rowsCount - 1)
            {
                for (int i = col; i < colsCount; i++)
                {
                    path.Add(matrix[row][i]);
                }
                if (path.Sum() < shortestPath.Sum())
                    shortestPath = new List<int>(path);
                return;
            }
            if(col == colsCount-1)
            {
                for(int i = row; i < rowsCount; i++)
                {
                    path.Add(matrix[i][col]);
                }
                if (path.Sum() < shortestPath.Sum())
                    shortestPath = new List<int>(path);
                return;
            }

            path.Add(matrix[row][col]);
            MinCostPath_1(matrix, row, col + 1, rowsCount, colsCount, path, ref shortestPath);
            MinCostPath_1(matrix, row + 1, col, rowsCount, colsCount, path, ref shortestPath);
            //PrintShortestPath(matrix, row + 1, col + 1, rowsCount, colsCount, path, shortestPathLength);
        }

        private static void MinCostPath_2(int[][] matrix, int rows, int cols)
        {
            int[][] pathsLength = new int[matrix.Length][];
            for(int i = 0; i < rows; i++)
            {
                pathsLength[i] = new int[cols];
            }

            pathsLength[0][0] = matrix[0][0];
            for(int i = 1; i < rows; i++)
            {
                pathsLength[i][0] = matrix[i][0] + pathsLength[i - 1][0];
            }
            for(int i = 1; i < cols; i++)
            {
                pathsLength[0][i] = matrix[0][i] + pathsLength[0][i - 1];
            }

            for(int  i = 1; i < rows; i++)
            {
                for(int j = 1; j < cols; j++)
                {
                    pathsLength[i][j] = matrix[i][j] + Math.Min(pathsLength[i][j - 1], pathsLength[i - 1][j]);
                }
            }

            int minPath = pathsLength[matrix.Length - 1][matrix[0].Length - 1];
        }
    }
}
