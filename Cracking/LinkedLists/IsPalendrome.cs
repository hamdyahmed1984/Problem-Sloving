using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.LinkedLists
{
    class IsPalendrome
    {
        public static bool IsPalendrome1(Node node)
        {
            if (node == null)
                return false;            
            Node current = node;
            Stack<Node> stack = new Stack<Node>();
            while(current != null)
            {
                stack.Push(current);
                current = current.Next;
            }
            while(node != null)
            {
                if (node.data != stack.Pop().data)
                    return false;
                node = node.Next;
            }
            return true;
        }
        /// <summary>
        /// This algorithm uses the stack method but instead of saving the whole list in stack, it stores the first half of the list.
        /// If the first half of the list is identical to the second half of it in reversed order so the list id palendrome
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static bool IsPalendrome2(Node node)
        {
            Node slow = node, fast = node;
            Stack<int> stack = new Stack<int>();
            while(fast != null && fast.Next != null)
            {
                stack.Push(slow.data);
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            /* Has odd number of elements, so skip the middle element*/
            if (fast != null)
                slow = slow.Next;

            while(slow != null)
            {
                if (slow.data != stack.Pop())
                    return false;
                slow = slow.Next;
            }
            return true;
        }
        public static bool IsPalendrome3(Node node)
        {
            //First we will reverse the list
            Node current = node;
            Node prev = null;
            while(current != null)
            {
                Node next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            //Second we loop the original list and compare with the reversed list to check if it is palendrome
            while (node != null && prev != null)
            {
                if (node.data != prev.data)
                    return false;
                node = node.Next;
                prev = prev.Next;
            }
            return node == null && prev == null;
        }
    }
}
