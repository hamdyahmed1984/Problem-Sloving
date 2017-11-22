using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    class StringPermutations
    {
        public static void Permutation(string str)
        {
            Permutation("", str);
        }

        private static void Permutation(string prefix, string str)
        {
            if (str.Length == 0)
                Console.WriteLine(prefix);
            else
            {
                for(int i = 0; i < str.Length; i++)
                {
                    string pre = prefix + str[i];
                    string remaining = str.Substring(0, i) + str.Substring(i + 1);
                    Permutation(pre, remaining);
                }
            }
        }
    }
}
