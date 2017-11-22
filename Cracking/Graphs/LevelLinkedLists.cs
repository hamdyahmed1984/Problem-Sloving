using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Graphs
{
    class LevelLinkedLists
    {
        public static void Test()
        {
            TreeNode root = new TreeNode(6);
            root.Insert(3);
            root.Insert(8);
            root.Insert(1);
            root.Insert(4);
            root.Insert(7);
            root.Insert(9);

            TreeNode root2 = new TreeNode(6);
            root2.Insert(3);
            root2.Insert(8);
            root2.Insert(1);
            root2.Insert(4);
            root2.Insert(7);
            root2.Insert(9);

            CreateLevelLinkedList_DFS(root);
            CreateLevelLinkedList_BFS(root2);
        }

        private static void CreateLevelLinkedList_DFS(TreeNode root)
        {
            List<LinkedList<TreeNode>> lists = new List<LinkedList<TreeNode>>();
            CreateLevelLinkedList_DFS(root, lists, level: 0);
        }

        private static void CreateLevelLinkedList_DFS(TreeNode root, List<LinkedList<TreeNode>> lists, int level)
        {
            if (root == null)
                return;
            LinkedList<TreeNode> list;
            if(lists.Count == level)
            {
                list = new LinkedList<TreeNode>();
                lists.Add(list);
            }
            else
            {
                list = lists[level];
            }
            list.AddLast(root);
            CreateLevelLinkedList_DFS(root.Left, lists, level + 1);
            CreateLevelLinkedList_DFS(root.Right, lists, level + 1);
        }

        private static List<LinkedList<TreeNode>> CreateLevelLinkedList_BFS(TreeNode root)
        {
            List<LinkedList<TreeNode>> result = new List<LinkedList<TreeNode>>();
            LinkedList<TreeNode> current = new LinkedList<TreeNode>();
            if (root != null)
                current.AddLast(root);
            while(current.Count > 0)
            {
                result.Add(current);
                LinkedList<TreeNode> parents = current;
                current = new LinkedList<TreeNode>();
                foreach(TreeNode parent in parents)
                {
                    if (parent.Left != null)
                        current.AddLast(parent.Left);
                    if (parent.Right != null)
                        current.AddLast(parent.Right);
                }
            }
            return result;
        }
    }
}
