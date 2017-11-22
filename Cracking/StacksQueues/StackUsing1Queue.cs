using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.StacksQueues
{
    class StackUsing1Queue
    {
        Queue<int> q = new Queue<int>();
        
        public void Push(int data)
        {
            q.Enqueue(data);
            for (int i = 0; i < q.Count - 1; i++)
            {
                q.Enqueue(q.Dequeue());
            }
        }

        public int Pop()
        {
            if (q.Count == 0)
                throw new InvalidOperationException("Queue is invalid.");
            return q.Dequeue();
        }
    }
}
