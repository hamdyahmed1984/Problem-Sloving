using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Moderate
{
    /// <summary>
    /// 16.7 Number Max: Write a method that finds the maximum of two numbers. You should not use if-else or any other comparison operator.
    /// </summary>
    class MaxOf2Numbers
    {
        public void Test()
        {
            //int a = int.MaxValue - 2;
            //int b = -15;
            int a = 5;
            int b = 2;
            int max = GetMax2(a, b);
            int min = GetMin2(a, b);
        }

        /// <summary>
        /// This will return wrong value if there is integer overflow
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private int GetMax1(int a, int b)
        {
            return ((a + b) + Math.Abs(a - b)) / 2;
        }
        /// <summary>
        /// This will return wrong value if there is integer overflow
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private int GetMin1(int a, int b)
        {
            return ((a + b) - Math.Abs(a - b)) / 2;
        }

        /// <summary>
        /// This will return wrong value if there is integer overflow
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private int GetMax2(int a, int b)
        {
            int c = a - b;
            //Rigth shift the sign bit (most significant bit) to be the first bit
            //k == 0 so the difference is positive so a > b, k == 1 so the difference is negative so a < b
            int k = (c >> 31) & 1;//The ANDing with 1 is additional step here
            /*
             * int max = a - k * c;
             * int min = b + k * c;
             */
            int k2 = Flip(k);
            int max = a * k2 + b * k;
            return max;
        }
        /// <summary>
        /// This will return wrong value if there is integer overflow
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private int GetMin2(int a, int b)
        {
            int c = a - b;
            //Rigth shift the sign bit (most significant bit) to be the first bit
            //k == 0 so the difference is positive so a > b, k == 1 so the difference is negative so a < b
            int k = (c >> 31) & 1;//The ANDing with 1 is additional step here
            int k2 = Flip(k);
            int min = a * k + b * k2;
            return min;
        }
        int Flip(int num)
        {
            //XORing with 1 will flip the bit
            return num ^ 1;
        }

        int GetMax3(int a, int b)
        {
            int c = a - b;
            int sa = (a >> 31) & 1;//If a >= 0, then 0  else 1
            int sb = (b >> 31) & 1;//If b >= 0, then 0 else 1
            int sc = (c >> 31) & 1;//depends on whether or not a - b overflows

            /*Goal: define a value k which is 0 if a > b and 1
             * (if a = b, it doesn't matter what value k is) */

            // If a and b have different signs, then k = sign(a)
            int use_sign_of_a = sa ^ sb;

            //If a and b have the same sign, then k = sign(a - b)
            int use_sign_of_c = Flip(sa ^ sb);

            int k = use_sign_of_a * sa + use_sign_of_c * sc;
            int k2 = Flip(k);

            int max = a * k2 + b * k;
            return max;
        }
    }
}
