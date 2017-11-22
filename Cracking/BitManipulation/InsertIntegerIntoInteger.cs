using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.BitManipulation
{
    class InsertIntegerIntoInteger
    {
        public static void Test()
        {
            Insert(1024, 19, 2, 6);
        }
        /// <summary>
        /// 
        /// 5.1 Insertion: You are given two 32-bit numbers, N and M, and two bit positions, i and j.
        /// Write a method to insert M into N such that M starts at bit j and ends at bit i.You can assume that the bits j through i have enough space to fit all of M. 
        /// That is, if M = 10011, you can assume that there are at least 5 bits between j and i.
        /// You would not, for example, have j = 3 and i = 2, because M could not fully fit between bit 3 and bit 2.
        /// EXAMPLE
        /// Input: N = 10000000000, M = 10011, i = 2, j = 6
        /// Output: N = 10001001100
        /// SOLUTION:
        /// This problem can be approached in three key steps:
        /// 1. Clear the bits j through i in N
        /// 2. Shift M so that it lines up with bits j through i
        /// 3. Merge M and N.
        /// 
        /// </summary>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        static int Insert(int N, int M, int i, int j)
        {
            /* Create a mask to clear bits i through j in n.EXAMPLE: i = 2, j = 4.
             * Result should be 11100011.For simplicity, we'll use just 8 bits for the example. */
            int left = -1 << (j + 1); // ls before position j, then 0s.left = 11100000
            int right = (1 << i) - 1;//l's after position i. right = 0000001
            int mask = left | right;//All ls, except for 0s between i and j. mask 11100011

            /* Clear bits j through i then put m in there */
            int clearedN = N & mask;//Clear bits j through i.
            int shiftedM = M << i;//Move m into correct position.

            int result = clearedN | shiftedM;// OR them, and we're done!
            return result;
        }
    }
}
