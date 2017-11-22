using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Trees;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            BST<int> bst = new BST<int>();
            bst.insertNode(5);
            bst.insertNode(2);
            bst.insertNode(8);
            bst.insertNode(6);
            bst.insertNode(10);
            bst.insertNode(1);            
            bst.insertNode(4);
            bst.insertNode(3);
            bst.insertNode(7);
            bst.insertNode(9);

            bst.removeNode(8);

            var x = bst.getNode(4);
            Console.WriteLine(x.Value.ToString());
            Trees.Node<int> parent=null;
            var xx = bst.getNode(2, out parent);
            Console.WriteLine(x.Value.ToString());
            var max = bst.getMaxNode();
            Console.WriteLine(max != null ? max.Value.ToString() : "NONE");
            var min = bst.getMinNode();
            Console.WriteLine(min != null ? min.Value.ToString() : "NONE");



            List<Trees.Node<int>> lst = new List<Trees.Node<int>>();
            bst.inOrder(bst.Root, ref lst);
            lst = new List<Trees.Node<int>>();
            bst.preOrder(bst.Root, ref lst);
            lst = new List<Trees.Node<int>>();
            bst.postOrder(bst.Root, ref lst);



            //var lst = bst.Traversal(bst.Root);

            //ArrayQueue<int> queue = new ArrayQueue<int>();
            //for (int i = 1; i <= 5; i++)
            //{
            //    queue.Enqueue(i);
            //}
            //Console.WriteLine(queue.displayQueue());

            //for (int i = 1; i <= 7; i++)
            //{
            //    Console.WriteLine(queue.Dequeue());
            //}
            //Console.WriteLine(queue.displayQueue());




            //LinkedListQueue<int> queue = new LinkedListQueue<int>();
            //for(int i=1; i<=5; i++)
            //{
            //    queue.Enqueue(i);
            //}
            //Console.WriteLine(queue.displayQueue());

            //for (int i = 1; i <= 7; i++)
            //{
            //    Console.WriteLine(queue.Dequeue());
            //}
            //Console.WriteLine(queue.displayQueue());



            //LinkedListStack<int> stack = new LinkedListStack<int>();
            //for (int i = 1; i <= 5; i++)
            //    stack.push(i);
            //Console.WriteLine(stack.displayStack());
            //Console.WriteLine(stack.peek());
            //Console.WriteLine(stack.pop());
            //ArrayStack<int> stack = new ArrayStack<int>();
            //for (int i = 1; i <= 5; i++)
            //    stack.push(i);
            //Console.WriteLine(stack.displayStack());
            //Console.WriteLine(stack.pop());
            //Console.WriteLine(stack.peek());
            //Console.WriteLine(stack.pop());
            //Console.WriteLine(stack.pop());
            //Console.WriteLine(stack.pop());
            //Console.WriteLine(stack.pop());
            //Console.WriteLine(stack.pop());
            //stack.push(7);
            //Console.WriteLine(stack.pop());
            //Console.WriteLine(stack.displayStack());
            //Console.WriteLine(stack.peek());



            //LinkedList<int> lst = new LinkedList<int>();
            //Console.WriteLine(lst.printList());
            //lst.addAtHead(1);
            //Console.WriteLine(lst.printList());
            //lst.addAtTail(5);
            //Console.WriteLine(lst.printList());
            //lst.addBefore(5, 4);
            //Console.WriteLine(lst.printList());
            //lst.addAfter(1, 2);
            //Console.WriteLine(lst.printList());
            //lst.addBefore(4, 3);
            //Console.WriteLine(lst.printList());

            //lst.deleteNode(3);
            //Console.WriteLine(lst.printList());
            //lst.deleteNode(1);
            //Console.WriteLine(lst.printList());
            //lst.deleteNode(5);
            //Console.WriteLine(lst.printList());

            //var node = lst.getNode(2);
            //Console.WriteLine(node.Value);
            //node = lst.getNode(3);
            //Console.WriteLine(node != null ? node.Value.ToString() : "null");
            Console.ReadLine();
        }
    }
}
