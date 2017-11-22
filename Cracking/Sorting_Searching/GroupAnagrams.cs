using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Sorting_Searching
{
    /// <summary>
    /// 10.2 Group Anagrams: Write a method to sort an array ot strings so that all tne anagrnms are next to each other.
    /// </summary>
    class GroupAnagrams
    {
        public void Test()
        {
            string[] arr = { "rat", "cat", "cta", "hamdy", "act", "test", "cat", "atc" };
            string[] arr2 = { "rat", "cat", "cta", "hamdy", "act", "test", "cat", "atc" };

            GroupAnagramsArr1(arr);
            arr.ToList().ForEach(Console.WriteLine);

            GroupAnagramsArr2(arr2);
            arr2.ToList().ForEach(Console.WriteLine);
        }

        /// <summary>
        /// O(n * log n)
        /// </summary>
        /// <param name="arr"></param>
        private void GroupAnagramsArr1(string[] arr)
        {
            Array.Sort(arr, new AnagramComparer());
        }

        /// <summary>
        /// O(n)
        /// </summary>
        /// <param name="arr"></param>
        private void GroupAnagramsArr2(string[] arr)
        {
            Dictionary<string, List<string>> dict = ConvertArrayToDict(arr);
            ConvertDictToArray(dict, arr);
        }

        private void ConvertDictToArray(Dictionary<string, List<string>> dict, string[] arr)
        {
            int index = 0;
            foreach(string key in dict.Keys)
            {
                foreach(string str in dict[key])
                {
                    arr[index++] = str;
                }
            }
        }

        private Dictionary<string, List<string>> ConvertArrayToDict(string[] arr)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            foreach (string str in arr)
            {
                string key = SortChars(str);
                if (dict.ContainsKey(key))
                    dict[key].Add(str);
                else
                    dict.Add(key, new List<string>() { str });
            }
            return dict;
        }

        string SortChars(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Sort(arr);
            return new string(arr);
        }

        class AnagramComparer : IComparer<string>
        {
            string SortChars(string str)
            {
                char[] arr = str.ToCharArray();
                Array.Sort(arr);
                return new string(arr);
            }
            public int Compare(string x, string y)
            {
                return SortChars(x).CompareTo(SortChars(y));
            }
        }
    }
}
