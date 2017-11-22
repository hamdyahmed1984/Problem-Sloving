using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Graphs
{
    class Predecessor_Successor
    {
        public static void Test()
        {
            TreeNode root = new TreeNode(50);
            root.Insert(17);
            root.Insert(72);
            root.Insert(12);
            root.Insert(23);
            root.Insert(9);
            root.Insert(14);
            root.Insert(19);
            root.Insert(54);
            root.Insert(76);
            root.Insert(67);

            TreeNode predecessor1 = null;
            TreeNode successor1 = null;
            GetPredecessorAndSuccessor_1(root.GetNode(19), ref predecessor1, ref successor1);

            TreeNode predecessor2 = null;
            TreeNode successor2 = null;
            GetPredecessorAndSuccessor_2(root, ref predecessor2, ref successor2, 19);
        }

        /// <summary>
        /// Use this if you want ot get the predecessor and successor of a node where this node knows about tis parent
        /// </summary>
        /// <param name="root"></param>
        /// <param name="predecessor"></param>
        /// <param name="successor"></param>
        private static void GetPredecessorAndSuccessor_1(TreeNode root, ref TreeNode predecessor, ref TreeNode successor)
        {
            if (root == null)
                return;
            //Get successor from the min node in the right subtree of the current node
            if (root.Right != null)
                successor = root.Right.Min();//This gets the left most node of the right subtree of the current node which is the node with smallest value
            else
            {
                //We don't use the passed root node object directly as we will change it to get the required parent node.
                //Because if we change it, the original tree will be changed also.
                //So we use 2 temp nodes
                TreeNode current = root;
                TreeNode parent = root.Parent;
                // Go up until we're on left instead of right
                while (parent != null && parent.Left != current)
                {
                    current = parent;
                    parent = parent.Parent;
                }
                successor = parent;
            }
            //Get predecessor from the max node of the left subtree of the current node
            if(root.Left != null)
            {
                predecessor = root.Left.Max();//This gets the right most node of the left subtree of the current node which is the node with the max value 
            }
            else
            {
                //We don't use the passed root node object directly as we will change it to get the required parent node.
                //Because if we change it, the original tree will be changed also.
                //So we use 2 temp nodes
                TreeNode current = root;
                TreeNode parent = root.Parent;
                // Go up until we're on right instead of left
                while (parent != null && parent.Right != current)
                {
                    current = parent;
                    parent = parent.Parent;
                }
                predecessor = parent;
            }
        }

        /// <summary>
        /// Use this if the node you want to find the successor and predecessor for doesn't know about its parent.
        /// Here you start from the original root node of the tree and deep until you find the key node.
        /// If you found the key node you get its predecessor and successor.
        /// If it is nor existing in the tree you get the two values which this key should lie between.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="predecessor"></param>
        /// <param name="successor"></param>
        /// <param name="val"></param>
        private static void GetPredecessorAndSuccessor_2(TreeNode root, ref TreeNode predecessor, ref TreeNode successor, int val)
        {
            if (root == null)
                return;
            if(root.Data > val)
            {
                successor = root;
                GetPredecessorAndSuccessor_2(root.Left, ref predecessor, ref successor, val);
            }
            else if(root.Data < val)
            {
                predecessor = root;
                GetPredecessorAndSuccessor_2(root.Right, ref predecessor, ref successor, val);
            }
            else//equals
            {
                if (root.Right != null)
                    successor = root.Right.Min();
                if (root.Left != null)
                    predecessor = root.Left.Max();
                return;
            }
        }
    }
}
