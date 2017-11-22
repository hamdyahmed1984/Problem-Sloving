using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    class Misc
    {
        public static int modulo(int a, int b)
        {
            if (b <= 0)
                throw new DivideByZeroException();
            int div = a / b;
            int modulo = a - div * b;
            return modulo;
        }
        public static int div(int a, int b)
        {
            int count = 0;
            int sum = b;
            while(sum < a)
            {
                sum += b;
                count++;
            }
            return count;
        }

        public static int sqrt(int n)
        {
            return sqrt(n, 1, n);
        }

        private static int sqrt(int n, int min, int max)
        {
            if (min > max)
                return -1;
            int guess = (min + max) / 2;
            if (guess * guess == n)
                return guess;
            else if (guess * guess < n)
                return sqrt(n, guess + 1, max);
            else
                return sqrt(n, min, guess - 1);
        }

        public static int sqrtImpl2(int n)
        {
            for (int guess = 1; guess * guess <= n; guess++)
                if (guess * guess == n)
                    return guess;
            return -1;
        }

        public static int sumDigitsInNumber(int n)
        {
            int sum = 0;
            while(n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }
    }
}
