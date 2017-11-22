using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Moderate
{
    /// <summary>
    /// 16.19 Pond Sizes: You have an integer matrix representing a plot of land, where the value at that location
    /// represents the height above sea level.A value of zero indicates water.A pond is a region of water
    /// connected vertically, horizontally, or diagonally. The size of the pond is the total number of
    /// connected water cells.Write a method to compute the sizes of all ponds in the matrix.
    /// EXAMPLE
    /// Input:
    /// 0 2 1 0
    /// 0 1 0 1
    /// 1 1 0 1
    /// 0 1 0 1
    /// Output: 2, 4, 1 (in any order)
    /// </summary>
    class PondSizes
    {
		public void Test()
        {
            int[][] matrix = new int[4][]
            {
                new int[]{0,2,1,0},
                new int[]{0,1,0,1},
                new int[]{1,1,0,1},
                new int[]{0,1,0,1}
            };

            List<int> pondSizes = ComputePondSizes(matrix);
            pondSizes = ComputePondSizes_Good(matrix);
        }

		private List<int> ComputePondSizes_Good(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0) return null;
            List<int> pondSizes = new List<int>();
			for(int r = 0; r < matrix.Length; r++)
            {
				for(int c = 0; c < matrix[0].Length; c++)
                {
					if(matrix[r][c] == 0)
                    {
                        int size = ComputeSize(matrix, r, c);
                        pondSizes.Add(size);
                    }
                }
            }
            return pondSizes;
        }

        private int ComputeSize(int[][] matrix, int r, int c)
        {
            if(r < 0 || r >= matrix.Length || c < 0 || c >= matrix[0].Length || matrix[r][c] != 0/*visited or not water*/)
            {
                return 0;
            }
            matrix[r][c] = -1;//Mark as visited
            int size = 1;
			for(int dr = -1; dr <= 1; dr++)
            {
				for(int dc = -1; dc <= 1; dc++)
                {
                    /*
					 * You might also notice that the for loop iterates through nine cells, not eight. It includes the current cell.
					 * We could add a line in there to not recurse if dr == 0 and de == 0. This really doesn't save us much.
					 * We'll execute this if-statement in eight cells unnecessarily, just to avoid one recursive call. The recursive call
					 * returns immediately since the cell is marked as visited.
					 */
                    size += ComputeSize(matrix, r + dr, c + dc);
                }
            }
            return size;
        }

        private List<int> ComputePondSizes(int[][] matrix)
        {
            List<int> sizes = new List<int>();
            bool[][] visited = new bool[matrix.Length][];
			for(int r = 0; r < matrix[0].Length; r++)
            {
                visited[r] = new bool[4];
            }

            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[0].Length; c++)
                {
					//If visited before or greater than 0 (water), continue to next cell
                    if (visited[r][c] || matrix[r][c] > 0)
                        continue;
                    else//Water
                    {
                        visited[r][c] = true;
                        int count = 1;
                        count += GetAdjacentCellsCounts(matrix, visited, r, c);
                        sizes.Add(count);
                    }
                }
            }
            return sizes;
        }

        private int GetAdjacentCellsCounts(int[][] matrix, bool[][] visited, int r, int c)
        {
            if (!IsInsideBounds(r, c, matrix))
                return 0;
            int count = 0;
            //Top
            if (IsInsideBounds(r - 1, c, matrix) && matrix[r - 1][c] == 0 && !visited[r - 1][c])
            {
                visited[r - 1][c] = true;
                count++;
                count += GetAdjacentCellsCounts(matrix, visited, r - 1, c);
            }
            //Bottom
            if (IsInsideBounds(r + 1, c, matrix) && matrix[r + 1][c] == 0 && !visited[r + 1][c])
            {
                visited[r + 1][c] = true;
                count++;
                count += GetAdjacentCellsCounts(matrix, visited, r + 1, c);
            }
            //Left
            if (IsInsideBounds(r, c - 1, matrix) && matrix[r][c - 1] == 0 && !visited[r][c - 1])
            {
                visited[r][c - 1] = true;
                count++;
                count += GetAdjacentCellsCounts(matrix, visited, r, c - 1);
            }
            //right
            if (IsInsideBounds(r, c + 1, matrix) && matrix[r][c + 1] == 0 && !visited[r][c + 1])
            {
                visited[r][c + 1] = true;
                count++;
                count += GetAdjacentCellsCounts(matrix, visited, r, c + 1);
            }

            //Diagonal
            if (IsInsideBounds(r + 1, c + 1, matrix) && matrix[r + 1][c + 1] == 0 && !visited[r + 1][c + 1])
            {
                visited[r + 1][c + 1] = true;
                count++;
                count += GetAdjacentCellsCounts(matrix, visited, r + 1, c + 1);
            }
            if (IsInsideBounds(r - 1, c - 1, matrix) && matrix[r - 1][c - 1] == 0 && !visited[r - 1][c - 1])
            {
                visited[r - 1][c - 1] = true;
                count++;
                count += GetAdjacentCellsCounts(matrix, visited, r - 1, c - 1);
            }
            if (IsInsideBounds(r + 1, c - 1, matrix) && matrix[r + 1][c - 1] == 0 && !visited[r + 1][c - 1])
            {
                visited[r + 1][c - 1] = true;
                count++;
                count += GetAdjacentCellsCounts(matrix, visited, r + 1, c - 1);
            }
            if (IsInsideBounds(r - 1, c + 1, matrix) && matrix[r - 1][c + 1] == 0 && !visited[r - 1][c + 1])
            {
                visited[r - 1][c + 1] = true;
                count++;
                count += GetAdjacentCellsCounts(matrix, visited, r - 1, c + 1);
            }
            return count;
        }

		bool IsInsideBounds(int r, int c , int[][] matrix)
        {
            return (r >= 0 && r < matrix.Length) && (c >= 0 && c < matrix[0].Length);
        }
		
    }
}
