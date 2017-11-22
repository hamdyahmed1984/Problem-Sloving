using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Arrays
{
    class SubString
    {
        public static void SubStringTest()
        {
            GetSubStringIndex("abcdefbcdx", "bc");
        }

        private static void GetSubStringIndex(string txt, string pat)
        {
            int n = txt.Length;
            int m = pat.Length;
            for(int i = 0; i <= n - m; i++)
            {
                int j;
                for(j = 0; j < m; j++)
                {
                    if (pat[j] != txt[i + j])
                        break;
                }
                if (j == m)
                    Console.WriteLine("Substring found at index: {0}", i);
            }
        }
    }
}
