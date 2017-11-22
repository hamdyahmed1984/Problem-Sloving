using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.BitManipulation
{
    class FloatingNumberToBinary
    {
        public static void Test()
        {
            string res = GetBinaryForTheNubmer(13.625);
            Console.WriteLine(res);
        }
        static string GetBinaryForTheNubmer(double num)
        {
            int intPart = (int)num;
            double fracPart = num - Math.Floor(num);
            string fracBin = GetBinaryOfFraction(fracPart);
            if (fracBin == "ERROR")
                return fracBin;
            return GetBinaryOfIntPart(intPart) + fracBin;

        }

        static string GetBinaryOfIntPart(int num)
        {
            StringBuilder sb = new StringBuilder();
            while(num > 0)
            {
                sb.Insert(0, num % 2);
                num = num / 2;                
            }
            return sb.ToString();
        }

        static string GetBinaryOfFraction(double num)
        {
            if (num >= 1 || num <= 0)
                return "ERROR";
            StringBuilder sb = new StringBuilder();
            sb.Append(".");
            while (num > 0)
            {
                if (sb.Length >= 32)
                    return "ERROR";
                double x = num * 2;
                if (x >= 1)
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
