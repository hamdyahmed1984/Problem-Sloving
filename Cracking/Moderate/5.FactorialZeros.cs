using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Moderate
{
    /// <summary>
    /// 16.5 Factorial zeros: Write an algorithm which computes the number of trailing zeros in n factorial.
    /// 
    /// 
    /// SOLUTION
    /// A simple approach is to compute the factorial, and then count the number of trailing zeros by continuously
    /// dividing by ten.The problem with this though is that the bounds of an int would be exceeded very
    /// quickly. To avoid this issue, we can look at this problem mathematically.
    /// Consider a factorial like 19 ! :
    /// 19! = 1*2*3*4*5*6*7*8*9*10*11*12*13*14*15*16*17*18*19
    /// A trailing zero is created with multiples of 10, and multiples of 10 are created with pairs of 5-multiples and 2-multiples.
    /// For example, in 19!, the following terms create the trailing zeros:
    /// 19! = 2 * ... * 5 * ... * 10 * ... * 15 * 16 * ...
    /// Therefore, to count the number of zeros, we only need to count the pairs of multiples of 5 and 2. There will
    /// always be more multiples of 2 than 5, though, so simply counting the number of multiples of 5 is sufficient.
    /// One "gotcha" here is 15 contributes a multiple of 5 (and therefore one trailing zero), while 25 contributes
    /// two(because 25 = 5 * 5).
    /// </summary>
    class FactorialZeros
    {
        public void Test()
        {
            //We use the mathematical formulas in the methods below because the overflow of large factorials such as 100!
            int num = 100;
            int countTrailingZeros = countFactTrailingZeros1(num);
            countTrailingZeros = countFactTrailingZeros2(num);
            countTrailingZeros = countFactTrailingZeros3(num);
        }

        /// <summary>
        /// directly counting the factors of 5. Using this
        /// approach, we would first count the number of multiples of 5 between 1 and n(which is num/5 ), then the
        /// number of multiples of 25 (num/25), then 125, and so on
        /// To count how many multiples of mare in n, we can just divide n by m.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private int countFactTrailingZeros1(int num)
        {
            if (num < 0) return -1;
            int count = 0;
            for (int i = 5; num / i > 0; i = i * 5)
                count += num / i;
            return count;
        }

        private int countFactTrailingZeros2(int num)
        {
            if (num < 0) return -1;
            int count = 0;
            for (int i = 2; i <= num; i++)
                count += FactorsOf5(i);
            return count;
        }

        private int FactorsOf5(int i)
        {
            int count = 0;
            while(i % 5 == 0)
            {
                count++;
                i = i / 5;
            }
            return count;
        }

        private int countFactTrailingZeros3(int num)
        {
            int count = 0;
            //Calculate factorial and then count the number of trailing zeros in the factorial, by using % 10
            return count;
        }
    }
}
