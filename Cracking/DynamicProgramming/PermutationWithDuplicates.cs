using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.DynamicProgramming
{
    /*
     * 8.8 Permutations with Duplicates: Write a method to compute all permutations of a string whose characters are not necessarily unique.
     * The list of permutations should not have duplicates.
     */
    class PermutationWithDuplicates
    {
        public static void Test()
        {
            string str = "aabc";
            List<string> perms = GetPerms(str);

            foreach (string perm in perms)
                Console.WriteLine(perm);
        }

        private static List<string> GetPerms(string str)
        {
            Dictionary<char, int> map = GetCharsFreq(str);
            List<string> perms = new List<string>();
            char[] characters = new char[map.Count];
            int[] count = new int[map.Count];

            int index = 0;
            foreach(char c in map.Keys)
            {
                characters[index] = c;
                count[index] = map[c];
                index++;
            }

            GetPerms(characters, count, new char[str.Length], 0, perms);
            return perms;
        }

        private static void GetPerms(char[] characters, int[] count, char[] singlePerm, int level, List<string> perms)
        {
            if(level == singlePerm.Length)
            {
                perms.Add(new string(singlePerm));
                return;
            }
            for (int i = 0; i < characters.Length; i++)
            {
                if (count[i] == 0)
                    continue;
                singlePerm[level] = characters[i];
                count[i]--;
                GetPerms(characters, count, singlePerm, level + 1, perms);
                count[i]++;
            }
        }

        //private static void GetPerms(Dictionary<char, int> map, string prefix, int remainingLength, List<string> perms)
        //{
        //    if(remainingLength == 0)
        //    {
        //        perms.Add(prefix);
        //        return;
        //    }
        //    foreach (char c in map.Keys)
        //    {
        //        int count = map[c];
        //        if (count > 0)
        //        {
        //            map[c]--;
        //            GetPerms(map, prefix + c, remainingLength - 1, perms);
        //            map[c] = count;
        //        }
        //    }
        //}

        private static Dictionary<char, int> GetCharsFreq(string str)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach(char c in str)
            {
                if (map.ContainsKey(c))
                    map[c]++;
                else
                    map.Add(c, 1);
            }
            return map;
        }
    }
}
