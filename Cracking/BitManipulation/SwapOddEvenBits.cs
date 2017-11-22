using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.BitManipulation
{
    class SwapOddEvenBits
    {
        public static void Test()
        {
            long swapped = SwapOddWithEvenBits(23);
            Console.WriteLine(swapped);
        }
        public static long SwapOddWithEvenBits(int n)
        {
            //return ((n & 0xaaaaaaaa) >> 1) | ((n & 0x55555555) << 1);

            // Get all even bits of x
            long even_bits = n & 0xAAAAAAAA;//The number 0xAAAAAAAA is a 32 bit number with all even bits set as 1 and all odd bits as 0.

            // Get all odd bits of x
            long odd_bits = n & 0x55555555;//The number 0x55555555 is a 32 bit number with all odd bits set as 1 and all even bits as 0.

            even_bits >>= 1;  // Right shift even bits
            odd_bits <<= 1;   // Left shift odd bits

            return (even_bits | odd_bits); // Combine even and odd bits
        }
    }
}
