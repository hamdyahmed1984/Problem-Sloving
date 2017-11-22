using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Arrays
{
    class Rabin_Karp
    {
        private static int prime = 101;

        public static void Test()
        {
            PatternSearch("abcdefcdggcdeee".ToCharArray(), "cd".ToCharArray());
        }
        private static void PatternSearch(char[] txt, char[] pattern)
        {
            int n = txt.Length;
            int m = pattern.Length;
            double patternHash = CreateHash(pattern, m);//hash for pattern
            double txtHash = CreateHash(txt, m);//hash for first window of text
            for(int i = 0; i <= n - m; i++)
            {
                if(patternHash == txtHash && CheckEqual(txt, i, i + m - 1, pattern, 0, m-1))
                {
                    Console.WriteLine("Match found at index: {0}", i);
                }
                else if(i < n - m)
                {
                    txtHash = RecalculateHash(txt, i, i + m, txtHash, m);
                }
            }
        }
        private static double CreateHash(char[] str, int end)
        {
            double hash = 0;
            for (int i = 0; i < end; i++)
            {
                hash += str[i] * Math.Pow(prime, i);
            }
            return Math.Ceiling(hash);//Math.Ceiling is very important for hashes comparison
        }
        private static double RecalculateHash(char[] str, int oldIndex, int newIndex, double oldHash, int patternLength)
        {
            double newHash = oldHash - str[oldIndex];
            newHash /= prime;
            newHash += str[newIndex] * Math.Pow(prime, patternLength - 1);
            return Math.Ceiling(newHash);
        }

        private static bool CheckEqual(char[] str1, int start1, int end1, char[] str2, int start2, int end2)
        {
            if (end1 - start1 != end2 - start2)
                return false;
            while(start1 <= end1 && start2 <= end2)
            {
                if (str1[start1++] != str2[start2++])
                    return false;
            }
            return true;
        }
    }
}
