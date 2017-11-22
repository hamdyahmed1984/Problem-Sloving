using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Cracking.DynamicProgramming
{
    /*
     * 8.1 Triple Step: A child is running up a staircase with n steps and can hop either 1 step, 
     * 2 steps, or 3 steps at a time. Implement a method to count how many possible ways the child can run up the stairs.
     */

    /*
     *Note that we use long here to avoid int overflow because after n=37 int will NOT be enough to hold the result so we use long datat type.
     * This will NOT prevent overflow also and we can use a bigger data type such as BigInteger from System.Numerics but we need to add reference to this dll first.
     */
    class TripleStep
    {
        public static void Test()
        {
            int n = 30;
            long numberOfWays = CountWays_Recursion(n);
            Console.WriteLine("Number of ways: " + numberOfWays);
            numberOfWays = CountWays_Memo(n);
            Console.WriteLine("Number of ways: " + numberOfWays);
            numberOfWays = CountWays_Iterative(n);
            Console.WriteLine("Number of ways: " + numberOfWays);
            numberOfWays = CountWays_Iterative_Optimal(n);
            Console.WriteLine("Number of ways: " + numberOfWays);
        }

        /// <summary>
        /// O(3^n) :( :( :(
        /// </summary>
        /// <param name="n">number of stairs</param>
        /// <returns></returns>
        private static long CountWays_Recursion(int n)
        {
            /*
             * Base case:
             * We can use also :
                if (n == 1) return 1;
                if (n == 2) return 2;
                if (n == 3) return 4;
             */
            if (n < 0) return 0;
            if (n == 0) return 1;
            else return CountWays_Recursion(n - 1) + CountWays_Recursion(n - 2) + CountWays_Recursion(n - 3);
        }

        private static long CountWays_Memo(int n)
        {
            long?[] memo = new long?[n + 1];
            return CountWays_Memo(n, memo);
        }

        private static long CountWays_Memo(int n, long?[] memo)
        {
            /*
             * Base case:
             * We can use also :
                if (n == 1) return 1;
                if (n == 2) return 2;
                if (n == 3) return 4;
             */
            if (n < 0) return 0;
            if (n == 0) return 1;
            if(!memo[n].HasValue)
                memo[n] = CountWays_Memo(n - 1, memo) + CountWays_Memo(n - 2, memo) + CountWays_Memo(n - 3, memo);
            return memo[n].Value;
        }

        private static long CountWays_Iterative(int n)
        {
            long[] ways = new long[n + 1];
            ways[0] = 0;
            ways[1] = 1;
            ways[2] = 2;
            ways[3] = 4;
            for(int i = 4; i <= n; i++)
            {
                ways[i] = ways[i - 1] + ways[i - 2] + ways[i - 3];
            }
            return ways[n];
        }

        private static long CountWays_Iterative_Optimal(int n)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 2;
            if (n == 3) return 4;

            long a = 1, b = 2, c = 4;
            long count = 0;
            for(int i = 4; i <= n; i++)
            {
                count = a + b + c;
                a = b;
                b = c;
                c = count;
            }
            return count;
        }
    }
}
