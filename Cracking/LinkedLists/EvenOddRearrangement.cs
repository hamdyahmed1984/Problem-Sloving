using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.LinkedLists
{
    class EvenOddRearrangement
    {
        public static void Test()
        {
            Node head = new Node(1);
            head.Next = new Node(2);
            head.Next.Next = new Node(3);
            head.Next.Next.Next = new Node(4);
            head.Next.Next.Next.Next = new Node(5);
            head.Next.Next.Next.Next.Next = new Node(6);
            head.Next.Next.Next.Next.Next.Next = new Node(7);
            head.Next.Next.Next.Next.Next.Next.Next = new Node(8);

            EvenOddRearrangement_1(head);
        }

        private static Node EvenOddRearrangement_1(Node head)
        {
            if (head == null)
                return null;
            if (head.Next == null || head.Next.Next == null)//if 1 or 2 elements return head
                return head;

            Node odd = head;
            Node even = head.Next;
            Node evenFirst = even;
            while(odd != null && even != null && even.Next != null)
            {
                odd.Next = even.Next;
                odd = odd.Next;

                even.Next = odd.Next;
                even = even.Next;
            }
            odd.Next = evenFirst;
            return head;
        }
    }
}
