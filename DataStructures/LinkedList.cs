using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class LinkedList<T>
    {
      Node<T> Head { get; set; }
        //public LinkedList()
        //{
        //    Head = null;
        //}

        public T getFirst()
        {
            return Head != null ? Head.Value : default(T);
        }

        public T getLast()
        {
            if (Head == null)
                return default(T);
            var current = Head;
            while(current.Next != null)
            {
                current = current.Next;
            }
            return current.Value;
        }
        public void addAtHead(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if(Head == null)
            {
                Head = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }
        }
        public void addAtTail(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if(Head == null)
            {
                Head = newNode;
            }
            else
            {
                var current = Head;
                while(current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }
        public bool deleteNode(T value)
        {
            Node<T> current = Head;
            if(current.Value.Equals(value))
            {
                Head = Head.Next;
                return true;
            }
            Node<T> currentPre = Head;
            while(current != null)
            {
                if(current.Value.Equals(value))
                {
                    currentPre.Next = current.Next;
                    current = null;
                    return true;
                }
                currentPre = current;
                current = current.Next;
            }
            return false;
        }

        public T removeHead()
        {
            if (Head == null)
                return default(T);            
            Head = Head.Next;
            return Head != null ? Head.Value : default(T);
        }
        public bool addAfter(T oldValue, T newValue)
        {
            if (Head == null)
                return false;
            var current = Head;
            while (current != null)
            {
                if(getNode(oldValue) != null)
                {
                    Node<T> newNode = new Node<T>(newValue);
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return true;
                }
                current = current.Next;
            }
                return false;
        }
        public bool addBefore(T oldValue, T newValue)
        {
            if (Head == null)
                return false;
            var current = Head;
            var currentPre = Head;
            while(current != null)
            {
                if(current.Value.Equals(oldValue))
                {
                    Node<T> newNode = new Node<T>(newValue);
                    newNode.Next = current;
                    currentPre.Next = newNode;
                    return true;
                }
                currentPre = current;
                current = current.Next;
            }
            return false;
        }
        public Node<T> getNode(T value)
        {
            Node<T> current = Head;
            while(current != null)
            {
                if (current.Value.Equals(value))
                    return current;
                current = current.Next;
            }
            return null;
        }
        public string printList()
        {
            if (Head == null)
                return "The list is empty";
            StringBuilder sbList = new StringBuilder();
            var current = Head;            
            while(current != null)
            {
                sbList.AppendLine(current.Value.ToString());
                current = current.Next;
            }
            return sbList.ToString();
        }
    }
    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }
}
