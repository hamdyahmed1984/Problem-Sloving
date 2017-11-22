using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.LinkedLists
{
    class KthElementFromLast
    {
        public static void GetKthElementFromLast(Node node, int k)
        {

            Console.WriteLine(k + "th element from the last is: " + GetKthElementFromLast2(node, k).data);
            Console.WriteLine(k + "th element from the last is: " + GetKthElementFromLast3(node, k).data);

            int distanceFromLast = 0;
            Console.WriteLine(k + "th element from the last is: " + GetKthElementFromLast1(node, k, ref distanceFromLast).data);
        }

        /// <summary>
        /// Runtime: O(N)
        /// Space: O(N)
        /// </summary>
        /// <param name="node"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static Node GetKthElementFromLast1(Node node, int k, ref int distanceFromLast)
        {
            if (node == null)
                return null;
            Node KthNodeFromLast = GetKthElementFromLast1(node.Next, k, ref distanceFromLast);
            distanceFromLast++;
            if (distanceFromLast == k)
                return node;
            return KthNodeFromLast;
        }

        /// <summary>
        /// Runtime: O(N)
        /// Space: O(1)
        /// </summary>
        /// <param name="node"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static Node GetKthElementFromLast2(Node node, int k)
        {
            int listLength = 0;
            Node current = node;
            while(current != null)
            {
                listLength++;
                current = current.Next;
            }

            int indexOfKthElementFromLast = listLength - k;
            if (indexOfKthElementFromLast < 0)
                return null;
            for(int i = 0; i < indexOfKthElementFromLast; i++)
            {
                node = node.Next;
            }
            return node;
        }

        /// <summary>
        /// Runtime: O(N)
        /// Space: O(1)
        /// </summary>
        /// <param name="node"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static Node GetKthElementFromLast3(Node node, int k)
        {
            Node p1 = node;
            Node p2 = node;
            //We will make p2 in a distance = k from p1
            for (int i = 0; i < k; i++)
            {
                if (p2 == null)
                    return null;
                p2 = p2.Next;
            }
            while(p2 != null)
            {
                p1 = p1.Next;
                p2 = p2.Next;
            }
            return p1;
        }
    }
}
