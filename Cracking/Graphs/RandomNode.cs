using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Graphs
{
    class RandomNode
    {
        /*
         * Option #1 [Slow & Working]
            One solution is to copy all the nodes to an array and return a random element in the array. This solution will
            take O(N) time and O(N) space, where N is the number of nodes in the tree.
            We can guess our interviewer is probably looking for something more optimal, since this is a little too
            straightforward (and should make us wonder why the interviewer gave us a binary tree, since we don't
            need that information).
            We should keep in mind as we develop this solution that we probably need to know something about the
            internals of the tree. Otherwise, the question probably wouldn't specify that we're developing the tree class
            from scratch.
            */
        /*
        Option #2 [Slow & Working)
        Returning to our original solution of copying the nodes to an array, we can explore a solution where we
        maintain an array at all times that lists all the nodes in the tree. The problem is that we'll need to remove
        nodes from this array as we delete them from the tree, and that will take O ( N) time.
        */
        /*
        Option #3 [Slow & Working]
        We could label all the nodes with an index from 1 to N and label them in binary search tree order (that
        is, according to its inorder traversal). Then, when we call getRandomNode, we generate a random index
        between 1 and N. If we apply the label correctly, we can use a binary search tree search to find this index.
        268 Cracking the Coding Interview, 6th Edition
        Solutions to Chapter 4 I Trees and Graphs
        However, this leads to a similar issue as earlier solutions. When we insert a node or a delete a node, all of the
        indices might need to be updated. This can take O(N) time.
        */
        /*
         Option #4 [Fast & Not Working]
        What if we knew the depth of the tree? (Since we're building our own class, we can ensure that we know
        this. It's an easy enough piece of data to track.)
        We could pick a random depth, and then traverse left/right randomly until we go to that depth. This
        wouldn't actually ensure that all nodes are equally likely to be chosen though.
        First, the tree doesn't necessarily have an equal number of nodes at each level. This means that nodes on
        levels with fewer nodes might be more likely to be chosen than nodes on a level with more nodes.
        Second, the random path we take might end up terminating before we get to the desired level. Then what?
        We could just return the last node we find, but that would mean unequal probabilities at each node.
        */

        /// <summary>
        /// Runtime: O(logN) or more accurately O(D), where D is the max depth of the tree.
        ///
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode GetRandomNodeFromTheTree_1(TreeNode root)
        {
            if (root == null) return null;
            return GetRandomNode(root);
        }
        public TreeNode GetRandomNode(TreeNode root)
        {
            int leftSize = root.Left == null ? 0 : root.Left.Size;
            Random rand = new Random();
            int index = rand.Next(root.Size);
            if (index == leftSize)
                return root;
            else if (index < leftSize)
                return GetRandomNode(root.Left);
            else
                return GetRandomNode(root.Right);
        }


        /// <summary>
        /// Runtime: O(logN) or more accurately O(D), where D is the max depth of the tree
        /// 
        /// 
        /// /// In this approach, instead of calculation a number number every time which is expensive.
        /// We just calculate it in the beginning and when we go right we shift (Left.Size + 1)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode GetRandomNodeFromTheTree_2(TreeNode root)
        {
            if (root == null) return null;
            Random rand = new Random();
            int i = rand.Next(root.Size);
            return GetIthNode(root, i);
        }

        private TreeNode GetIthNode(TreeNode root, int i)
        {
            int leftSize = root.Left == null ? 0 : root.Left.Size;
            if (i == leftSize)
                return root;
            else if (i < leftSize)
                return GetIthNode(root.Left, i);
            else
                return GetIthNode(root.Right, i - (leftSize + 1));
        }
    }
}
