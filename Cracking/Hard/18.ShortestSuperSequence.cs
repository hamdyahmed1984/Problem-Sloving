using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Hard
{
    /// <summary>
    /// 17 .18 Shortest Supersequence: You are given two arrays, one shorter (with all distinct elements) and one longer.
    /// Find the shortest subarray in the longer array that contains all the elements in the shorter array.
    /// The items can appear in any order.
    /// EXAMPLE
    /// Input: { 1, 5, 9} {7, 5, 9, 0, 2, 1, 3, 5, 7, 9, 1, 1, 5, 8, 8, 9, 7}
    /// Output:[7, 10] (the underlined portion above)
    /// </summary>
    public class ShortestSuperSequence
    {
        #region Naive Solution
        /// <summary>
        /// Runtime: O(B^2 * S), where B is the length of the big array and S is the length of the small array
        /// </summary>
        /// <param name="big"></param>
        /// <param name="small"></param>
        /// <returns></returns>
        public Range FindShortestSupersequence_BF(int[] big, int[] small)
        {
            if (small.Length > big.Length) return new Range(-1, -1);//impossible that a smaller array contains all elements in a bigger array with all distinct elements
            int bestStart = -1;
            int bestEnd = -1;
            /*loop until the last small.Length elements in big, this is because of course less than this will not contain all small elemnts*/
            for (int i = 0; i <= big.Length - small.Length; i++)
            {
                int end = FindClosure(big, small, i);
                if (end == -1) break;
                if (bestStart == -1 || end - i < bestEnd - bestStart)
                {
                    bestStart = i;
                    bestEnd = end;
                }
            }
            return new Range(bestStart, bestEnd);
        }
        /*Given an index, find the closure (i.e., the element which terminates a complete subarray containing all elements in smallArray). 
         * This will be the max of the next locations of each element in smallArray.*/
        private int FindClosure(int[] big, int[] small, int index)
        {
            int max = -1;
            foreach (int num in small)
            {
                int next = FindNext(big, num, index);
                if (next == -1) return -1;
                max = Math.Max(max, next);
            }
            return max;
        }
        /*Find next instance of element starting from index.*/
        private int FindNext(int[] big, int num, int start)
        {
            for (int i = start; i < big.Length; i++)
            {
                if (big[i] == num) return i;
            }
            return -1;
        }
        #endregion

        #region Partially Optimal Solution
        /// <summary>
        /// Runtime: O(SB), where B is the length of the big array and S is the length of the small array
        /// Space: O(SB), where B is the length of the big array and S is the length of the small array
        /// </summary>
        /// <param name="big"></param>
        /// <param name="small"></param>
        /// <returns></returns>
        public Range FindShortestSupersequence_PartiallyOptimal(int[] big, int[] small)
        {
            if (small.Length > big.Length) return new Range(-1, -1);//impossible that a smaller array contains all elements in a bigger array with all distinct elements
            int[][] nextElements = GetNextElementsForSmalls(big, small);
            int[] closures = GetClosuresFromNextElements(nextElements);
            return GetShortestClosure(closures);
        }
        /* Create table of next occurrences. */
        private int[][] GetNextElementsForSmalls(int[] big, int[] small)
        {
            int[][] nextElements = new int[small.Length][];
            for (int i = 0; i < small.Length; i++)
            {
                nextElements[i] = GetNextElementsForNumber(big, small[i]);
            }
            return nextElements;
        }
        /*Do backwards sweeps to get a list of the next occurrence of num from each index */
        private int[] GetNextElementsForNumber(int[] big, int num)
        {
            int[] nexts = new int[big.Length];
            int next = -1;
            for (int i = big.Length - 1; i >= 0; i--)
            {
                if (big[i] == num)
                    next = i;
                nexts[i] = next;
            }
            return nexts;
        }
        /* Get closure for each index. */
        private int[] GetClosuresFromNextElements(int[][] nextElements)
        {
            int[] maxNextElement = new int[nextElements[0].Length];
            for (int i = 0; i < nextElements[0].Length; i++)
            {
                for (int j = 0; j < nextElements.Length; j++)
                {
                    if (nextElements[j][i] == -1)
                    {
                        maxNextElement[i] = -1;
                        break;
                    }
                    maxNextElement[i] = Math.Max(maxNextElement[i], nextElements[j][i]);
                }
            }
            return maxNextElement;
        }
        /* Get shortest closure. */
        private Range GetShortestClosure(int[] closures)
        {
            int bestStart = -1, bestEnd = -1;
            for (int i = 0; i < closures.Length; i++)
            {
                if (closures[i] == -1) break;//If no closure at some index, there will not be any closure after that index
                if (bestStart == -1 || closures[i] - i < bestEnd - bestStart)
                {
                    bestStart = i;
                    bestEnd = closures[i];
                }
            }
            return new Range(bestStart, bestEnd);
        }
        #endregion

        /// <summary>
        /// Runtime: O(SB), where B is the length of the big array and S is the length of the small array
        /// Space: O(B), where B is the length of the big array and S is the length of the small array
        /// </summary>
        /// <param name="big"></param>
        /// <param name="small"></param>
        /// <returns></returns>
        public Range FindShortestSupersequence_MoreOptimal(int[] big, int[] small)
        {
            int[] closures = GetClosures(big, small);
            return GetShortestClosure(closures);
        }

        private int[] GetClosures(int[] big, int[] small)
        {
            int[] closures = new int[big.Length];
            for (int i = 0; i < small.Length; i++)
            {
                int num = small[i];
                int next = -1;
                for (int j = big.Length - 1; j >= 0 ; j--)
                {
                    if (big[j] == num)
                        next = j;
                    if ((next == -1 || closures[j] < next) && closures[j] != -1)
                        closures[j] = next;
                }
            }
            return closures;
        }

        public class Range
        {
            public int Start { get; set; }
            public int End { get; set; }
            public Range(int start, int end)
            {
                this.Start = start;
                this.End = end;
            }
        }
    }
}
