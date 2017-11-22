using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.LinkedLists
{
    class LoopStart
    {
        public static Node GetLoopStart(Node node)
        {
            Node slow = node, fast = node;
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
                if (fast == slow)
                    break;
            }

            if (fast == null || fast.Next == null)
                return null;
            /*When fast and slow meets inside the loop they will be at distance from the loop start equal to the distance
            of the head node to the loop start.
            so we will move any pointer(either fast or slow) to the head and leave the other at its place(collision point),
            and make them move with same speed and they will meet again in the loop start node as they are at the same distance from it.
             */
            slow = node;
            while(slow != fast)
            {
                slow = slow.Next;
                fast = fast.Next;
            }

            return slow;//or either fast, they are now the same.
        }
    }
}
