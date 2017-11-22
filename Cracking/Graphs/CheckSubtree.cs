using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Graphs
{
    class CheckSubtree
    {
        public static void Test()
        {

        }

        /// <summary>
        /// This approach checks if a tree is a subtree of another tree.
        /// The idea here is to use PREORDER traversal for each tree and check if the string of the smaller tree substring of the larger one.
        /// We add "X" in place of null nodes to solve the problem of exitence of a node where it has left is null and right is not null or the reverse.
        /// This problem will make the preorder for this node is the same althought he structure is different.
        /// Example for this proble is: T1={2,3} and T2={3,2} where 3 is the root and 2 is the left in the first tree and the right in the second tree.
        /// 
        /// Also we can't use InOrder traversal as it always produces ordered nodes.
        /// And this may lead to same traversal for 2 trees with same data but different structure.
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        bool ContainsTree_1(TreeNode t1, TreeNode t2)
        {
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();

            GetPreOrderTraversalString(t1, sb1);
            GetPreOrderTraversalString(t2, sb2);

            return sb1.ToString().IndexOf(sb2.ToString()) != -1;
        }
        /// <summary>
        /// Runtime: O(n + m)
        /// Space: O(n + m)
        /// </summary>
        /// <param name="node"></param>
        /// <param name="sb"></param>
        private void GetPreOrderTraversalString(TreeNode node, StringBuilder sb)
        {
            if(node == null)
            {
                sb.Append("X");// Add null indicator
                return;
            }
            sb.Append(node.Data);
            GetPreOrderTraversalString(node.Left, sb);
            GetPreOrderTraversalString(node.Right, sb);
        }

        /// <summary>
        /// The isea of this approach is to search through the larger tree, Tl. 
        /// Each time a node in Tl matches the root of T2, call MatchTrees.
        /// The MatchTrees method will compare the two subtrees to see if they are identical.
        /// 
        /// 
        /// This approach Big O
        /// Runtime: O (nm) in worst case but actually it is O(n + km) where k is the number of times we found a match in data and call MatchTrees.
        /// Space: O(log(n) + log(m))
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        bool ContainsTree_2(TreeNode t1, TreeNode t2)
        {
            if (t2 == null)
                return true;//An empty tree is always a subtree
            return IsSubTree(t1, t2);
        }

        private bool IsSubTree(TreeNode node1, TreeNode node2)
        {
            if (node1 == null)
            {
                return false; //big tree empty &subtree still not found.
            }
            else if(node1.Data == node2.Data && MatchTrees(node1, node2))
            {
                return true;
            }
            return IsSubTree(node1.Left, node2) || IsSubTree(node1.Right, node2);
        }

        private bool MatchTrees(TreeNode node1, TreeNode node2)
        {
            if (node1 == null && node2 == null)
            {
                return true;//nothing left in the subtree
            }
            else if (node1 == null || node2 == null)
            {
                return false;//exactly tree is empty, therefore trees don't match
            }
            else if (node1.Data != node2.Data)
            {
                return false; //data doesn't match
            }
            return MatchTrees(node1.Left, node2.Left) && MatchTrees(node1.Right, node2.Right);
        }
    }
}
