using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Primitives
{
    class BaseConversion
    {
        public static string ConvertFromBaseToBase(string num, int baseFrom, int baseTo)
        {
            bool isNegative = false;
            if (num[0] == '-')
                isNegative = true;

            int intValue = 0;//Convert the num from baseFrom to base 10
            for (int i = isNegative ? 1 : 0; i < num.Length; i++)
            {
                intValue *= baseFrom;
                intValue += char.IsDigit(num[i]) ? num[i] - '0' : num[i] - 'A' + 10;
            }

            StringBuilder sbNumIn_baseTo = new StringBuilder();
            while(intValue > 0)
            {
                char c;
                int remainder = intValue % baseTo;
                if (remainder >= 10)
                    c = (char)(remainder + 'A' - 10);
                else
                    c = (char)(remainder + '0');
                sbNumIn_baseTo.Append(c);
                intValue = intValue / baseTo;
            }
            for(int i = 0; i < sbNumIn_baseTo.Length / 2; i++)
            {
                char tmp = sbNumIn_baseTo[i];
                sbNumIn_baseTo[i] = sbNumIn_baseTo[sbNumIn_baseTo.Length - 1 - i];
                sbNumIn_baseTo[sbNumIn_baseTo.Length - 1 - i] = tmp;
            }

            return sbNumIn_baseTo.ToString();
        }
    }
}
