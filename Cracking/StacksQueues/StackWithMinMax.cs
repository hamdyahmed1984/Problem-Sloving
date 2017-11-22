using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.StacksQueues
{
    class StackNodeMinMax
    {
        public int Data;
        public StackNodeMinMax Next;
        public int Min;
        public int Max;
        public StackNodeMinMax(int data, int min, int max)
        {
            this.Data = data;
            this.Min = min;
            this.Max = max;
        }
    }
    class StackWithMinMax
    {
        StackNodeMinMax top;
        
        public void Push(int data)
        {
            int min = Math.Min(data, Min());
            int max = Math.Max(data, Max());
            StackNodeMinMax tmp = new StackNodeMinMax(data, min, max);
            tmp.Next = top;
            top = tmp;
        }
        public int Pop()
        {
            if(top == null)
                throw new InvalidOperationException("Stack is empty.");
            int data = top.Data;
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
            if (top == null)
                return int.MaxValue;
            else
                return top.Min;
        }
        public int Max()
        {
            if (top == null)
                return int.MinValue;
            else
                return top.Max;
        }
    }
}
