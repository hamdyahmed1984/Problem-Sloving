using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.StacksQueues
{
    class QueueUsing2Stacks
    {
        Stack<int> s1, s2;
        public QueueUsing2Stacks()
        {
            s1 = new Stack<int>();
            s2 = new Stack<int>();
        }

        public int Size()
        {
            return s1.Count + s2.Count;
        }
        public void Enqueue(int data)
        {
            s1.Push(data);
        }

        public int Pop()
        {
            TransferStacks();
            return s2.Pop();
        }

        public int Peek()
        {
            TransferStacks();
            return s2.Peek();
        }

        private void TransferStacks()
        {
            if(s2.Count == 0)
            {
                while(s1.Count > 0)
                {
                    s2.Push(s1.Pop());
                }
            }
        }
    }
}
