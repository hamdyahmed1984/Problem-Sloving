using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Hard
{
    /// <summary>
    /// 17.24 Max Submatrix: Given an NxN matrix of positive and negative integers, write code to find the submatrix with the largest possible sum.
    /// </summary>
    public class MaxSumSubMatrix
    {
        /// <summary>
        /// Runtime: O(N^6)
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public SubMatrix GetSubMatrixWithMaxSum_BF(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0) return null;
            SubMatrix best = null;
            int rowCount = matrix.Length;
            int colCount = matrix[0].Length;
            for(int r1 = 0; r1 < rowCount; r1++)
                for(int r2 = r1; r2 < rowCount; r2++)
                    for(int c1 = 0; c1 < colCount; c1++)
                        for(int c2 = c1; c2 < colCount; c2++)
                        {
                            int sum = GetSubMatrixSum(matrix, r1, c1, r2, c2);
                            if (best == null || best.Sum < sum)
                                best = new SubMatrix(r1, c1, r2, c2, sum);
                        }
            return best;
        }

        private int GetSubMatrixSum(int[][] matrix, int r1, int c1, int r2, int c2)
        {
            int sum = 0;
            for (int r = r1; r <= r2; r++)
                for (int c = c1; c <= c2; c++)
                    sum += matrix[r][c];
            return sum;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// O(N^4)
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public SubMatrix GetSubMatrixWithMaxSum_Optimized(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0) return null;
            SubMatrix best = null;
            int rowCount = matrix.Length;
            int colCount = matrix[0].Length;
            for (int r1 = 0; r1 < rowCount; r1++)
            {
                for (int r2 = r1; r2 < rowCount; r2++)
                {
                    int[] colSum = new int[colCount];
                    for(int c = 0; c < colCount; c++)
                    {
                        colSum[c] = GetColSum(matrix, r1, r2, c);
                    }
                    Range range = GetMaxSumSubArr(colSum);
                    if (best == null || range.Sum > best.Sum)
                        best = new SubMatrix(r1, range.Start, r2, range.End, range.Sum);
                }
            }
            return best;
        }

        private Range GetMaxSumSubArr(int[] colSum)
        {
            int start = 0, end = 0, sumSoFar = 0, maxSum = 0, bestStart = 0;
            for(int i = 0; i < colSum.Length; i++)
            {
                sumSoFar += colSum[i];
                if(sumSoFar > maxSum)
                {
                    maxSum = sumSoFar;
                    bestStart = start;
                    end = i;
                }
                /* If running_sum is < 0 no point in trying to continue the series. Reset. */
                if (sumSoFar < 0 )
                {
                    sumSoFar = 0;
                    start = i + 1;
                }
            }
            return new Range(bestStart, end, maxSum);
        }

        private int GetColSum(int[][] matrix, int r1, int r2, int c)
        {
            int sum = 0;
            for (int r = r1; r <= r2; r++)
                sum += matrix[r][c];
            return sum;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// O(N^3)
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public SubMatrix GetSubMatrixWithMaxSum_Optimal(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0) return null;
            SubMatrix best = null;
            int rowCount = matrix.Length;
            int colCount = matrix[0].Length;
            for (int r1 = 0; r1 < rowCount; r1++)
            {
                int[] colSum = new int[colCount];
                for (int r2 = r1; r2 < rowCount; r2++)
                {                    
                    for (int c = 0; c < colCount; c++)
                    {
                        colSum[c] += matrix[r2][c];
                    }
                    Range range = GetMaxSumSubArr(colSum);
                    if (best == null || range.Sum > best.Sum)
                        best = new SubMatrix(r1, range.Start, r2, range.End, range.Sum);
                }
            }
            return best;
        }

        public class SubMatrix
        {
            public int R1 { get; set; }
            public int C1 { get; set; }
            public int R2 { get; set; }
            public int C2 { get; set; }
            public int Sum { get; set; }
            public SubMatrix(int r1, int c1, int r2, int c2, int sum)
            {
                R1 = r1;
                C1 = c1;
                R2 = r2;
                C2 = c2;
                Sum = sum;
            }
        }

        private class Range
        {
            public int Start { get; set; }
            public int End { get; set; }
            public int Sum { get; set; }
            public Range(int start, int end, int sum)
            {
                Start = start;
                End = end;
                Sum = sum;
            }
        }
    }
}
