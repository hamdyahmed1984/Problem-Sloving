using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Graphs
{
    class PathsWithSum
    {
        /// <summary>
        /// Runtime: O(N log N)
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public int CountPathsWithSum(TreeNode root, int targetSum)
        {
            if (root == null) return 0;            
             /* Count paths with sum starting from the root. */
            int pathsWithSumFromRoot = CountPathsWithSumFromNode(root, targetSum, 0);
            /* Try the nodes on the left and right. */
            int pathsWithSumFromLeft = CountPathsWithSum(root.Left, targetSum);
            int pathWithSumFromRight = CountPathsWithSum(root.Right, targetSum);

            return pathsWithSumFromRoot + pathsWithSumFromLeft + pathWithSumFromRight;
        }

        private int CountPathsWithSumFromNode(TreeNode node, int targetSum, int currentSum)
        {
            if (node == null)
                return 0;
            currentSum += node.Data;
            int countPaths = 0;
            if (currentSum == targetSum)
                countPaths++;
            CountPathsWithSumFromNode(node.Left, targetSum, currentSum);
            CountPathsWithSumFromNode(node.Right, targetSum, currentSum);
            return countPaths;
        }
    }
}
