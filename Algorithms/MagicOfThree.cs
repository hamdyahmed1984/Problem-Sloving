using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class MagicOfThree
    {
        public double findNumberOfOnes(double number)
        {
            double numberOfOnes = 1;
            double remainder = 1;
            while(remainder != 0)
            {
                remainder = (remainder * 10 + 1) % number;
                numberOfOnes++;
            }
            return numberOfOnes;
        }
    }
}
