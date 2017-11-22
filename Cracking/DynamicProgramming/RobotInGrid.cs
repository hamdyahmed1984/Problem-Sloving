using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.DynamicProgramming
{
    /*
     * 8.2 Robot in a Grid: Imagine a robot sitting on the upper left corner of grid with r rows and c columns.
     * The robot can only move in two directions, right and down, but certain cells are "off limits" such that 
     * the robot cannot step on them. Design an algorithm to find a path for the robot from the top left to
     * the bottom right.
     * */
    class RobotInGrid
    {
        public static void Test()
        {
            int[][] maze = new int[3][]
            {
                new int[]{1, 1, 1 },
                new int[]{1, 0, 1},
                new int[]{1, 1, 1}
            };
            FindPath_Memo(maze);
        }

        private static bool FindPath(int[][] maze)
        {
            if (maze == null || maze.Length == 0)
                return false;
            List<Cell> path = new List<Cell>();
            return FindPath(maze, maze.Length - 1, maze[0].Length - 1, path);
        }

        private static bool FindPath(int[][] maze, int row, int col, List<Cell> path)
        {
            if (row < 0 || col < 0 || maze[row][col] == 0)
                return false;
            bool isAtOrigin = row == 0 && col == 0;
            if(isAtOrigin || FindPath(maze, row, col-1, path) || FindPath(maze, row-1, col, path))
            {
                Cell c = new Cell(row, col);
                path.Add(c);
                return true;
            }
            return false;
        }

        private static bool FindPath_Memo(int[][] maze)
        {
            if (maze == null || maze.Length == 0)
                return false;
            List<Cell> path = new List<Cell>();
            HashSet<Cell> falieddCells = new HashSet<Cell>();
            return FindPath_Memo(maze, maze.Length - 1, maze[0].Length - 1, path, falieddCells);
        }

        private static bool FindPath_Memo(int[][] maze, int row, int col, List<Cell> path, HashSet<Cell> falieddCells)
        {
            if (row < 0 || col < 0 || maze[row][col] == 0)
                return false;
            Cell c = new Cell(row, col);
            /* If we've already visited this cell, return. */
            if (falieddCells.Contains(c))
                return false;
            bool isAtOrigin = row == 0 && col == 0;
            if (isAtOrigin || FindPath_Memo(maze, row, col - 1, path, falieddCells) || FindPath_Memo(maze, row - 1, col, path, falieddCells))
            {
                path.Add(c);
                return true;
            }
            falieddCells.Add(c);
            return false;
        }
    }
    class Cell
    {
        int Row { get; set; }
        int Col { get; set; }
        public Cell(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}
