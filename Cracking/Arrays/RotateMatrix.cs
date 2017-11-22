using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Arrays
{
    class RotateMatrix
    {
        public static void RotateMatrixInPlace(int[][] matrix, bool isClockWise, int degrees = 90)
        {
            if (matrix.Length == 0 || matrix.Length != matrix[0].Length)
                throw new InvalidOperationException("Matrix should be N*N and N should be greater than 0");

            Console.WriteLine("Original matrix:");
            DisplayMatrix(matrix);

            /*
             * Here we can rotate it 90, 180 or 270 degrees
             * /

            //We will loop the first half of the rows and swap and then enter inside rows.

            /*
             * Top row    --> Matrix[row][col]
             * Bottom Row --> Matrix[n - 1 - row][n - 1 - col]
             * Left Row:  --> Matrix[n - 1 - col][row]
             * Right Row  --> Matrix[col][n - 1 - row]
             */

            int n = matrix.Length;
            for (int row = 0; row < n / 2; row++)
            {
                for (int col = row; col < (n - 1 - row); col++)//Every loop we shrink the matrix, 1 from left and 1 from right
                {
                    int top = matrix[row][col];
                    if (isClockWise)
                    {
                        //Left --> Top
                        matrix[row][col] = matrix[n - 1 - col][row];
                        //Bottom --> Left
                        matrix[n - 1 - col][row] = matrix[n - 1 - row][n - 1 - col];
                        //Right --> Bottom
                        matrix[n - 1 - row][n - 1 - col] = matrix[col][n - 1 - row];
                        //Top --> Right
                        matrix[col][n - 1 - row] = top;
                    }
                    else
                    {
                        //Right --> Top
                        matrix[row][col] = matrix[col][n - 1 - row];
                        //Bottom --> Right
                        matrix[col][n - 1 - row] = matrix[n - 1 - row][n - 1 - col];
                        //Left --> Bottom
                        matrix[n - 1 - row][n - 1 - col] = matrix[n - 1 - col][row];
                        //Top --> Left : the temp value
                        matrix[n - 1 - col][row] = top;
                    }
                }
            }

            Console.WriteLine("Rotated matrix:");
            DisplayMatrix(matrix);

        }
        public static void RotateMatrixWithAddionalSpace(int[][] matrix, bool isClockWise)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0)
                throw new InvalidOperationException("Matrix should be M*N Where M is number of rows and N is number of columns. and M and N should be greater than 0");

            int rows = matrix.Length;
            int cols = matrix[0].Length;

            //Create temp matrix to store rotation result in
            int[][] rotatedMatrix = new int[cols][];
            for (int i = 0; i < rotatedMatrix.Length; i++)
                rotatedMatrix[i] = new int[rows];

            //Do the rotation
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (isClockWise)
                        rotatedMatrix[col][rows - 1 - row] = matrix[row][col];
                    else
                        rotatedMatrix[cols - 1 - col][row] = matrix[row][col];
                }
            }

            Console.WriteLine("Original matric:");
            DisplayMatrix(matrix);
            Console.WriteLine("Rotated Matrix:\r\n");
            DisplayMatrix(rotatedMatrix);
        }
        public static void DisplayMatrix(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + "\t");
                }
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
