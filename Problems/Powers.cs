using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    class Powers
    {
        public static double printPowersOfTwo(double n)
        {
            if (n < 1)
                return 0;
            if(Math.Round(n, 0) == 1)
            {
                Console.WriteLine("1");
                return 1;
            }
            else
            {
                double prev = printPowersOfTwo(n / 2);
                double current = prev * 2;
                Console.WriteLine(current.ToString());
                return current;
            }

        }

        /// <summary>
        /// Get a to the power b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int getPower(int a, int b)
        {
            if (b < 0)
                return 0;
            if (b == 0)
                return 1;
            else
            {
                return a * getPower(a, b - 1);
            }
        }
        public static int getPowerImp2(int a, int b)
        {
            if (b < 0)
                return 0;
            if (b == 1)
                return a;
            else
            {
                return a * getPowerImp2(a, b - 1);
            }
        }

        public static int getPowerImp3(int a, int b)
        {
            int power = a;
            while(b > 1)
            {
                power *= a;
                b--;
            }
            return power;
        }
    }
}
