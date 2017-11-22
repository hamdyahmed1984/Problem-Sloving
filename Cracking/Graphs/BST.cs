using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Graphs
{
    class TreeNode
    {
        public int Data;
        public TreeNode Left;
        public TreeNode Right;
        public TreeNode Parent;
        public int Size;

        public TreeNode(int data)
        {
            this.Data = data;
            Size = 1;
        }

        public void Insert(int val)
        {
            if(val <= Data)
            {
                if (Left == null)
                {
                    Left = new TreeNode(val);
                    Left.Parent = this;
                }
                else
                    Left.Insert(val);
            }
            else
            {
                if (Right == null)
                {
                    Right = new TreeNode(val);
                    Right.Parent = this;
                }
                else
                    Right.Insert(val);
            }
            Size++;
        }

        public bool Contains(int val)
        {
            if (Data == val)
                return true;
            if (val < Data)
            {
                if (Left == null)
                    return false;
                else
                    return Left.Contains(val);
            }
            else
            {
                if (Right == null)
                    return false;
                else
                    return Right.Contains(val);
            }
        }

        public TreeNode GetNode(int val)
        {
            if (Data == val)
                return this;
            else if (val < Data)
            {
                if (Left == null)
                    return null;
                else
                    return Left.GetNode(val);
            }
            else
            {
                if (Right == null)
                    return null;
                else
                    return Right.GetNode(val);
            }
        }

        public TreeNode Remove(TreeNode root, int val)
        {
            if (root == null) return null;
            if (val < root.Data)
                root.Left = Remove(root.Left, val);
            else if (val > root.Data)
                root.Right = Remove(root.Right, val);
            else
            {
                root.Size--;
                // node with only one child or no child
                if (root.Left == null)
                    return root.Right;
                if (root.Right == null)
                    return root.Left;

                // if nodeToBeDeleted have both children
                TreeNode min = root.Right.Min();// Finding minimum element from right
                root.Data = min.Data;// Replacing current node with minimum node from right subtree
                root.Right = Remove(root.Right, min.Data);// Deleting minimum node from right now
            }
            return root;
        }

        public TreeNode Min()
        {
            if (Left == null)
                return this;
            return Left.Min();
        }

        public TreeNode Max()
        {
            if (Right == null)
                return this;
            return Right.Max();
        }

        /// <summary>
        /// check if current node contains a node
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        public bool Contains(TreeNode child)
        {
            if (Parent == null) return false;
            if (Parent == child) return true;
            return (Parent.Left != null && Parent.Left.Contains(child)) || (Parent.Right != null && Parent.Right.Contains(child));
        }

        public int GetDepth(TreeNode root)
        {
            int depth = 0;
            while(Parent != null)
            {
                Parent = Parent.Parent;
                depth++;
            }
            return depth;
        }

        public TreeNode GetSibling()
        {
            if (Parent == null) return null;
            return Parent.Left == this ? Right : Left;
        }

        public TreeNode GoUpBy(int levelsToGoUp)
        {
            TreeNode tmp = this;
            while(levelsToGoUp > 0)
            {
                tmp = tmp.Parent;
                levelsToGoUp--;
            }
            return tmp;
        }

        public void InOrder()
        {
            if (Left != null)
                Left.InOrder();
            Console.WriteLine(Data);
            if (Right != null)
                Right.InOrder();
        }

        public void PreOrder()
        {
            Console.WriteLine(Data);
            if (Left != null)
                Left.PreOrder();
            if (Right != null)
                Right.PreOrder();            
        }

        public void PostOrder()
        {
            if (Left != null)
                Left.PostOrder();
            if (Right != null)
                Right.PostOrder();
            Console.WriteLine(Data);
        }
    }
}
