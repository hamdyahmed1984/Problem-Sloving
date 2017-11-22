using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.LinkedLists
{
    public class IsLinkedListCyclic
    {
        public static bool IsLinkedListCyclic1(LinkedList list)
        {
            if (list.Head == null)
                return false;
            Node fast = list.Head.Next;
            Node slow = list.Head;
            while(fast != null && fast.Next != null)
            {
                if (fast == slow)
                    return true;
                fast = fast.Next.Next;
                slow = slow.Next;
            }
            return false;
        }
        public static bool IsLinkedListCyclic2(LinkedList list)
        {
            HashSet<int> visitedNodes = new HashSet<int>();
            Node current = list.Head;
            while (current != null)
            {
                if (visitedNodes.Contains(current.data))
                    return true;
                else
                    visitedNodes.Add(current.data);
                current = current.Next;
            }
            return false;
        }
    }
}
