using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.BitManipulation
{
    class NextPrevNumberWithSameCardinality
    {
        int getNext(int n)
        {
            /* Compute c0 and cl*/
            int c = n;
            int c0 = 0;
            int c1 = 0;
            while (((c & 1) == 0) && (c != 0))
            {
                c0++;
                c >>= 1;
            }

            while ((c & 1) == 1)
            {
                c1++;
                c >>= 1;
            }
            /* Error: if n == 11 .. 1100 ... 00, then there is no bigger number with the same
            * number of ls. */
            if (c0 + c1 == 31 || c0 + c1 == 0)
            {
                return -1;
            }

            int p = c0 + c1; // position of rightmost non-trailing zero

            n |= (1 << p); // Flip rightmost non-trailing zero
            n &= ~((1 << p) - 1); // Clear all bits to the right of p
            n |= (1 << (c1 - 1)) - 1; // Insert(cl-1) ones on the right.
            return n;
        }

        int getPrev(int n)
        {
            int temp = n;
            int c0 = 0;
            int c1 = 0;
            while ((temp & 1) == 1)
            {
                c1++;
                temp >>= 1;
            }
            if (temp == 0) return -1;

            while (((temp & 1) == 0) && (temp != 0))
            {
                c0++;
                temp >>= 1;
            }

            int p = c0 + c1; // position of rightmost non-trailing one
            n &= ((~0) << (p + 1)); // clears from bit p onwards

            int mask = (1 << (c1 + 1)) - 1; // Sequence of (cl+l) ones
            n |= mask << (c0 - 1);

            return n;
        }
    }
}
