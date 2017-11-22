using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.DynamicProgramming
{
    /*
     *8.13 Stack of Boxes: You have a stack of n boxes, with widths wi , heights hi, and depths di .
     * The boxes cannot be rotated and can only be stacked on top of one another if each box in the stack is strictly larger than the box above it
     * in width, height, and depth. Implement a method to compute the height of the tallest possible stack.
     * The height of a stack is the sum of the heights of each box. 
     */
    class BoxStacking_WithoutRotation
    {
        public void Test()
        {
            List<Box> boxes = new List<Box>
            {
                //new Box(1, 2, 3),
                //new Box(7, 8, 9),
                //new Box(4, 5, 6)
                 new Box(6, 4, 4), new Box(8, 6, 2), new Box(5, 3, 3), new Box(7, 8, 3), new Box(4, 2, 2), new Box(9, 7, 3)
            };
            int maxStackHeight = CreateStack(boxes);
            Console.WriteLine("Max Stack Height: " + maxStackHeight);
        }

        int CreateStack(List<Box> boxes)
        {
            boxes.Sort(new BoxComparer());
            int maxHeight = 0;
            int[] stackMap = new int[boxes.Count];
            for(int i = 0; i < boxes.Count; i++)
            {
                int height = CreateStack(boxes, i, stackMap);
                maxHeight = Math.Max(maxHeight, height);
            }
            return maxHeight;
        }
        /// <summary>
        /// This is with memorization
        /// </summary>
        /// <param name="boxes"></param>
        /// <param name="bottomIndex"></param>
        /// <param name="stackMap"></param>
        /// <returns></returns>
        private int CreateStack(List<Box> boxes, int bottomIndex, int[] stackMap)
        {
            if (stackMap[bottomIndex] == 0)
            {
                int maxHeight = 0;
                Box bottom = boxes[bottomIndex];
                for (int i = bottomIndex + 1; i < boxes.Count; i++)
                {
                    if (boxes[i].CanBeAbove(bottom))
                    {
                        int height = CreateStack(boxes, i,stackMap);
                        maxHeight = Math.Max(maxHeight, height);
                    }
                }
                maxHeight += bottom.GetHeight();
                stackMap[bottomIndex] = maxHeight;
            }
            return stackMap[bottomIndex];
        }
    }
    class Box
    {
        int height, length, width;
        public Box(int height, int length, int width)
        {
            this.height = height;
            this.length = length;
            this.width = width;
        }

        public int GetHeight() { return height; }
        public int GetLength() { return length; }
        public int GetWidth() { return width; }       

        public bool CanBeAbove(Box box)
        {
            return this.height < box.height &&
                this.length < box.length &&
                this.width < box.width;
        }
    }
    class BoxComparer : IComparer<Box>
    {
        public int Compare(Box x, Box y)
        {
            //return x.GetHeight() - y.GetHeight();//Ascending
            return y.GetHeight() - x.GetHeight();//Descending
        }
    }
}
