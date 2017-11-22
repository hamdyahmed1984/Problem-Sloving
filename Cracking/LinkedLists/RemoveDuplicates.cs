using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.LinkedLists
{
    public class RemoveDuplicates
    {
        /// <summary>
        /// Runtime: O(N)
        /// Space: O(N)
        /// </summary>
        /// <param name="node"></param>
        public static void RemoveDups1(Node node)
        {
            HashSet<int> set = new HashSet<int>();
            Node prevNode = node;
            while(node != null)
            {
                if (set.Contains(node.data))
                {
                    prevNode.Next = node.Next;
                }
                else
                {
                    set.Add(node.data);
                    prevNode = node;
                }                
                node = node.Next;
            }
        }
        /// <summary>
        /// Runtime: O(N^2)
        /// Space: O(1)
        /// </summary>
        public static void RemoveDups2(Node node)
        {
            Node current = node;
            while(current != null)
            {
                Node runner = current;
                while(runner.Next != null)
                {
                    if (current.data == runner.Next.data)
                    {
                        runner.Next = runner.Next.Next;
                    }
                    else
                    {
                        runner = runner.Next;
                    }
                }
                current = current.Next;
            }
        }
    }
}
