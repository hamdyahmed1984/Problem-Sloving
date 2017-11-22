using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.DynamicProgramming
{
    class NQueensPlacement
    {
        int GRID_SIZE = 4;
        public void Test()
        {
            List<int[]> results = new List<int[]>();

            PlaceNQueens_AllValidPlacements(new int[GRID_SIZE], 0, results);

            foreach(int[] arr in results)
            {
                Console.WriteLine(string.Join(",", arr));
            }
        }

        private void PlaceNQueens_AllValidPlacements(int[] validPositions, int row, List<int[]> results)
        {
            if (row == GRID_SIZE)//Found valid placement
            {
                results.Add(validPositions.ToArray());//Very important to add positions.ToArray() not positions to prevent changes to already added arrays (reference issue)
            }
            else
            {
                for (int col = 0; col < GRID_SIZE; col++)
                {
                    if (CheckValid(validPositions, row, col))
                    {
                        validPositions[row] = col;
                        PlaceNQueens_AllValidPlacements(validPositions, row + 1, results);
                    }
                }
            }
        }
        /* Check if (rowl, column!) is a valid spot for a queen by checking if there is a queen in the same column or diagonal.
         * We don't need to check it for queens in the same row because the calling placeQueen only attempts to place one queen at a time. We know this row is empty.
         */
        private bool CheckValid(int[] positions, int row, int col)
        {
            for(int r = 0; r < row; r++)
            {
                int c = positions[r];
                /* Check if (r, c) invalidates (row, col) as a queen spot. */                
                /* Check if rows have a queen in the same column */
                if (col == c)
                    return false;
                /* Check diagonals: if the distance between the columns equals the distance between the rows, then they're in the same diagonal. */
                int rowDistance = row - r;/* rowl > row2, so no need for abs */
                int colDistance = Math.Abs(col - c);

                if (rowDistance == colDistance)
                    return false;                
            }
            return true;
        }






        private bool PlaceNQueens_OneValidPlacement(int[] validPositions, int row, List<int[]> results)
        {
            if (row == GRID_SIZE)//Found valid placement
            {
                results.Add(validPositions.ToArray());//Very important to add positions.ToArray() not positions to prevent changes to already added arrays (reference issue)
                return true;
            }
            else
            {
                for (int col = 0; col < GRID_SIZE; col++)
                {
                    if (CheckValid(validPositions, row, col))
                    {
                        validPositions[row] = col;
                        if (PlaceNQueens_OneValidPlacement(validPositions, row + 1, results)) return true;
                    }
                }
            }
            return false;
        }
    }
}
