using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Graphs
{
    /// <summary>
    /// Implementation using recursion
    /// </summary>
    class TrieNode3
    {
        public bool IsLeaf;
        public readonly static int ALPHAPET_SIZE = 26;
        public TrieNode3[] Children = new TrieNode3[ALPHAPET_SIZE];
        int size = 0;

        public void Insert(string word)
        {
            Insert(word, 0);
        }

        public void Insert(string word, int index)
        {
            size++;
            if (index == word.Length) return;
            char c = word[index];
            int charCode = c - 'a';
            if (Children[charCode] == null)
                Children[charCode] = new TrieNode3();
            Children[charCode].Insert(word, index + 1);            
        }

        public int FindCount(string str)
        {
            return FindCount(str, 0);
        }

        private int FindCount(string str, int index)
        {
            if (index == str.Length) return size;
            char c = str[index];
            int charCode = c - 'a';
            if (Children[charCode] == null)
                return 0;
            return Children[charCode].FindCount(str, index + 1);
        }

        public TrieNode3 SearchWord(string str)
        {
            return SearchWord(str, 0);
        }

        private TrieNode3 SearchWord(string str, int index)
        {
            if (index == str.Length) return this;
            char c = str[index];
            int charCode = c - 'a';
            if (Children[charCode] == null)
                return null;
            return Children[charCode].SearchWord(str, index + 1);            
        }
    }
}
