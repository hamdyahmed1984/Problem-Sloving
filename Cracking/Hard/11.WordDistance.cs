using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Hard
{
    /// <summary>
    /// 17 .11 Word Distance: You have a large text file containing words. Given any two words, find the shortest
    /// distance(in terms of number of words) between them in the file.
    /// If the operation will be repeated many times for the same file (but different pairs of words), can you optimize your solution?
    /// </summary>
    public class WordDistance
    {
        public int[] FindClosestDistance(string[] words, string word1, string word2)
        {
            int currentIndex1 = -1, currentIndex2 = -1, bestIndex1 = -1, bestIndex2 = -1;
            for(int i = 0;i < words.Length;i++)
            {
                string word = words[i];
                if(word.Equals(word1))
                {
                    currentIndex1 = i;
                    //We always set bestIndex1 and bestIndex2 if any of them still not set(equals -1)
                    if (bestIndex1 == -1 || bestIndex2 == -1 || Math.Abs(currentIndex1 - currentIndex2) < Math.Abs(bestIndex1 - bestIndex2))
                    {
                        bestIndex1 = currentIndex1;
                        bestIndex2 = currentIndex2;
                    }
                }
                else if(word.Equals(word2))
                {
                    currentIndex2 = i;
                    //We always set bestIndex1 and bestIndex2 if any of them still not set(equals -1)
                    if (bestIndex1 == -1 || bestIndex2 == -1 || Math.Abs(currentIndex1 - currentIndex2) < Math.Abs(bestIndex1 - bestIndex2))
                    {
                        bestIndex1 = currentIndex1;
                        bestIndex2 = currentIndex2;
                    }
                }
            }
            return new int[] { bestIndex1, bestIndex2 };
        }

        public int[] FindClosestDistance2(string[] words, string word1, string word2)
        {
            List<int> locations1 = new List<int>();
            List<int> locations2 = new List<int>();
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if (word.Equals(word1))
                {
                    locations1.Add(i);
                }
                else if (word.Equals(word2))
                {
                    locations2.Add(i);
                }
            }

            return FindMinDistancePair(locations1, locations2);
        }

        private int[] FindMinDistancePair(List<int> locations1, List<int> locations2)
        {
            if (locations1 == null || locations2 == null || locations1.Count == 0 || locations2.Count == 0) return null;
            int bestIndex1 = -1, bestIndex2 = -1;
            int a = 0, b = 0;
            int minDisttance = int.MaxValue;
            while(a < locations1.Count && b < locations2.Count)
            {
                if (Math.Abs(locations1[a] - locations2[b]) < minDisttance)
                {
                    minDisttance = Math.Abs(locations1[a] - locations2[b]);
                    bestIndex1 = locations1[a];
                    bestIndex2 = locations2[b];
                }                
                if (locations1[a] < locations2[b])
                    a++;
                else
                    b++;
            }
            return new int[] { a, b };
        }

        public int[] FindClosestDistance3(string[] words, string word1, string word2)
        {
            Dictionary<string, List<int>> map = ConstructWordsMap(words);
            return FindMinDistancePair(map.ContainsKey(word1) ? map[word1] : null, map.ContainsKey(word2) ? map[word2] : null);
        }

        private Dictionary<string, List<int>> ConstructWordsMap(string[] words)
        {
            Dictionary<string, List<int>> map = new Dictionary<string, List<int>>();
            for(int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if (map.ContainsKey(word))
                    map[word].Add(i);
                else
                    map.Add(word, new List<int>() { i });
            }
            return map;
        }
    }
}
