using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class LinkedListStack<T>
    {
        LinkedList<T> lst = new LinkedList<T>();
        public void push(T val)
        {
            lst.addAtHead(val);
        }
        public T pop()
        {
            return lst.removeHead();
        }
        public T peek()
        {
            return lst.getFirst();
        }
        public string displayStack()
        {
            return lst.printList();
        }
    }
}
