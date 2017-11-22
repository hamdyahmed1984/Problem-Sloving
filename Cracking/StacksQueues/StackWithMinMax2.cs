using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.StacksQueues
{
    class StackNode2
    {
        public int Data;
        public StackNode2 Next;
        public StackNode2(int data)
        {
            this.Data = data;
        }
    }
    class StackWithMinMax2
    {
        StackNode2 top;

        StackNode2 minStack;
        public StackWithMinMax2()
        {

        }

        public void Push(int data)
        {
            StackNode2 tmp = new StackNode2(data);
            tmp.Next = top;
            top = tmp;
            if (data < Min())
            {
                StackNode2 min = new StackNode2(data);
                if (minStack == null)
                    minStack = min;
                else
                {
                    min.Next = minStack;
                    minStack = min;
                }
            }
        }
        public int Pop()
        {
            if(top == null)
                throw new InvalidOperationException("Stack is empty.");
            int data = top.Data;
            //Change min
            if (data == Min())
                minStack = minStack.Next;

            top = top.Next;
            return data;
        }
        public int Peek()
        {
            if (top == null)
                throw new InvalidOperationException("Stack is empty.");
            return top.Data;
        }
        public bool IsEmpty()
        {
            return top == null;
        }

        public int Min()
        {
            if (minStack == null)
                return int.MaxValue;
            else
                return minStack.Data;
        }
    }
}
