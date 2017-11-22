using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.LinkedLists
{
    class ReverseLinkedList
    {
        public static Node Reverse1(Node node)
        {
            if (node == null)
                return null;
            Stack<Node> stack = new Stack<Node>();
            while (node != null)
            {
                Node next = node.Next;

                node.Next = null;
                stack.Push(node);

                node = next;
            }

            Node head = stack.Pop();
            Node current = head;
            while (stack.Count > 0)
            {
                Node popped = stack.Pop();
                current.Next = popped;
                current = popped;
            }
            return head;
        }

        public static Node Reverse2(Node node)
        {
            if (node == null)
                return null;
            Node prev = null;
            while(node != null)
            {
                Node next = node.Next;

                node.Next = prev;
                prev = node;

                node = next;
            }
            return prev;
        }
    }
}
