using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Graphs
{
    class ValidateBST
    {
        public static void Test()
        {
            TreeNode root = new TreeNode(20);
            root.Insert(10);
            root.Insert(30);
            root.Insert(5);
            root.Insert(15);
            root.Insert(3);
            root.Insert(7);
            root.Insert(17);

            TreeNode root2 = new TreeNode(20);
            root2.Insert(10);
            root2.Insert(30);
            root2.Insert(25);

            TreeNode root3 = new TreeNode(20);
            root3.Insert(20);

            Console.WriteLine(ValidateBST_AllowDuplicates(root));
            Console.WriteLine(ValidateBST_NoDuplicates1(root));
            Console.WriteLine(ValidateBST_NoDuplicates_2(root));

            Console.WriteLine(ValidateBST_AllowDuplicates(root2));
            Console.WriteLine(ValidateBST_NoDuplicates1(root2));
            Console.WriteLine(ValidateBST_NoDuplicates_2(root2));

            Console.WriteLine(ValidateBST_AllowDuplicates(root3));
            Console.WriteLine(ValidateBST_NoDuplicates1(root3));
            Console.WriteLine(ValidateBST_NoDuplicates_2(root3));
        }

        private static bool ValidateBST_AllowDuplicates(TreeNode root)
        {
            return ValidateBST_AllowDuplicates(root, int.MinValue, int.MaxValue);
        }
        /// <summary>
        /// This is the optimal solution that validates binary trees even if the tree allows duplicates
        /// </summary>
        /// <param name="root"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private static bool ValidateBST_AllowDuplicates(TreeNode root, int min, int max)
        {
            if (root == null)
                return true;
            if (root.Data <= min || root.Data > max)
                return false;
            if (!ValidateBST_AllowDuplicates(root.Left, min, root.Data) || !ValidateBST_AllowDuplicates(root.Right, root.Data, max))
                return false;
            return true;
        }

        static int? lastVisitedNode = null;
        /// <summary>
        /// This can be used inly if the tree doesn't allow duplicates
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static bool ValidateBST_NoDuplicates1(TreeNode root)
        {
            if (root == null)
                return true;
            if (!ValidateBST_NoDuplicates1(root.Left))
                return false; ;
            if (lastVisitedNode.HasValue && root.Data <= lastVisitedNode.Value)
                return false;
            lastVisitedNode = root.Data;
            if (!ValidateBST_NoDuplicates1(root.Right))
                return false;
            return true;
        }

        /// <summary>
        /// This can be used inly if the tree doesn't allow duplicates
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static bool ValidateBST_NoDuplicates_2(TreeNode root)
        {
            List<int> sortedNodes = new List<int>();
            InOrder(root, sortedNodes);
            for (int i = 1; i < sortedNodes.Count; i++)
                if (sortedNodes[i - 1] >= sortedNodes[i])
                    return false;
            return true;
        }
        private static void InOrder(TreeNode root, List<int> sortedNodes)
        {
            if (root != null)
            {
                InOrder(root.Left, sortedNodes);
                sortedNodes.Add(root.Data);
                InOrder(root.Right, sortedNodes);
            }
        }
    }
}
