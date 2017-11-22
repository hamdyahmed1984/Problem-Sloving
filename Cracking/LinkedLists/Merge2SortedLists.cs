using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.LinkedLists
{
    class Merge2SortedLists
    {
        public static Node Merge1(Node a, Node b)
        {
            Node merged;
            if (a == null)
                return b;
            else if (b == null)
                return a;
            if(a.data <= b.data)
            {
                merged = a;
                merged.Next = Merge1(a.Next, b);
            }
            else
            {
                merged = b;
                merged.Next = Merge1(a, b.Next);
            }
            return merged;
        }

        public static Node Merge2(Node a, Node b)
        {
            if (a == null)
                return b;
            if (b == null)
                return a;
            Node result = new Node(-1);//a.data < b.data ? a : b;
            Node tail = result;
            while(true)
            {
                if(a == null)
                {
                    tail.Next = b;
                    break;
                }
                else if(b == null)
                {
                    tail.Next = a;
                    break;
                }
                else
                {
                    if(a.data <= b.data)
                    {                        
                        tail.Next = a;
                        tail = a;
                        a = a.Next;
                    }
                    else
                    {
                        tail.Next = b;
                        tail = b;
                        b = b.Next;
                    }
                }
            }

            result.Next.PrintList();
            return result.Next;
        }
    }
}
