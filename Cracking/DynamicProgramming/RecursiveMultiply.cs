using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.DynamicProgramming
{
    /*
     * There's nothing substantially better or worse about this solution compared to the first one. 
     * 8.5 Recursive Multiply: Write a recursive function to multiply two positive integers without using the * operator (or / operator).
     * You can use addition, subtraction, and bit shifting, but you should minimize the number of those operations.
     * 
     * Explanation:
     * We can think about multiplying 8x7 as doing 8+8+8+8+8+8+8 (or adding 7 eight times). We can also think about it as the number of squares in an 8x7 grid.
     * How would we count the number of squares in this grid? We could just count each cell. That's pretty slow, though.
     * Alternatively, we could count half the squares and then double it (by adding this count to itself).
     * To count half the squares, we repeat the same process.
     * Of course, this "doubling" only works if the number is in fact even. When it's not even, we need to do the counting/summing from scratch.
     * 
     * 
     * 
     * Solutions below starts from a good solution and goes to the better then best one.
     */
    class RecursiveMultiply
    {
        public static void Test()
        {
            int a = 31;
            int b = 35;
            int prod = MinProduct(a, b);
            Console.WriteLine("Product with minimum steps: " + prod);
            prod = MinProduct_Memo(a, b);
            Console.WriteLine("Product with minimum steps better solution with memorization: " + prod);
            prod = MinProduct_Optimal(a, b);
            Console.WriteLine("Product with minimum steps optimal solution if O(log s): " + prod);
        }

        static int MinProduct(int a, int b)
        {
            int smaller = a < b ? a : b;
            int bigger = a < b ? b : a;
            return MinProduct_Helper(smaller, bigger);
        }

        static int MinProduct_Helper(int smaller, int bigger)
        {
            if (smaller == 0) return 0;// 0 x bigger = 0
            if (smaller == 1) return bigger;// 1 x bigger bigger
            /* Compute half. If uneven, compute other half. If even, double it. */
            int s = smaller >> 1;// 0 x bigger = 0
            int side1 = MinProduct_Helper(s, bigger);
            int side2 = side1;
            if (smaller % 2 == 1)
                side2 = MinProduct_Helper(smaller - s, bigger);
            return side1 + side2;
        }

        static int MinProduct_Memo(int a, int b)
        {
            int smaller = a < b ? a : b;
            int bigger = a < b ? b : a;
            return MinProduct_Helper_Memo(smaller, bigger, new int?[smaller + 1]);
        }

        private static int MinProduct_Helper_Memo(int smaller, int bigger, int?[] memo)
        {
            if (smaller == 0) return 0;// 0 x bigger = 0
            if (smaller == 1) return bigger;// 1 x bigger bigger
            if (!memo[smaller].HasValue)
            {
                /* Compute half. If uneven, compute other half. If even, double it. */
                int s = smaller >> 1;// 0 x bigger = 0
                int side1 = MinProduct_Helper_Memo(s, bigger, memo);
                int side2 = side1;
                if (smaller % 2 == 1)
                    side2 = MinProduct_Helper_Memo(smaller - s, bigger, memo);
                memo[smaller] = side1 + side2;
            }
            return memo[smaller].Value;
        }

        /// <summary>
        /// Runtime: O(log s) where s is the smaller number
        /// </summary>
        /// <param name="smaller"></param>
        /// <param name="bigger"></param>
        /// <returns></returns>
        private static int MinProduct_Optimal(int smaller, int bigger)
        {
            if (smaller == 0) return 0;// 0 x bigger = 0
            if (smaller == 1) return bigger;// 1 x bigger bigger
            int s = smaller >> 1;// 0 x bigger = 0
            int halfProd = MinProduct_Optimal(s, bigger);
            if (smaller % 2 == 0)
                return halfProd + halfProd;
            else
                return halfProd + halfProd + bigger;
        }
    }
}
