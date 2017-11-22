using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    class Factorial
    {
        public int LoopFactorial(int n)
        {
            int ret = n;
            for (int i = n; i > 1; i--)
            {
                ret *= (i - 1);
            }
            return ret;
        }

        public int WhileFactorial(int n)
        {
            int fact = n;
            while (n > 1)
            {
                fact *= (n - 1);
                n--;
            }
            return fact;
        }

        public int RecurFactorial(int n)
        {
            if (n == 1)
                return 1;
            else
                return n * RecurFactorial(n - 1);
        }
    }
}
