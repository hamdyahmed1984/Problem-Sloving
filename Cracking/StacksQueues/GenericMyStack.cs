using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.StacksQueues
{
    class MyStack<T>
    {
        private class StackNode<T>
        {
            public T Data;
            public StackNode<T> Next;
            public StackNode(T data)
            {
                this.Data = data;
            }
        }

        StackNode<T> top;
        
        public void Push(T data)
        {
            StackNode<T> tmp = new StackNode<T>(data);
            tmp.Next = top;
            top = tmp;
        }

        public T Pop()
        {
            if (top == null)
                throw new InvalidOperationException("Stack is empty.");
            T data = top.Data;
            top = top.Next;
            return data;
        }

        public T Peek()
        {
            if (top == null)
                throw new InvalidOperationException("Stack is empty.");
            return top.Data;
        }

        public bool IsEmpty()
        {
            return top == null;
        }
    }
}
