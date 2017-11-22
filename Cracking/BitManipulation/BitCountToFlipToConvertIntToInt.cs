using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.BitManipulation
{
    class BitCountToFlipToConvertIntToInt
    {
        /*
         This gets the count of bits to change in an integer to convert it to another integer. (i.e XOR)
             */
        public static void Test()
        {
            int a = 12;
            int b = 5;
            Console.WriteLine(BitsToFlipCount_1(a, b));
            Console.WriteLine(BitsToFlipCount_2(a, b));
            Console.WriteLine(BitsToFlipCount_3(a, b));
        }

        /// <summary>
        /// c = c & (c - 1) --> this clears the least significant bit.
        /// we can continuously flip the least significant bit and count how long it takes c to reach 0. 
        /// The operation c = c & (c - 1) will clear the least significant bit in c.
        /// Example: c=1011100 after this operation it becomes 1011000
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int BitsToFlipCount_1(int a, int b)
        {
            int count = 0;
            for(int c = a ^ b; c != 0; c = c & (c - 1))
            {
                count++;
            }
            return count;
        }
        static int BitsToFlipCount_2(int a, int b)
        {
            int count = 0;
            for(int c = a ^ b; c != 0; c = c >> 1)
            {
                count += c & 1;
            }
            return count;
        }

        static int BitsToFlipCount_3(int a, int b)
        {
            int count = 0;
            int c = a ^ b;
            while (c != 0)
            {
                count += c & 1;
                c = c >> 1;
            }
            return count;
        }
    }
}
