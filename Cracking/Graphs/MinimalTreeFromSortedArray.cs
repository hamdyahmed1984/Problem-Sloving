using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Graphs
{
    class MinimalTreeFromSortedArray
    {
        public static void Test()
        {
            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            TreeNode node = CreateMinimalBST(arr, 0, arr.Length - 1);
            if (node != null)
                node.InOrder();
        }

        private static TreeNode CreateMinimalBST(int[] arr, int start, int end)
        {
            if (start > end)
                return null;
            int middle = (start + end) / 2;
            TreeNode node = new TreeNode(arr[middle]);
            node.Left = CreateMinimalBST(arr, start, middle - 1);
            node.Right = CreateMinimalBST(arr, middle + 1, end);
            return node;
        }
    }
}
