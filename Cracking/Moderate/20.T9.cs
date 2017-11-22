using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Moderate
{
    /// <summary>
    /// 16.20 T9: On old cell phones, users typed on a numeric keypad and the phone would provide a list of words
    /// that matched these numbers.Each digit mapped to a set of O - 4 letters.Implement an algorithm
    /// to return a list of matching words, given a sequence of digits.You are provided a list of valid words
    /// (provided in whatever data structure you'd like). The mapping is shown in the diagram below:
    /// EXAMPLE
    /// Input:
    /// 8733
    /// Output:
    /// tree, used
    /// </summary>
    class T9
    {
        public void Test()
        {
            string input = "8733";
            FillMap();
            List<string> possibleWords = GetPossibleWords(input);
        }

        private void FillMap()
        {
            map.Add('2', new List<char>() {'a', 'b', 'c' });
            map.Add('3', new List<char>() { 'd', 'e', 'f' });
            map.Add('4', new List<char>() { 'g', 'h', 'i' });
            map.Add('5', new List<char>() { 'j', 'k', 'l' });
            map.Add('6', new List<char>() { 'm', 'n', 'o' });
            map.Add('7', new List<char>() { 'p', 'q', 'r', 's' });
            map.Add('8', new List<char>() { 't', 'u', 'v' });
            map.Add('9', new List<char>() { 'w', 'x', 'y', 'z' });            
        }

        HashSet<string> allValidWords = new HashSet<string>() { "used", "tree" };
        Dictionary<char, List<char>> map = new Dictionary<char, List<char>>();
        private List<string> GetPossibleWords(string input)
        {
            List<string> possibleWords = new List<string>();
            GetPossibleWords(input, 0, "", possibleWords);
            return possibleWords;
        }

        private void GetPossibleWords(string input, int index, string prefix, List<string> possibleWords)
        {
            /*If it's a complete word, print it.*/
            if (index == input.Length)
            {
                if (allValidWords.Contains(prefix))
                    possibleWords.Add(prefix);
                return;//We should return when index = input.Length to prevent out of range exception in input[index]
            }
            char digit = input[index];
            List<char> mapped = map[digit];//Get characters that match this digit.
            if (mapped != null)
            {
                /*Go through all remaining options*/
                foreach (char c in mapped)
                {
                    GetPossibleWords(input, index + 1, prefix + c.ToString(), possibleWords);
                }
            }
        }
    }
}
