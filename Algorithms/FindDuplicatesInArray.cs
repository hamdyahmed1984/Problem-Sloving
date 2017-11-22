using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class FindDuplicatesInArray
    {

        public List<int> getDuplicatesWithoutExtraSpace(int[] arr)
        {
            List<int> arrDuplicates = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[Math.Abs(arr[i])] >= 0)
                    arr[Math.Abs(arr[i])] = -arr[Math.Abs(arr[i])];
                else
                    arrDuplicates.Add(Math.Abs(arr[i]));
            }
            return arrDuplicates;
        }
        public List<int> getDuplicatesUsingBruteForce(int[] arr)
        {
            List<int> arrDuplicates = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                for(int j = i + 1; j < arr.Length; j++)
                {
                    if(arr[i] == arr[j])
                    {
                        arrDuplicates.Add(arr[i]);
                    }
                }
            }
            return arrDuplicates;
        }

        public int[] getDuplicatesUsingHashSet(int[] arr)
        {
            int[] arrDuplicates = new int[0];
            HashSet<int> set = new HashSet<int>();
            for(int i = 0; i< arr.Length; i++)
            {
                if (set.Contains(arr[i]))
                {
                    Array.Resize(ref arrDuplicates, arrDuplicates.Length + 1);
                    arrDuplicates[arrDuplicates.Length - 1] = arr[i];
                }
                else
                    set.Add(arr[i]);
            }
            return arrDuplicates;
        }

        public int[] getDuplicatesUsingDictionary(int[] arr)
        {
            int[] arrDuplicates = new int[0];
            Dictionary<int, int> dictUnique = new Dictionary<int, int>();
            for(int i = 0; i <arr.Length; i++)
            {
                if (dictUnique.ContainsKey(arr[i]))
                {
                    Array.Resize(ref arrDuplicates, arrDuplicates.Length + 1);
                    arrDuplicates[arrDuplicates.Length - 1] = arr[i];
                    dictUnique[arr[i]]++;
                }
                else
                    dictUnique.Add(arr[i], 1);
            }
            return arrDuplicates;
        }
    }
}
