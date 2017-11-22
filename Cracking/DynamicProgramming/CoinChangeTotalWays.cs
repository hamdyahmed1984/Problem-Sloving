using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.DynamicProgramming
{
    /*
     * 8.11 Coins: Given an infinite number of quarters (25 cents), dimes (1 O cents), nickels (5 cents), and pennies (1 cent), 
     * write code to calculate the number of ways of representing n cents.
     */
    class CoinChangeTotalWays
    {
        public static void Test()
        {
            int[] coins = { 2, 1, 3 };
            int amount = 5;
            int ways = CountWays_Recursive(coins, coins.Length, amount);
            Console.WriteLine("Total number of ways recursively: " + ways);

            ways = CountWays_DP(coins, amount);
            Console.WriteLine("Total number of ways DP: " + ways);

            ways = CountWays_DP_BetterSpace(coins, amount);
            Console.WriteLine("Total number of ways DP with better space time: " + ways);

            printCoinChangingSolutions(amount, coins);
        }

        private static int CountWays_DP(int[] coins, int amount)
        {
            int[][] temp = new int[coins.Length + 1][];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = new int[amount + 1];
                temp[i][0] = 1;
            }

            for(int i = 1; i <= coins.Length; i++)
            {
                for(int j = 1; j <= amount; j++)
                {
                    if (j >= coins[i - 1])
                        temp[i][j] = temp[i - 1][j] + temp[i][j - coins[i - 1]];
                    else
                        temp[i][j] = temp[i - 1][j];
                }
            }
            return temp[coins.Length][amount];
        }

        private static int CountWays_DP_BetterSpace(int[] coins, int amount)
        {
            int[] temp = new int[amount + 1];
            temp[0] = 1;
            for(int i = 0; i < coins.Length; i++)
            {
                for(int j = coins[i]; j <= amount; j++)
                {
                    temp[j] = temp[j] + temp[j - coins[i]];
                }
            }
            return temp[amount];
        }
        private static int CountWays_Recursive(int[] coins, int coinsCount, int amount)
        {
            // If amount is 0 then there is 1 solution (do not include any coin)
            if (amount == 0)
                return 1;
            // If amount is less than 0 then no solution exists
            if (amount < 0)
                return 0;
            //If there are no coins, there is no solution
            if (coinsCount <= 0)
                return 0;
            // count is sum of solutions (i) including coint[coinsCount-1] (ii) excluding coins[coinsCount-1]
            return CountWays_Recursive(coins, coinsCount - 1, amount) + CountWays_Recursive(coins, coinsCount, amount - coins[coinsCount - 1]);
        }

        /**
         * This method actually prints all the combination. It takes exponential time.
         */
        public static void printCoinChangingSolutions(int total, int[] coins)
        {
            List<int> result = new List<int>();
            printActualSolutions(result, total, coins, 0);
        }

        /// <summary>
        /// THIS METHOD IS NOT WORKING CORRECTLY
        /// </summary>
        /// <param name="result"></param>
        /// <param name="total"></param>
        /// <param name="coins"></param>
        /// <param name="pos"></param>
        private static void printActualSolutions(List<int> result, int total, int[] coins, int pos)
        {
            if (total == 0)
            {
                foreach (int r in result)
                {
                    Console.Write(r + " ");
                }
                Console.Write("\n");
            }
            else
            {
                for (int i = pos; i < coins.Length; i++)
                {
                    if (total >= coins[i])
                    {
                        result.Add(coins[i]);
                        printActualSolutions(result, total - coins[i], coins, i);
                        result.Clear();
                    }
                }
            }
        }
    }
}
