using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.LinkedLists
{
    class SumLists
    {
        public static int Sum2Lists(Node a, Node b)
        {
            int sum = SumList1(a) + SumList1(b);
            int div = sum;
            int mod = 0;
            Node sumNode = new Node(-1);
            Node tail = sumNode;
            while(div > 0)
            {
                mod = div % 10;
                div = div / 10;
                Node n = new Node(mod);
                tail.Next = n;
                tail = n;
            }
            //We should return sumNode.Next due to the dummy node
            sumNode.Next.PrintList();
            return sum;
        }

        /// <summary>
        /// Elements in list are in reverse to their decimal places. i.e 1->2->3 = 321
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        private static int SumList1(Node a)
        {
            int decimalPlace = 1;
            int sum = 0;
            while(a != null)
            {
                sum += a.data * decimalPlace;
                decimalPlace *= 10;
                a = a.Next;
            }
            return sum;
        }

        /// <summary>
        /// Elements in list are proportinal to their decimal places. i.e 1->2->3 = 123
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        private static int SumList2(Node a)
        {
            int decimalPlace = 1;
            Node current = a;
            while(current != null)
            {
                decimalPlace *= 10;
                current = current.Next;
            }
            decimalPlace /= 10;
           
            int sum = 0;
            while (a != null)
            {
                sum += a.data * decimalPlace;
                decimalPlace /= 10;
                a = a.Next;
            }
            return sum;
        }
    }
}
