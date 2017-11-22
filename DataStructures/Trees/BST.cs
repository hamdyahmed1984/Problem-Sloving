using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class Node<T>
    {
        private readonly IComparer<T> comparer = Comparer<T>.Default;
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node(T val)
        {
            Value = val;
        }

        public int Compare(T other)
        {
            return comparer.Compare(this.Value, other);//0:equal, -1:this is less,1:this is greater
        }
    }
    public class BST<T>
    {

        public Node<T> Root { get; set; }
        public int Count { get; set; }

        public BST()
        {
            Root = null;
            Count = 0;
        }

        public Node<T> insertNode(T val)
        {
            Node<T> newNode = new Node<T>(val);
            Count++;
            if (Root == null)
            {
                Root = newNode;                
                return newNode;
            }
            Node<T> current = Root;
            while (current != null)
            {
                if (newNode.Compare(current.Value) < 0)//left
                {
                    if (current.Left == null)
                    {
                        current.Left = newNode;
                        break;
                    }
                    current = current.Left;
                }
                else if (newNode.Compare(current.Value) > 0)//right
                {
                    if(current.Right == null)
                    {
                        current.Right = newNode;
                        break;
                    }
                    current = current.Right;
                }
                else
                {
                    throw new ArgumentException("BST should not contain duplicate values, the value " + val.ToString() +
                        " already exists");
                }
            }
            return newNode;
        }

        public Node<T> getNode(T val, out Node<T> parent)
        {
            parent = null;
            if (Root == null)
                return null;
            Node<T> current = Root;
            Node<T> newNode = new Node<T>(val);
            while (current != null)
            {
                int compareResult = newNode.Compare(current.Value);
                if (compareResult == 0)
                    return current;
                else if (compareResult < 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (compareResult > 0)
                {
                    parent = current;
                    current = current.Right;
                }
            }
            return null;
        }
        public Node<T> getNode(T val)
        {
            Node<T> parent = new Node<T>(default(T));
            return getNode(val, out parent);
        }

        public bool removeNode(T val)
        {
            Node<T> parent = null;
            Node<T> foundNode = getNode(val, out parent);
            if (foundNode == null)
                return false;
            Count--;
            List<Node<T>> childNodes = new List<Node<T>>();
            if (foundNode.Left != null)
            {
                List<Node<T>> leftNodes = new List<Node<T>>();
                inOrder(foundNode.Left, ref leftNodes);
                childNodes.AddRange(leftNodes);
            }
            if (foundNode.Right != null)
            {
                List<Node<T>> rightNodes = new List<Node<T>>();
                inOrder(foundNode.Right, ref rightNodes);
                childNodes.AddRange(rightNodes);
            }
            if(parent != null)
            {
                if (parent.Left == foundNode)
                    parent.Left = null;
                if (parent.Right == foundNode)
                    parent.Right = null;
            }
            foreach(Node<T> n in childNodes)
            {
                insertNode(n.Value);
                Count--;
            }

            return false;
        }

        public Node<T> getMaxNode()
        {
            if (Root == null)
                return null;
            Node<T> current = Root;
            while (current.Right != null)
                current = current.Right;
            return current;
        }

        public Node<T> getMinNode()
        {
            if (Root == null)
                return null;
            Node<T> current = Root;
            while (current.Left != null)
                current = current.Left;
            return current;
        }

        public void inOrder(Node<T> parent, ref List<Node<T>> lst)
        {
            if(parent != null)
            {
                inOrder(parent.Left, ref lst);
                lst.Add(parent);
                inOrder(parent.Right, ref lst);
            }
        }
        public void preOrder(Node<T> parent, ref List<Node<T>> lst)
        {
            if (parent != null)
            {
                lst.Add(parent);
                preOrder(parent.Left, ref lst);
                preOrder(parent.Right, ref lst);
            }
        }
        public void postOrder(Node<T> parent, ref List<Node<T>> lst)
        {
            if (parent != null)
            {
                postOrder(parent.Left, ref lst);
                postOrder(parent.Right, ref lst);
                lst.Add(parent);                
            }
        }
    }
}
