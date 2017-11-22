using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.BitManipulation
{
    class FractionBinary
    {
        public static void Test()
        {
            string bin = PrintBinaryOfFraction(.72);
        }
        static string PrintBinaryOfFraction(double num)
        {
            if (num >= 1 || num <= 0)
                return "ERROR";
            StringBuilder sb = new StringBuilder();
            sb.Append(".");
            while(num > 0)
            {
                if (sb.Length >= 32)
                    return "ERROR";
                double x = num * 2;
                if(x >= 1)
                {
                    sb.Append("1");
                    num = x - 1;
                }
                else
                {
                    sb.Append("0");
                    num = x;
                }
            }
            return sb.ToString();
        }
    }
}
