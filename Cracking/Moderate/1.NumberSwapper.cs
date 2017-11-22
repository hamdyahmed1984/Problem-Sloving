using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Moderate
{
    /// <summary>
    /// 16.1 Number Swapper: Write a function to swap a number in place (that is, without temporary variables).
    /// </summary>
    class NumberSwapper
    {
        public void Test()
        {
            int a = 9, b = 4;
            Swap1(a, b);
            Swap2(a, b);
            Swap3(a, b);
            Swap4(a, b);
        }

        private void Swap1(int a, int b)
        {
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;
        }
        private void Swap2(int a, int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }

        private void Swap3(int a, int b)
        {
            a = a - b;
            b = a + b;
            a = b - a;
        }

        private void Swap4(int a, int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }        
    }
}
