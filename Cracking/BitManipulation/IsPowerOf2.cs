using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.BitManipulation
{
    class IsPowerOf2
    {
        public static void Test()
        {
            Console.WriteLine(NumberIsPowerOfTwo(16));
        }

        private static bool NumberIsPowerOfTwo(int v)
        {
            return (v & (v - 1)) == 0;
        }
    }
}
