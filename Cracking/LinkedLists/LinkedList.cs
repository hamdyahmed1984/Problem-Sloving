using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.LinkedLists
{
    public class Node
    {
        public Node Next;
        public int data;
        public Node child;
        public Node(int data)
        {
            this.data = data;
        }

        public void PrintList()
        {
            for(Node current = this; current != null; current = current.Next)
            {
                Console.WriteLine(current.data);
            }
        }
    }
    public class LinkedList
    {
        public Node Head { get; set; }

        private int _count;
        public int Count { get { return _count; } }

        public void Append(int data)
        {
            if (Head == null)
            {
                Head = new Node(data);
                return;
            }
            Node current = Head;
            while(current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node(data);
            _count++;
        }

        public void Prepend(int data)
        {
            Node current = new Node(data);
            if (Head == null)
                Head = current;
            else
            {
                current.Next = Head;
                Head = current;             
            }
            _count++;
        }

        public void Delete(int data)
        {
            if (Head == null)
                return;
            if (Head.data == data)
            {
                Head = Head.Next;
                _count--;
            }
            else
            {
                Node current = Head;
                while (current.Next != null)
                {
                    if (current.Next.data == data)
                    {
                        current.Next = current.Next.Next;
                        _count--;
                        return;
                    }
                    current = current.Next;
                }
            }
        }

        public bool AddAfter(int afterThis, int data)
        {
            Node theAfterNode = FindNode(afterThis);
            if(theAfterNode != null)
            {
                Node current = new Node(data)
                {
                    Next = theAfterNode.Next
                };
                theAfterNode.Next = current;
                _count++;
                return true;
            }
            return false;
        }

        public bool AddBefore(int beforeThis, int data)
        {
            if (Head == null)
                return false;
            if(Head.data == beforeThis)
            {
                Node newHead = new Node(data);
                newHead.Next = Head;
                Head = newHead;
                _count++;
                return true;
            }
            Node current = Head;
            while(current.Next != null)
            {
                if(current.Next.data == beforeThis)
                {
                    Node newNode = new Node(data);
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    _count++;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public Node FindNode(int data)
        {
            if (Head == null)
                return null;
            if (Head.data == data)
                return Head;
            Node current = Head.Next;
            while(current != null)
            {
                if (current.data == data)
                    return current;
                current = current.Next;
            }
            return null;
        }
    }
}
