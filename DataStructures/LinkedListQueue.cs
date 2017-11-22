using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class LinkedListQueue<T>
    {
        LinkedList<T> queue = new LinkedList<T>();
        public void Enqueue(T val)
        {
            queue.addAtTail(val);
        }
        public T Dequeue()
        {
            T firstInQueue = queue.getFirst();
            queue.removeHead();
            return firstInQueue;
        }
        public string displayQueue()
        {
            return queue.printList();
        }
    }
}
