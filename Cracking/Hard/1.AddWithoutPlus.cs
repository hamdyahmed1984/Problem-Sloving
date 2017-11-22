using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Hard
{
    /// <summary>
    /// 17 .1 Add Without Plus: Write a function that adds two numbers. You should not use+ or any arithmetic operators.
    /// </summary>
    public class AddWithoutPlus
    {

        public int Add(int a, int b)
        {
            while (b != 0)
            {
                int sum = a ^ b;//add without carrying
                int carry = (a & b) << 1;//carry, but don't add
                a = sum;
                b = carry;
            }
            return a;
        }
    }
}
