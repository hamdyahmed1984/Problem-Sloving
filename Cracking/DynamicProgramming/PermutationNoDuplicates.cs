using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.DynamicProgramming
{
    /*
     * 8.7 Permutations without Dups: Write a method to compute all permutations of a string of unique characters.
     */
    class PermutationNoDuplicates
    {
        public static void Test()
        {
            string str = "abc";
            List<string> perms = GetPerms(str);

            Console.WriteLine("Permutations using passing list back up the stack: ");
            foreach (string perm in perms)
                Console.WriteLine(perm);
            Console.WriteLine("Permutations using passing prefix down the stack: ");
            perms = GetPerms2(str);
            foreach (string perm in perms)
                Console.WriteLine(perm);
        }

        private static List<string> GetPerms(string str)
        {
            List<string> perms = new List<string>();
            if(str.Length == 0)
            {
                perms.Add("");
                return perms;
            }
            for(int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                string before = str.Substring(0, i);
                string after = str.Substring(i + 1);
                List<string> partials = GetPerms(before + after);
                foreach (string s in partials)
                    perms.Add(c + s);
            }
            return perms;
        }

        private static List<string> GetPerms2(string str)
        {
            List<string> perms = new List<string>();
            GetPerms2("", str, perms);
            return perms;
        }

        private static void GetPerms2(string prefix, string remaining, List<string> perms)
        {
            if (remaining.Length == 0)
                perms.Add(prefix);
            for(int i = 0; i < remaining.Length; i++)
            {
                char c = remaining[i];
                string before = remaining.Substring(0, i);
                string after = remaining.Substring(i + 1);
                GetPerms2(prefix + c, before + after, perms);
            }
        }
    }
}
