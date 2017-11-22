using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Graphs
{
    class CheckBalanced
    {

        /// <summary>
        /// Runtime: O(N)
        /// Space: O(H), where H is the height of the tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool CheckIfTreeIsBalanced(TreeNode root)
        {
            return GetNodeHeight(root) != int.MinValue;
        }

        /// <summary>
        /// O(N)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static int GetNodeHeight(TreeNode root)
        {
            if (root == null) return -1;//base case

            int leftHeight = GetNodeHeight(root.Left);
            if (leftHeight == int.MinValue)
                return int.MinValue;

            int rightHeight = GetNodeHeight(root.Right);
            if (rightHeight == int.MinValue)
                return int.MinValue;

            int heightDiff = leftHeight - rightHeight;
            if (Math.Abs(heightDiff) > 1)
                return int.MinValue;
            else
                return Math.Max(leftHeight, rightHeight) + 1;
        }

        /// <summary>
        /// O(N^2)
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        bool isBalanced(TreeNode node)
        {
            int lh; /* for height of left subtree */

            int rh; /* for height of right subtree */

            /* If tree is empty then return true */
            if (node == null)
                return true;

            /* Get the height of left and right sub trees */
            lh = height(node.Left);
            rh = height(node.Right);

            if (Math.Abs(lh - rh) <= 1
                    && isBalanced(node.Left)
                    && isBalanced(node.Right))
                return true;

            /* If we reach here then tree is not height-balanced */
            return false;
        }

        /* UTILITY FUNCTIONS TO TEST isBalanced() FUNCTION */
        /*  The function Compute the "height" of a tree. Height is the
            number of nodes along the longest path from the root node
            down to the farthest leaf node.*/
        int height(TreeNode node)
        {
            /* base case tree is empty */
            if (node == null)
                return 0;

            /* If tree is not empty then height = 1 + max of left
             height and right heights */
            return 1 + Math.Max(height(node.Left), height(node.Right));
        }
    }
}
