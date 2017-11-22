using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class MostFrequentNumber
    {
        public string getMostFrequentNumber(int[] arr)
        {
            string ret = "";
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for(int i = 0; i < arr.Length; i++)
            {
                if (dict.ContainsKey(arr[i]))
                    dict[arr[i]]++;
                else
                    dict.Add(arr[i], 1);
            }
            int mostFrequent = arr[0];
            int frequency = 1;            
            foreach(KeyValuePair<int, int> kvp in dict)
            {
                if(kvp.Value > frequency)
                {
                    frequency = kvp.Value;
                    mostFrequent = kvp.Key;
                }
            }
            foreach (KeyValuePair<int, int> kvp in dict)
            {
                if (kvp.Value == frequency && kvp.Key <= mostFrequent)
                {
                    mostFrequent = kvp.Key;
                }
            }
            ret = mostFrequent + ": " + frequency;
            return ret;
        }
        public string getMostFrequentNumber2(int[] arr)
        {
            string ret = "";
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (dict.ContainsKey(arr[i]))
                    dict[arr[i]]++;
                else
                    dict.Add(arr[i], 1);
            }
            var maxFreq = dict.Max(a => a.Value);
            var lowestNumberWithMaxFrequency = dict.Where(a => a.Value == maxFreq).Min(a => a.Key);
            ret = lowestNumberWithMaxFrequency + ": " + maxFreq;
            return ret;
        }

        //public string getMostFrequentNumber3(int[] arr)
        //{
        //    int counter = 0;
        //    int mostFrequent = 0;
        //    int frequency = 0;
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        counter = 0;
        //        for(int j = 0; j <arr.Length; j++)
        //        {
        //            if (arr[i] == arr[j])
        //                counter++;
        //        }
        //        if(counter > frequency)
        //        {
        //            mostFrequent = arr[i];
        //            frequency = counter;
        //        }
        //    }
        //    return mostFrequent + ": " + frequency;            
        //}
    }
}
