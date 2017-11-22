using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Hard
{
    /// <summary>
    /// 17.5 Letters and Numbers: Given an array filled with letters and numbers, find the longest subarray with
    /// an equal number of letters and numbers.
    /// </summary>
    public class LettersAndNumbers
    {
        public char[] FindLongestSubArray_BF(char[] arr)
        {
            int start = 0, end = 0;
            for(int i = 0; i < arr.Length - 1; i++)
            {
                for(int j = i + 1; j < arr.Length; j++)
                {
                    if(HasEqualLettersAndNumbers(arr, i, j) && (j - i > end - start))
                    {
                        start = i;
                        end = j;
                    }
                }
            }
            return ExtractSubArray(arr, start, end);            
        }

        public char[] FindLongestSubArray_BF_Optimized(char[] arr)
        {
            for(int len = arr.Length; len > 0; len--)
            {
                for(int i = 0; i <= arr.Length - len; i++)
                {
                    if(HasEqualLettersAndNumbers(arr, i, i + len - 1))
                    {
                        return ExtractSubArray(arr, i, i + len - 1);
                    }
                }
            }
            return null;
        }

        public char[] FindLongestSubArray_Optimal(char[] arr)
        {
            /*Compute deltas between count of numbers and count of letters.*/
            int[] deltas = FindDeltasArray(arr);
            /*Find pair in deltas with matching values and largest span.*/
            int[] maxDistance = FindMaxDistance(deltas);
            /*Return the subarray. Note that it starts one *after* the initial occurence of this delta.*/
            return ExtractSubArray(arr, maxDistance[0] + 1, maxDistance[1]);
        }
        /// <summary>
        /// Compute the difference between the number of letters and numbers between the beginning of the array and each index.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private int[] FindDeltasArray(char[] arr)
        {
            int[] deltas = new int[arr.Length];
            int delta = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if(char.IsDigit(arr[i]))
                {
                    delta++;
                }
                else if(char.IsLetter(arr[i]))
                {
                    delta--;
                }
                deltas[i] = delta;
            }
            return deltas;
        }
        /// <summary>
        /// Find the matching pair of values in the deltas array with the largest difference in indices.
        /// </summary>
        /// <param name="deltas"></param>
        /// <returns></returns>
        private int[] FindMaxDistance(int[] deltas)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int[] max = new int[2];
            for(int i = 0; i < deltas.Length; i++)
            {
                if(!map.ContainsKey(deltas[i]))
                {
                    map.Add(deltas[i], i);
                }
                else
                {
                    int match = map[deltas[i]];
                    int longest = max[1] - max[0];
                    int candidate = i - match;
                    if(candidate > longest)
                    {
                        max[0] = match;
                        max[1] = i;
                    }
                }
            }
            return max;
        }

        private bool HasEqualLettersAndNumbers(char[] arr, int startIndex, int endIndex)
        {
            int count = 0;
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (char.IsDigit(arr[i]))
                    count++;
                else if (char.IsLetter(arr[i]))
                    count--;
            }
            return count == 0;
        }

        private char[] ExtractSubArray(char[] arr, int startIndex, int endIndex)
        {
            char[] result = new char[endIndex - startIndex + 1];
            for(int i = 0; i < result.Length; i++)
            {
                result[i] = arr[i + startIndex];
            }
            return result;
        }
    }
}
