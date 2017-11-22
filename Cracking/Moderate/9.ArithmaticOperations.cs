using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Moderate
{
    class ArithmeticOperations
    {
		public void Test()
        {
            int x = Subtract(5, 2);
            x = Subtract(5, -2);
            x = Subtract(-5, 2);
            x = Subtract(-5, -2);
            x = Subtract(2, 5);
            x = Subtract(2, -5);

            x = Multiply(5, 2);
            x = Multiply(2, 5);
            x = Multiply(5, -2);
            x = Multiply(-5, -2);

            x = Div(5, 2);
            x = Div(2, 5);
            x = Div(5, -2);
            x = Div(-5, 2);
            x = Div(0, 5);
            x = Div(5, 0);
        }

        /// <summary>
        /// Flip a positive sign to negative or negative sign to pos.
        /// 5 becomes -5, -5 becomes 5
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private int ReverseSign(int num)
        {
            int factor = num < 0 ? 1 : -1;
            int newNumber = 0;
			while(num != 0)
            {
                newNumber += factor;
                num += factor;
            }
            return newNumber;
        }

        /// <summary>
        /// Subtract two numbers by negating b and adding them
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private int Subtract(int a, int b)
        {
            return a + ReverseSign(b);
        }

		private int Multiply(int a, int b)
        {
            if (a < b)
                return Multiply(b, a);//algorithm is faster if b < a
            int prod = 0;
            int b_abs = Abs(b);//Get absolute value of b
			while(b_abs > 0)//Continuously add a to prod until b is 0
            {
                prod += a;
                b_abs = Subtract(b_abs, 1);//b_abs--
            }
            if (b < 0)
                prod = ReverseSign(prod);
            return prod;
        }

		private int Div(int a, int b)
        {
            if (b == 0) throw new DivideByZeroException("Divide by zero is invalid!");
            int count = 0;
            int a_abs = Abs(a);
            int b_abs = Abs(b);

			while(b_abs <= a_abs)
            {
                b_abs += b_abs;
                count++;
            }

            if ((a > 0 && b > 0) || (a < 0 && b < 0))
                return count;
            else
                return ReverseSign(count);
        }
        /// <summary>
        /// Return absolute value
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private int Abs(int num)
        {
            if (num < 0)
                return ReverseSign(num);
            return num;
        }
    }
}
