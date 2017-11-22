using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.StacksQueues
{
    class ReverseStack
    {
        public static void Test()
        {
            Stack<int> s = new Stack<int>();
            s.Push(1);
            s.Push(2);
            s.Push(3);
            Reverse(s);
        }

        /// <summary>
        /// Time: O(N^2)
        /// Space: O(2N)
        /// </summary>
        /// <param name="s"></param>
        private static void Reverse(Stack<int> s)
        {
            if(s.Count > 0)
            {
                int tmp = s.Pop();
                Reverse(s);
                InsertAtBottom(s, tmp);
            }
        }

        /// <summary>
        /// Time: O(N)
        /// Space: O(N)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="val"></param>
        private static void InsertAtBottom(Stack<int> s, int val)
        {
            if(s.Count == 0)
            {
                s.Push(val);
            }
            else
            {
                int tmp = s.Pop();
                InsertAtBottom(s, val);
                s.Push(tmp);
            }
        }
    }
}
