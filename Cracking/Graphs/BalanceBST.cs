using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Graphs
{
    class BalanceBST
    {
        public static void Test()
        {
            TreeNode root = new TreeNode(1);
            root.Insert(2);
            root.Insert(3);
            root.Insert(4);
            root.Insert(5);
            root.Insert(6);
            root.Insert(7);
            root.Insert(8);
            root.Insert(9);
            root.Insert(10);

            TreeNode newRoot = BalanceTheBST(root);
            newRoot.InOrder();//Print tree after balancing
        }

        private static TreeNode BalanceTheBST(TreeNode root)
        {
            List<int> sortedNodes = new List<int>();
            InOrder(root, sortedNodes);

            return BuildBalancedBST(sortedNodes, 0, sortedNodes.Count - 1);
        }

        private static TreeNode BuildBalancedBST(List<int> sortedNodes, int start, int end)
        {
            if (start > end)
                return null;
            int middle = (start + end) / 2;
            TreeNode root = new TreeNode(sortedNodes[middle]);
            root.Left = BuildBalancedBST(sortedNodes, start, middle - 1);
            root.Right = BuildBalancedBST(sortedNodes, middle + 1, end);

            return root;
        }

        private static void InOrder(TreeNode root, List<int> sortedNodes)
        {
            if(root != null)
            {
                InOrder(root.Left, sortedNodes);
                sortedNodes.Add(root.Data);
                InOrder(root.Right, sortedNodes);
            }
        }
    }
}
