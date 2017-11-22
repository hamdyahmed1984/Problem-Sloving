using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Graphs
{
    class FirstCommonAncestor
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
            root.Insert(11);
            root.Insert(12);

            FirstCommonAncestor_ParentUnKnown(root, root, root);

        }

        /// <summary>
        /// Solution #3: Without Links to Parents
        /// </summary>
        /// <param name="root"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static TreeNode FirstCommonAncestor_ParentUnKnown(TreeNode root, TreeNode a, TreeNode b)
        {
            /* Error check - one node is not in the tree. */
            if (!root.Contains(a) || !root.Contains(b))
                return null;
            return FirstCommonAncestor_ParentUnKnown_Helper(root, a, b);
        }

        private static TreeNode FirstCommonAncestor_ParentUnKnown_Helper(TreeNode root, TreeNode a, TreeNode b)
        {
            if (root == null || root == a || root == b) return root;

            bool is_a_OnLeft = root.Left.Contains(a);
            bool is_b_OnLeft = root.Left.Contains(b);

            //If nodes are on different sides
            if (is_a_OnLeft != is_b_OnLeft)
                return root;

            TreeNode childTree = is_a_OnLeft ? root.Left : root.Right;
            return FirstCommonAncestor_ParentUnKnown_Helper(childTree, a, b);
        }

        /// <summary>
        /// Solution #1: With Links to Parents
        /// O(d) time, where d is the depth of the deeper node.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static TreeNode FirstCommonAncestor_ParentKnown1(TreeNode root,TreeNode a, TreeNode b)
        {
            int delta = a.GetDepth(root) - b.GetDepth(root);
            TreeNode deeper = delta > 0 ? a : b;
            TreeNode shallower = delta > 0 ? b : a;
            deeper.GoUpBy(Math.Abs(delta));
            /* Find where paths intersect. */
            while (deeper != null && shallower != null && deeper != shallower)
            {
                deeper = deeper.Parent;
                shallower = shallower.Parent;
            }
            return deeper == null || shallower == null ? null : deeper;//here deeper = shalower
        }

        /// <summary>
        /// Solution #2: With Links to Parents (Better Worst-Case Runtime)
        /// O(t) time, where t is the size of the subtree for the first common ancestor.
        /// In the worst case, this will be O(n), where n is the number of nodes in the tree.
        /// We can derive this runtime by noticing that each node in that subtree is searched once.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static TreeNode FirstCommonAncestor_ParentKnown2(TreeNode root, TreeNode a, TreeNode b)
        {
            /* Check if either node is not in the tree, or if one covers the other. */
            if (!root.Contains(a) || !root.Contains(b)) return null;
            if (a.Contains(b)) return a;//If a contains b then a is the FCA
            if (b.Contains(a)) return b;//If b contains a then b is the FCA
            /* Traverse upwards until you find a node that contains q. */
            TreeNode sibling = a.GetSibling();
            TreeNode parent = a.Parent;
            while(!sibling.Contains(b))
            {
                sibling = parent.GetSibling();
                parent = parent.Parent;
            }
            return parent;
        }
    }
}
