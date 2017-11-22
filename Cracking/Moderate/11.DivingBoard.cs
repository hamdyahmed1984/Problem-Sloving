using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Moderate
{
    class DivingBoard
    {
        /// <summary>
        /// 16.11 Diving Board: You are building a diving board by placing a bunch of planks of wood end-to-end.
        /// There are two types of planks, one of length shorter and one of length longer.You must use
        /// exactly K planks of wood.Write a method to generate all possible lengths for the diving board.
        /// </summary>
        public void Test()
        {
            int shorter = 3, longer = 4;            
            HashSet<int> allLength = new HashSet<int>();

            int numberOfPlanks = 1;
            allLength = GetAllPossibleLength_Recursive(numberOfPlanks, shorter, longer);
            allLength = GetAllPossibleLength_Recursive_Memo(numberOfPlanks, shorter, longer);
            allLength = GetAllPossibleLength_Optimal(numberOfPlanks, shorter, longer);

            numberOfPlanks = 2;
            allLength = GetAllPossibleLength_Recursive(numberOfPlanks, shorter, longer);
            allLength = GetAllPossibleLength_Recursive_Memo(numberOfPlanks, shorter, longer);
            allLength = GetAllPossibleLength_Optimal(numberOfPlanks, shorter, longer);

            numberOfPlanks = 3;
            allLength = GetAllPossibleLength_Recursive(numberOfPlanks, shorter, longer);
            allLength = GetAllPossibleLength_Recursive_Memo(numberOfPlanks, shorter, longer);
            allLength = GetAllPossibleLength_Optimal(numberOfPlanks, shorter, longer);
        }

        /// <summary>
        /// O(2^K)
        /// 
        /// For a recursive solution, we can imagine ourselves building a diving board. We make K decisions, each time
        /// choosing which plank we will put on next.Once we've put on K planks, we have a complete diving board
        /// and we can add this to the list (assuming we haven't seen this length before).
        /// We can follow this logic to write recursive code. Note that we don't need to track the sequence of planks.
        /// All we need to know is the current length and the number of planks remaining.
        /// </summary>
        /// <param name="numberOfPlanks"></param>
        /// <param name="shorter"></param>
        /// <param name="longer"></param>
        /// <returns></returns>
        private HashSet<int> GetAllPossibleLength_Recursive(int numberOfPlanks, int shorter, int longer)
        {
            HashSet<int> lengths = new HashSet<int>();
            GetAllPossibleLength_Recursive_Helper(numberOfPlanks, shorter, longer, 0, lengths);
            return lengths;
        }

        private void GetAllPossibleLength_Recursive_Helper(int numberOfPlanks, int shorter, int longer, int currentLength, HashSet<int> lengths)
        {
            if(numberOfPlanks == 0)
            {
                lengths.Add(currentLength);
                return;
            }
            //Either we elect the shorter or the longer
            GetAllPossibleLength_Recursive_Helper(numberOfPlanks - 1, shorter, longer, currentLength + shorter, lengths);
            GetAllPossibleLength_Recursive_Helper(numberOfPlanks - 1, shorter, longer, currentLength + longer, lengths);
        }


        /// <summary>
        /// O(K^2)
        /// 
        /// Observe that some of the recursive calls will be essentially equivalent. For example, picking plank 1 and
        /// then plank 2 is equivalent to picking plank 2 and then plank 1.
        /// Therefore, if we've seen this (total, plank count) pair before then we stop this recursive path. We
        /// can do this using a HashSet with a key of(total, plank count).
        /// </summary>
        /// <param name="numberOfPlanks"></param>
        /// <param name="shorter"></param>
        /// <param name="longer"></param>
        /// <returns></returns>
        private HashSet<int> GetAllPossibleLength_Recursive_Memo(int numberOfPlanks, int shorter, int longer)
        {
            HashSet<int> lengths = new HashSet<int>();
            HashSet<string> visited = new HashSet<string>();
            GetAllPossibleLength_Recursive_Memo_Helper(numberOfPlanks, shorter, longer, 0, lengths, visited);
            return lengths;
        }

        private void GetAllPossibleLength_Recursive_Memo_Helper(int numberOfPlanks, int shorter, int longer, int currentLength, HashSet<int> lengths, HashSet<string> visited)
        {
            if (numberOfPlanks == 0)
            {
                lengths.Add(currentLength);
                return;
            }
            string key = numberOfPlanks + "_" + currentLength;
            if (visited.Contains(key))
                return;
            //Either we select the shorter or the longer
            GetAllPossibleLength_Recursive_Memo_Helper(numberOfPlanks - 1, shorter, longer, currentLength + shorter, lengths, visited);
            GetAllPossibleLength_Recursive_Memo_Helper(numberOfPlanks - 1, shorter, longer, currentLength + longer, lengths, visited);
            visited.Add(key);
        }

        /// <summary>
        /// O(K), where K is the number of blanks
        /// 
        /// There are only K distinct sums we can get.
        /// Isn't that the whole point of the problem-to find all possible sums?
        /// We don't actually need to go through all arrangements of planks. We just need to go through all unique sets of K planks(sets, not orders!).
        /// There are only K ways of picking K planks if we only have two possible types:
        /// {0 of type A, K of type B}, {1 of type A, K-1 of type B}, {2 of type A, K-2 of type B}, ...
        /// 
        /// We've used a Hash Set here for consistency with the prior solutions. This isn't really necessary though, since
        /// we shouldn't get any duplicates. We could instead use an Arraylist. If we do this, though, we just need to
        /// handle an edge case where the two types of planks are the same length.In this case, we would just return an Arraylist of size 1.
        /// </summary>
        /// <param name="numberOfPlanks"></param>
        /// <param name="shorter"></param>
        /// <param name="longer"></param>
        /// <returns></returns>
        private HashSet<int> GetAllPossibleLength_Optimal(int numberOfPlanks, int shorter, int longer)
        {
            HashSet<int> lengths = new HashSet<int>();
            for(int shorter_count = 0; shorter_count <= numberOfPlanks; shorter_count++)
            {
                int longer_count = numberOfPlanks - shorter_count;
                int length = shorter_count * shorter + longer_count * longer;
                lengths.Add(length);
            }
            return lengths;
        }
    }
}
