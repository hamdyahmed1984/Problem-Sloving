using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.StacksQueues
{
    class SortStack
    {
        public static void Test()
        {
            Stack<int> s = new Stack<int>();
            s.Push(2);
            s.Push(5);
            s.Push(1);
            s.Push(3);
            s.Push(4);

            Sort_1(s);
        }

        private static void Sort_1(Stack<int> s1)
        {
            Stack<int> s2 = new Stack<int>();
            while(s1.Count > 0)
            {
                int curr = s1.Pop();
                while(s2.Count > 0 && s2.Peek() > curr)
                {
                    s1.Push(s2.Pop());
                }
                s2.Push(curr);
            }
            //The next loop is to make s1 sorted in  such a way that the smallest item is in the top of the stack, otherwise we return s1 sorted in reverse order.
            while(s2.Count > 0)
            {
                s1.Push(s2.Pop());
            }
        }
    }
}
