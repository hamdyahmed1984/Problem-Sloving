using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.StacksQueues
{
    class MyQueue<T>
    {
        class QueueNode<T>
        {
            public T Data;
            public QueueNode<T> Next;
            public QueueNode(T data)
            {
                this.Data = data;
            }
        }

        QueueNode<T> first, last;

        public void Enqueue(T data)
        {
            QueueNode<T> tmp = new QueueNode<T>(data);
            if (last != null)
                last.Next = tmp;
            last = tmp;
            if (first == null)
                first = last;
        }

        public T Dequeue()
        {
            if (first == null)
                throw new InvalidOperationException("Queue is empty.");
            T data = first.Data;
            first = first.Next;
            if (first == null)
                last = null;
            return data;
        }

        public T Peek()
        {
            if (first == null)
                throw new InvalidOperationException("Queue is empty.");
            return first.Data;
        }

        public bool IsEmpty()
        {
            return first == null;
        }
    }
}
