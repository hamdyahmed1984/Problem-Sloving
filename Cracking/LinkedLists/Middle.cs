using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.LinkedLists
{
    class Middle
    {
        public static void Test()
        {
            Node head = new Node(5);
            head.Next = new Node(3);
            head.Next.Next = new Node(1);
            head.Next.Next.Next = new Node(2);
            head.Next.Next.Next.Next = new Node(9);
            head.Next.Next.Next.Next.Next= new Node(7);

            //head.Next.Next.Next.Next.Next.Next = new Node(6);

            int middle = MiddleOfSLL_3(head);

            Console.WriteLine("Middle is: {0}", middle);
        }

        /// <summary>
        /// O(N) --> 2 loops, one loop to the end of the list to calculate its length and the other to the half of the list to get the middle
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        private static int MiddleOfSLL_1(Node head)
        {
            int nodes_count = 0;
            Node current = head;
            while(current != null)
            {
                current = current.Next;
                nodes_count++;
            }
            Node current2 = head;
            for(int i = 0; i < nodes_count / 2; i++)
            {
                current2 = current2.Next;
            }
            return current2.data;
        }

        /// <summary>
        /// Update next on the starting node on odd numbers only so in the end of the loop you are in the middle
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        private static int MiddleOfSLL_2(Node head)
        {
            if (head == null)
                return -1;
            Node middle = head;
            int count_odds = 0;
            while (head != null)
            {
                if ((count_odds & 1) == 1)
                    middle = middle.Next;
                count_odds++;
                head = head.Next;
            }
            return middle.data;
        }

        private static int MiddleOfSLL_3(Node head)
        {
            if (head == null)
                return -1;
            Node slow = head, fast = head;
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return slow.data;
        }
    }
}
