using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Graphs
{
    /// <summary>
    /// Implementation using array for child nodes
    /// </summary>
    class TrieNode1
    {
        public const int ALPHAPET_SIZE = 26;
        public bool IsLeaf;
        public TrieNode1[] Children;
        public TrieNode1()
        {
            Children = new TrieNode1[ALPHAPET_SIZE];
        }

        public void Insert(string word)
        {
            TrieNode1 node = this;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                int index = c - 'a';
                if(node.Children[index] == null)
                {
                    node.Children[index] = new TrieNode1();
                }
                node = node.Children[index];
            }
            node.IsLeaf = true;
        }

        public bool StartsWith(string str)
        {
            TrieNode1 node = SearchNode(str);
            if (node == null)
                return false;
            return true;
        }

        public bool ContainsWord(string word)
        {
            TrieNode1 node = SearchNode(word);
            if (node != null && node.IsLeaf)
                return true;
            return false;
        }
        public TrieNode1 SearchNode(string str)
        {
            TrieNode1 node = this;
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                int index = c - 'a';
                if (node.Children[index] == null)
                    return null;
                node = node.Children[index];
            }
            return node;
        }

        public int AutoComplete(string prefix)
        {
            TrieNode1 node = SearchNode(prefix);
            if (node == null)
                return -1;
            bool isParent = node.IsParentForAny();
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
                for(int i = 0; i < ALPHAPET_SIZE; i++)
                {
                    TrieNode1 child = Children[i];
                    if(child != null)
                    {
                        child.GetSuggestions(prefix + (char)(i + 'a'));
                    }
                }
            }
        }

        public void DisplayWords()
        {
            TrieNode1 node = this;
            DisplayWords(node, new char[50], 0);
        }
        public void DisplayWords(TrieNode1 node, char[] str, int level)
        {
            if (node.IsLeaf)
            {
                //str[level] = '\0';
                Console.WriteLine(str);
            }
            for (int i = 0; i < node.Children.Length; i++)
            {
                if(node.Children[i] != null)
                {
                    str[level] = (char)(i + 'a');
                    DisplayWords(node.Children[i], str, level + 1);
                    
                }
            }
        }

        public bool Remove(string word, int level)
        {
            if(level == word.Length)//Base case
            {
                if (IsLeaf)
                    IsLeaf = false;
                if (IsParentForAny())
                    return false;
                return true;
            }
            else
            {
                TrieNode1 child = Children[word[level] - 'a'];
                if(child.Remove(word, level + 1))
                {
                    child = null;
                    return true;// !IsLeaf && !IsParentForAny();
                }
            }
            return false;
        }

        public bool IsParentForAny()
        {
            for (int i = 0; i < ALPHAPET_SIZE; i++)
            {
                if (Children[i] != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
