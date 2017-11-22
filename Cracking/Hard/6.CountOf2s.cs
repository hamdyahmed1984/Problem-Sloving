using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Hard
{
    public class CountOf2s
    {
        public int CountNumberOf2sInRange_BF(int n)
        {
            int count = 0;
            for(int i = 2; i <= n; i++)
            {
                count += CountOf2sInNumber(i);
            }
            return count;
        }

        /// <summary>
        /// Counts the number of '2' digits in a single number
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private int CountOf2sInNumber(int n)
        {
            int count = 0;
            while(n > 0)
            {
                if (n % 10 == 2)
                    count++;
                n /= 10;
            }
            return count;
        }

        public int CountNumberOf2sInRange_BF2(int n)
        {
            int count = 0;
            for (int i = 2; i <= n; i++)
            {
                count += CountOf2sInNumber(i);
            }
            return count;
        }
        private int CountOf2sInNumber2(int n)
        {
            int count = 0;
            foreach(char c in n.ToString())
            {
                if (c == '2')
                    count++;
            }                      
            return count;
        }

        public int CountNumberOf2sInRange_Optimal(int n)
        {
            int count = 0;
            for(int digitIndex = 0; digitIndex < n.ToString().Length; digitIndex++)
            {
                count += CountNumberOf2InRangeAtDigit(n, digitIndex);
            }
            return count;
        }

        private int CountNumberOf2InRangeAtDigit(int n, int digitIndex)
        {
            int powerOf10 = (int)Math.Pow(10, digitIndex);
            int nextPowerOf10 = powerOf10 * 10;
            int right = n % powerOf10;

            int roundDown = n - n % nextPowerOf10;
            int roundUp = roundDown + nextPowerOf10;

            int digitValue = (n / powerOf10) % 10;

            if (digitValue < 2)
                return roundDown / 10;
            else if (digitValue == 2)
                return roundDown / 10 + right + 1;
            else
                return roundUp / 10;
        }
    }
}
