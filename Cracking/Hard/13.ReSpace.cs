using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Hard
{
    /// <summary>
    /// 17.13 Re-Space: Oh, no! You have accidentally removed all spaces, punctuation, and capitalization in a
    ///lengthy document.A sentence like "I reset the c omputer. It still didn't boot!"
    ///became "iresetthec omputeri tstilldidntboot''. You'll deal with the punctuation and capitalization
    ///later; right now you need to re-insert the spaces.Most of the words are in a dictionary but
    ///a few are not.Given a dictionary(a list of strings) and the document(a string), design an algorithm
    ///to unconcatenate the document in a way that minimizes the number of unrecognized characters.
    ///EXAMPLE
    ///Input jesslookedjustliketimherbrother
    ///Output: jess looked just like tim her brother(7 unrecognized characters)
    /// </summary>
    public class ReSpace
    {
        public string BestSplit(HashSet<string> dictionary, string sentence)
        {
            ParseResult r = Split(dictionary, sentence, 0);
            return r == null ? null : r.StringWithSpaces;
        }

        private ParseResult Split(HashSet<string> dictionary, string sentence, int start)
        {
            if (start >= sentence.Length)
                return new ParseResult(0, "");

            int bestInvalid = int.MaxValue;
            string bestParsing = null;
            string partial = "";
            int index = start;
            while (index < sentence.Length)
            {
                char c = sentence[index];
                partial += c;
                int invalid = dictionary.Contains(partial) ? 0 : partial.Length;
                if (invalid < bestInvalid)//Short Circuit
                {
                    /*Recurse, putting a space after this character. If this is better than the current best option, replace the best option.*/
                    ParseResult result = Split(dictionary, sentence, index + 1);
                    if (invalid + result.UnrecognisedCharsCount < bestInvalid)
                    {
                        bestInvalid = invalid + result.UnrecognisedCharsCount;
                        bestParsing = partial + " " + result.StringWithSpaces;
                        if (bestInvalid == 0) break;// Short circuit
                    }
                }
                index++;
            }
            return new ParseResult(bestInvalid, bestParsing);
        }



        public ParseResult ReSpaceSentence(String sentence, HashSet<string> dictionary)
        {
            if (string.IsNullOrEmpty(sentence))
                return new ParseResult(0, "");
            int len = sentence.Length;
            if (dictionary == null || dictionary.Count == 0)
                return new ParseResult(sentence.Length, sentence);
            int[] dp = new int[len + 1];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = int.MaxValue;
            dp[0] = 0;
            StringBuilder sbWithSpaces = new StringBuilder();
            sbWithSpaces.Append(sentence[0]);//Add first char
            for (int i = 1; i <= len; i++)
            {                
                for (int j = 0; j < i; j++)
                {
                    String word = sentence.Substring(j, i - j);
                    int unrecogCharsCount = dictionary.Contains(word) ? 0 : word.Length;
                    if (unrecogCharsCount == 0)
                    {
                        sbWithSpaces.Append(" ");
                        int indexBeforeRecogWord = i - word.Length;
                        if (sbWithSpaces[indexBeforeRecogWord] != ' ')
                            sbWithSpaces.Insert(indexBeforeRecogWord, ' ');
                    }
                    dp[i] = Math.Min(dp[i], dp[j] + unrecogCharsCount);                                  
                    // where dp[n] is minimal number of unrecognized chars in first n chars
                }
                //if (dp[i] == 0)
                //    sbWithSpaces.Append(" ");
                if (i < len)
                    sbWithSpaces.Append(sentence[i]);
            }
            return new ParseResult(dp[len], sbWithSpaces.ToString());            
        }

        public int parse(String sentence, HashSet<String> dictionary)
        {
            if (string.IsNullOrEmpty(sentence))
                return 0;
            int len = sentence.Length;
            if (dictionary == null || dictionary.Count == 0)
                return len;
            int[] dp = new int[len + 1];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = int.MaxValue;
            dp[0] = 0;
            for (int i = 1; i <= len; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    String word = sentence.Substring(j, i - j);
                    int unrecogCharNum = dictionary.Contains(word) ? 0 : word.Length;
                    int totalUnrecogCharNum = dp[j] + unrecogCharNum;
                    if (totalUnrecogCharNum < dp[i]) dp[i] = totalUnrecogCharNum;
                    // recurrence:
                    // dp[i] = min(dp[i], dp[j] + unrecogCharNum)
                    // where dp[n] is minimal number of unrecognized chars in first n chars
                }
            }
            return dp[len];
        }

        public class ParseResult
        {
            public int UnrecognisedCharsCount { get; set; }
            public string StringWithSpaces { get; set; }
            public ParseResult(int unrecogCount, string stringWithSpaces)
            {
                this.UnrecognisedCharsCount = unrecogCount;
                this.StringWithSpaces = stringWithSpaces;
            }
        }
    }
}
