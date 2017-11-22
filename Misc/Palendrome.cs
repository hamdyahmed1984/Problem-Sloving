using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    class Palendrome
    {
        public bool IsPalendrome(string word)
        {
            if (word.Length == 1 || word.Length == 0)
                return true;
            else if (word[0] == word[word.Length - 1])
                return IsPalendrome(word.Substring(1, word.Length - 2));
            else
                return false;
        }
    }
}
