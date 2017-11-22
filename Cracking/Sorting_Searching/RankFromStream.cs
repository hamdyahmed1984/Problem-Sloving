using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Sorting_Searching
{
    /// <summary>
    /// 10.10 Rank from Stream: Imagine you are reading in a stream of integers. Periodically, you wish
    /// to be able to look up the rank of a number x(the number of values less than or equal to x).
    /// Implement the data structures and algorithms to support these operations.That is, implementthe method track(int x), which is called when each number is generated, and the method
    /// getRankOfNumber(int x), which returns the number of values less than or equal to x (not
    /// including x itself).
    /// EXAMPLE
    /// Stream(in order of appearance):5, 1, 4, 4, 5, 9, 7, 13, 3
    /// getRankOfNumber(l) 0
    /// getRankOfNumber(3) 1
    /// getRankOfNumber(4) 3
    /// </summary>
    class RankFromStream
    {
        public void Test()
        {
            int[] arr = { 5, 1, 4, 4, 5, 9, 7, 13, 3 };

            RankNode root = new RankNode(5);
            for(int i = 1; i < arr.Length; i++)
            {
                root.Track(arr[i]);
            }

            int rank = root.GetRankOf(1);
            rank = root.GetRankOf(3);
            rank = root.GetRankOf(4);
            rank = root.GetRankOf(50);
            rank = root.GetRankOf(13);
        }

        class RankNode
        {
            int data;
            RankNode Left, Right;
            int Rank = 0;
            public RankNode(int data)
            {
                this.data = data;
            }

            public void Track(int d)
            {
                if(d <= data)
                {
                    Rank++;//Increase rank of current node only if we added a node to its left, because nodes added to its right will be greater than it
                    if (Left == null)
                        Left = new RankNode(d);
                    else
                        Left.Track(d);
                }
                else
                {
                    if (Right == null)
                        Right = new RankNode(d);
                    else
                        Right.Track(d);
                }
            }

            public int GetRankOf(int data)
            {
                int rank = 0;
                RankNode curr = this;
                while(curr != null)
                {
                    /*
                     * If we found the node we add its rank to the cumulative rank and return it 
                     */
                    if(data == curr.data)
                    {
                        rank += curr.Rank;
                        return rank;
                    }
                    /*
                     * If data is less than current node data we move to its left subtree and DON'T increament cumulative rank because we didn't reach smaller nodes yet.
                     */
                    else if (data < curr.data)
                    {
                        curr = curr.Left;
                    }
                    /*
                     * If data is greater than current node data, we move to its right subtree and add current node rank + 1 to cumulative rank.
                     * This is because the left subtree is always less than the right subtree.
                     */
                    else
                    {
                        rank += curr.Rank + 1;
                        curr = curr.Right;
                    }
                }
                return -1;//Not found
            }
        }

        //RankNode root;
        //void Track(int val)
        //{
        //    if (root == null)
        //        root = new RankNode(val);
        //    else
        //        root.Insert(val);
        //}

        //private int GetRank(int val)
        //{
        //    return root.GetRank(val);
        //}

        //class RankNode
        //{
        //    int leftSize = 0;
        //    int data;
        //    RankNode Left;
        //    RankNode Right;
        //    public RankNode(int d)
        //    {
        //        data = d;
        //    }

        //    public void Insert(int d)
        //    {
        //        if(d <= data)
        //        {
        //            if (Left == null)
        //                Left = new RankNode(d);
        //            else
        //                Left.Insert(d);
        //            leftSize++;
        //        }
        //        else
        //        {
        //            if (Right == null)
        //                Right = new RankNode(d);
        //            else
        //                Right.Insert(d);
        //        }
        //    }

        //    public int GetRank(int d)
        //    {
        //        if(d == data)
        //        {
        //            return leftSize;
        //        }
        //        else if(d < data)
        //        {
        //            if (Left == null) return -1;
        //            else
        //                return Left.GetRank(d);
        //        }
        //        else
        //        {
        //            int rightRank = Right == null ? -1 : Right.GetRank(d);
        //            if (rightRank == -1) return -1;
        //            else
        //                return leftSize + 1 + rightRank;
        //        }
        //    }
        //}
        
    }
}
