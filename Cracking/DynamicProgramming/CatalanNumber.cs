using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.DynamicProgramming
{
    class CatalanNumber
    {
        public void Test()
        {
            int n = 4;
            long? catalan = 0;
            catalan = Catalan_Recursive(n);
            Console.WriteLine(catalan);

            catalan = Catalan_Memo(n, new long?[n + 1]);
            Console.WriteLine(catalan);

            catalan = Catalan_DP(n);
            Console.WriteLine(catalan);

            catalan = Catalan_UsingFactorial(n);
            Console.WriteLine(catalan);
        }

        private long Catalan_Recursive(int n)
        {
            if (n <= 1) return 1;
            long catalan = 0;
            for (int i = 0; i < n; i++)
                catalan += Catalan_Recursive(i) * Catalan_Recursive(n - i - 1);
            return catalan;
        }
        private long? Catalan_Memo(int n, long?[] memo)
        {
            if (n <= 1) return 1;
            if (!memo[n].HasValue)
            {
                long catalan = 0;
                for (int i = 0; i < n; i++)
                    catalan += Catalan_Recursive(i) * Catalan_Recursive(n - i - 1);
                memo[n] = catalan;
            }
            return memo[n];
        }

        private long Catalan_DP(int n)
        {
            long[] catalan = new long[n + 1];
            catalan[0] = catalan[1] = 1;
            for(int i = 2; i <= n; i++)
            {
                catalan[i] = 0;
                for(int j = 0; j < i; j++)
                {
                    catalan[i] += catalan[j] * catalan[i - j - 1];
                }
            }
            return catalan[n];
        }

        private long Catalan_UsingFactorial(int n)
        {
            return Fact(2 * n) / ((Fact(n + 1) * Fact(n)));
        }
        private long Fact(int n)
        {
            long[] fact = new long[n + 1];
            fact[0] = fact[1] = 1;
            for (int i = 2; i <= n; i++)
                fact[i] = i * fact[i - 1];
            return fact[n];
        }
    }
}
