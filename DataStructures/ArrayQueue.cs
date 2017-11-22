using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class ArrayQueue<T>
    {
        T[] arr;
        int _arraySize = 3;
        int _enqueueIndex = 0;

        public ArrayQueue()
        {
            arr = new T[_arraySize];
        }
        public ArrayQueue(int arraySize):this()
        {
            _arraySize = arraySize;
        }

        public void Enqueue(T val)
        {
            if (_enqueueIndex == arr.Length)
                Array.Resize(ref arr, arr.Length + 1);
            arr[_enqueueIndex++] = val;
        }
        public T Dequeue()
        {
            T val = arr[--_enqueueIndex];
            arr[_enqueueIndex] = default(T);
            return val;
        }
        public string displayQueue()
        {
            StringBuilder sb = new StringBuilder();
            for(int i=0; i<arr.Length;i++)
            {
                sb.AppendLine(arr[i].ToString());
            }
            return sb.ToString();
        }
    }
}
