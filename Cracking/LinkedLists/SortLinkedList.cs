using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.LinkedLists
{
    class SortLinkedList
    {
        public static Node Sort(Node node)
        {
            if (node == null) return null;
            int pivot = node.data;
            Node lessStart = null, lessEnd = null, equalStart = null, equalEnd= null, greaterStart = null, greaterEnd = null;            
            while(node != null)
            {
                Node next = node.Next;
                node.Next = null;
                if(node.data < pivot)
                {
                    if(lessStart == null)
                    {
                        lessStart = lessEnd = node;
                    }
                    else
                    {
                        lessEnd.Next = node;
                        lessEnd = node;
                    }
                }
                else if(node.data > pivot)
                {
                    if(greaterStart == null)
                    {
                        greaterStart = greaterEnd = node;
                    }
                    else
                    {
                        greaterEnd.Next = node;
                        greaterEnd = node;
                    }
                }
                else
                {
                    if(equalStart == null)
                    {
                        equalStart = equalEnd = node;
                    }
                    else
                    {
                        equalEnd.Next = node;
                        equalEnd = node;
                    }
                }
                node = next;
            }
            if(lessStart == null)
            {
                if (equalStart == null)
                    return greaterStart;
                equalEnd.Next = greaterStart;
                return equalStart;
            }
            if (equalStart == null)
            {
                lessEnd.Next = greaterStart;
                return lessStart;
            }
            lessEnd.Next = equalStart;
            equalEnd.Next = greaterStart;

            return lessStart;
        }
    }
}
