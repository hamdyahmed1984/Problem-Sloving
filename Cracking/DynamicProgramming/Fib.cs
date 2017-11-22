using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.DynamicProgramming
{
    class Fib
    {
        public static void Test()
        {
            int n = 6;
            Console.WriteLine("Fib: " + Fib_Recursive(n));
            Console.WriteLine("Fib: " + Fib_Recursive_Memo(n));
            Console.WriteLine("Fib: " + Fib_BottomUp(n));
            Console.WriteLine("Fib: " + Fib_BottomUp_Optimal(n));
        }
        private static int Fib_Recursive(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fib_Recursive(n - 1) + Fib_Recursive(n - 2);
        }

        private static int Fib_Recursive_Memo(int n)
        {
            return Fib_Recursive_Memo(n, new int[n + 1]);
        }

        private static int Fib_Recursive_Memo(int n, int[] memo)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (memo[n] == 0)
                memo[n] = Fib_Recursive_Memo(n - 1, memo) + Fib_Recursive_Memo(n - 2, memo);
            return memo[n];
        }

        private static int Fib_BottomUp(int n)
        {
            int[] fibs = new int[n + 1];
            fibs[0] = 0;
            fibs[1] = 1;
            for (int i = 2; i <= n; i++)
                fibs[i] = fibs[i - 1] + fibs[i - 2];
            return fibs[n];
        }

        private static int Fib_BottomUp_Optimal(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            int a = 0;
            int b = 1;
            int fib = 0;
            for(int i = 2; i <= n; i++)
            {
                fib = a + b;
                a = b;
                b = fib;
            }
            return fib;
        }
    }
}
