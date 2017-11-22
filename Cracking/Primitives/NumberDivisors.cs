using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Primitives
{
    class NumberDivisors
    {
        /// <summary>
        /// O(N)
        /// </summary>
        /// <param name="num"></param>
        public static void  GetNumberDivisors1(int num)
        {
            for(int i = 1; 
                i <= num; i++)
            {
                if (num % i == 0)
                    Console.WriteLine(i);
            }
        }

        /// <summary>
        /// O(sqrt(N))
        /// Note that divisors are in pairs so we can loop until sqrt of num
        /// EX: 100 --> (1,100),(2,50),(4,25),(5,20),(10,10)
        /// </summary>
        /// <param name="num"></param>
        public static void GetNumberDivisors2(int num)
        {
            for(int i = 1; i <= Math.Sqrt(num); i++)
            {
                if(num % i == 0)
                {
                    if (i == (num / i))//Same divisors, i.e 10 and 10
                        Console.WriteLine(i);
                    else
                    {
                        Console.WriteLine(i);
                        Console.WriteLine(num / i);
                    }
                }
            }
        }
    }
}
