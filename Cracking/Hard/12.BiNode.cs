using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Hard
{
    /// <summary>
    /// 17.12 BiNode: Consider a simple data structure called BiNode, which has pointers to two other nodes. The
    ///    data structure BiNode could be used to represent both a binary tree(where node1 is the left node
    ///    and node2 is the right node) or a doubly linked list(where node1 is the previous node and node2
    ///    is the next node). Implement a method to convert a binary search tree(implemented with BiNode)
    ///into a doubly linked list.The values should be kept in order and the operation should be performed
    ///in place(that is, on the original data structure).
    /// </summary>
    public class BiNodeDS
    {
        /// <summary>
        /// O(N^2), due to getting the tail
        /// Instead of returning the head and tail of the linked list with NodePair, we can return just the head, and
        /// then we can use the head to find the tail of the linked list.
        /// 
        /// A leaf node at depth d will be "touched" by the getTail method d times (one for each node above it), 
        /// leading to an 0(N2 ) overall runtime, where N is the number of nodes in the tree.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public BiNode ConvertBST_ToDLL(BiNode root)
        {
            if (root == null) return null;
            BiNode left = ConvertBST_ToDLL(root.Node1);
            BiNode right = ConvertBST_ToDLL(root.Node2);

            if(left != null)
            {
                BiNode tail = GetTail(left);
                Concat(tail, root);
            }
            if(right != null)
            {
                Concat(root, right);
            }

            return left == null ? root : left;
        }
        private BiNode GetTail(BiNode node)
        {
            if (node == null) return null;
            while(node.Node2 != null)
            {
                node = node.Node2;
            }
            return node;
        }

        private void Concat(BiNode x, BiNode y)
        {
            x.Node2 = y;
            y.Node1 = x;
        }

        /// <summary>
        /// O(N)
        /// 
        /// Using Additional Data Structure.
        /// create a new data structure called BiNodePair which holds just the head and tail of a linked list.
        /// The convert method can then return something of type BiNodePair.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public BiNodePair ConvertBST_ToDLL2(BiNode root)
        {
            if (root == null) return null;
            BiNodePair left = ConvertBST_ToDLL2(root.Node1);
            BiNodePair right = ConvertBST_ToDLL2(root.Node2);

            if(left != null)
            {
                Concat(left.Tail, root);
            }
            if(right != null)
            {
                Concat(root, right.Head);
            }

            return new BiNodePair(left == null ? root : left.Head, right == null ? root : right.Tail);
        }

        /// <summary>
        /// This is not in place by the way
        /// </summary>
        /// <param name="root"></param>
        public void ConvertBST_ToDLL3(BiNode root)
        {
            if (root == null) return;
            ConvertBST_ToDLL3(root.Node1);
            AddNode(root);
            ConvertBST_ToDLL3(root.Node2);
        }
        private BiNode head, tail;
        private void AddNode(BiNode node)
        {
            if(head == null)
            {
                head = tail = node;
                head.Node1 = head.Node2 = null;
            }
            else
            {
                tail.Node2 = node;
                node.Node1 = tail;
                tail = node;
            }
        }

        public string PrintList(BiNode root)
        {
            StringBuilder sb = new StringBuilder();
            while(root != null)
            {
                sb.Append(root.Value);
                if (root.Node2 != null)
                    sb.Append(" --> ");
                root = root.Node2;
            }
            return sb.ToString();
        }

        public class BiNodePair
        {
            public BiNode Head { get; set; }
            public BiNode Tail { get; set; }
            public BiNodePair(BiNode h, BiNode t)
            {
                this.Head = h;
                this.Tail = t;
            }
        }
        public class BiNode
        {
            public BiNode Node1 { get; set; }
            public BiNode Node2 { get; set; }
            public int Value { get; set; }
            public BiNode(int val)
            {
                this.Value = val;
            }
        }
    }
}
