using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.DynamicProgramming
{
    /*
     * 8.4 Power Set: Write a method to return all subsets of a set.
     * 
     * Explanation:
     * How many subsets of a set are there? When we generate a subset, each element has the "choice" of either being in there or not.
     * That is, for the first element, there are two choices: it is either in the set or it is not. For the second, there are two, etc.
     * So, doing { 2 * 2 * . . . } n times gives us 2" subsets.
     * Assuming that we're going to be returning a list of subsets, then our best case time is actually the total number of elements across all of those subsets.
     * There are 2" subsets and each of the n elements will be contained in half of the subsets (which 2n- 1 subsets).
     * Therefore, the total number of elements across all of those subsets is n * 2n-1.
     * We will not be able to beat 0( n2") in space or time complexity.
     * The subsets of {a1 , a2 , ••• , an} are also called the powersetP({a1, a2 , ••• , an}),orjustP(n).
     */
    class PowerSet
    {
        public static void Test()
        {
            int[] set = new int[] { 1, 2, 3 };
            List<List<int>> powerSet = GetPowerSet_UsingRecursion(set, 0, new List<List<int>>());

            Console.WriteLine("Using Resursion:");
            foreach(List<int> subset in powerSet)
            {
                Console.WriteLine("{ " + string.Join(",", subset) + " }");
            }

            powerSet = GetPowerSet_UsingBinary(set);

            Console.WriteLine("Using Binary:");
            foreach (List<int> subset in powerSet)
            {
                Console.WriteLine("{ " + string.Join(",", subset) + " }");
            }
        }

        /// <summary>
        /// Runtime: O(n * 2^n)
        /// Space: O(n * 2^n)
        /// </summary>
        /// <param name="set"></param>
        /// <param name="index"></param>
        private static List<List<int>> GetPowerSet_UsingRecursion(int[] set, int index, List<List<int>> allSubsets)
        {            
            if (index == set.Length)//base case
            {                
                allSubsets.Add(new List<int>());// Empty set
            }
            else
            {
                GetPowerSet_UsingRecursion(set, index + 1, allSubsets);
                int itm = set[index];
                List<List<int>> moreSubsets = new List<List<int>>();
                foreach(List<int> subset in allSubsets)
                {
                    List<int> newSubSet = new List<int>();
                    newSubSet.AddRange(subset);
                    newSubSet.Add(itm);
                    moreSubsets.Add(newSubSet);
                }
                allSubsets.AddRange(moreSubsets);
            }
            return allSubsets;
        }

        private static List<List<int>> GetPowerSet_UsingBinary(int[] set)
        {
            List<List<int>> allSubSets = new List<List<int>>();
            for(int i = 0; i < 1 << set.Length; i++)/* 1 << set.Length means 2^n */
            {
                List<int> subset = new List<int>();
                for(int j = 0; j < set.Length; j++)
                {
                    if (((i & (1 << j)) >= 1))
                        subset.Add(set[j]);
                }
                allSubSets.Add(subset);
            }
            return allSubSets;
        }
    }
}
