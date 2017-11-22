using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.StacksQueues
{
    class StackUsing2Queues
    {
        Queue<int> q1, q2;
        public StackUsing2Queues()
        {
            q1 = new Queue<int>();
            q2 = new Queue<int>();
        }

        public int Size()
        {
            return q2.Count + q1.Count;
        }

        public void Push(int data)
        {
            if (q1.Count == 0)
                q1.Enqueue(data);
            else
            {
                while(q1.Count > 0)
                {
                    q2.Enqueue(q1.Dequeue());
                }
                q1.Enqueue(data);
                while(q2.Count > 0)
                {
                    q1.Enqueue(q2.Dequeue());
                }
            }
        }
        public int Pop()
        {
            if (q1.Count == 0)
                throw new InvalidOperationException("Stack is empty :) .");
            return q1.Dequeue();
        }

        private void TransferQueues()
        {
            if(q1.Count == 0)
            {
                while(q2.Count > 0)
                {
                    q1.Enqueue(q2.Dequeue());
                }
            }
        }
    }
}
