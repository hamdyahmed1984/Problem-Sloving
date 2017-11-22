using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Primitives
{
    class ConvertBetweenStrAndInt
    {
        public static int StrToInt(string str)
        {
            int result = 0;
            bool isNegative = str[0] == '-';
            for(int i = isNegative ? 1 : 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    result = result * 10;
                    result += ConvertCharToInt(str[i]);
                }
                else
                    throw new InvalidCastException("String is not a valid integer.");
            }
            if (isNegative)
                return -result;
            else return result;
        }

        public static string IntToStr(int x)
        {
            StringBuilder sb = new StringBuilder();
            bool isNegative = x < 0;
            if (isNegative)
                x = -x;
            while(x > 0)
            {
                sb.Append(x % 10);
                x /= 10;
            }
            if (isNegative)
                sb.Append('-');
           
            for(int i = 0; i < sb.Length / 2; i++)
            {
                char tmp = sb[i];
                sb[i] = sb[sb.Length - 1 - i];
                sb[sb.Length - 1 - i] = tmp;
            }
            return sb.ToString();
        }

        private static int ConvertCharToInt(char c)
        {
            return c - '0';//Subtracting ascii codes so we get the numeric respresentation not the ascii code
        }
    }
}
