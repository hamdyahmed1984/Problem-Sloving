using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.DynamicProgramming
{
    class CountPathsInMatrix
    {
        static int callCount = 0;
        public static void Test()
        {
            
            int[][] matrix = new int[4][]
                {
                    new int[] { 1,1,1,1},
                    new int[] { 1,1,1,1},
                    new int []{ 1,1,1,1},
                    new int []{ 1,1,1,1}
                };
            int numberOfPaths = CountPaths_WITHOUT_Recursion(matrix);
            Console.WriteLine("Number of paths: " + numberOfPaths);
            Console.WriteLine("Call Count: " + callCount);
        }

        private static int CountPaths(int[][] matrix)
        {
            return CountPaths(matrix, matrix.Length, matrix[0].Length);
        }

        private static int CountPaths(int[][] matrix, int row, int col)
        {
            callCount++;
            // If either given row number is first or 
            // given column number is first
            if (row == 1 || col == 1) return 1;
            // If diagonal movements are allowed then 
            // the last addition is required.
            return CountPaths(matrix, row, col - 1) + CountPaths(matrix, row - 1, col);
            // + numberOfPaths(m-1,n-1);
        }

        private static int CountPaths_Memo(int[][] matrix)
        {
            int[][] memo = new int[matrix.Length][];
            for (int i = 0; i < memo.Length; i++)
                memo[i] = new int[matrix[0].Length];
            return CountPaths_Memo(matrix, memo, matrix.Length - 1, matrix[0].Length - 1);
        }

        private static int CountPaths_Memo(int[][] matrix, int[][] memo, int row, int col)
        {
            callCount++;
            if (row < 1 || col < 1) return 1;
            if (memo[row][col] == 0)
                memo[row][col] = CountPaths_Memo(matrix, memo, row, col - 1) + CountPaths_Memo(matrix, memo, row - 1, col);
            return memo[row][col];
        }

        private static int CountPaths_WITHOUT_Recursion(int[][] matrix)
        {
            // Create a 2D table to store results 
            // of subproblems
            int[][] count = new int[matrix.Length][];
            for (int i = 0; i < count.Length; i++)
                count[i] = new int[matrix[0].Length];
            // Count of paths to reach any cell in 
            // first column is 1
            for (int i = 0; i < matrix.Length; i++)
                count[i][0] = 1;
            // Count of paths to reach any cell in
            // first column is 1
            for (int j = 0; j < matrix[0].Length; j++)
                count[0][j] = 1;
            // Calculate count of paths for other 
            // cells in bottom-up manner
            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[0].Length; j++)
                {
                    // By uncommenting the last part the 
                    // code calculatest he total possible paths 
                    // if the diagonal Movements are allowed
                    count[i][j] = count[i - 1][j] + count[i][j - 1]; //+ count[i-1][j-1];
                }
            }
            return count[matrix.Length - 1][matrix[0].Length - 1];

        }
    }
}
