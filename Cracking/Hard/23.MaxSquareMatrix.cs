using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Hard
{
    /// <summary>
    /// 17.23 Max Square Matrix: Imagine you have a square matrix, where each cell (pixel) is either black or white.
    /// Design an algorithm to find the maximum subsquare such that all four borders are filled with black pixels.
    /// </summary>
    public class MaxSquareMatrix
    {
        /// <summary>
        /// Runtime: O(N^4)
        /// Space: O(1)
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public SubSquareMatrix FindSubSquareMatrixWithZeroBordere_BF(int[][] matrix)
        {
            for(int squareSize = matrix.Length; squareSize >= 1; squareSize--)
            {
                SubSquareMatrix square = FindSquareWithAllBordersZeros(matrix, squareSize);
                /*We start by the max length of the square, so we return imemdiately when we find it as it is the max one that satisfies our reqs*/
                if (square != null)
                    return square;
            }
            return null;
        }

        private SubSquareMatrix FindSquareWithAllBordersZeros(int[][] matrix, int squareSize)
        {
            /* On an edge of length N, there are (N - squareSize + 1) squares of length squareSize. */
            int length = matrix.Length - squareSize + 1;
            for(int r = 0; r < length; r++)
            {
                for(int c = 0; c < length; c++)
                {
                    if (IsSquareWithAllBordersZeros(matrix, r, c, squareSize))
                        return new SubSquareMatrix(r, c, squareSize);
                }
            }
            return null;
        }

        private bool IsSquareWithAllBordersZeros(int[][] matrix, int r, int c, int squareSize)
        {
            for(int i = 0; i < squareSize; i++)
            {
                /*Top Row*/
                if (matrix[r][c + i] == 1) return false;
                /*Bottom Row*/
                if (matrix[r + squareSize - 1][c] == 1) return false;
                /*Left Col*/
                if (matrix[r + i][c] == 1) return false;
                /*Right Col*/
                if (matrix[r + i][c + squareSize - 1] == 1) return false;
            }
            return true;
        }

        public class SubSquareMatrix
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public int SquareSize { get; set; }
            public SubSquareMatrix(int row, int col, int squareSize)
            {
                this.Row = row;
                this.Col = col;
                this.SquareSize = squareSize;
            }
        }

        ///////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Runtime: O(N^3)
        /// Space: O(N^2)
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public SubSquareMatrix FindSubSquareMatrixWithZeroBordere_Optimal(int[][] matrix)
        {
            SquareCell[][] processedMatrix = ProcessMatrix(matrix);
            for (int squareSize = processedMatrix.Length; squareSize >= 1; squareSize--)
            {
                SubSquareMatrix square = FindSquareWithAllBordersZeros_Optimal(processedMatrix, squareSize);
                /*We start by the max length of the square, so we return imemdiately when we find it as it is the max one that satisfies our reqs*/
                if (square != null)
                    return square;
            }
            return null;
        }

        private SubSquareMatrix FindSquareWithAllBordersZeros_Optimal(SquareCell[][] processedMatrix, int squareSize)
        {
            /* On an edge of length N, there are (N - squareSize + 1) squares of length squareSize. */
            int length = processedMatrix.Length - squareSize + 1;
            for (int r = 0; r < length; r++)
            {
                for (int c = 0; c < length; c++)
                {
                    if (IsSquareWithAllBordersZeros_Optimal(processedMatrix, r, c, squareSize))
                        return new SubSquareMatrix(r, c, squareSize);
                }
            }
            return null;
        }

        private bool IsSquareWithAllBordersZeros_Optimal(SquareCell[][] processedMatrix, int r, int c, int squareSize)
        {
            SquareCell topLeft = processedMatrix[r][c];
            SquareCell topRight = processedMatrix[r][c + squareSize - 1];
            SquareCell bottomLeft = processedMatrix[r + squareSize - 1][c];
            //SquareCell bottomRigth = processedMatrix[r + squareSize - 1][c + squareSize - 1];
            if (topLeft.ZerosRight < squareSize ||
                topLeft.ZerosBelow < squareSize ||
                topRight.ZerosBelow < squareSize ||
                bottomLeft.ZerosRight < squareSize)
                return false;
            return true;
        }

        private SquareCell[][] ProcessMatrix(int[][] matrix)
        {
            SquareCell[][] processed = new SquareCell[matrix.Length][];
            for(int r = matrix.Length - 1; r >= 0; r--)
            {
                processed[r] = new SquareCell[matrix.Length];
                for(int c = matrix.Length - 1; c >= 0; c--)
                {
                    int zerosRight = 0;
                    int zerosBelow = 0;
                    if(matrix[r][c] == 0)
                    {
                        zerosRight++;
                        zerosBelow++;

                        if (c + 1 < matrix.Length)
                            zerosRight += processed[r][c + 1].ZerosRight;

                        if (r + 1 < matrix.Length)
                            zerosBelow += processed[r + 1][c].ZerosBelow;
                    }
                    processed[r][c] = new SquareCell(zerosRight, zerosBelow);
                }
            }
            return processed;
        }

        public class SquareCell
        {
            //public int Row { get; set; }
            //public int Col { get; set; }
            public int ZerosRight { get; set; }
            public int ZerosBelow { get; set; }
            public SquareCell(/*int row, int col, */int zerosRight, int zerosBelow)
            {
                //this.Row = row;
                //this.Col = col;
                this.ZerosRight = zerosRight;
                this.ZerosBelow = zerosBelow;
            }
        }
    }
}
