using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Hard
{
    /// <summary>
    /// 17.15 Longest Word: Given a list of words, write a program to find the longest word made of other words in the list.'
    /// </summary>
    public class LongestWord
    {
        ///// <summary>
        ///// O(N^2), where N is the list length
        ///// </summary>
        ///// <param name="words"></param>
        ///// <returns></returns>
        //public string FindLongestCompoundWord_Bad(string[] words)
        //{
        //    for(int i = 0; i < words.Length; i++)
        //    {
        //        string word1 = words[i];
        //        for(int j = i + 1; j < words.Length; j++)
        //        {
        //            string word2 = words[j];
        //            if(word1 + word2 == )
        //        }
        //    }
        //}

            /// <summary>
            /// This method will not work in case of there are multiple instances of some words in the main list.
            /// We can use string.Replace instead of string.Remove to remove all instances, but this will remove smaller words where they are
            /// part of larger words, ex: there and the
            /// </summary>
            /// <param name="words"></param>
            /// <returns></returns>
        public string FindLongestCompoundWord_2Loops(string[] words)
        {
            HashSet<string> dictionary = GetWordsHashSet(words);
            Array.Sort(words, new StringLengthComparer());
            foreach (string word in words)
            {
                string backup = word;
                foreach (string otherWord in words)
                {
                    if (otherWord != backup && word.Contains(otherWord))
                        backup = backup.Remove(backup.IndexOf(otherWord), otherWord.Length);//backup.Replace(otherWord, "");
                }
                if (backup.Length == 0)
                    return backup;
            }
            return null;

        }
        public string FindLongestCompoundWord_TwoWords(string[] words)
        {
            HashSet<string> dictionary = GetWordsHashSet(words);
            Array.Sort(words, new StringLengthComparer());
            
            foreach(string word in words)
            {
                for(int i = 1; i < word.Length; i++)
                {
                    string left = word.Substring(0, i);
                    string right = word.Substring(i);
                    if (dictionary.Contains(left) && dictionary.Contains(right))
                        return word;
                }
            }
            return null;
        }

        public string FindLongestCompoundWord_Recursion(string[] words)
        {
            HashSet<string> dictionary = GetWordsHashSet(words);
            Array.Sort(words, new StringLengthComparer());

            foreach(string word in words)
            {
                if (CanBuildWord(word, dictionary, true))
                    return word;
            }
            return null;
        }

        private bool CanBuildWord(string word, HashSet<string> dictionary, bool isTheCheckedWord)
        {
            if(dictionary.Contains(word) && !isTheCheckedWord)
            {
                return true;
            }
            for(int i = 1; i < word.Length; i++)
            {
                string left = word.Substring(0, i);
                string right = word.Substring(i);
                if (dictionary.Contains(left) && CanBuildWord(right, dictionary, false))
                    return true;
            }
            return false;
        }

        public string FindLongestCompoundWord_Memo(string[] words)
        {
            Dictionary<string, bool> dictionary = GetWordsMap(words);
            Array.Sort(words, new StringLengthComparer());

            foreach (string word in words)
            {
                if (CanBuildWord_Memo(word, dictionary, true))
                    return word;
            }
            return null;
        }

        private bool CanBuildWord_Memo(string word, Dictionary<string, bool> dictionary, bool isTheCheckedWord)
        {
            if(dictionary.ContainsKey(word) && !isTheCheckedWord)
            {
                return dictionary[word];//This line will return true if the word contained in the original list or false if the word is calculated before and there is no way to make it of other words.
            }
            for(int i = 1; i < word.Length; i++)
            {
                string left = word.Substring(0, i);
                string right = word.Substring(i);
                if (dictionary.ContainsKey(left) && dictionary[left] == true && CanBuildWord_Memo(right, dictionary, false))
                    return true;
            }
            if (!dictionary.ContainsKey(word))
            {
                //Now the current word no way to make it of other words, we add it to the map so we don't compute it again and just return false in the start of the methos.
                dictionary.Add(word, false);
            }
            return false;
        }

        private HashSet<string> GetWordsHashSet(string[] words)
        {
            HashSet<string> set = new HashSet<string>();
            foreach (string word in words)
                set.Add(word);
            return set;
        }
        private Dictionary<string, bool> GetWordsMap(string[] words)
        {
            Dictionary<string, bool> map = new Dictionary<string, bool>();
            foreach (string word in words)
                if (!map.ContainsKey(word))
                    map.Add(word, true);
            return map;
        }

        private class StringLengthComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                //sort in desc order
                return y.Length.CompareTo(x.Length);
            }
        }
    }
}
