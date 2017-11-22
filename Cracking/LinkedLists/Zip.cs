using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.LinkedLists
{
    class Zip
    {
        public static void Test()
        {
            Node head = new Node(1);
            head.Next = new Node(3);
            head.Next.Next = new Node(5);
            head.Next.Next.Next = new Node(4);
            head.Next.Next.Next.Next = new Node(2);

            head = Zip_1(head);
        }

        private static Node Zip_1(Node head)
        {
            Node slow = head;
            Node fast = head.Next;
            while(fast !=  null && fast.Next !=  null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            //Now slow is in the end of the first half of the list, we reverse the second half
            Node slowNext = slow.Next;
            slow.Next = null;//We need to clear the first half of the list so when we merge the 2 half no other pointers
            slow = Reverse(slowNext);//Now slow is the last node in the original list

            Node half1 = head;
            Node half2 = slow;
            while(half1 != null && half2 != null)
            {
                //Put half2 in half1.Next and advance half1
                Node half1Next = half1.Next;
                half1.Next = half2;
                half1 = half1Next;
                //Put half1 in half2.Next and advance half2
                Node half2Next = half2.Next;
                half2.Next = half1;
                half2 = half2Next;
            }
            return head;
        }

        private static Node Reverse(Node node)
        {
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
