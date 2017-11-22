using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class ArrayStack<T>
    {
        int _topOfStack = 0;
        int _stackSize = 3;
        T[] arr;

        public ArrayStack()
        {
            arr = new T[_stackSize];
        }
        public ArrayStack(int stackSize) : this()
        {
            _stackSize = stackSize;
        }
        public void push(T val)
        {
            if (_topOfStack == arr.Length)
                Array.Resize(ref arr, arr.Length + 1);
            arr[_topOfStack++] = val;
        }
        public T pop()
        {
            if (isEmpty())
                return default(T);
            T ret = arr[--_topOfStack];
            arr[_topOfStack] = default(T);
            return ret;
        }
        public T peek()
        {
            if (isEmpty())
                return default(T);
            return arr[_topOfStack - 1];
        }
        public bool isEmpty()
        {
            return _topOfStack == 0;
        }
        public string displayStack()
        {
            StringBuilder sb = new StringBuilder();
            for(int i=0; i<_topOfStack;i++)
            {
                sb.AppendLine(arr[i].ToString());
            }
            return sb.ToString();
        }
    }
}
