using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.DynamicProgramming
{
    /**
 * Date 05/09/2015
 * @author tusroy
 * 
 * Given different dimensions and unlimited supply of boxes for each dimension, stack boxes
 * on top of each other such that it has maximum height but with caveat that length and width
 * of box on top should be strictly less than length and width of box under it. You can
 * rotate boxes as you like.
 * 
 * 1) Create all rotations of boxes such that length is always greater or equal to width
 * 2) Sort boxes by base area in non increasing order (length * width). This is because box
 * with more area will never ever go on top of box with less area.
 * 3) Take T[] and result[] array of same size as total boxes after all rotations are done
 * 4) Apply longest increasing subsequence of algorithm to get max height.
 * 
 * If n number of dimensions are given total boxes after rotation will be 3n.
 * So space complexity is O(n)
 * Time complexity - O(nlogn) to sort boxes. O(n^2) to apply DP on it So really O(n^2)
 *
 * References
 * http://www.geeksforgeeks.org/dynamic-programming-set-21-box-stacking-problem/
 * http://people.cs.clemson.edu/~bcdean/dp_practice/
 */

        /*
         * Note: in this problem it is required that the below box is greater in length and width but this is not required for the height.
         * This is unlike the problem in the ctci which requires that the each box should be greater than its above for all dimensions (length, width and height).
         */
    class BoxStacking_WithRotation
    {        
        public void Test()
        {
            Box_Rot[] boxes = { new Box_Rot(2, 5, 3), new Box_Rot(2, 4, 1) };
            List<Box_Rot> maxStackBoxes = new List<Box_Rot>();
            int maxHeight = MaxStackHeight(boxes, maxStackBoxes);
        }

        public int MaxStackHeight(Box_Rot[] boxes, List<Box_Rot> maxStack)
        {
            int count = boxes.Length * 3;

            Box_Rot[] allRotations = new Box_Rot[count];
            int index = 0;
            foreach(Box_Rot box in boxes)
            {
                Box_Rot[] boxRotations = box.CreateAllRotations();
                allRotations[index++] = boxRotations[0];
                allRotations[index++] = boxRotations[1];
                allRotations[index++] = boxRotations[2];
            }
            //sort these boxes in non increasing order by their base area.(length X width)
            Array.Sort(allRotations);

            int[] T = new int[count];
            int[] result = new int[count];
            //apply longest increasing subsequence kind of algorithm on these sorted boxes.
            for (int i = 0; i < count; i++)
            {
                T[i] = allRotations[i].height;
                result[i] = -1;
            }
            //find max in T[] and that will be our max height.
            //Result can also be found using result[] array.            
            for (int i = 1; i < T.Length; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    if(allRotations[i].length < allRotations[j].length &&
                        allRotations[i].width < allRotations[j].width)
                    {
                        if(T[j] + allRotations[i].height > T[i])
                        {
                            T[i] = T[j] + allRotations[i].height;
                            result[i] = j;
                        }
                    }
                }
            }

            int max = int.MinValue;
            int maxIndex = -1;
            for(int i = 0; i < T.Length;i++)
            {
                if (T[i] > max)
                {
                    max = T[i];
                    maxIndex = i;
                }
            }

            Console.WriteLine("Max Stack Height: " + max);
            int topIndex = maxIndex;
            while (topIndex != -1)
            {
                Console.WriteLine("Box: " + allRotations[topIndex].ToString());
                topIndex = result[topIndex];
            }

            return max;
        }
    }


    class Box_Rot : IComparable
    {
        public int length, width, height;
        public Box_Rot(int length, int width, int height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }
        public static Box_Rot CreateRotatedBox(int height, int side1, int side2)
        {
            int l = side1 >= side2 ? side1 : side2;
            int w = side1 >= side2 ? side2 : side1;
            return new Box_Rot(l, w, height);
        }
        //get all rotations of box dimensions.
        //e.g if box is 1,2,3 rotations will be 2,1,3  3,2,1  3,1,2  . Here length is always greater
        //or equal to width and we can do that without loss of generality.
        public Box_Rot[] CreateAllRotations()
        {
            /* We always need the length to be greater than width*/
            int l, w, h;

            h = this.height;
            l = this.length >= this.width ? this.length : this.width;
            w = this.length >= this.width ? this.width : this.length;
            Box_Rot rotation1 = new Box_Rot(l, w, h);

            h = this.length;
            l = this.width >= this.height ? this.width : this.height;
            w = this.width >= this.height ? this.height : this.width;
            Box_Rot rotation2 = new Box_Rot(l, w, h);

            h = this.width;
            l = this.length >= this.height ? this.length : this.height;
            w = this.length >= this.height ? this.height : this.length;
            Box_Rot rotation3 = new Box_Rot(l, w, h);

            return new Box_Rot[] { rotation1, rotation2, rotation3 };
        }

        public override string ToString()
        {
            return "Box [height=" + height + ", length=" + length
               + ", width=" + width + "]";
        }

        public int CompareTo(Object obj)
        {
            Box_Rot box = (Box_Rot)obj;

            int thisBaseArea = this.length * this.width;
            int boxBaseArea = box.length * box.width;

            if (thisBaseArea > boxBaseArea) return -1;
            if (thisBaseArea < boxBaseArea) return 1;
            else return 0;
        }
    }
}
