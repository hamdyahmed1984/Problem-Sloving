using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.LinkedLists
{
    class MedianOfCLL
    {
        public static void Test()
        {
            Node head = new Node(1);
            head.Next = new Node(2);
            head.Next.Next = new Node(3);
            head.Next.Next.Next = new Node(5);
            head.Next.Next.Next.Next = new Node(7);
            head.Next.Next.Next.Next.Next = new Node(8);
            
            head.Next.Next.Next.Next.Next.Next = head;

            //head.Next.Next.Next.Next.Next.Next = new Node(10);
            //head.Next.Next.Next.Next.Next.Next.Next = head;



            int median = MedianOfCLL_2(head.Next);

            Console.WriteLine("Median is: {0}", median);
        }
        /// <summary>
        /// This is for circular linked lists.
        /// We know the head so we can easily calculate the median
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        private static int MedianOfCLL_1(Node head)
        {
            if (head == null)
                return -1;
            if (head.Next == head || head.Next.Next == head)
                return head.data;

            Node slow = head, fast = head.Next;
            while(fast != head && fast.Next != head)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return slow.data;
        }

        /// <summary>
        /// This is for SORTED circular linked lists.
        /// We don't know the head but we have a node in the list
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        private static int MedianOfCLL_2(Node node)
        {
            if (node == null)
                return -1;
            if (node.Next == node || node.Next.Next == node)
                return node.data;

            int count = 1;
            Node smallest = node;
            Node curr = node.Next;
            while(curr != node)
            {
                count++;
                /*
                 * keeping smallest node to have the smallest data means that in end of the loop we will be at the start of the list,
                 * this is because the list is sorted so the smallest node represents the start of the list
                 */
                if (curr.data <= smallest.data)
                    smallest = curr;
                curr = curr.Next;
            }
            for(int i = 0; i < (count >> 1); i++)
            {
                smallest = smallest.Next;
            }
            return smallest.data;
        }
    }
}
