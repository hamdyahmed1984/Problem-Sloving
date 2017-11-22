using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.LinkedLists
{
    class PartitionList
    {
        /// <summary>
        /// This algorithm preserves the order of elements in the main list.
        /// If we don't care the order of the pivoting element, we remove the equalStart and equalEnd lists and add the pivoting element to the greater list or smaller as we want
        /// </summary>
        /// <param name="n"></param>
        /// <param name="pivot"></param>
        /// <returns></returns>
        public static Node PartitionListAroundValue1(Node n, int pivot)
        {
            Node smallerStart = null, smallerEnd = null, equalStart = null, equalEnd = null, greaterStart = null, greaterEnd = null;            
            while(n != null)
            {
                Node next = n.Next;
                n.Next = null;
                if (n.data < pivot)
                {
                    if(smallerStart == null)
                    {
                        smallerStart = smallerEnd = n;
                    }
                    else
                    {                                                
                        smallerEnd.Next = n;
                        smallerEnd = n;
                    }
                }
                else if(n.data > pivot)
                {
                    if(greaterStart == null)
                    {
                        greaterStart = greaterEnd = n;
                    }
                    else
                    {                        
                        greaterEnd.Next = n;
                        greaterEnd = n;
                    }
                }
                else
                {
                    if (equalStart == null)
                    {
                        equalStart = equalEnd = n;
                    }
                    else
                    {
                        equalEnd.Next = n;
                        equalEnd = n;
                    }
                }
                n = next;
            }
            if (smallerStart == null)
            {
                if (equalStart == null)
                    return greaterStart;
                equalEnd.Next = greaterStart;
                return equalStart;
            }
            if(equalStart == null)
            {
                smallerEnd.Next = greaterStart;
                return smallerStart;
            }

            smallerEnd.Next = equalStart;
            equalEnd.Next = greaterStart;

            smallerStart.PrintList();

            return smallerStart;
        }

        /// <summary>
        /// This algorith DOESNOT preserve elements order
        /// </summary>
        /// <param name="node"></param>
        /// <param name="pivot"></param>
        /// <returns></returns>
        public static Node PartitionListAroundValue2(Node node, int pivot)
        {
            Node head = node, tail = node;
            while(node != null)
            {
                Node next = node.Next;
                if(node.data < pivot)
                {
                    node.Next = head;
                    head = node;
                }
                else
                {
                    tail.Next = node;
                    tail = node;
                }
                node = next;
            }
            tail.Next = null;

            head.PrintList();
            return head;
        }
        public static Node partition(Node node, int x)
        {
            Node head = node;
            Node tail = node;

            while (node != null)
            {
                Node next = node.Next;
                if (node.data < x)
                {
                    /* Insert node at head. */
                    node.Next = head;
                    head = node;
                }
                else
                {
                    /* Insert node at tail. */
                    tail.Next = node;
                    tail = node;
                }
                node = next;
            }
            tail.Next = null;

            // The head has changed, so we need to return it to the user.
            return head;
        }

        public static Node SplitListAndReturnSecondHalf(Node node)
        {
            Node runner = node.Next;
            while(runner != null)
            {
                node = node.Next;
                runner = runner.Next;
                if (runner != null)
                    runner = runner.Next;
            }
            Node secondPart = node.Next;//Keep the pointer to the second part
            node.Next = null;//Empty the pointer to the second part so the list is splitted
            return secondPart;
        }
    }
}
