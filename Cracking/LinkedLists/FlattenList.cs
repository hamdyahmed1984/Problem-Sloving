using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.LinkedLists
{
    class FlattenList
    {
        public static void FlattenListNodes()
        {
            Node n10 = new Node(10);
            Node n5 = new Node(5);
            Node n12 = new Node(12);
            Node n7 = new Node(7);
            Node n11 = new Node(11);

            Node n4 = new Node(4);
            Node n20 = new Node(20);
            Node n13 = new Node(13);

            Node n17 = new Node(17);
            Node n6 = new Node(6);

            Node n2 = new Node(2);
            Node n16 = new Node(16);
            Node n9 = new Node(9);
            Node n8 = new Node(8);

            Node n3 = new Node(3);
            Node n19 = new Node(19);
            Node n15 = new Node(15);

            n10.Next = n5;
            n5.Next = n12;
            n12.Next = n7;
            n7.Next = n11;

            n4.Next = n20;
            n20.Next = n13;

            n17.Next = n6;

            n9.Next = n8;

            n19.Next = n15;

            n10.child = n4;
            n7.child = n17;
            n20.child = n2;
            n13.child = n16;
            n16.child = n3;
            n17.child = n9;
            n9.child = n19;
            FlattenChildrenAfterParent(n10);
        }

        public static void FlattenChildrenAfterTail(Node n)
        {
            Node tail = n;
            while (tail.Next != null)
                tail = tail.Next;

            Node cur = n;
            while (cur != null)
            {
                if (cur.child != null)
                {
                    tail.Next = cur.child;
                    Node child = cur.child;
                    while (child.Next != null)
                    {
                        child = child.Next;
                    }
                    tail = child;
                }
                cur = cur.Next;
            }

            Node toPrint = n;
            while (toPrint != null)
            {
                Console.Write(toPrint.data);
                if (toPrint.Next != null)
                    Console.Write(" --> ");
                toPrint = toPrint.Next;
            }
        }

        public static void FlattenChildrenAfterParent(Node n)
        {
            Node cur = n;
            while (cur != null)
            {
                if (cur.child != null)
                {
                    Node child = cur.child;
                    Node curNext = cur.Next;
                    cur.Next = child;
                    
                    while(child.Next != null)
                    {
                        child = child.Next;
                    }

                    child.Next = curNext;
                }
                cur = cur.Next;
            }

            Node toPrint = n;
            while (toPrint != null)
            {
                Console.Write(toPrint.data);
                if (toPrint.Next != null)
                    Console.Write(" --> ");
                toPrint = toPrint.Next;
            }
        }
    }
}
