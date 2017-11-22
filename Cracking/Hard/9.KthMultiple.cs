using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Hard
{
    /// <summary>
    /// 17 .9 Kth Multiple: Design an algorithm to find the kth number such that the only prime factors are 3, 5, and 7. 
    /// Note that 3, 5, and 7 do not have to be factors, but it should not have any other prime factors.
    /// For example, the first several multiples would be(in order) 1, 3, 5, 7, 9, 15, 21.
    /// </summary>
    public class KthMultiple
    {
        /// <summary>
        /// O(K^3 Log K^3) which is equal to O(K^3 Log K)
        /// 
        /// We know that biggest this kth number could be is 3^k * 5^k * 7^k . So, the "stupid" way of doing this is to
        /// compute 3^a* 5^b * 7^c for all values of a, b, and c between 0 and k.We can throw them all into a list, sort
        /// the list, and then pick the kth smallest value.
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public int GetKthMagicNumber_BF(int k)
        {
            List<int> allPossibilities = new List<int>();
            for (int a = 0; a <= k; a++)
            {
                int powA = (int)Math.Pow(3, a);
                for (int b = 0; b <= k; b++)
                {
                    int powB = (int)Math.Pow(5, b);
                    for (int c = 0; c <= k; c++)
                    {
                        int powC = (int)Math.Pow(7, c);
                        int val = powA * powB * powC;
                        if (val < 0 || powA == int.MaxValue || powB == int.MaxValue || powC == int.MaxValue)
                        {
                            val = int.MaxValue;
                        }
                        allPossibilities.Add(val);
                    }
                }
            }

            allPossibilities.Sort();
            return allPossibilities[k];
        }

        /// <summary>
        /// we can think about each previous value in the list as "pushing" out three subsequent values in the list. That
        /// is, each number Ai will eventually be used later in the list in the following forms:
        /// 3 * Ai
        /// 5 * Ai
        /// 7 * Ai
        /// 
        /// We can use this thought to plan in advance. Each time we add a number Ai to the list, we hold on to the
        /// values 3Ai, 5Ai, and 7Ai in some sort of temporary list.To generate Ai+1' we search through this temporary        
        /// list to find the smallest value.
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public int GetKthMagicNumber_Better(int k)
        {
            if (k < 0) return 0;
            int val = 1;
            LinkedList<int> multiplesList = new LinkedList<int>();
            AddMultiples(multiplesList, 1);
            for (int i = 0; i < k; i++)
            {
                val = RemoveMin(multiplesList);
                AddMultiples(multiplesList, val);
            }
            return val;
        }

        private void AddMultiples(LinkedList<int> q, int min)
        {
            q.AddLast(min * 3);
            q.AddLast(min * 5);
            q.AddLast(min * 7);
        }

        private int RemoveMin(LinkedList<int> multiplesList)
        {
            int min = multiplesList.First();
            foreach (int num in multiplesList)
            {
                if (num < min)
                    min = num;
            }

            while (multiplesList.Contains(min))
                multiplesList.Remove(min);

            return min;
        }


        public int GetKthMagicNumber_Optimal(int k)
        {
            if (k < 0) return 0;
            int val = 0;

            Queue<int> Q3 = new Queue<int>();
            Queue<int> Q5 = new Queue<int>();
            Queue<int> Q7 = new Queue<int>();

            Q3.Enqueue(1);
            /* Include 0th through kth iteration */
            for (int i = 0; i <= k; i++)
            {
                int v3 = Q3.Count > 0 ? Q3.Peek() : int.MaxValue;
                int v5 = Q5.Count > 0 ? Q5.Peek() : int.MaxValue;
                int v7 = Q7.Count > 0 ? Q7.Peek() : int.MaxValue;

                val = Math.Min(v3, Math.Min(v5, v7));

                if (val == v3) // enqueue into queue 3, 5 and 7
                {
                    Q3.Dequeue();
                    Q3.Enqueue(val * 3);
                    Q5.Enqueue(val * 5);
                }
                else if (val == v5) // enqueue into queue 5 and 7
                {
                    Q5.Dequeue();
                    Q5.Enqueue(val * 5);
                }
                else if (val == v7) // enqueue into queue 7
                {
                    Q7.Dequeue();
                }
                Q7.Enqueue(val * 7);//Always enqueue into Q7
            }
            return val;
        }
        public int GetKthMagicNumber_Optimal_2(int k)
        {
            if (k < 0) return 0;

            List<int> numbers = new List<int>();
            numbers.Add(1);

            int count3 = 0;
            int count5 = 0;
            int count7 = 0;

            for (int i = 0; i < k; i++)
            {
                int min = Math.Min(numbers[count3] * 3, Math.Min(numbers[count7] * 7, numbers[count5] * 5));

                numbers.Add(min);

                if (min == numbers[count3] * 3) count3++;
                if (min == numbers[count5] * 5) count5++;
                if (min == numbers[count7] * 7) count7++;
            }
            return numbers[k];
        }
    }
}
