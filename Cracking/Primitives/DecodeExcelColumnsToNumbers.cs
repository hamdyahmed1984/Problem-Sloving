using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Primitives
{
    class DecodeExcelColumnsToNumbers
    {
        public static int DecodeColumn(string col)
        {
            int result = 0;
            for(int i = 0; i < col.Length; i++)
            {
                result = result * 26;//We have 26 letters so this is our base
                result += col[i] - 'A' + 1;//subtract 'A' ascii from the letter to get its number
            }
            return result;
        }
    }
}
