using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Moderate
{
    /// <summary>
    /// 16.24 Pairs with Sum: Design an algorithm to find all pairs of integers within an array which sum to a specified value.
    /// </summary>
    class PairsWithSum
    {
        public void Test()
        {
            int[] arr = { 5, 3, 1, 6, 5, 4, 9, 5, 8 };
            int targetSum = 10;

            List<Pair> pairsWithSum;
            pairsWithSum = FindPairsWithSum_BF(arr, targetSum);
            pairsWithSum = FindPairsWithSum_Optimal1(arr, targetSum);
            pairsWithSum = FindPairsWithSum_Optimal2(arr, targetSum);
            pairsWithSum = FindPairsWithSum_Optimal3(arr, targetSum);
        }

        /// <summary>
        /// O(N^2)
        /// If there are duplicate numbers in the array it will print duplicates sums
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        private List<Pair> FindPairsWithSum_BF(int[] arr, int targetSum)
        {
            List<Pair> pairsWithSum = new List<Pair>();
            for(int i = 0; i < arr.Length; i++)
            {
                for (int j =  i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == targetSum)
                        pairsWithSum.Add(new Pair() { First = arr[i], Second = arr[j] });
                }
            }
            return pairsWithSum;
        }

        /// <summary>
        /// O(N)
        /// This also will print duplicate result if theere duplicates in the array
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        private List<Pair> FindPairsWithSum_Optimal1(int[] arr, int targetSum)
        {
            List<Pair> pairsWithSum = new List<Pair>();
            //First: create array of complements of each element in the array(duplicates will be neglected)
            Dictionary<int, bool> map = new Dictionary<int, bool>();
            foreach(int num in arr)
            {
                int complement = targetSum - num;
                if (!map.ContainsKey(complement) && !map.ContainsKey(num))//Make sure to add only the num or its complement
                    map.Add(complement, true);
            }
            //Second: loop through the array and get pair the with the target sum
            foreach(int num in arr)
            {
                if(map.ContainsKey(num))
                {
                    pairsWithSum.Add(new Pair() { First = num, Second = targetSum - num });
                }
            }
            return pairsWithSum;
        }

        /// <summary>
        /// O(N) time and O(N) space.
        /// This solution will print duplicate pairs, but will not reuse the same instance of an element. It will take 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        private List<Pair> FindPairsWithSum_Optimal2(int[] arr, int targetSum)
        {
            List<Pair> pairsWithSum = new List<Pair>();
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach(int num in arr)
            {
                int complement = targetSum - num;
                if (map.ContainsKey(complement))
                {
                    if (map[complement] > 0)//If complement of the number exists in the dictionary
                    {
                        pairsWithSum.Add(new Pair() { First = num, Second = complement });
                        map[complement]--;//Decrement the complement so it is not used again
                    }
                }
                else
                {
                    map.Add(num, 1);//Add the number to the dictionary
                }
            }
            return pairsWithSum;
        }

        /// <summary>
        /// O(N log N)
        /// 
        /// It can be done also by binary search
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        private List<Pair> FindPairsWithSum_Optimal3(int[] arr, int targetSum)
        {
            List<Pair> pairsWithSum = new List<Pair>();
            Array.Sort(arr);
            int first = 0, last = arr.Length - 1;
            while(first < last)
            {
                int sum = arr[first] + arr[last];
                if (sum == targetSum)
                {
                    pairsWithSum.Add(new Pair() { First = arr[first], Second = arr[last] });
                    first++;
                    last--;
                }
                else if (sum < targetSum)
                    first++;
                else
                    last--;
            }
            return pairsWithSum;
        }

        class Pair
        {
            public int First { get; set; }
            public int Second { get; set; }
        }
    }
}
