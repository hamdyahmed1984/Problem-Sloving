using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    class IsPalendrome
    {
        public bool isPalendrome(string test)
        {
            bool isPalendrome = true;
            for(int i = 0; i < test.Length / 2; i++)
            {
                if (test[i] != test[test.Length - 1 - i])
                {
                    return false;
                }
            }
            return isPalendrome;
        }
        public bool isPalendromeRecursive(string word)
        {
            if (word.Length == 1 || word.Length == 0)
                return true;
            else if (word[0] == word[word.Length - 1])
                return isPalendromeRecursive(word.Substring(1, word.Length - 2));
            else
                return false;
        }
    }
}
