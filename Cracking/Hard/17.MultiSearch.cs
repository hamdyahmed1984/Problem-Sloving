using Cracking.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Hard
{
    /// <summary>
    /// 17.17 Multi Search: Given a string band an array of smaller strings T, design a method to search b for each small string in T.
    /// </summary>
    public class MultiSearch
    {
        /// <summary>
        /// Runtime: O(kbt), where k is the length of the longest string in smalls, b is the length of the big string, and t is the number of strings within smalls.
        /// </summary>
        /// <param name="big"></param>
        /// <param name="smalls"></param>
        /// <returns></returns>
        public Dictionary<string, List<int>> SearchAll_Naive(string big, string[] smalls)
        {
            Dictionary<string, List<int>> lookup = new Dictionary<string, List<int>>();
            foreach(string small in smalls)
            {
                GetSmallStringsLocations(big, small, lookup);
            }
            return lookup;
        }

        /*Find all locations of the smaller string within the bigger string.*/
        private void GetSmallStringsLocations(string big, string small, Dictionary<string, List<int>> lookup)
        {
            for(int offset = 0; offset <= big.Length - small.Length; offset++)
            {
                if(GetStringLocation(big, small, offset, lookup))
                {
                    if (!lookup.ContainsKey(small))
                        lookup.Add(small, new List<int>() { offset });
                    else
                        lookup[small].Add(offset);
                }
            }
        }
        /*Check if small appears at index offset within big.*/
        private bool GetStringLocation(string big, string small, int offset, Dictionary<string, List<int>> lookup)
        {
            for(int i = 0; i < small.Length; i++)
            {
                if (big[offset + i] != small[i])
                    return false;
            }
            return true;
        }

        /// <summary>
        /// O(t*k + b*k), where k is the length of the longest string in smalls, b is the length of the big string, and t is the number of strings within smalls.
        /// </summary>
        /// <param name="big"></param>
        /// <param name="smalls"></param>
        /// <returns></returns>
        public Dictionary<string, List<int>> SearchAll_Trie(string big, string[] smalls)
        {
            Dictionary<string, List<int>> lookup = new Dictionary<string, List<int>>();
            TrieNode2 tree = CreateTrieFromList(smalls, big);
            for (int start = 0; start < big.Length; start++)
            {
                List<string> stringsAtLocation = FindStringsAtLocation(big, start, tree);
                AddStringToLookup(lookup, stringsAtLocation, start);
            }
            return lookup;
        }
        /*Insert each string into trie (provided string is not longer than maxLen).*/
        private TrieNode2 CreateTrieFromList(string[] smalls, string big)
        {
            int maxLength = big.Length;
            TrieNode2 tree = new TrieNode2();
            foreach (string small in smalls)
                if (small.Length <= maxLength)
                    tree.Insert(small);
            return tree;
        }
        /*Find strings in trie that start at index "start" within big.*/
        private List<string> FindStringsAtLocation(string big, int start, TrieNode2 tree)
        {
            List<string> foundSmalls = new List<string>();
            int index = start;
            while(index < big.Length)
            {
                tree = tree.GetChild(big[index]);
                if (tree == null) break;
                if (tree.IsLeaf)
                    foundSmalls.Add(big.Substring(start, index - start + 1));//Take the string starting from start and count index -start + 1 chars
                index++;
            }
            return foundSmalls;
        }
        private void AddStringToLookup(Dictionary<string, List<int>> lookup, List<string> stringsAtLocation, int index)
        {
            foreach(string small in stringsAtLocation)
            {
                if (!lookup.ContainsKey(small))
                    lookup.Add(small, new List<int>() { index });
                else
                    lookup[small].Add(index);
            }
        }
    }
}
