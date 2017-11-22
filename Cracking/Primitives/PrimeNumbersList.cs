using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Primitives
{
    class PrimeNumbersList
    {
        public static void Test()
        {
            int n = 1000000;
            DateTime dtStart = DateTime.Now;
            bool[] primes = GetPrimeNumbersLessThanN(n);
            //for(int i = 0; i < 1000000000;i++)
            //{
            //    int x = 0;
            //}
            DateTime dtEnd = DateTime.Now;
            Console.WriteLine("Elapsed Time: " + (dtEnd-dtStart).ToString());

            //for (int i = 2; i < primes.Length; i++)
            //    if (primes[i]) Console.Write(i + ", ");
        }

        private static bool[] GetPrimeNumbersLessThanN(int n)
        {
            // Create a boolean array "prime[0..n]" and initialize
            // all entries it as true. A value in prime[i] will
            // finally be false if i is Not a prime, else true.
            bool[] primes = new bool[n + 1];
            // Set all flags to true other than 0 and 1
            for (int i = 2; i <= n; i++)
                primes[i] = true;

            for (int prime = 2; prime <= Math.Sqrt(n); prime++)
            {
                // If primes[prime] is not changed, then it is a prime
                if (primes[prime])
                {
                    /* Unmark all remaining multiples of prime. We can start with (prime*prime),
                    * because if we have a j * prime, where j < prime, this value would have
                    * already been crossed off in a prior iteration. */
                    for (int j = prime * prime; j <= n; j = j + prime)
                    {
                        primes[j] = false;
                    }
                }
            }

            return primes;
        }
    }
}
