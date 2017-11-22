using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.DynamicProgramming
{
    /*
     * Given set of coins of unlimited quantity and a total. How many minimum coins would it take to form this total.
     */
    class CoinChangeMinCount
    {
        public static void Test()
        {
            int[] coins = { 3, 2, 4 };
            int amount = 6;
            int minCoinsCount = GetMinCoinsCountToTotal(coins, amount);
        }

        private static int GetMinCoinsCountToTotal(int[] coins, int amount)
        {
            //This array will contain min coins count to make each amount, here each amount is the each index in the array
            int[] minCoinsCountToMakeAmount = new int[amount + 1];
            //This array is used to save which coins used to make amount, each index represent an amount and contains the last used coin index.
            int[] lastUsedCoinToMakeAmount = new int[amount + 1];

            minCoinsCountToMakeAmount[0] = 0;//Base case here: there are 0 coins to make amount of 0.
            //make all entries MaxValue
            for (int i = 1; i < minCoinsCountToMakeAmount.Length; i++)
                minCoinsCountToMakeAmount[i] = int.MaxValue;
            //Make all values -1 so all indexces(amounts) that can be made will contain the last used coin index, otherwise it will contain -1
            for (int i = 0; i < lastUsedCoinToMakeAmount.Length; i++)
                lastUsedCoinToMakeAmount[i] = -1;
            //loop coins
            for(int coinIndex = 0; coinIndex < coins.Length; coinIndex++)
            {
                //loop each amount starting from 0 till the required amount
                for(int currentAmount = 1; currentAmount <= amount; currentAmount++)
                {
                    //if currentAmount is greater than or equal to the current coin, as if the coin is greater then the current amount it will be used anymore to make the current amount
                    if(currentAmount >= coins[coinIndex])
                    {
                        /*                         
                         * If we used the coin, we will add 1 to the value in [currentAmount - coins[coinIndex]] as we used the coin
                         * * If we didn't use the coin, we will let the value in the array as it is.
                         */
                        int val = minCoinsCountToMakeAmount[currentAmount - coins[coinIndex]];
                        //Very important to chack if val != int.MaxValue, because if we add 1 to int.MaxValue we will get -int.MaxValue
                        if (val != int.MaxValue && val + 1 < minCoinsCountToMakeAmount[currentAmount])
                        {
                            minCoinsCountToMakeAmount[currentAmount] = val + 1;
                            lastUsedCoinToMakeAmount[currentAmount] = coinIndex;//Update the array with the last use coin for current amount
                        }
                    }
                }
            }
            //OPTIONAL: get coins used to make the amount
            PrintCoinsUsedToMakeTheAmount(coins, lastUsedCoinToMakeAmount, amount);
            return minCoinsCountToMakeAmount[amount];
        }

        private static void PrintCoinsUsedToMakeTheAmount(int[] coins, int[] lastUsedCoinToMakeAmount, int amount)
        {
            if (lastUsedCoinToMakeAmount[amount] == -1)
                Console.WriteLine("The amount: " + amount + " cannot be made by any combination of the coins" + string.Join(",", coins) + ".");
            else
            {
                int currentIndex = lastUsedCoinToMakeAmount.Length - 1;
                while (currentIndex > 0)
                {
                    int coinIndex = lastUsedCoinToMakeAmount[currentIndex];
                    int coin = coins[coinIndex];
                    Console.Write(coin + ",");
                    currentIndex = currentIndex - coin;
                }
            }
        }
    }
}
