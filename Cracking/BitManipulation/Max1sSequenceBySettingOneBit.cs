using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.BitManipulation
{
    class Max1sSequenceBySettingOneBit
    {
        public static void Test()
        {
            int max1sLengthAfterSettingOnlyOneBit = GetMax1sSequenceBySettingOnlyOneBit(1775);
            Console.WriteLine(max1sLengthAfterSettingOnlyOneBit);
        }
        /// <summary>
        /// O ( b) time and O ( b) memory, where b is the length of the sequence.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int GetMax1sSequenceBySettingOnlyOneBit(int n)
        {
            if (~n == 0) return 32;//If n == -1 this means that it contains all 1's

            int maxLength = 1; // We can always have a sequence of at least one 1
            int prevLength = 0;
            int currLength = 0;
            while(n != 0)
            {
                if((n & 1) == 1) // Current bit is a 1
                {
                    currLength++;
                }
                else//Current bit is a 0
                {
                    /* Update prevLength to 0(if next bit is 0) or currLength(if next bit is 1). */
                    if ((n & 2) == 0)
                        prevLength = 0;
                    else
                        prevLength = currLength;
                    currLength = 0;
                }
                maxLength = Math.Max(prevLength + currLength + 1, maxLength);
                n = n >> 1;
            }
            return maxLength;
        }
    }
}
