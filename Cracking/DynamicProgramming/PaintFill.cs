using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.DynamicProgramming
{
    /*
     * 8.10 Paint Fill: Implement the "paint fill" function that one might see on many image editing programs.
     * That is, given a screen (represented by a two-dimensional array of colors), a point, and a new color,
     * fill in the surrounding area until the color changes from the original color.
     */
    class PaintFill
    {       
        bool DoPaintFill(Color[][] screen, int row, int col, Color nColor)
        {
            if (screen[row][col] == nColor) return false;
            return DoPaintFill(screen, row, col, nColor, screen[row][col]);
        }

        /// <summary>
        /// This is depth first search, we can also do by breadth first search.
        /// </summary>
        /// <param name="screen"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="nColor"></param>
        /// <param name="oColor"></param>
        /// <returns></returns>
        private bool DoPaintFill(Color[][] screen, int row, int col, Color nColor, Color oColor)
        {
            if (row < 0 || row >= screen.Length || col < 0 || col >= screen[0].Length) return false;
            if(screen[row][col] == oColor)
            {
                screen[row][col] = nColor;
                DoPaintFill(screen, row, col + 1, nColor, oColor);//right
                DoPaintFill(screen, row, col - 1, nColor, oColor);//left
                DoPaintFill(screen, row + 1, col, nColor, oColor);//bottom
                DoPaintFill(screen, row - 1, col, nColor, oColor);//up
            }
            return true;
        }
    }

    enum Color
    {
        Red,
        Green,
        Blue,
        Yellow,
        Brown
    }
}
