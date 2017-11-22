using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Graphs
{
    /// <summary>
    /// Implementation using Dictionary for child nodes
    /// </summary>
    class TrieNode2
    {
        public bool IsLeaf;
        public Dictionary<char, TrieNode2> Children = new Dictionary<char, TrieNode2>();

        public void Insert(string word)
        {
            TrieNode2 node = this;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (!node.Children.ContainsKey(c))
                    node.Children.Add(c, new TrieNode2());
                node = node.Children[c];
            }
            node.IsLeaf = true;
        }

        public bool ContainsWord(string word)
        {
            TrieNode2 node = SearchNode(word);
            if (node != null && node.IsLeaf)
                return true;
            return false;
        }

        public bool StartsWith(string str)
        {
            TrieNode2 node = SearchNode(str);
            if (node == null)
                return false;
            return true;
        }

        public TrieNode2 SearchNode(string str)
        {
            TrieNode2 node = this;
            foreach (char c in str)
            {
                if (node.Children.ContainsKey(c))
                    node = node.Children[c];
                else
                    return null;
            }
            return node;
        }

        public void DisplayWords()
        {
            //Call DisplayWords of the root node and in the called method for each cild of the node recurse to get children
            DisplayWords(new StringBuilder(), 0);
        }
        public void DisplayWords(StringBuilder str, int level)
        {
            if (IsLeaf)
            {
                Console.WriteLine(str);
            }
            foreach (KeyValuePair<char, TrieNode2> kvp in Children)
            {
                char c = kvp.Key;
                TrieNode2 child = kvp.Value;
                if (str.Length <= level)//Increase capacity of the string builder to fit to the level of the string
                    str.Length++;
                str[level] = c;
                child.DisplayWords(str, level + 1);
            }
        }

        public int AutoComplete(string prefix)
        {
            TrieNode2 node = SearchNode(prefix);
            if (node == null)
                return -1;
            bool isParent = IsParentForAny();

            if(node.IsLeaf && !isParent)
            {
                Console.WriteLine(prefix);
                return 0;
            }

            node.GetSuggestions(prefix);
            return 1;
        }

        private void GetSuggestions(string prefix)
        {
            if(IsLeaf)
            {
                Console.WriteLine(prefix);
            }
            else
            {
                foreach(KeyValuePair<char, TrieNode2> kvp in Children)
                {
                    char c = kvp.Key;
                    TrieNode2 child = kvp.Value;
                    child.GetSuggestions(prefix + c);
                }
            }
        }

        private bool IsParentForAny()
        {
            return Children.Count > 0;
        }
    }
}
