using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.LinkedLists
{
    class IntersectionNode
    {
        public static Node GetIntersectionPoint(Node n1, Node n2)
        {
            if (n1 == null || n2 == null)
                return null;
            int length1 = 1, length2 = 1;
            Node tail1 = null, tail2 = null;
            GetTailAndLength(n1, ref tail1, ref length1);
            GetTailAndLength(n2, ref tail2, ref length2);

            if (tail1 != tail2)
                return null;

            Node bigger = length1 > length2 ? n1 : n2;
            Node smaller = length1 > length2 ? n2 : n1;

            int lengthDiff = Math.Abs(length1 - length2);
            while(lengthDiff > 0)
            {
                bigger = bigger.Next;
                lengthDiff--;
            }

            while(bigger != smaller)
            {
                bigger = bigger.Next;
                smaller = smaller.Next;
            }
            return bigger;//or smaller, they are the same

        }

        private static void GetTailAndLength(Node n, ref Node tail, ref int length)
        {
            tail = n;
            while(tail.Next != null)
            {
                length++;
                tail = tail.Next;
            }
        }
    }
}
